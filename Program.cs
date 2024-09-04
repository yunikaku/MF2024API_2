using Microsoft.EntityFrameworkCore;
using MF2024API_2.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MF2024API.Interfaces;
using MF2024API.Service;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;



var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Mf2024api2Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MF2024API_2Context") ?? throw new InvalidOperationException("Connection string 'MF2024API_2Context' not found.")));

// Add services to the container.

builder.Services.AddControllers();



builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<Mf2024api2Context>()
    .AddDefaultTokenProviders();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen
    (
    option =>
    {
        option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
        option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter a valid token",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "Bearer"
        });
        option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
    }
    );



builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme =
    options.DefaultChallengeScheme =
    options.DefaultForbidScheme =
    options.DefaultScheme =
    options.DefaultSignInScheme =
    options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:Audience"],
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
            System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JWT:SigningKey"])
        )
    };
});


builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<ITokenService, TokenService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

//InitializeDatabase(app);

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var looger = services.GetRequiredService<ILoggerFactory>();
    try
    {
        seetdata.seetdatainput(services).Wait();

    }
    catch (Exception ex)
    {
        var logger = looger.CreateLogger<Program>();
        logger.LogError(ex, "An error occurred seeding the DB.");
    }

}



app.Run();


void InitializeDatabase(IApplicationBuilder app)
{
    // IServiceScope を作成して、スコープ内のサービスを解決する
    using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
    {
        // スコープ内で ApplicationDbContext サービスを取得する
        var context = serviceScope.ServiceProvider.GetRequiredService<Mf2024api2Context>();

        // データベースを最新のマイグレーションに基づいて更新する
        context.Database.Migrate();
    }
}


X509Certificate2 LoadCertificate()
{
    X509Store store = new(StoreName.My, StoreLocation.CurrentUser);
    store.Open(OpenFlags.ReadOnly);
    var certificate = store.Certificates.Find(X509FindType.FindBySubjectName, "localhost", true)[0];
    store.Close();
    return certificate;
}

using MF2024API_2.Models;
using MF2024API_2;
using Microsoft.AspNetCore.Identity;
using System.Text;
using MF2024API_2.Controllers;
using System.Net.WebSockets;
using Microsoft.EntityFrameworkCore;

namespace MF2024API.Service
{

    public class seetdata
    {
        public static async Task seetdatainput(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<Mf2024api2Context>();
                    var userManager = services.GetRequiredService<UserManager<User>>();
                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

                    context.Database.EnsureCreated();
                    //Role初期値設定
                    //Admin
                    //User
                    if (!context.Roles.Any())
                    {
                        var role = new List<IdentityRole>
                                    {
                                        new IdentityRole()
                                        {
                                            Name = "Admin",
                                            NormalizedName = "ADMIN",
                                            ConcurrencyStamp = "1",
                                        },
                                        new IdentityRole()
                                        {
                                            Name = "User",
                                            NormalizedName = "USER",
                                            ConcurrencyStamp = "2"
                                        },
                                    };

                        foreach (var item in role)
                        {
                            var result = await roleManager.CreateAsync(item);
                            if (!result.Succeeded)
                            {
                                throw new Exception("初期値設定失敗");
                            }
                        }
                    }

                    //User初期値設定
                    if (!context.Users.Any())
                    {
                        var user = new List<User>
                        {
                            new User
                            {
                                UserName = "Admin",
                                UserNameKana = "アドミン",
                                Email = "ASCkmn`123546",
                                UserGender="男",
                                UserSlackId="123456",
                                UserSlackUrl="https://slack.com",
                                UserAddress="東京都",
                                UserUpdataUser="admin",
                                UserIndustry = "IT",
                            }
                        };

                        foreach (var item in user)
                        {
                            var result = await userManager.CreateAsync(item, "Admin@01");
                            if (result.Succeeded)
                            {
                                await userManager.AddToRoleAsync(item, "Admin");
                            }
                        }
                    }
                    //ClientCompany初期値設定
                    if (!context.ClientCompanies.Any())
                    {
                        var clientCompany = new List<ClientCompany>
                        {
                            new ClientCompany
                            {
                                ClientCompanyName = "クライアント1",
                                ClientCompanyAddress = "東京都",
                                ClientCompanyEmail = "",
                                ClientCompanyPhoneNumber = "123456",
                            },
                        };

                        context.ClientCompanies.AddRange(clientCompany);
                        await context.SaveChangesAsync();
                    }

                    //ClientCompanyEmployee初期値設定
                    var clientCompany1 = await context.ClientCompanies.FirstOrDefaultAsync(c => c.ClientCompanyName == "クライアント1");
                    if (!context.ClientCompanyEmployees.Any())
                    {
                        var clientCompanyEmployee = new List<ClientCompanyEmployee>
                        {
                            new ClientCompanyEmployee
                            {
                                ClientCompanyId = clientCompany1.ClientCompanyId,
                                ClientCompanyEmployeesName = "社員1",
                                ClientCompanyEmployeesNameKana = "シャイン1",
                                ClientCompanyEmployeesEmail = "123456",
                                ClientCompanyEmployeesPhoneNumber = "123456",
                                ClientCompanyEmployeesPosition = "管理者",
                                ClientCompanyEmployeesSection = "セクション1",
                            },
                        };

                        context.ClientCompanyEmployees.AddRange(clientCompanyEmployee);
                        await context.SaveChangesAsync();
                    }



                    var user1 = await userManager.FindByNameAsync("Admin");
                    //Device初期値設定
                    if (!context.Devices.Any()) 
                    {
                        var device = new List<Device>
                        {
                            new Device
                            {
                                DeviceName = "デバイス1",
                                DeviceLocation = "東京都",
                                CreationTime = DateTime.Now,
                                UpdateTime = DateTime.Now,
                                DeviceUpdateUserID = user1.Id,
                            },
                        };

                        context.Devices.AddRange(device);
                        await context.SaveChangesAsync();
                    }
                    //Nfc初期値設定
                    if (!context.Nfcs.Any()) 
                    {
                        var nfc = new List<Nfc>
                        {
                            new Nfc
                            {
                                NfcUid = "123456",
                                AlloottedTime = DateTime.Now,
                                UpdateTime = DateTime.Now,
                                NfcPayload= "",
                            },
                        };

                        context.Nfcs.AddRange(nfc);
                        await context.SaveChangesAsync();
                    }
                    //Status初期値設定
                    if (!context.Statuses.Any()) 
                    {
                        var status = new List<Status>
                        {
                            new Status
                            {
                                StatusName = "ステータス1",
                            },
                        };
                        context.Statuses.AddRange(status);
                        await context.SaveChangesAsync();


                    }
                    
                    //Department初期値設定
                    if (!context.Departments.Any())
                    {
                        var department = new List<Department>
                        {
                            new Department
                            {
                                DepartmentName = "部署1",
                                DepartmentSlackId = "123456",
                                
                            },
                        };

                        context.Departments.AddRange(department);
                        await context.SaveChangesAsync();
                    }
                    var department1 = await context.Departments.FirstOrDefaultAsync(d => d.DepartmentName == "部署1");
                    //section初期値設定
                    if (!context.Sections.Any())
                    {
                        var section = new List<Section>
                        {
                            new Section
                            {
                                SectionName = "セクション1",
                                SectionSlackId = "123456",
                                SectionSlakUrl = "https://slack.com",
                                DepartmentId = department1.DepartmentId,
                            },
                        };

                        context.Sections.AddRange(section);
                        await context.SaveChangesAsync();
                    }

                    

                    

                    //Company初期値設定
                    if (!context.Companies.Any())
                    {
                        var company = new List<Company>
                        {
                            new Company
                            {
                                CompanyName = "会社1",
                                CompanySlakId = "123456",
                                UserName = "admin",
                                UserPosition = "管理者",
                                StandardWorkingHours = 8,
                                DateOfGrantWithPay = DateTime.Now,
                                FirstDayOfTheCalendarYear = DateTime.Now,
                                UpdateTime = DateTime.Now,
                                UpdateUser = user1.Id,
                            },
                        };

                        context.Companies.AddRange(company);
                        await context.SaveChangesAsync();
                    }
                    //ConferenceRoom初期値設定
                    if (!context.ConferenceRooms.Any())
                    {
                        var conferenceRoom = new List<ConferenceRoom>
                        {
                            new ConferenceRoom
                            {
                                ConferenceRoomName = "会議室1",
                                ConferenceRoomCapacity = 10,
                                UpdateTime = DateTime.Now,
                                UpdateUser = user1.Id,
                            },
                        };

                        context.ConferenceRooms.AddRange(conferenceRoom);
                        await context.SaveChangesAsync();
                    }
                    //ConferenceRoomReservation初期値設定
                    if (!context.ConferenceRoomReservations.Any())
                    {
                        var conferenceRoomReservation = new List<ConferenceRoomReservation>
                        {
                            new ConferenceRoomReservation
                            {
                                ConferenceRoomId = 1,
                                UserId = user1.Id,
                                Requirement = "会議",
                                StartTime = DateTime.Now,
                                EndTime = DateTime.Now,
                                ReservationTime = DateTime.Now,
                            },
                        };

                        context.ConferenceRoomReservations.AddRange(conferenceRoomReservation);
                        await context.SaveChangesAsync();
                    }
                    //UserPosition初期値設定
                    if (!context.UserPositions.Any())
                    {
                        var userPosition = new List<UserPosition>
                        {
                            new UserPosition
                            {
                                UserId = user1.Id,
                                RoleId = "Admin",
                                UserPositionUpdateUser = user1.Id,
                                SectionId = 1,
                                UpdateTime = DateTime.Now,
                            },
                        };

                        context.UserPositions.AddRange(userPosition);
                        await context.SaveChangesAsync();
                    }
                    //ClientCompany初期値設定
                    if (!context.ClientCompanies.Any())
                    {
                        var clientCompany = new List<ClientCompany>
                        {
                            new ClientCompany
                            {
                                ClientCompanyName = "クライアント1",
                                ClientCompanyAddress = "東京都",
                                ClientCompanyEmail = "",
                                ClientCompanyPhoneNumber = "123456",
                            },
                        };

                        context.ClientCompanies.AddRange(clientCompany);
                        await context.SaveChangesAsync();
                    }

                    //ClientCompanyEmployee初期値設定
                    if (!context.ClientCompanyEmployees.Any())
                    {
                        var clientCompanyEmployee = new List<ClientCompanyEmployee>
                        {
                            new ClientCompanyEmployee
                            {
                                ClientCompanyId = 1,
                                ClientCompanyEmployeesName = "社員1",
                                ClientCompanyEmployeesNameKana = "シャイン1",
                                ClientCompanyEmployeesEmail = "123456",
                                ClientCompanyEmployeesPhoneNumber = "123456",
                                ClientCompanyEmployeesPosition = "管理者",
                                ClientCompanyEmployeesSection = "セクション1",

                            },
                        };

                        context.ClientCompanyEmployees.AddRange(clientCompanyEmployee);
                        await context.SaveChangesAsync();
                    }

                    var clientCompanyEmployee1 = await context.ClientCompanyEmployees.FirstOrDefaultAsync(c => c.ClientCompanyEmployeesName == "社員1");

                    //EmployeeReservition初期値設定
                    if (!context.EmployeeReservations.Any())
                    {
                        var employeeReservition = new List<EmployeeReservation>
                        {
                            new EmployeeReservation
                            {
                                
                                ClientCompanyEmployeesId = clientCompanyEmployee1.ClientCompanyEmployeesId,
                                UserId = user1.Id,
                                ReservationsTime = DateTime.Now,
                                Qr = Encoding.ASCII.GetBytes("123456"),
                                CompleteFlag = "完了",
                                Requirement = "会議",
                            },
                            
                        };

                        context.EmployeeReservations.AddRange(employeeReservition);
                        await context.SaveChangesAsync();
                    }


                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }


        }

    }
}

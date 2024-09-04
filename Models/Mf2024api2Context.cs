using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace MF2024API_2.Models;

public partial class Mf2024api2Context : IdentityDbContext<User>
{

    public Mf2024api2Context(DbContextOptions<Mf2024api2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<ClientCompany> ClientCompanies { get; set; }

    public virtual DbSet<ClientCompanyEmployee> ClientCompanyEmployees { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<ConferenceRoom> ConferenceRooms { get; set; }

    public virtual DbSet<ConferenceRoomReservation> ConferenceRoomReservations { get; set; }

    public virtual DbSet<ConferenceRoomUse> ConferenceRoomUses { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Device> Devices { get; set; }

    public virtual DbSet<EmployeeReservation> EmployeeReservations { get; set; }

    public virtual DbSet<EnteringAndLeaving> EnteringAndLeavings { get; set; }

    public virtual DbSet<Nfc> Nfcs { get; set; }

    public virtual DbSet<Section> Sections { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserPosition> UserPositions { get; set; }

    public virtual DbSet<NotReservation> NotReservations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MF2024API_2;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ClientCompany>(entity =>
        {
            entity.ToTable("ClientCompany");
        });

        modelBuilder.Entity<ClientCompanyEmployee>(entity =>
        {
            entity.HasKey(e => e.ClientCompanyEmployeesId);

            entity.HasIndex(e => e.ClientCompanyId, "IX_ClientCompanyEmployees_ClientCompanyId");

            entity.HasOne(d => d.ClientCompany).WithMany(p => p.ClientCompanyEmployees)
                .HasForeignKey(d => d.ClientCompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClientCompanyEmployees_ClientCompanyId");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.ToTable("Company");
        });

        modelBuilder.Entity<ConferenceRoom>(entity =>
        {
            entity.ToTable("ConferenceRoom");

            entity.HasIndex(e => e.UpdateUser, "IX_ConferenceRoom_UpdateUser");

            entity.HasOne(d => d.UpdateUserNavigation).WithMany(p => p.ConferenceRooms)
                .HasForeignKey(d => d.UpdateUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ConferenceRoom_UpdateUser");
        });

        modelBuilder.Entity<ConferenceRoomReservation>(entity =>
        {
            entity.HasKey(e => e.ConferenceRoomReservationsId);

            entity.HasIndex(e => e.ConferenceRoomId, "IX_ConferenceRoomReservations_ConferenceRoomId");

            entity.HasIndex(e => e.UserId, "IX_ConferenceRoomReservations_UserId");

            entity.HasOne(d => d.ConferenceRoom).WithMany(p => p.ConferenceRoomReservations)
                .HasForeignKey(d => d.ConferenceRoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ConferenceRoomReservations_ConferenceRoomId");

            entity.HasOne(d => d.User).WithMany(p => p.ConferenceRoomReservations)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ConferenceRoomReservations_UserId");
        });

        modelBuilder.Entity<ConferenceRoomUse>(entity =>
        {
            entity.ToTable("ConferenceRoomUse");

            entity.HasIndex(e => e.ConferenceRoomId, "IX_ConferenceRoomUse_ConferenceRoomId");

            entity.HasIndex(e => e.UserId, "IX_ConferenceRoomUse_UserId");

            entity.HasOne(d => d.ConferenceRoom).WithMany(p => p.ConferenceRoomUses)
                .HasForeignKey(d => d.ConferenceRoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ConferenceRoomUse_ConferenceRoomId");

            entity.HasOne(d => d.User).WithMany(p => p.ConferenceRoomUses)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ConferenceRoomUse_UserId");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.ToTable("Department");

            
        });

        modelBuilder.Entity<Device>(entity =>
        {
            entity.ToTable("Device");

            entity.HasIndex(e => e.DeviceUpdateUserID, "IX_Device_DeviceUpdateUser");

            entity.HasOne(d => d.DeviceUpdateUserNavigation).WithMany(p => p.Devices)
                .HasForeignKey(d => d.DeviceUpdateUserID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Device_DeviceUpdateUser");
        });

        modelBuilder.Entity<EmployeeReservation>(entity =>
        {
            entity.HasKey(e => e.EmployeeReservationsId);

            entity.HasIndex(e => e.ClientCompanyEmployeesId, "IX_EmployeeReservations_ClientCompanyEmployeesId");

            entity.HasIndex(e => e.UserId, "IX_EmployeeReservations_UserId");

            entity.Property(e => e.Qr).HasColumnName("QR");

            entity.HasOne(d => d.ClientCompanyEmployees).WithMany(p => p.EmployeeReservations)
                .HasForeignKey(d => d.ClientCompanyEmployeesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeReservations_ClientCompanyEmployeesId");

            entity.HasOne(d => d.User).WithMany(p => p.EmployeeReservations)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeReservations_UserId");
        });

        modelBuilder.Entity<EnteringAndLeaving>(entity =>
        {
            entity.ToTable("EnteringAndLeaving");

            entity.HasIndex(e => e.DeviceId, "IX_EnteringAndLeaving_DeviceId");

            entity.HasOne(d => d.Device).WithMany(p => p.EnteringAndLeavings)
                .HasForeignKey(d => d.DeviceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EnteringAndLeaving_DeviceId");

            entity.HasOne(d => d.Nfc).WithMany(p => p.EnteringAndLeavings)
                .HasForeignKey(d => d.NfcId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EnteringAndLeaving_NfcUid");

            entity.HasOne(d => d.Status).WithMany(p => p.EnteringAndLeavings)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EnteringAndLeaving_StatusId");

            entity.HasOne(d => d.User).WithMany(p => p.EnteringAndLeavings)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EnteringAndLeaving_UserId");

            entity.HasOne(d => d.ClientCompanyEmployees).WithMany(p => p.EnteringAndLeavings)
                .HasForeignKey(d => d.ClientCompanyEmployeesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EnteringAndLeaving_ClientCompanyEmployeesId");
        });

        modelBuilder.Entity<Nfc>(entity =>
        {
            entity.ToTable("Nfc");
            entity.HasKey(e => e.NfcId);

            entity.HasIndex(e => e.UserId, "IX_Nfc_UserId");

            entity.HasOne(d => d.ClientCompanyEmployees).WithMany(p => p.Nfcs)
                .HasForeignKey(d => d.ClientCompanyEmployeesId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Nfc_ClientCompanyEmployeesId");

            entity.HasOne(d => d.User).WithMany(p => p.Nfcs)
                .HasForeignKey(d => d.UserId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Nfc_UserId");
        });

        modelBuilder.Entity<Section>(entity =>
        {
            entity.ToTable("Section");

            entity.Property(e => e.SectionSlakUrl).HasColumnName("SectionSlakURL");

            
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__Status__C8EE20632C92258B");

            entity.ToTable("Status");

            entity.Property(e => e.StatusId).ValueGeneratedNever();
        });

        modelBuilder.Entity<User>(entity =>
        {
            
            entity.ToTable("User");
        });

        modelBuilder.Entity<UserPosition>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("UserPosition");
        });


        modelBuilder.Entity<NotReservation>(entity =>
        {
            entity.ToTable("NotReservation");
        });
        base.OnModelCreating(modelBuilder);
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Api_Passport_and_Visa_Service;

public partial class VisaDbContext : DbContext
{
    public VisaDbContext()
    {
    }

    public VisaDbContext(DbContextOptions<VisaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Answertorecord> Answertorecords { get; set; }

    public virtual DbSet<Answertoreqpassport> Answertoreqpassports { get; set; }

    public virtual DbSet<Answertoreqvisa> Answertoreqvisas { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Clientaccount> Clientaccounts { get; set; }

    public virtual DbSet<Departurecountry> Departurecountries { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Employeeaccount> Employeeaccounts { get; set; }

    public virtual DbSet<Internationalpassport> Internationalpassports { get; set; }

    public virtual DbSet<Passportdatum> Passportdata { get; set; }

    public virtual DbSet<Passportsdatafromapi> Passportsdatafromapis { get; set; }

    public virtual DbSet<Paymentinvoice> Paymentinvoices { get; set; }

    public virtual DbSet<PostList> PostLists { get; set; }

    public virtual DbSet<Recordappointment> Recordappointments { get; set; }

    public virtual DbSet<Registration> Registrations { get; set; }

    public virtual DbSet<Requestonintpassport> Requestonintpassports { get; set; }

    public virtual DbSet<Requestonvisa> Requestonvisas { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Userdatum> Userdata { get; set; }

    public virtual DbSet<Visa> Visas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=db_Visa;Username=postgres;Password=spec24GRU");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Answertorecord>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_answertorecord_id");

            entity.ToTable("answertorecord");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.ApplicationStatus)
                .HasMaxLength(8)
                .HasColumnName("application_status");
            entity.Property(e => e.DateAnswer).HasColumnName("date_answer");
            entity.Property(e => e.MessageToClient).HasColumnName("message_to_client");
            entity.Property(e => e.Number).HasColumnName("number");
            entity.Property(e => e.RecordsId).HasColumnName("records_id");
        });

        modelBuilder.Entity<Answertoreqpassport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_answertoreqpassport_id");

            entity.ToTable("answertoreqpassport");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.ApplicationStatus)
                .HasMaxLength(8)
                .HasColumnName("application_status");
            entity.Property(e => e.DateAnswer).HasColumnName("date_answer");
            entity.Property(e => e.MessageToClient).HasColumnName("message_to_client");
            entity.Property(e => e.Number).HasColumnName("number");
            entity.Property(e => e.ReqPassportId).HasColumnName("req_passport_id");
        });

        modelBuilder.Entity<Answertoreqvisa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_answertoreqvisa_id");

            entity.ToTable("answertoreqvisa");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.ApplicationStatus)
                .HasMaxLength(8)
                .HasColumnName("application_status");
            entity.Property(e => e.DateAnswer).HasColumnName("date_answer");
            entity.Property(e => e.MessageToClient).HasColumnName("message_to_client");
            entity.Property(e => e.Number).HasColumnName("number");
            entity.Property(e => e.ReqVisaId).HasColumnName("req_visa_id");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_client_id");

            entity.ToTable("client");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Birthday)
                .HasMaxLength(11)
                .HasColumnName("birthday");
            entity.Property(e => e.Cituzenship)
                .HasMaxLength(50)
                .HasColumnName("cituzenship");
            entity.Property(e => e.FamilyStatus)
                .HasMaxLength(10)
                .HasColumnName("family_status");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .HasColumnName("middle_name");
            entity.Property(e => e.NameClient)
                .HasMaxLength(50)
                .HasColumnName("name_client");
            entity.Property(e => e.Nationaly)
                .HasMaxLength(100)
                .HasColumnName("nationaly");
            entity.Property(e => e.PassportDataId).HasColumnName("passport_data_id");
            entity.Property(e => e.PlaceOfBirth)
                .HasMaxLength(50)
                .HasColumnName("place_of_birth");
            entity.Property(e => e.RegistrationId).HasColumnName("registration_id");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .HasColumnName("surname");
        });

        modelBuilder.Entity<Clientaccount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("clientaccounts_pkey");

            entity.ToTable("clientaccounts");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Accountid).HasColumnName("accountid");
            entity.Property(e => e.Clientid).HasColumnName("clientid");

            entity.HasOne(d => d.Account).WithMany(p => p.Clientaccounts)
                .HasForeignKey(d => d.Accountid)
                .HasConstraintName("clientaccounts_accountid_fkey");

            entity.HasOne(d => d.Client).WithMany(p => p.Clientaccounts)
                .HasForeignKey(d => d.Clientid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("clientaccounts_clientid_fkey");
        });

        modelBuilder.Entity<Departurecountry>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_departurecountry_id");

            entity.ToTable("departurecountry");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.DateDeparture).HasColumnName("date_departure");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_employee_id");

            entity.ToTable("employee");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Birthday).HasColumnName("birthday");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .HasColumnName("gender");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .HasColumnName("middle_name");
            entity.Property(e => e.NameEmp)
                .HasMaxLength(50)
                .HasColumnName("name_emp");
            entity.Property(e => e.PostId).HasColumnName("post_id");
            entity.Property(e => e.QualificationLevel)
                .HasMaxLength(50)
                .HasColumnName("qualification_level");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .HasColumnName("surname");
        });

        modelBuilder.Entity<Employeeaccount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("employeeaccounts_pkey");

            entity.ToTable("employeeaccounts");

            entity.HasIndex(e => e.Employeeid, "employeeaccounts_employeeid_key").IsUnique();

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Accountid).HasColumnName("accountid");
            entity.Property(e => e.Employeeid).HasColumnName("employeeid");

            entity.HasOne(d => d.Account).WithMany(p => p.Employeeaccounts)
                .HasForeignKey(d => d.Accountid)
                .HasConstraintName("employeeaccounts_accountid_fkey");

            entity.HasOne(d => d.Employee).WithOne(p => p.Employeeaccount)
                .HasForeignKey<Employeeaccount>(d => d.Employeeid)
                .HasConstraintName("employeeaccounts_employeeid_fkey");
        });

        modelBuilder.Entity<Internationalpassport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_internationalpassport_id");

            entity.ToTable("internationalpassport");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.DateEnd).HasColumnName("date_end");
            entity.Property(e => e.DateStart).HasColumnName("date_start");
            entity.Property(e => e.Number)
                .HasMaxLength(6)
                .HasColumnName("number");
            entity.Property(e => e.Organization)
                .HasMaxLength(100)
                .HasColumnName("organization");
            entity.Property(e => e.Series)
                .HasMaxLength(4)
                .HasColumnName("series");
        });

        modelBuilder.Entity<Passportdatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_passportdata_id");

            entity.ToTable("passportdata");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Number)
                .HasMaxLength(6)
                .HasColumnName("number");
            entity.Property(e => e.Series)
                .HasMaxLength(4)
                .HasColumnName("series");
        });

        modelBuilder.Entity<Passportsdatafromapi>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_passportsdatafromapi_id");

            entity.ToTable("passportsdatafromapi");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Number)
                .HasMaxLength(6)
                .HasColumnName("number");
            entity.Property(e => e.Series)
                .HasMaxLength(4)
                .HasColumnName("series");
        });

        modelBuilder.Entity<Paymentinvoice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_paymentinvoice_id");

            entity.ToTable("paymentinvoice");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.DatePayment).HasColumnName("date_payment");
            entity.Property(e => e.Price).HasColumnName("price");
        });

        modelBuilder.Entity<PostList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_post_list_id");

            entity.ToTable("post_list");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Managet).HasColumnName("managet");
            entity.Property(e => e.NamePost)
                .HasMaxLength(50)
                .HasColumnName("name_post");
        });

        modelBuilder.Entity<Recordappointment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_recordappointment_id");

            entity.ToTable("recordappointment");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.DateAppointment)
                .HasMaxLength(11)
                .HasColumnName("date_appointment");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.PurposeOfAdmission)
                .HasMaxLength(100)
                .HasColumnName("purpose_of_admission");
        });

        modelBuilder.Entity<Registration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_registration_id");

            entity.ToTable("registration");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .HasColumnName("city");
            entity.Property(e => e.Flat)
                .HasMaxLength(50)
                .HasColumnName("flat");
            entity.Property(e => e.House)
                .HasMaxLength(50)
                .HasColumnName("house");
            entity.Property(e => e.Street)
                .HasMaxLength(50)
                .HasColumnName("street");
        });

        modelBuilder.Entity<Requestonintpassport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_requestonintpassport_id");

            entity.ToTable("requestonintpassport");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.DateReq).HasColumnName("date_req");
            entity.Property(e => e.Number).HasColumnName("number");
        });

        modelBuilder.Entity<Requestonvisa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_requestonvisa_id");

            entity.ToTable("requestonvisa");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .HasColumnName("country");
            entity.Property(e => e.DateReq).HasColumnName("date_req");
            entity.Property(e => e.DepartureGoals)
                .HasMaxLength(100)
                .HasColumnName("departure_goals");
            entity.Property(e => e.Number).HasColumnName("number");
            entity.Property(e => e.ReturnDate).HasColumnName("return_date");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_status_id");

            entity.ToTable("status");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.NameStatus)
                .HasMaxLength(50)
                .HasColumnName("name_status");
            entity.Property(e => e.Reasonforrefusal)
                .HasMaxLength(255)
                .HasColumnName("reasonforrefusal");
        });

        modelBuilder.Entity<Userdatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("userdata_pkey");

            entity.ToTable("userdata");

            entity.HasIndex(e => e.Login, "userdata_login_key").IsUnique();

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Login)
                .HasMaxLength(100)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
        });

        modelBuilder.Entity<Visa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_visa_id");

            entity.ToTable("visa");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.DateEnd).HasColumnName("date_end");
            entity.Property(e => e.DateOfIssue).HasColumnName("date_of_issue");
            entity.Property(e => e.DateStart).HasColumnName("date_start");
            entity.Property(e => e.Number).HasColumnName("number");
            entity.Property(e => e.PlaceOfIssue)
                .HasMaxLength(100)
                .HasColumnName("place_of_issue");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

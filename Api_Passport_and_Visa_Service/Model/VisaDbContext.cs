﻿using System;
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

    public virtual DbSet<Authorizationsession> Authorizationsessions { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Departurecountry> Departurecountries { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Employeeaccount> Employeeaccounts { get; set; }

    public virtual DbSet<Employeesdatum> Employeesdata { get; set; }

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

    public virtual DbSet<Usersaccount> Usersaccounts { get; set; }

    public virtual DbSet<Usersdatum> Usersdata { get; set; }

    public virtual DbSet<Visa> Visas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=db_Visa;Username=postgres;Password=spec24GRU");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Answertorecord>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("answertorecord_pkey");

            entity.ToTable("answertorecord");

            entity.HasIndex(e => e.Number, "answertorecord_number_key").IsUnique();

            entity.HasIndex(e => e.Number, "unique_number_record").IsUnique();

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

            entity.HasOne(d => d.Records).WithMany(p => p.Answertorecords)
                .HasForeignKey(d => d.RecordsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("record_foreign_key");
        });

        modelBuilder.Entity<Answertoreqpassport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("answertoreqpassport_pkey");

            entity.ToTable("answertoreqpassport");

            entity.HasIndex(e => e.Number, "answertoreqpassport_number_key").IsUnique();

            entity.HasIndex(e => e.Number, "unique_number_passport").IsUnique();

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

            entity.HasOne(d => d.ReqPassport).WithMany(p => p.Answertoreqpassports)
                .HasForeignKey(d => d.ReqPassportId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("record_foreign_key");
        });

        modelBuilder.Entity<Answertoreqvisa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("answertoreqvisa_pkey");

            entity.ToTable("answertoreqvisa");

            entity.HasIndex(e => e.Number, "answertoreqvisa_number_key").IsUnique();

            entity.HasIndex(e => e.Number, "unique_number_visa").IsUnique();

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

            entity.HasOne(d => d.ReqVisa).WithMany(p => p.Answertoreqvisas)
                .HasForeignKey(d => d.ReqVisaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("record_foreign_key");
        });

        modelBuilder.Entity<Authorizationsession>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("authorizationsession_pkey");

            entity.ToTable("authorizationsession");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Access).HasColumnName("access");
            entity.Property(e => e.Accountsid).HasColumnName("accountsid");
            entity.Property(e => e.Dateauthorization)
                .HasMaxLength(30)
                .HasColumnName("dateauthorization");
            entity.Property(e => e.Status)
                .HasMaxLength(7)
                .HasColumnName("status");

            entity.HasOne(d => d.Accounts).WithMany(p => p.Authorizationsessions)
                .HasForeignKey(d => d.Accountsid)
                .HasConstraintName("authorizationsession_accountsid_fkey");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("client_pkey");

            entity.ToTable("client");

            entity.HasIndex(e => e.PassportDataId, "uniq_foreign_passport_data").IsUnique();

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

            entity.HasOne(d => d.PassportData).WithOne(p => p.Client)
                .HasForeignKey<Client>(d => d.PassportDataId)
                .HasConstraintName("passport_data_foreign_key_client");

            entity.HasOne(d => d.Registration).WithMany(p => p.Clients)
                .HasForeignKey(d => d.RegistrationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("reg_foreign_key_client");
        });

        modelBuilder.Entity<Departurecountry>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("departurecountry_pkey");

            entity.ToTable("departurecountry");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.DateDeparture).HasColumnName("date_departure");
            entity.Property(e => e.StatusId).HasColumnName("status_id");

            entity.HasOne(d => d.Client).WithMany(p => p.Departurecountries)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("dep_country_foreign_key");

            entity.HasOne(d => d.Status).WithMany(p => p.Departurecountries)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("dep_status_foreign_key");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("employee_pkey");

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

            entity.HasOne(d => d.Post).WithMany(p => p.Employees)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("post_foreign_key_emp");
        });

        modelBuilder.Entity<Employeeaccount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("employeeaccounts_pkey");

            entity.ToTable("employeeaccounts");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Accountsid).HasColumnName("accountsid");
            entity.Property(e => e.Emloyeeid).HasColumnName("emloyeeid");

            entity.HasOne(d => d.Accounts).WithMany(p => p.Employeeaccounts)
                .HasForeignKey(d => d.Accountsid)
                .HasConstraintName("employeeaccounts_accountsid_fkey");

            entity.HasOne(d => d.Emloyee).WithMany(p => p.Employeeaccounts)
                .HasForeignKey(d => d.Emloyeeid)
                .HasConstraintName("employeeaccounts_emloyeeid_fkey");
        });

        modelBuilder.Entity<Employeesdatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("employeesdata_pkey");

            entity.ToTable("employeesdata");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Login)
                .HasMaxLength(255)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
        });

        modelBuilder.Entity<Internationalpassport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("internationalpassport_pkey");

            entity.ToTable("internationalpassport");

            entity.HasIndex(e => e.Number, "unq_number_int_passport").IsUnique();

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

            entity.HasOne(d => d.Client).WithMany(p => p.Internationalpassports)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("int_passport_foreign_key_client");
        });

        modelBuilder.Entity<Passportdatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("passportdata_pkey");

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
            entity.HasKey(e => e.Id).HasName("passportsdatafromapi_pkey");

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
            entity.HasKey(e => e.Id).HasName("paymentinvoice_pkey");

            entity.ToTable("paymentinvoice");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.DatePayment).HasColumnName("date_payment");
            entity.Property(e => e.Price).HasColumnName("price");

            entity.HasOne(d => d.Client).WithMany(p => p.Paymentinvoices)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("client_foreign_key_payment");
        });

        modelBuilder.Entity<PostList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("post_list_pkey");

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
            entity.HasKey(e => e.Id).HasName("recordappointment_pkey");

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

            entity.HasOne(d => d.Client).WithMany(p => p.Recordappointments)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("client_foreign_key_record_appointment");

            entity.HasOne(d => d.Employee).WithMany(p => p.Recordappointments)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("employee_foreign_key_record_appointment");
        });

        modelBuilder.Entity<Registration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("registration_pkey");

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
            entity.HasKey(e => e.Id).HasName("requestonintpassport_pkey");

            entity.ToTable("requestonintpassport");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.DateReq).HasColumnName("date_req");
            entity.Property(e => e.Number).HasColumnName("number");

            entity.HasOne(d => d.Client).WithMany(p => p.Requestonintpassports)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("req_passport_foreign_key");
        });

        modelBuilder.Entity<Requestonvisa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("requestonvisa_pkey");

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

            entity.HasOne(d => d.Client).WithMany(p => p.Requestonvisas)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("req_visa_foreign_key");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("status_pkey");

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

        modelBuilder.Entity<Usersaccount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("usersaccounts_pkey");

            entity.ToTable("usersaccounts");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Accountsid).HasColumnName("accountsid");
            entity.Property(e => e.Clientid).HasColumnName("clientid");

            entity.HasOne(d => d.Accounts).WithMany(p => p.Usersaccounts)
                .HasForeignKey(d => d.Accountsid)
                .HasConstraintName("usersaccounts_accountsid_fkey");

            entity.HasOne(d => d.Client).WithMany(p => p.Usersaccounts)
                .HasForeignKey(d => d.Clientid)
                .HasConstraintName("usersaccounts_clientid_fkey");
        });

        modelBuilder.Entity<Usersdatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("usersdata_pkey");

            entity.ToTable("usersdata");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Login)
                .HasMaxLength(255)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
        });

        modelBuilder.Entity<Visa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("visa_pkey");

            entity.ToTable("visa");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.DateEnd)
                .HasMaxLength(11)
                .HasColumnName("date_end");
            entity.Property(e => e.DateOfIssue).HasColumnName("date_of_issue");
            entity.Property(e => e.DateStart)
                .HasMaxLength(11)
                .HasColumnName("date_start");
            entity.Property(e => e.Number).HasColumnName("number");
            entity.Property(e => e.PlaceOfIssue)
                .HasMaxLength(100)
                .HasColumnName("place_of_issue");

            entity.HasOne(d => d.Client).WithMany(p => p.Visas)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("visa_foreign_key_client");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

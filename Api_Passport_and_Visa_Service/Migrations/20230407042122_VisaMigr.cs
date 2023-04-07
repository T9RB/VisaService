using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Api_Passport_and_Visa_Service.Migrations
{
    /// <inheritdoc />
    public partial class VisaMigr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "departureCountry",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    dateDeparture = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departureCountry", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "internationalPassport",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    series = table.Column<string>(type: "text", nullable: false),
                    number = table.Column<string>(type: "text", nullable: false),
                    dateStart = table.Column<DateOnly>(type: "date", nullable: false),
                    dateEnd = table.Column<DateOnly>(type: "date", nullable: false),
                    organization = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_internationalPassport", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "paymentInvoice",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    date_Payment = table.Column<DateOnly>(type: "date", nullable: false),
                    price = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paymentInvoice", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "recordAppointment",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    dateAppointment = table.Column<DateOnly>(type: "date", nullable: false),
                    purposeOfAdmission = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recordAppointment", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "requestOnIntPassport",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    number = table.Column<int>(type: "integer", nullable: false),
                    dateReq = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_requestOnIntPassport", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "requestOnVisa",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    number = table.Column<int>(type: "integer", nullable: false),
                    dateReq = table.Column<DateOnly>(type: "date", nullable: false),
                    departureGoals = table.Column<string>(type: "text", nullable: false),
                    returnDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_requestOnVisa", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "visa",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    number = table.Column<int>(type: "integer", nullable: false),
                    dateStart = table.Column<DateOnly>(type: "date", nullable: false),
                    dateEnd = table.Column<DateOnly>(type: "date", nullable: false),
                    placeOfIssue = table.Column<string>(type: "text", nullable: false),
                    dateOfIssue = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_visa", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "status",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nameStatus = table.Column<string>(type: "text", nullable: false),
                    reasonForRefusal = table.Column<string>(type: "text", nullable: false),
                    DepartureCountryid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_status", x => x.id);
                    table.ForeignKey(
                        name: "FK_status_departureCountry_DepartureCountryid",
                        column: x => x.DepartureCountryid,
                        principalTable: "departureCountry",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    surname = table.Column<string>(type: "text", nullable: false),
                    nameEmp = table.Column<string>(type: "text", nullable: false),
                    middleName = table.Column<string>(type: "text", nullable: false),
                    birthday = table.Column<DateOnly>(type: "date", nullable: false),
                    gender = table.Column<string>(type: "text", nullable: false),
                    qualificationLevel = table.Column<string>(type: "text", nullable: false),
                    RecordAppointmentid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.id);
                    table.ForeignKey(
                        name: "FK_employees_recordAppointment_RecordAppointmentid",
                        column: x => x.RecordAppointmentid,
                        principalTable: "recordAppointment",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "client",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    surname = table.Column<string>(type: "text", nullable: false),
                    nameClient = table.Column<string>(type: "text", nullable: false),
                    middleName = table.Column<string>(type: "text", nullable: false),
                    placeOfBirth = table.Column<string>(type: "text", nullable: false),
                    nationaly = table.Column<string>(type: "text", nullable: false),
                    Birthday = table.Column<DateOnly>(type: "date", nullable: false),
                    familyStatus = table.Column<string>(type: "text", nullable: false),
                    Citizenship = table.Column<string>(type: "text", nullable: false),
                    DepartureCountryid = table.Column<int>(type: "integer", nullable: true),
                    InternationalPassportid = table.Column<int>(type: "integer", nullable: true),
                    PaymentInvoiceid = table.Column<int>(type: "integer", nullable: true),
                    RecordAppointmentid = table.Column<int>(type: "integer", nullable: true),
                    RequestOnIntPassportid = table.Column<int>(type: "integer", nullable: true),
                    RequestOnVisaid = table.Column<int>(type: "integer", nullable: true),
                    Visaid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_client", x => x.id);
                    table.ForeignKey(
                        name: "FK_client_departureCountry_DepartureCountryid",
                        column: x => x.DepartureCountryid,
                        principalTable: "departureCountry",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_client_internationalPassport_InternationalPassportid",
                        column: x => x.InternationalPassportid,
                        principalTable: "internationalPassport",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_client_paymentInvoice_PaymentInvoiceid",
                        column: x => x.PaymentInvoiceid,
                        principalTable: "paymentInvoice",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_client_recordAppointment_RecordAppointmentid",
                        column: x => x.RecordAppointmentid,
                        principalTable: "recordAppointment",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_client_requestOnIntPassport_RequestOnIntPassportid",
                        column: x => x.RequestOnIntPassportid,
                        principalTable: "requestOnIntPassport",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_client_requestOnVisa_RequestOnVisaid",
                        column: x => x.RequestOnVisaid,
                        principalTable: "requestOnVisa",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_client_visa_Visaid",
                        column: x => x.Visaid,
                        principalTable: "visa",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "postList",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    namePost = table.Column<string>(type: "text", nullable: false),
                    managet = table.Column<bool>(type: "boolean", nullable: false),
                    Employeeid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_postList", x => x.id);
                    table.ForeignKey(
                        name: "FK_postList_employees_Employeeid",
                        column: x => x.Employeeid,
                        principalTable: "employees",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "passportData",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    series = table.Column<string>(type: "text", nullable: false),
                    number = table.Column<string>(type: "text", nullable: false),
                    Clientid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_passportData", x => x.id);
                    table.ForeignKey(
                        name: "FK_passportData_client_Clientid",
                        column: x => x.Clientid,
                        principalTable: "client",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "registration",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    City = table.Column<string>(type: "text", nullable: false),
                    Street = table.Column<string>(type: "text", nullable: false),
                    House = table.Column<string>(type: "text", nullable: false),
                    Flat = table.Column<string>(type: "text", nullable: false),
                    Clientid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_registration", x => x.ID);
                    table.ForeignKey(
                        name: "FK_registration_client_Clientid",
                        column: x => x.Clientid,
                        principalTable: "client",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_client_DepartureCountryid",
                table: "client",
                column: "DepartureCountryid");

            migrationBuilder.CreateIndex(
                name: "IX_client_InternationalPassportid",
                table: "client",
                column: "InternationalPassportid");

            migrationBuilder.CreateIndex(
                name: "IX_client_PaymentInvoiceid",
                table: "client",
                column: "PaymentInvoiceid");

            migrationBuilder.CreateIndex(
                name: "IX_client_RecordAppointmentid",
                table: "client",
                column: "RecordAppointmentid");

            migrationBuilder.CreateIndex(
                name: "IX_client_RequestOnIntPassportid",
                table: "client",
                column: "RequestOnIntPassportid");

            migrationBuilder.CreateIndex(
                name: "IX_client_RequestOnVisaid",
                table: "client",
                column: "RequestOnVisaid");

            migrationBuilder.CreateIndex(
                name: "IX_client_Visaid",
                table: "client",
                column: "Visaid");

            migrationBuilder.CreateIndex(
                name: "IX_employees_RecordAppointmentid",
                table: "employees",
                column: "RecordAppointmentid");

            migrationBuilder.CreateIndex(
                name: "IX_passportData_Clientid",
                table: "passportData",
                column: "Clientid");

            migrationBuilder.CreateIndex(
                name: "IX_postList_Employeeid",
                table: "postList",
                column: "Employeeid");

            migrationBuilder.CreateIndex(
                name: "IX_registration_Clientid",
                table: "registration",
                column: "Clientid");

            migrationBuilder.CreateIndex(
                name: "IX_status_DepartureCountryid",
                table: "status",
                column: "DepartureCountryid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "passportData");

            migrationBuilder.DropTable(
                name: "postList");

            migrationBuilder.DropTable(
                name: "registration");

            migrationBuilder.DropTable(
                name: "status");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "client");

            migrationBuilder.DropTable(
                name: "departureCountry");

            migrationBuilder.DropTable(
                name: "internationalPassport");

            migrationBuilder.DropTable(
                name: "paymentInvoice");

            migrationBuilder.DropTable(
                name: "recordAppointment");

            migrationBuilder.DropTable(
                name: "requestOnIntPassport");

            migrationBuilder.DropTable(
                name: "requestOnVisa");

            migrationBuilder.DropTable(
                name: "visa");
        }
    }
}

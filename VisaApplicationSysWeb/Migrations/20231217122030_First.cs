using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VisaApplicationSysWeb.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblApplicant",
                columns: table => new
                {
                    ApplicantID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisaType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisaTypeId = table.Column<int>(type: "int", nullable: false),
                    IsVisaApplied = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblApplicant", x => x.ApplicantID);
                });

            migrationBuilder.CreateTable(
                name: "tblUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblVisaType",
                columns: table => new
                {
                    VisaTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblVisaType", x => x.VisaTypeId);
                });

            migrationBuilder.CreateTable(
                name: "tblVisaStatus",
                columns: table => new
                {
                    VisaStatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisaSatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisaType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicantID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblVisaStatus", x => x.VisaStatusID);
                    table.ForeignKey(
                        name: "FK_tblVisaStatus_tblApplicant_ApplicantID",
                        column: x => x.ApplicantID,
                        principalTable: "tblApplicant",
                        principalColumn: "ApplicantID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblBusinessVisaForm",
                columns: table => new
                {
                    BusinessVisaFormId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassportNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessNature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IntendedArrivalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IntendedDepartureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PassportPhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Passportpath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicantID = table.Column<int>(type: "int", nullable: false),
                    VisaTypeId = table.Column<int>(type: "int", nullable: false),
                    IsVisaApplied = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblBusinessVisaForm", x => x.BusinessVisaFormId);
                    table.ForeignKey(
                        name: "FK_tblBusinessVisaForm_tblApplicant_ApplicantID",
                        column: x => x.ApplicantID,
                        principalTable: "tblApplicant",
                        principalColumn: "ApplicantID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblBusinessVisaForm_tblVisaType_VisaTypeId",
                        column: x => x.VisaTypeId,
                        principalTable: "tblVisaType",
                        principalColumn: "VisaTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblEmploymentVisaForm",
                columns: table => new
                {
                    EmploymentVisaFormId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassportNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentEmployer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MonthlySalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ContractStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContractEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PassportPhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResumePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmploymentContractPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Passportpath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicantID = table.Column<int>(type: "int", nullable: false),
                    VisaTypeId = table.Column<int>(type: "int", nullable: false),
                    IsVisaApplied = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmploymentVisaForm", x => x.EmploymentVisaFormId);
                    table.ForeignKey(
                        name: "FK_tblEmploymentVisaForm_tblApplicant_ApplicantID",
                        column: x => x.ApplicantID,
                        principalTable: "tblApplicant",
                        principalColumn: "ApplicantID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblEmploymentVisaForm_tblVisaType_VisaTypeId",
                        column: x => x.VisaTypeId,
                        principalTable: "tblVisaType",
                        principalColumn: "VisaTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblStudentVisaForm",
                columns: table => new
                {
                    StudentVisaFormId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassportNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HighestEducationLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstitutionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpectedStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProofOfFundsType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LanguageTestTaken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LanguageTestScore = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HighestEducationLevelMarkSheetPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassportPhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResumePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TestCardPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Passportpath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicantID = table.Column<int>(type: "int", nullable: false),
                    IsVisaApplied = table.Column<bool>(type: "bit", nullable: false),
                    VisaTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblStudentVisaForm", x => x.StudentVisaFormId);
                    table.ForeignKey(
                        name: "FK_tblStudentVisaForm_tblApplicant_ApplicantID",
                        column: x => x.ApplicantID,
                        principalTable: "tblApplicant",
                        principalColumn: "ApplicantID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblStudentVisaForm_tblVisaType_VisaTypeId",
                        column: x => x.VisaTypeId,
                        principalTable: "tblVisaType",
                        principalColumn: "VisaTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblTouristVisaForm",
                columns: table => new
                {
                    TouristVisaFormId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassportNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IntendedArrivalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IntendedDepartureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PassportPhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TravelItineraryPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HotelReservationPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Passportpath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicantID = table.Column<int>(type: "int", nullable: false),
                    VisaTypeId = table.Column<int>(type: "int", nullable: false),
                    IsVisaApplied = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTouristVisaForm", x => x.TouristVisaFormId);
                    table.ForeignKey(
                        name: "FK_tblTouristVisaForm_tblApplicant_ApplicantID",
                        column: x => x.ApplicantID,
                        principalTable: "tblApplicant",
                        principalColumn: "ApplicantID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblTouristVisaForm_tblVisaType_VisaTypeId",
                        column: x => x.VisaTypeId,
                        principalTable: "tblVisaType",
                        principalColumn: "VisaTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblBusinessVisaForm_ApplicantID",
                table: "tblBusinessVisaForm",
                column: "ApplicantID");

            migrationBuilder.CreateIndex(
                name: "IX_tblBusinessVisaForm_VisaTypeId",
                table: "tblBusinessVisaForm",
                column: "VisaTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmploymentVisaForm_ApplicantID",
                table: "tblEmploymentVisaForm",
                column: "ApplicantID");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmploymentVisaForm_VisaTypeId",
                table: "tblEmploymentVisaForm",
                column: "VisaTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblStudentVisaForm_ApplicantID",
                table: "tblStudentVisaForm",
                column: "ApplicantID");

            migrationBuilder.CreateIndex(
                name: "IX_tblStudentVisaForm_VisaTypeId",
                table: "tblStudentVisaForm",
                column: "VisaTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblTouristVisaForm_ApplicantID",
                table: "tblTouristVisaForm",
                column: "ApplicantID");

            migrationBuilder.CreateIndex(
                name: "IX_tblTouristVisaForm_VisaTypeId",
                table: "tblTouristVisaForm",
                column: "VisaTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblVisaStatus_ApplicantID",
                table: "tblVisaStatus",
                column: "ApplicantID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblBusinessVisaForm");

            migrationBuilder.DropTable(
                name: "tblEmploymentVisaForm");

            migrationBuilder.DropTable(
                name: "tblStudentVisaForm");

            migrationBuilder.DropTable(
                name: "tblTouristVisaForm");

            migrationBuilder.DropTable(
                name: "tblUser");

            migrationBuilder.DropTable(
                name: "tblVisaStatus");

            migrationBuilder.DropTable(
                name: "tblVisaType");

            migrationBuilder.DropTable(
                name: "tblApplicant");
        }
    }
}

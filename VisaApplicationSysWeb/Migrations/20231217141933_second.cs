using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VisaApplicationSysWeb.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblStudentVisaForm_tblVisaType_VisaTypeId",
                table: "tblStudentVisaForm");

            migrationBuilder.DropColumn(
                name: "IsVisaApplied",
                table: "tblStudentVisaForm");

            migrationBuilder.AlterColumn<int>(
                name: "VisaTypeId",
                table: "tblStudentVisaForm",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_tblStudentVisaForm_tblVisaType_VisaTypeId",
                table: "tblStudentVisaForm",
                column: "VisaTypeId",
                principalTable: "tblVisaType",
                principalColumn: "VisaTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblStudentVisaForm_tblVisaType_VisaTypeId",
                table: "tblStudentVisaForm");

            migrationBuilder.AlterColumn<int>(
                name: "VisaTypeId",
                table: "tblStudentVisaForm",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsVisaApplied",
                table: "tblStudentVisaForm",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_tblStudentVisaForm_tblVisaType_VisaTypeId",
                table: "tblStudentVisaForm",
                column: "VisaTypeId",
                principalTable: "tblVisaType",
                principalColumn: "VisaTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

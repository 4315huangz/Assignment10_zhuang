using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bank4Us.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class BusinessRuleUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanOfficers_Persons_PersonId",
                table: "LoanOfficers");

            migrationBuilder.DropForeignKey(
                name: "FK_MortgageApplicants_CreditReports_CreditReportReportID",
                table: "MortgageApplicants");

            migrationBuilder.DropForeignKey(
                name: "FK_MortgageApplicants_Persons_PersonId",
                table: "MortgageApplicants");

            migrationBuilder.DropColumn(
                name: "ApproveStatus",
                table: "Mortgages");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "admin",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SSN",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Persons",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Persons",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Persons",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Persons",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "EmailAddress",
                table: "Persons",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "admin",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Persons",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Mortgages",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "admin",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PropertyAddress",
                table: "Mortgages",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Mortgages",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "admin",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Mortgages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "MortgageApplicants",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "admin",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "MortgageApplicants",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CreditReportReportID",
                table: "MortgageApplicants",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "MortgageApplicants",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "admin",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "LoanOfficers",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "admin",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "LoanOfficers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "LoanOfficers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "LoanOfficers",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "admin",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "CreditReports",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "admin",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "CreditReports",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "admin",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanOfficers_Persons_PersonId",
                table: "LoanOfficers",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MortgageApplicants_CreditReports_CreditReportReportID",
                table: "MortgageApplicants",
                column: "CreditReportReportID",
                principalTable: "CreditReports",
                principalColumn: "ReportID");

            migrationBuilder.AddForeignKey(
                name: "FK_MortgageApplicants_Persons_PersonId",
                table: "MortgageApplicants",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanOfficers_Persons_PersonId",
                table: "LoanOfficers");

            migrationBuilder.DropForeignKey(
                name: "FK_MortgageApplicants_CreditReports_CreditReportReportID",
                table: "MortgageApplicants");

            migrationBuilder.DropForeignKey(
                name: "FK_MortgageApplicants_Persons_PersonId",
                table: "MortgageApplicants");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Mortgages");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "admin");

            migrationBuilder.AlterColumn<int>(
                name: "SSN",
                table: "Persons",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Persons",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Persons",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Persons",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Persons",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmailAddress",
                table: "Persons",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "admin");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Persons",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Mortgages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "admin");

            migrationBuilder.AlterColumn<string>(
                name: "PropertyAddress",
                table: "Mortgages",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Mortgages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "admin");

            migrationBuilder.AddColumn<bool>(
                name: "ApproveStatus",
                table: "Mortgages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "MortgageApplicants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "admin");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "MortgageApplicants",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreditReportReportID",
                table: "MortgageApplicants",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "MortgageApplicants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "admin");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "LoanOfficers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "admin");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "LoanOfficers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "LoanOfficers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "LoanOfficers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "admin");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "CreditReports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "admin");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "CreditReports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "admin");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanOfficers_Persons_PersonId",
                table: "LoanOfficers",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MortgageApplicants_CreditReports_CreditReportReportID",
                table: "MortgageApplicants",
                column: "CreditReportReportID",
                principalTable: "CreditReports",
                principalColumn: "ReportID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MortgageApplicants_Persons_PersonId",
                table: "MortgageApplicants",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

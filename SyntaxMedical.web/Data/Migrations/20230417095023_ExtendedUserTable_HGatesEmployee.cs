using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SyntaxMedical.web.Data.Migrations
{
    public partial class ExtendedUserTable_HGatesEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DateJoined",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StaffID",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateJoined",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StaffID",
                table: "AspNetUsers");
        }
    }
}

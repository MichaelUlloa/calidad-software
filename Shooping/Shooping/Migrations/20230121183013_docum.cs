using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shooping.Migrations
{
    public partial class docum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Suplidores",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "Document",
                table: "Suplidores",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Document",
                table: "Suplidores");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Suplidores",
                newName: "ID");
        }
    }
}

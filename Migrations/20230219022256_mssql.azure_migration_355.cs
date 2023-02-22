using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NataliRecords.Migrations
{
    public partial class mssqlazure_migration_355 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "Records",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Records");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JornadaMilhasApp.Migrations
{
    /// <inheritdoc />
    public partial class AddNewFieldsToDestiny : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Destiny",
                type: "NVARCHAR(120)",
                maxLength: 120,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Meta",
                table: "Destiny",
                type: "NVARCHAR(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhotoTwo",
                table: "Destiny",
                type: "NVARCHAR(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Destiny");

            migrationBuilder.DropColumn(
                name: "Meta",
                table: "Destiny");

            migrationBuilder.DropColumn(
                name: "PhotoTwo",
                table: "Destiny");
        }
    }
}

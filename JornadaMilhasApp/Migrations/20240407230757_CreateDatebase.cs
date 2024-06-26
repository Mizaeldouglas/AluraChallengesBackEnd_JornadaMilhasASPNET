﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JornadaMilhasApp.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatebase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Testimonial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Photo = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    Comment = table.Column<string>(type: "NVARCHAR(MAX)", maxLength: 1000, nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(120)", maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testimonial", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Testimonial");
        }
    }
}

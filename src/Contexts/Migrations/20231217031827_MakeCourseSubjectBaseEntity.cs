using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace timeasyapi.src.Contexts.Migrations
{
    /// <inheritdoc />
    public partial class MakeCourseSubjectBaseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "CourseSubject",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "CourseSubject",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "CourseSubject");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CourseSubject");
        }
    }
}

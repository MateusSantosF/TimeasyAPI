using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace timeasyapi.src.Contexts.Migrations
{
    /// <inheritdoc />
    public partial class AddInstituteFKInAllTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "TimetableSubjects",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "InstituteId",
                table: "Subject",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "OperationalSystem",
                table: "RoomType",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(uint),
                oldType: "int unsigned",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<Guid>(
                name: "InstituteId",
                table: "RoomType",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "InstituteId",
                table: "Room",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "Turn",
                table: "Course",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(uint),
                oldType: "int unsigned")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Period",
                table: "Course",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(uint),
                oldType: "int unsigned")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_InstituteId",
                table: "Subject",
                column: "InstituteId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomType_InstituteId",
                table: "RoomType",
                column: "InstituteId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_InstituteId",
                table: "Room",
                column: "InstituteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Room_Institute_InstituteId",
                table: "Room",
                column: "InstituteId",
                principalTable: "Institute",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomType_Institute_InstituteId",
                table: "RoomType",
                column: "InstituteId",
                principalTable: "Institute",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_Institute_InstituteId",
                table: "Subject",
                column: "InstituteId",
                principalTable: "Institute",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Room_Institute_InstituteId",
                table: "Room");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomType_Institute_InstituteId",
                table: "RoomType");

            migrationBuilder.DropForeignKey(
                name: "FK_Subject_Institute_InstituteId",
                table: "Subject");

            migrationBuilder.DropIndex(
                name: "IX_Subject_InstituteId",
                table: "Subject");

            migrationBuilder.DropIndex(
                name: "IX_RoomType_InstituteId",
                table: "RoomType");

            migrationBuilder.DropIndex(
                name: "IX_Room_InstituteId",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TimetableSubjects");

            migrationBuilder.DropColumn(
                name: "InstituteId",
                table: "Subject");

            migrationBuilder.DropColumn(
                name: "InstituteId",
                table: "RoomType");

            migrationBuilder.DropColumn(
                name: "InstituteId",
                table: "Room");

            migrationBuilder.AlterColumn<uint>(
                name: "OperationalSystem",
                table: "RoomType",
                type: "int unsigned",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<uint>(
                name: "Turn",
                table: "Course",
                type: "int unsigned",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<uint>(
                name: "Period",
                table: "Course",
                type: "int unsigned",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}

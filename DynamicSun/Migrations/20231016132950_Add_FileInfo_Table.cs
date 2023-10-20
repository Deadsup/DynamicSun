using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DynamicSun.Migrations
{
    /// <inheritdoc />
    public partial class Add_FileInfo_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "WindDirection",
                table: "WeatherByHours",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "WeatherEvent",
                table: "WeatherByHours",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FileId",
                table: "WeatherByHours",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FileInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    DateUploaded = table.Column<DateOnly>(type: "date", nullable: false),
                    Path = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileInfo", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WeatherByHours_FileId",
                table: "WeatherByHours",
                column: "FileId");

            migrationBuilder.AddForeignKey(
                name: "FK_WeatherByHours_FileInfo_FileId",
                table: "WeatherByHours",
                column: "FileId",
                principalTable: "FileInfo",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeatherByHours_FileInfo_FileId",
                table: "WeatherByHours");

            migrationBuilder.DropTable(
                name: "FileInfo");

            migrationBuilder.DropIndex(
                name: "IX_WeatherByHours_FileId",
                table: "WeatherByHours");

            migrationBuilder.DropColumn(
                name: "FileId",
                table: "WeatherByHours");

            migrationBuilder.AlterColumn<string>(
                name: "WindDirection",
                table: "WeatherByHours",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "WeatherEvent",
                table: "WeatherByHours",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}

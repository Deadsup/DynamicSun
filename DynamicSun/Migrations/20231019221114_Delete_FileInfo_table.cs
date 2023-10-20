using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DynamicSun.Migrations
{
    /// <inheritdoc />
    public partial class Delete_FileInfo_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "WeatherByHours",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "WeatherByHours",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

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
                    DateUploaded = table.Column<DateOnly>(type: "date", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
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
    }
}

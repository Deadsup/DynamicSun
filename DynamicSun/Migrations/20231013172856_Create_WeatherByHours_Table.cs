using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DynamicSun.Migrations
{
    /// <inheritdoc />
    public partial class Create_WeatherByHours_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeatherByHours",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Temperature = table.Column<double>(type: "double precision", nullable: false),
                    AirHumidity = table.Column<double>(type: "double precision", nullable: false),
                    Td = table.Column<double>(type: "double precision", nullable: false),
                    ATMPressure = table.Column<double>(type: "double precision", nullable: false),
                    WindDirection = table.Column<string>(type: "text", nullable: true),
                    WindSpeed = table.Column<double>(type: "double precision", nullable: false),
                    CloudCover = table.Column<double>(type: "double precision", nullable: false),
                    H = table.Column<double>(type: "double precision", nullable: false),
                    VV = table.Column<double>(type: "double precision", nullable: false),
                    WeatherEvent = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherByHours", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeatherByHours");
        }
    }
}

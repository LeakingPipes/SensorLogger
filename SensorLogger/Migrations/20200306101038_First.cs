using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SensorLogger.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Microcontroller",
                columns: table => new
                {
                    MicrocontrollerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MicrocontrollerName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Microcontroller", x => x.MicrocontrollerID);
                });

            migrationBuilder.CreateTable(
                name: "Reading",
                columns: table => new
                {
                    ReadingID = table.Column<int>(nullable: false),
                    Date_time = table.Column<DateTime>(nullable: false),
                    MicrocontrollerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reading", x => x.ReadingID);
                    table.ForeignKey(
                        name: "FK_Reading_Microcontroller_MicrocontrollerID",
                        column: x => x.MicrocontrollerID,
                        principalTable: "Microcontroller",
                        principalColumn: "MicrocontrollerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReadingValue",
                columns: table => new
                {
                    ReadingValueID = table.Column<int>(nullable: false),
                    Value = table.Column<float>(nullable: false),
                    ValueType = table.Column<string>(nullable: true),
                    ReadingID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReadingValue", x => x.ReadingValueID);
                    table.ForeignKey(
                        name: "FK_ReadingValue_Reading_ReadingID",
                        column: x => x.ReadingID,
                        principalTable: "Reading",
                        principalColumn: "ReadingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reading_MicrocontrollerID",
                table: "Reading",
                column: "MicrocontrollerID");

            migrationBuilder.CreateIndex(
                name: "IX_ReadingValue_ReadingID",
                table: "ReadingValue",
                column: "ReadingID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReadingValue");

            migrationBuilder.DropTable(
                name: "Reading");

            migrationBuilder.DropTable(
                name: "Microcontroller");
        }
    }
}

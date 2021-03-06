﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SensorLogger.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Board",
                columns: table => new
                {
                    BoardID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BoardName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Board", x => x.BoardID);
                });

            migrationBuilder.CreateTable(
                name: "Component",
                columns: table => new
                {
                    ComponentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ComponentName = table.Column<string>(nullable: true),
                    NumberOfPins = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Component", x => x.ComponentID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Role = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Microcontroller",
                columns: table => new
                {
                    MicrocontrollerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MicrocontrollerName = table.Column<string>(nullable: true),
                    APIauthKey = table.Column<string>(nullable: true),
                    isPrivate = table.Column<bool>(nullable: false),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Microcontroller", x => x.MicrocontrollerID);
                    table.ForeignKey(
                        name: "FK_Microcontroller_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reading",
                columns: table => new
                {
                    ReadingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date_time = table.Column<DateTime>(nullable: true),
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
                    ReadingValueID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                name: "IX_Microcontroller_UserID",
                table: "Microcontroller",
                column: "UserID");

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
                name: "Board");

            migrationBuilder.DropTable(
                name: "Component");

            migrationBuilder.DropTable(
                name: "ReadingValue");

            migrationBuilder.DropTable(
                name: "Reading");

            migrationBuilder.DropTable(
                name: "Microcontroller");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}

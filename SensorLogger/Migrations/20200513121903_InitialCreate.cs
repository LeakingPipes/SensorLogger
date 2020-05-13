using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SensorLogger.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "User",
                newName: "UserID");

            migrationBuilder.AlterColumn<int>(
                name: "Role",
                table: "User",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "User",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date_time",
                table: "Reading",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Microcontroller",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "isPrivate",
                table: "Microcontroller",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Microcontroller_UserID",
                table: "Microcontroller",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Microcontroller_User_UserID",
                table: "Microcontroller",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Microcontroller_User_UserID",
                table: "Microcontroller");

            migrationBuilder.DropIndex(
                name: "IX_Microcontroller_UserID",
                table: "Microcontroller");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Microcontroller");

            migrationBuilder.DropColumn(
                name: "isPrivate",
                table: "Microcontroller");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "User",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "User",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "User",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date_time",
                table: "Reading",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}

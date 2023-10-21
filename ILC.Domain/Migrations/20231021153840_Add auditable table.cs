using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ILC.Domain.Migrations
{
    public partial class Addauditabletable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "SilderHome",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreationDate",
                table: "SilderHome",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LastModifiedById",
                table: "SilderHome",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastModifiedDate",
                table: "SilderHome",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "AboutUsHome",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreationDate",
                table: "AboutUsHome",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LastModifiedById",
                table: "AboutUsHome",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastModifiedDate",
                table: "AboutUsHome",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SilderHome_CreatedById",
                table: "SilderHome",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_SilderHome_LastModifiedById",
                table: "SilderHome",
                column: "LastModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_AboutUsHome_CreatedById",
                table: "AboutUsHome",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AboutUsHome_LastModifiedById",
                table: "AboutUsHome",
                column: "LastModifiedById");

            migrationBuilder.AddForeignKey(
                name: "FK_AboutUsHome_AppUsers_CreatedById",
                table: "AboutUsHome",
                column: "CreatedById",
                principalTable: "AppUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AboutUsHome_AppUsers_LastModifiedById",
                table: "AboutUsHome",
                column: "LastModifiedById",
                principalTable: "AppUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SilderHome_AppUsers_CreatedById",
                table: "SilderHome",
                column: "CreatedById",
                principalTable: "AppUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SilderHome_AppUsers_LastModifiedById",
                table: "SilderHome",
                column: "LastModifiedById",
                principalTable: "AppUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AboutUsHome_AppUsers_CreatedById",
                table: "AboutUsHome");

            migrationBuilder.DropForeignKey(
                name: "FK_AboutUsHome_AppUsers_LastModifiedById",
                table: "AboutUsHome");

            migrationBuilder.DropForeignKey(
                name: "FK_SilderHome_AppUsers_CreatedById",
                table: "SilderHome");

            migrationBuilder.DropForeignKey(
                name: "FK_SilderHome_AppUsers_LastModifiedById",
                table: "SilderHome");

            migrationBuilder.DropIndex(
                name: "IX_SilderHome_CreatedById",
                table: "SilderHome");

            migrationBuilder.DropIndex(
                name: "IX_SilderHome_LastModifiedById",
                table: "SilderHome");

            migrationBuilder.DropIndex(
                name: "IX_AboutUsHome_CreatedById",
                table: "AboutUsHome");

            migrationBuilder.DropIndex(
                name: "IX_AboutUsHome_LastModifiedById",
                table: "AboutUsHome");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "SilderHome");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "SilderHome");

            migrationBuilder.DropColumn(
                name: "LastModifiedById",
                table: "SilderHome");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "SilderHome");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "AboutUsHome");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "AboutUsHome");

            migrationBuilder.DropColumn(
                name: "LastModifiedById",
                table: "AboutUsHome");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "AboutUsHome");
        }
    }
}

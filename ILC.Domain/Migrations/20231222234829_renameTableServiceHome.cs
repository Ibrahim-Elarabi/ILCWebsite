using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ILC.Domain.Migrations
{
    public partial class renameTableServiceHome : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceHome");

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitleEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitleAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    AppearInHomePage = table.Column<bool>(type: "bit", nullable: false),
                    ParentServiceId = table.Column<int>(type: "int", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastModifiedById = table.Column<int>(type: "int", nullable: true),
                    LastModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Service_AppUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AppUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Service_AppUsers_LastModifiedById",
                        column: x => x.LastModifiedById,
                        principalTable: "AppUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Service_Service_ParentServiceId",
                        column: x => x.ParentServiceId,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Service_CreatedById",
                table: "Service",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Service_LastModifiedById",
                table: "Service",
                column: "LastModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Service_ParentServiceId",
                table: "Service",
                column: "ParentServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.CreateTable(
                name: "ServiceHome",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    LastModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DescriptionAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    LastModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    TitleAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleEn = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceHome", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceHome_AppUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AppUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ServiceHome_AppUsers_LastModifiedById",
                        column: x => x.LastModifiedById,
                        principalTable: "AppUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceHome_CreatedById",
                table: "ServiceHome",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceHome_LastModifiedById",
                table: "ServiceHome",
                column: "LastModifiedById");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Santader.UserControl.Migrations.AppDbContextOraMigrations
{
    public partial class MyFirstMigrationOra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeleteUsers",
                columns: table => new
                {
                    id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    idUser = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ResignationDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Process = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeleteUsers", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeleteUsers");
        }
    }
}

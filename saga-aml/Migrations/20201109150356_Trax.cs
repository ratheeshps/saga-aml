using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AmlService.Migrations
{
    public partial class Trax : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AmlTransactions",
                columns: table => new
                {
                    TrackID = table.Column<Guid>(nullable: false),
                    CustomerName = table.Column<string>(nullable: true),
                    CountryName = table.Column<string>(nullable: true),
                    AmlStatus = table.Column<string>(nullable: true),
                    RemitterID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmlTransactions", x => x.TrackID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AmlTransactions");
        }
    }
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NationBuilder.Data.Migrations
{
    public partial class NationModelCrazy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nations",
                columns: table => new
                {
                    NationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Capital = table.Column<string>(nullable: true),
                    Economy = table.Column<string>(nullable: true),
                    Geography = table.Column<string>(nullable: true),
                    Government = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Religion = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nations", x => x.NationId);
                    table.ForeignKey(
                        name: "FK_Nations_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Resource",
                columns: table => new
                {
                    ResourcesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Coal = table.Column<int>(nullable: false),
                    CoalGrowth = table.Column<int>(nullable: false),
                    CoalLabor = table.Column<int>(nullable: false),
                    Currency = table.Column<int>(nullable: false),
                    CurrencyGrowth = table.Column<int>(nullable: false),
                    CurrencyLabor = table.Column<int>(nullable: false),
                    Food = table.Column<int>(nullable: false),
                    FoodGrowth = table.Column<int>(nullable: false),
                    FoodLabor = table.Column<int>(nullable: false),
                    Happiness = table.Column<int>(nullable: false),
                    HappinessGrowth = table.Column<int>(nullable: false),
                    LaborPoints = table.Column<int>(nullable: false),
                    Lumber = table.Column<int>(nullable: false),
                    LumberGrowth = table.Column<int>(nullable: false),
                    LumberLabor = table.Column<int>(nullable: false),
                    Medical = table.Column<int>(nullable: false),
                    MedicalGrowth = table.Column<int>(nullable: false),
                    MedicalLabor = table.Column<int>(nullable: false),
                    NationId = table.Column<int>(nullable: false),
                    Oil = table.Column<int>(nullable: false),
                    OilGrowth = table.Column<int>(nullable: false),
                    OilLabor = table.Column<int>(nullable: false),
                    Population = table.Column<int>(nullable: false),
                    PopulationGrowth = table.Column<int>(nullable: false),
                    RareEarth = table.Column<int>(nullable: false),
                    RareEarthGrowth = table.Column<int>(nullable: false),
                    RareEarthLabor = table.Column<int>(nullable: false),
                    Steel = table.Column<int>(nullable: false),
                    SteelGrowth = table.Column<int>(nullable: false),
                    SteelLabor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resource", x => x.ResourcesId);
                    table.ForeignKey(
                        name: "FK_Resource_Nations_NationId",
                        column: x => x.NationId,
                        principalTable: "Nations",
                        principalColumn: "NationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nations_UserId",
                table: "Nations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Resource_NationId",
                table: "Resource",
                column: "NationId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Resource");

            migrationBuilder.DropTable(
                name: "Nations");
        }
    }
}

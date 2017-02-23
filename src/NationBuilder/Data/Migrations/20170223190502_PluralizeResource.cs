using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NationBuilder.Data.Migrations
{
    public partial class PluralizeResource : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resource_Nations_NationId",
                table: "Resource");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Resource",
                table: "Resource");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Resources",
                table: "Resource",
                column: "ResourcesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Resources_Nations_NationId",
                table: "Resource",
                column: "NationId",
                principalTable: "Nations",
                principalColumn: "NationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.RenameIndex(
                name: "IX_Resource_NationId",
                table: "Resource",
                newName: "IX_Resources_NationId");

            migrationBuilder.RenameTable(
                name: "Resource",
                newName: "Resources");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resources_Nations_NationId",
                table: "Resources");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Resources",
                table: "Resources");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Resource",
                table: "Resources",
                column: "ResourcesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Resource_Nations_NationId",
                table: "Resources",
                column: "NationId",
                principalTable: "Nations",
                principalColumn: "NationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.RenameIndex(
                name: "IX_Resources_NationId",
                table: "Resources",
                newName: "IX_Resource_NationId");

            migrationBuilder.RenameTable(
                name: "Resources",
                newName: "Resource");
        }
    }
}

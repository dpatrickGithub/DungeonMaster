using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DungeonMaster.Data.Migrations
{
    public partial class AddCharacterAbilityScoreFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CharacterId",
                table: "DNDClass",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DNDClass_CharacterId",
                table: "DNDClass",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Character_AbilityScore_Character_Id",
                table: "Character_AbilityScore",
                column: "Character_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Character_AbilityScore_Character_Character_Id",
                table: "Character_AbilityScore",
                column: "Character_Id",
                principalTable: "Character",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DNDClass_Character_CharacterId",
                table: "DNDClass",
                column: "CharacterId",
                principalTable: "Character",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_AbilityScore_Character_Character_Id",
                table: "Character_AbilityScore");

            migrationBuilder.DropForeignKey(
                name: "FK_DNDClass_Character_CharacterId",
                table: "DNDClass");

            migrationBuilder.DropIndex(
                name: "IX_DNDClass_CharacterId",
                table: "DNDClass");

            migrationBuilder.DropIndex(
                name: "IX_Character_AbilityScore_Character_Id",
                table: "Character_AbilityScore");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "DNDClass");
        }
    }
}

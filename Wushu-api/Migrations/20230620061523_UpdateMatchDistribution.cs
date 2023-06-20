using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wushu_api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMatchDistribution : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_MatchDistributions_MatchDistributionsId",
                table: "Matches");

            migrationBuilder.AlterColumn<Guid>(
                name: "MatchDistributionsId",
                table: "Matches",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_MatchDistributions_MatchDistributionsId",
                table: "Matches",
                column: "MatchDistributionsId",
                principalTable: "MatchDistributions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_MatchDistributions_MatchDistributionsId",
                table: "Matches");

            migrationBuilder.AlterColumn<Guid>(
                name: "MatchDistributionsId",
                table: "Matches",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_MatchDistributions_MatchDistributionsId",
                table: "Matches",
                column: "MatchDistributionsId",
                principalTable: "MatchDistributions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

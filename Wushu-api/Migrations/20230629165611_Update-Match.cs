using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wushu_api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMatch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ParticipantWinnerId",
                table: "Matches",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Matches_ParticipantWinnerId",
                table: "Matches",
                column: "ParticipantWinnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Participants_ParticipantWinnerId",
                table: "Matches",
                column: "ParticipantWinnerId",
                principalTable: "Participants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Participants_ParticipantWinnerId",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_ParticipantWinnerId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "ParticipantWinnerId",
                table: "Matches");
        }
    }
}

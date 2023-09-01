using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Wushu_api.Migrations
{
    /// <inheritdoc />
    public partial class RoundWinner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_AspNetUsers_UserId",
                table: "Matches");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ef72011-33d7-4ac0-8654-90da0a1bd0e7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "216ed5a4-c086-4eaf-828f-63b748fe479c");

            migrationBuilder.AddColumn<Guid>(
                name: "ParticipantWinnerId",
                table: "Rounds",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Matches",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CompetitorSecondId",
                table: "Matches",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CompetitorFirstId",
                table: "Matches",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "11192d89-9d91-45b4-a111-6e4b481217ea", "871231d8-a67c-4b66-a303-997ced955ec0", "Admin", "ADMIN" },
                    { "de44f958-db9e-4714-a3e2-17fed2662da0", "8c5e1e12-fe2f-4cf6-a714-e6814b9c3287", "Referee", "REFEREE" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_ParticipantWinnerId",
                table: "Rounds",
                column: "ParticipantWinnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_AspNetUsers_UserId",
                table: "Matches",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rounds_Participants_ParticipantWinnerId",
                table: "Rounds",
                column: "ParticipantWinnerId",
                principalTable: "Participants",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_AspNetUsers_UserId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Rounds_Participants_ParticipantWinnerId",
                table: "Rounds");

            migrationBuilder.DropIndex(
                name: "IX_Rounds_ParticipantWinnerId",
                table: "Rounds");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11192d89-9d91-45b4-a111-6e4b481217ea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de44f958-db9e-4714-a3e2-17fed2662da0");

            migrationBuilder.DropColumn(
                name: "ParticipantWinnerId",
                table: "Rounds");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Matches",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "CompetitorSecondId",
                table: "Matches",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "CompetitorFirstId",
                table: "Matches",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0ef72011-33d7-4ac0-8654-90da0a1bd0e7", "a8b2649b-78b8-46ce-916f-e384d43e3eb9", "Admin", "ADMIN" },
                    { "216ed5a4-c086-4eaf-828f-63b748fe479c", "4e5c1ef6-089d-4734-9ab7-7876be109020", "Referee", "REFEREE" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_AspNetUsers_UserId",
                table: "Matches",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}

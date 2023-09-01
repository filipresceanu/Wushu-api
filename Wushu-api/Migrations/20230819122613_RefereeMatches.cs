using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Wushu_api.Migrations
{
    /// <inheritdoc />
    public partial class RefereeMatches : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23e6c984-676e-40f5-897b-71cc8af449fc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a47b595e-81a8-4f99-9ed8-682c29e45973");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Matches",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0ef72011-33d7-4ac0-8654-90da0a1bd0e7", "a8b2649b-78b8-46ce-916f-e384d43e3eb9", "Admin", "ADMIN" },
                    { "216ed5a4-c086-4eaf-828f-63b748fe479c", "4e5c1ef6-089d-4734-9ab7-7876be109020", "Referee", "REFEREE" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_UserId",
                table: "Matches",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_AspNetUsers_UserId",
                table: "Matches",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_AspNetUsers_UserId",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_UserId",
                table: "Matches");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ef72011-33d7-4ac0-8654-90da0a1bd0e7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "216ed5a4-c086-4eaf-828f-63b748fe479c");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Matches");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "23e6c984-676e-40f5-897b-71cc8af449fc", "b4821c23-db21-4d63-b1eb-f49b639ee8b7", "Referee", "REFEREE" },
                    { "a47b595e-81a8-4f99-9ed8-682c29e45973", "d0ee2f7d-ae2b-41f9-97e9-95b6950666e6", "Admin", "ADMIN" }
                });
        }
    }
}

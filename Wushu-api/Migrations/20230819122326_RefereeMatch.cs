﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Wushu_api.Migrations
{
    /// <inheritdoc />
    public partial class RefereeMatch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9d03956d-3fb9-43f2-9371-d7af56109114");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f275af18-4233-4b58-ae8d-956dce996c65");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "23e6c984-676e-40f5-897b-71cc8af449fc", "b4821c23-db21-4d63-b1eb-f49b639ee8b7", "Referee", "REFEREE" },
                    { "a47b595e-81a8-4f99-9ed8-682c29e45973", "d0ee2f7d-ae2b-41f9-97e9-95b6950666e6", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23e6c984-676e-40f5-897b-71cc8af449fc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a47b595e-81a8-4f99-9ed8-682c29e45973");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9d03956d-3fb9-43f2-9371-d7af56109114", "5c99c01a-f0f3-4696-8f89-b0ec24738782", "Admin", "ADMIN" },
                    { "f275af18-4233-4b58-ae8d-956dce996c65", "7539dbba-ec91-4a0d-96bc-96928b3fa090", "Referee", "REFEREE" }
                });
        }
    }
}

﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wushu_api.Migrations
{
    /// <inheritdoc />
    public partial class RemoveReferee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Referees");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Referees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MatchId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Referees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Referees_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Referees_MatchId",
                table: "Referees",
                column: "MatchId");
        }
    }
}
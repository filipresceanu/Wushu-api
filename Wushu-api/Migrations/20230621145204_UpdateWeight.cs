using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wushu_api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateWeight : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Weight",
                table: "Categories",
                newName: "LessThanWeight");

            migrationBuilder.AddColumn<int>(
                name: "GraterThanWeight",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GraterThanWeight",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "LessThanWeight",
                table: "Categories",
                newName: "Weight");
        }
    }
}

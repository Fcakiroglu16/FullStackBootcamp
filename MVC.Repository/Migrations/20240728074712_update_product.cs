using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.Repository.Migrations
{
    /// <inheritdoc />
    public partial class update_product : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CreatedByUser",
                table: "Products",
                type: "uniqueidentifier",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedByUser",
                table: "Products",
                type: "uniqueidentifier",
                maxLength: 256,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedByUser",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UpdatedByUser",
                table: "Products");
        }
    }
}

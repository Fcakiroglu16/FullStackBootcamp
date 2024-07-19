using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Example.Repository.Migrations
{
    /// <inheritdoc />
    public partial class updatetag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ArticleTags_TagId",
                table: "ArticleTags",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleTags_Tags_TagId",
                table: "ArticleTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleTags_Tags_TagId",
                table: "ArticleTags");

            migrationBuilder.DropIndex(
                name: "IX_ArticleTags_TagId",
                table: "ArticleTags");
        }
    }
}

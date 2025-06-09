using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UrlShortenerBack.Migrations
{
    /// <inheritdoc />
    public partial class UrlCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Urls",
                table: "Urls");

            migrationBuilder.AlterColumn<string>(
                name: "ShortUrl",
                table: "Urls",
                type: "VARCHAR(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(8)",
                oldMaxLength: 8);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Urls",
                type: "VARCHAR(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Urls",
                table: "Urls",
                column: "Code");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Urls",
                table: "Urls");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Urls");

            migrationBuilder.AlterColumn<string>(
                name: "ShortUrl",
                table: "Urls",
                type: "VARCHAR(8)",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Urls",
                table: "Urls",
                column: "ShortUrl");
        }
    }
}

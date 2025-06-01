using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UrlShortenerBack.Migrations
{
    /// <inheritdoc />
    public partial class LongUrlSize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LongUrl",
                table: "Urls",
                type: "VARCHAR(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(8)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LongUrl",
                table: "Urls",
                type: "VARCHAR(8)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)");
        }
    }
}

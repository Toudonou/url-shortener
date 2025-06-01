using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UrlShortenerBack.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Urls",
                columns: table => new
                {
                    ShortUrl = table.Column<string>(type: "VARCHAR(8)", maxLength: 8, nullable: false),
                    LongUrl = table.Column<string>(type: "VARCHAR(8)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATE", nullable: false),
                    UsedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urls", x => x.ShortUrl);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Urls");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "albums",
                columns: table => new
                {
                    title = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    description = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    createdBy = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_albums", x => x.title);
                });

            migrationBuilder.CreateTable(
                name: "images",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    title = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: false),
                    url = table.Column<string>(type: "TEXT", nullable: false),
                    topic = table.Column<string>(type: "TEXT", nullable: false),
                    album_title = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_images", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "albums");

            migrationBuilder.DropTable(
                name: "images");
        }
    }
}

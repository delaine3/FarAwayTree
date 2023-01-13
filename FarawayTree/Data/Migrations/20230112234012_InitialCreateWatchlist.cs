using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarawayTree.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateWatchlist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WatchList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OnAir = table.Column<bool>(type: "bit", nullable: false),
                    SeasonStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SeasonEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Watched = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WatchList", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WatchList");
        }
    }
}

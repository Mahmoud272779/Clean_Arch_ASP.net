using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanMovie.API.Migrations
{
    public partial class AddedRental_Member : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "Movies",
                newName: "MovieName");

            migrationBuilder.RenameColumn(
                name: "cost",
                table: "Movies",
                newName: "RentalCost");

            migrationBuilder.AddColumn<int>(
                name: "RentalDuration",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Rentals",
                columns: table => new
                {
                    RentalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RentalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RentalExpiry = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals", x => x.RentalId);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RentalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MemberId);
                    table.ForeignKey(
                        name: "FK_Members_Rentals_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Rentals",
                        principalColumn: "RentalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieRentals",
                columns: table => new
                {
                    RentalId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieRentals", x => new { x.MovieId, x.RentalId });
                    table.ForeignKey(
                        name: "FK_MovieRentals_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieRentals_Rentals_RentalId",
                        column: x => x.RentalId,
                        principalTable: "Rentals",
                        principalColumn: "RentalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieRentals_RentalId",
                table: "MovieRentals",
                column: "RentalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "MovieRentals");

            migrationBuilder.DropTable(
                name: "Rentals");

            migrationBuilder.DropColumn(
                name: "RentalDuration",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "RentalCost",
                table: "Movies",
                newName: "cost");

            migrationBuilder.RenameColumn(
                name: "MovieName",
                table: "Movies",
                newName: "name");
        }
    }
}

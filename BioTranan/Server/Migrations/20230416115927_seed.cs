using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BioTranan.Server.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Genre = table.Column<int>(type: "INTEGER", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    Duration = table.Column<int>(type: "INTEGER", nullable: false),
                    Language = table.Column<string>(type: "TEXT", nullable: false),
                    AgeLimit = table.Column<int>(type: "INTEGER", nullable: false),
                    Director = table.Column<string>(type: "TEXT", nullable: false),
                    Cast = table.Column<string>(type: "TEXT", nullable: false),
                    PremiereYear = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxViews = table.Column<int>(type: "INTEGER", nullable: false),
                    ViewCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Theaters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Capacity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Theaters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ShowDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    AvalibleTickets = table.Column<int>(type: "INTEGER", nullable: false),
                    TheaterId = table.Column<int>(type: "INTEGER", nullable: false),
                    MovieId = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Time = table.Column<TimeSpan>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shows_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shows_Theaters_TheaterId",
                        column: x => x.TheaterId,
                        principalTable: "Theaters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerEmail = table.Column<string>(type: "TEXT", nullable: false),
                    NumberOfTickets = table.Column<int>(type: "INTEGER", nullable: false),
                    ShowId = table.Column<int>(type: "INTEGER", nullable: false),
                    BookingCode = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Shows_ShowId",
                        column: x => x.ShowId,
                        principalTable: "Shows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "AgeLimit", "Cast", "Description", "Director", "Duration", "Genre", "ImageUrl", "Language", "MaxViews", "PremiereYear", "Title", "ViewCount" },
                values: new object[] { 1, 18, "Marlon Brando, Al Pacino, James Caan", "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.", "Francis Ford Coppola", 175, 2, "https://m.media-amazon.com/images/M/MV5BM2MyNjYxNmUtYTAwNi00MTYxLWJmNWYtYzZlODY3ZTk3OTFlXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_FMjpg_UX1000_.jpg", "English", 1, 1972, "The Godfather", 0 });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "AgeLimit", "Cast", "Description", "Director", "Duration", "Genre", "ImageUrl", "Language", "MaxViews", "PremiereYear", "Title", "ViewCount" },
                values: new object[] { 2, 16, "Tim Robbins, Morgan Freeman, Bob Gunton", "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.", "Frank Darabont", 142, 2, "https://m.media-amazon.com/images/M/MV5BNDE3ODcxYzMtY2YzZC00NmNlLWJiNDMtZDViZWM2MzIxZDYwXkEyXkFqcGdeQXVyNjAwNDUxODI@._V1_FMjpg_UX1000_.jpg", "English", 10, 1994, "The Shawshank Redemption", 0 });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "AgeLimit", "Cast", "Description", "Director", "Duration", "Genre", "ImageUrl", "Language", "MaxViews", "PremiereYear", "Title", "ViewCount" },
                values: new object[] { 3, 14, "Christian Bale, Heath Ledger, Aaron Eckhart", "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.", "Christopher Nolan", 152, 0, "https://m.media-amazon.com/images/M/MV5BMTMxNTMwODM0NF5BMl5BanBnXkFtZTcwODAyMTk2Mw@@._V1_FMjpg_UX1000_.jpg", "English", 10, 2008, "The Dark Knight", 0 });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "AgeLimit", "Cast", "Description", "Director", "Duration", "Genre", "ImageUrl", "Language", "MaxViews", "PremiereYear", "Title", "ViewCount" },
                values: new object[] { 4, 12, "Tom Hanks, Robin Wright, Gary Sinise", "The presidencies of Kennedy and Johnson, the events of Vietnam, Watergate, and other historical events unfold through the perspective of an Alabama man with an IQ of 75, whose only desire is to be reunited with his childhood sweetheart.", "Robert Zemeckis", 142, 2, "https://m.media-amazon.com/images/M/MV5BYWY2MjE2NGQtZGNiMy00NThkLTlhZTAtMjFkNGMyMGJiZTJiXkEyXkFqcGdeQXVyNjAwNDUxODI@._V1_.jpg", "English", 10, 1994, "Forrest Gump", 0 });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "AgeLimit", "Cast", "Description", "Director", "Duration", "Genre", "ImageUrl", "Language", "MaxViews", "PremiereYear", "Title", "ViewCount" },
                values: new object[] { 5, 14, "Leonardo DiCaprio, Joseph Gordon-Levitt, Ellen Page", "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a CEO.", "Christopher Nolan", 148, 0, "https://m.media-amazon.com/images/M/MV5BMjExMjkwNTQ0Nl5BMl5BanBnXkFtZTcwNTY0OTk1Mw@@._V1_.jpg", "English", 10, 2010, "Inception", 0 });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "AgeLimit", "Cast", "Description", "Director", "Duration", "Genre", "ImageUrl", "Language", "MaxViews", "PremiereYear", "Title", "ViewCount" },
                values: new object[] { 6, 18, "John Travolta, Uma Thurman, Samuel L. Jackson", "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.", "Quentin Tarantino", 154, 0, "https://m.media-amazon.com/images/M/MV5BNGNhMDIzZTUtNTBlZi00MTRlLWFjM2ItYzViMjE3YzI5MjljXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_FMjpg_UX1000_.jpg", "English", 10, 1994, "Pulp Fiction", 0 });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "AgeLimit", "Cast", "Description", "Director", "Duration", "Genre", "ImageUrl", "Language", "MaxViews", "PremiereYear", "Title", "ViewCount" },
                values: new object[] { 7, 15, "Keanu Reeves, Laurence Fishburne, Carrie-Anne Moss", "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.", "Lana Wachowski, Lilly Wachowski", 136, 0, "https://m.media-amazon.com/images/M/MV5BNzQzOTk3OTAtNDQ0Zi00ZTVkLWI0MTEtMDllZjNkYzNjNTc4L2ltYWdlXkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_.jpg", "English", 10, 1999, "The Matrix", 0 });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "AgeLimit", "Cast", "Description", "Director", "Duration", "Genre", "ImageUrl", "Language", "MaxViews", "PremiereYear", "Title", "ViewCount" },
                values: new object[] { 8, 18, "Brad Pitt, Diane Kruger, Eli Roth", "In Nazi-occupied France during World War II, a plan to assassinate Nazi leaders by a group of Jewish U.S. soldiers coincides with a theatre owner's vengeful plans for the same.", "Quentin Tarantino", 153, 0, "https://m.media-amazon.com/images/M/MV5BOTJiNDEzOWYtMTVjOC00ZjlmLWE0NGMtZmE1OWVmZDQ2OWJhXkEyXkFqcGdeQXVyNTIzOTk5ODM@._V1_.jpg", "English, German, French, Italian", 10, 2009, "Inglourious Basterds", 0 });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "AgeLimit", "Cast", "Description", "Director", "Duration", "Genre", "ImageUrl", "Language", "MaxViews", "PremiereYear", "Title", "ViewCount" },
                values: new object[] { 9, 18, "Robert De Niro, Ray Liotta, Joe Pesci", "The story of Henry Hill and his life in the mob, covering his relationship with his wife Karen Hill and his mob partners Jimmy Conway and Tommy DeVito in the Italian-American crime syndicate.", "Martin Scorsese", 146, 2, "https://m.media-amazon.com/images/M/MV5BY2NkZjEzMDgtN2RjYy00YzM1LWI4ZmQtMjIwYjFjNmI3ZGEwXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_FMjpg_UX1000_.jpg", "English", 10, 1990, "Goodfellas", 0 });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "AgeLimit", "Cast", "Description", "Director", "Duration", "Genre", "ImageUrl", "Language", "MaxViews", "PremiereYear", "Title", "ViewCount" },
                values: new object[] { 10, 18, "Brad Pitt, Edward Norton, Helena Bonham Carter", "An insomniac office worker and a devil-may-care soapmaker form an underground fight club that evolves into something much, much more.", "David Fincher", 139, 2, "https://m.media-amazon.com/images/M/MV5BMmEzNTkxYjQtZTc0MC00YTVjLTg5ZTEtZWMwOWVlYzY0NWIwXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_FMjpg_UX1000_.jpg", "English", 10, 1999, "Fight Club", 0 });

            migrationBuilder.InsertData(
                table: "Theaters",
                columns: new[] { "Id", "Capacity", "Name" },
                values: new object[] { 1, 65, "Salong 1" });

            migrationBuilder.InsertData(
                table: "Theaters",
                columns: new[] { "Id", "Capacity", "Name" },
                values: new object[] { 2, 80, "Salong 2" });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ShowId",
                table: "Bookings",
                column: "ShowId");

            migrationBuilder.CreateIndex(
                name: "IX_Shows_MovieId",
                table: "Shows",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Shows_TheaterId",
                table: "Shows",
                column: "TheaterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Shows");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Theaters");
        }
    }
}

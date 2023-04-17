namespace BioTranan.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=movie_database.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 1,
                    Title = "The Godfather",
                    Description = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.",
                    Genre = Genre.Drama,
                    ImageUrl = "https://m.media-amazon.com/images/M/MV5BM2MyNjYxNmUtYTAwNi00MTYxLWJmNWYtYzZlODY3ZTk3OTFlXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_FMjpg_UX1000_.jpg",
                    Duration = 175,
                    Language = "English",
                    AgeLimit = 18,
                    Director = "Francis Ford Coppola",
                    Cast = "Marlon Brando, Al Pacino, James Caan",
                    PremiereYear = 1972,
                    MaxViews = 1
                },
                new Movie
                {
                    Id = 2,
                    Title = "The Shawshank Redemption",
                    Description = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
                    Genre = Genre.Drama,
                    ImageUrl = "https://m.media-amazon.com/images/M/MV5BNDE3ODcxYzMtY2YzZC00NmNlLWJiNDMtZDViZWM2MzIxZDYwXkEyXkFqcGdeQXVyNjAwNDUxODI@._V1_FMjpg_UX1000_.jpg",
                    Duration = 142,
                    Language = "English",
                    AgeLimit = 16,
                    Director = "Frank Darabont",
                    Cast = "Tim Robbins, Morgan Freeman, Bob Gunton",
                    PremiereYear = 1994,
                    MaxViews = 10
                },
                new Movie
                {
                    Id = 3,
                    Title = "The Dark Knight",
                    Description = "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.",
                    Genre = Genre.Action,
                    ImageUrl = "https://m.media-amazon.com/images/M/MV5BMTMxNTMwODM0NF5BMl5BanBnXkFtZTcwODAyMTk2Mw@@._V1_FMjpg_UX1000_.jpg",
                    Duration = 152,
                    Language = "English",
                    AgeLimit = 14,
                    Director = "Christopher Nolan",
                    Cast = "Christian Bale, Heath Ledger, Aaron Eckhart",
                    PremiereYear = 2008,
                    MaxViews = 10
                },
                new Movie
                {
                    Id = 4,
                    Title = "Forrest Gump",
                    Description = "The presidencies of Kennedy and Johnson, the events of Vietnam, Watergate, and other historical events unfold through the perspective of an Alabama man with an IQ of 75, whose only desire is to be reunited with his childhood sweetheart.",
                    Genre = Genre.Drama,
                    ImageUrl = "https://m.media-amazon.com/images/M/MV5BYWY2MjE2NGQtZGNiMy00NThkLTlhZTAtMjFkNGMyMGJiZTJiXkEyXkFqcGdeQXVyNjAwNDUxODI@._V1_.jpg",
                    Duration = 142,
                    Language = "English",
                    AgeLimit = 12,
                    Director = "Robert Zemeckis",
                    Cast = "Tom Hanks, Robin Wright, Gary Sinise",
                    PremiereYear = 1994,
                    MaxViews = 10
                },
                new Movie
                {
                    Id = 5,
                    Title = "Inception",
                    Description = "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a CEO.",
                    Genre = Genre.Action,
                    ImageUrl = "https://m.media-amazon.com/images/M/MV5BMjExMjkwNTQ0Nl5BMl5BanBnXkFtZTcwNTY0OTk1Mw@@._V1_.jpg",
                    Duration = 148,
                    Language = "English",
                    AgeLimit = 14,
                    Director = "Christopher Nolan",
                    Cast = "Leonardo DiCaprio, Joseph Gordon-Levitt, Ellen Page",
                    PremiereYear = 2010,
                    MaxViews = 10
                },
                        new Movie
                        {
                            Id = 6,
                            Title = "Pulp Fiction",
                            Description = "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.",
                            Genre = Genre.Action,
                            ImageUrl = "https://m.media-amazon.com/images/M/MV5BNGNhMDIzZTUtNTBlZi00MTRlLWFjM2ItYzViMjE3YzI5MjljXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_FMjpg_UX1000_.jpg",
                            Duration = 154,
                            Language = "English",
                            AgeLimit = 18,
                            Director = "Quentin Tarantino",
                            Cast = "John Travolta, Uma Thurman, Samuel L. Jackson",
                            PremiereYear = 1994,
                            MaxViews = 10
                        },
        new Movie
        {
            Id = 7,
            Title = "The Matrix",
            Description = "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.",
            Genre = Genre.Action,
            ImageUrl = "https://m.media-amazon.com/images/M/MV5BNzQzOTk3OTAtNDQ0Zi00ZTVkLWI0MTEtMDllZjNkYzNjNTc4L2ltYWdlXkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_.jpg",
            Duration = 136,
            Language = "English",
            AgeLimit = 15,
            Director = "Lana Wachowski, Lilly Wachowski",
            Cast = "Keanu Reeves, Laurence Fishburne, Carrie-Anne Moss",
            PremiereYear = 1999,
            MaxViews = 10
        },
        new Movie
        {
            Id = 8,
            Title = "Inglourious Basterds",
            Description = "In Nazi-occupied France during World War II, a plan to assassinate Nazi leaders by a group of Jewish U.S. soldiers coincides with a theatre owner's vengeful plans for the same.",
            Genre = Genre.Action,
            ImageUrl = "https://m.media-amazon.com/images/M/MV5BOTJiNDEzOWYtMTVjOC00ZjlmLWE0NGMtZmE1OWVmZDQ2OWJhXkEyXkFqcGdeQXVyNTIzOTk5ODM@._V1_.jpg",
            Duration = 153,
            Language = "English, German, French, Italian",
            AgeLimit = 18,
            Director = "Quentin Tarantino",
            Cast = "Brad Pitt, Diane Kruger, Eli Roth",
            PremiereYear = 2009,
            MaxViews = 10
        },
        new Movie
        {
            Id = 9,
            Title = "Goodfellas",
            Description = "The story of Henry Hill and his life in the mob, covering his relationship with his wife Karen Hill and his mob partners Jimmy Conway and Tommy DeVito in the Italian-American crime syndicate.",
            Genre = Genre.Drama,
            ImageUrl = "https://m.media-amazon.com/images/M/MV5BY2NkZjEzMDgtN2RjYy00YzM1LWI4ZmQtMjIwYjFjNmI3ZGEwXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_FMjpg_UX1000_.jpg",
            Duration = 146,
            Language = "English",
            AgeLimit = 18,
            Director = "Martin Scorsese",
            Cast = "Robert De Niro, Ray Liotta, Joe Pesci",
            PremiereYear = 1990,
            MaxViews = 10
        },
        new Movie
        {
            Id = 10,
            Title = "Fight Club",
            Description = "An insomniac office worker and a devil-may-care soapmaker form an underground fight club that evolves into something much, much more.",
            Genre = Genre.Drama,
            ImageUrl = "https://m.media-amazon.com/images/M/MV5BMmEzNTkxYjQtZTc0MC00YTVjLTg5ZTEtZWMwOWVlYzY0NWIwXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_FMjpg_UX1000_.jpg",
            Duration = 139,
            Language = "English",
            AgeLimit = 18,
            Director = "David Fincher",
            Cast = "Brad Pitt, Edward Norton, Helena Bonham Carter",
            PremiereYear = 1999,
            MaxViews = 10
        });

            modelBuilder.Entity<Theater>().HasData(
                new Theater { Id = 1, Name = "Salong 1", Capacity = 65 },
                new Theater { Id = 2, Name = "Salong 2", Capacity = 80 });
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Theater> Theaters { get; set; }
        public DbSet<Show> Shows { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}
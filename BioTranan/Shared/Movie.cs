using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Movie
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public string Title { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public Genre Genre { get; set; }

    [Required]
    public string ImageUrl { get; set; }

    [Required]
    public int Duration { get; set; }

    [Required]
    public string Language { get; set; }

    [Required]
    public int? AgeLimit { get; set; }

    [Required]
    public string Director { get; set; }

    [Required]
    public string Cast { get; set; }

    [Required]
    public int PremiereYear { get; set; }

    [Required]
    public int MaxViews { get; set; }

    public int ViewCount { get; set; }

    public Movie()
    {
    }

    public Movie(string title, string description, Genre genre, string imageUrl, int duration, string language, int ageLimit, string director, string cast, int premiereYear, int maxViews)
    {
        Title = title;
        Description = description;
        Genre = genre;
        ImageUrl = imageUrl;
        Duration = duration;
        Language = language;
        AgeLimit = ageLimit;
        Director = director;
        Cast = cast;
        PremiereYear = premiereYear;
        MaxViews = maxViews;
        ViewCount = 0;
    }
}

public enum Genre
{
    Action,
    Comedy,
    Drama,
    Fantasy,
    Horror,
    Romance,
    SciFi,
    Thriller
}
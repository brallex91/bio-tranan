using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BioTranan.Shared
{
    public class Show
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public DateTime ShowDateTime { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int AvalibleTickets { get; set; }

        [Required]
        public int TheaterId { get; set; }
        public Theater Theater { get; set; }

        [Required]
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public Show()
        {
        }

        public Show(DateTime showDateTime, decimal price, Theater theater, Movie movie)
        {
            ShowDateTime = showDateTime;
            Price = price;
            Theater = theater;
            Movie = movie;
            AvalibleTickets = theater.Capacity;
        }

        public DateTime Date
        {
            get { return ShowDateTime.Date; }
            set { ShowDateTime = new DateTime(value.Year, value.Month, value.Day, ShowDateTime.Hour, ShowDateTime.Minute, 0); }
        }

        public TimeSpan Time
        {
            get { return ShowDateTime.TimeOfDay; }
            set { ShowDateTime = ShowDateTime.Date + value; }
        }
    }
}
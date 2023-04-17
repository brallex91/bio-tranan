using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BioTranan.Shared
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string CustomerEmail { get; set; }

        [Required] public int NumberOfTickets { get; set; }

        [Required]
        public int ShowId { get; set; }
        public Show Show { get; set; }

        [Required]
        public string BookingCode { get; set; }

        public Booking()
        {

        }

        public Booking(string customerEmail, int numberOfTickets, Show show)
        {
            CustomerEmail = customerEmail;
            Show = show;
            NumberOfTickets = numberOfTickets;
            BookingCode = GenerateBookingCode();
        }

        public string GenerateBookingCode()
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 10)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
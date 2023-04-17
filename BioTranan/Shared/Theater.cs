using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BioTranan.Shared
{
    public class Theater
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public int Capacity { get; set; }

        public Theater()
        {
        }

        public Theater(int id, string? name, int capacity)
        {
            Id = id;
            Name = name;
            Capacity = capacity;
        }
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WildPaws.Infrastructure.Data
{
    public class Pet
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [StringLength(25)]
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0,25)]
        public int Age { get; set; }

        [Required]
        public int BreedId { get; set; }

        [ForeignKey(nameof(BreedId))]
        public Breed Breed { get; set; }

        [Required]
        public double Weight { get; set; }


    }
}

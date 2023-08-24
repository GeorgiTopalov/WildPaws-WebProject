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
        [Range(0,20)]
        public int Age { get; set; }

        [Required]
        public int BreedId { get; set; }

        [ForeignKey(nameof(BreedId))]
        public Breed Breed { get; set; }

        [Required]
        []
        public double Weight { get; set; }

        [StringLength(6)]
        [Required]
        public string Gender { get; set; }

        [Required]
        public bool IsSpayed { get; set; }

        [Required]
        public bool HasHealthIssues { get; set; }

        [Required]
        public string BodyStatus { get; set; }

        [Required]
        public string ActivityLevel { get; set; }

        [Required]
        public string CurrentFoodType { get; set; }
    }
}

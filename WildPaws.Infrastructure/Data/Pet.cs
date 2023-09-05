using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WildPaws.Infrastructure.Data.Identity;

namespace WildPaws.Infrastructure.Data
{
    public class Pet
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(25)]
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0,20)]
        public int Age { get; set; }

        [Required]
        public string Breed { get; set; }

        [Required]
        [Range(0.5, 65)]
        public double Weight { get; set; }

        [StringLength(6)]
        [Required]
        public string Gender { get; set; }

        [Required]
        public bool IsSpayed { get; set; }

        [Required]
        [StringLength(15)]
        public string BodyStatus { get; set; }

        [Required]
        [StringLength(15)]
        public string ActivityLevel { get; set; }

        [Required]
        [StringLength(15)]
        public string CurrentFoodType { get; set; }

        [Required]
        public bool HasHealthIssues { get; set; }

        [Required]
        [StringLength(25)]
        public string TreatsAndScraps { get; set; }


        [Required]
        [ForeignKey(nameof(WildPawsUserId))]
        public WildPawsUser WildPawsUser { get; set; }

        public string WildPawsUserId { get; set; }

        [StringLength(200)]
        public string? Comment { get; set; }

    }
}

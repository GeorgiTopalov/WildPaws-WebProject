using System.ComponentModel.DataAnnotations;

namespace WildPaws.Core.Models
{
    public class QuestionnaireViewModel
    {
        [Required]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string WildPawsUserId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Breed { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        [Range(0.5, 65)]
        public double Weight { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public bool IsSpayed { get; set; }

        [Required]
        public string BodyStatus { get; set; }

        [Required]
        public string ActivityLevel { get; set; }

        [Required]
        public string CurrentFoodType { get; set; }

        [Required]
        public string TreatsAndScraps { get; set; }

        [Required]
        public bool HasHealthIssues { get; set; }

        [StringLength(200)]
        public string? Comment { get; set; }
    }
}

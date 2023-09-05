using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WildPaws.Core.Models
{
    public class QuestionnaireViewModel
    {
        [Key]
        [BindNever]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "This field is required.")]
        [StringLength(25, ErrorMessage = "Name can't be more than 25 letters.")]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage = "Name must contain only letters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage = "Name must contain only letters.")]
        [StringLength(40, ErrorMessage = "Breed can't be more than 40 letters.")]

        public string Breed { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [Range(0.5, 65, ErrorMessage = "Weight can't be less than 0.5 or greater than 65")]
        [RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Weight must be a numeric value.")]
        public double Weight { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public bool IsSpayed { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public string BodyStatus { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public string ActivityLevel { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public string CurrentFoodType { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public string TreatsAndScraps { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public bool HasHealthIssues { get; set; }

        [StringLength(200)]
        public string? Comment { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace WildPaws.Infrastructure.Data
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string RecipeName { get; set; }

        [StringLength(250)]

        public string Description { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; }
    }
}

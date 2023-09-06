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


        public ICollection<Ingredient> Ingredients { get; set; } = new HashSet<Ingredient>();
    }
}

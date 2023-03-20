using System.ComponentModel.DataAnnotations;

namespace WildPaws.Infrastructure.Data
{
    public class Ingredient
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        public string Name { get; set; }
        public ICollection<Recipe> Recipes { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WildPaws.Infrastructure.Data
{
    public class RecipeIngredient
    {
        [Required]
        public int IngredientId { get; set; }

        [Required]
        public int RecipeId { get; set; }

        [ForeignKey(nameof(IngredientId))]
        public virtual Ingredient Ingredient { get; set; }

        [ForeignKey(nameof(RecipeId))]
        public virtual Recipe Recipe { get; set; }
    }
}

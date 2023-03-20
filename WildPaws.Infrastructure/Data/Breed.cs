using System.ComponentModel.DataAnnotations;

namespace WildPaws.Infrastructure.Data
{
    public class Breed
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string BreedName { get; set; }
    }
}

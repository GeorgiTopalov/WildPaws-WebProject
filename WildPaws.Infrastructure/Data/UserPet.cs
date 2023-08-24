using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WildPaws.Infrastructure.Data.Identity;

namespace WildPaws.Infrastructure.Data
{
    public class UserPet
    {
        [Required]
        public int WildPawsUserId { get; set; }

        [Required]
        public int PetId { get; set; }

        [ForeignKey(nameof(WildPawsUserId))]
        public virtual WildPawsUser WildPawsUser { get; set; }

        [ForeignKey(nameof(PetId))]
        public virtual Pet Pet { get; set; }
    }
}

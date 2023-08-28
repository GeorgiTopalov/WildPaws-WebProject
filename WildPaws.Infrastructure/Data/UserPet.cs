using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WildPaws.Infrastructure.Data.Identity;

namespace WildPaws.Infrastructure.Data
{
    public class UserPet
    {
        [Required]
        public string WildpawsUserId { get; set; }

        [Required]
        public Guid PetId { get; set; }

        [ForeignKey(nameof(WildpawsUserId))]
        public virtual WildPawsUser WildpawsUser { get; set; }

        [ForeignKey(nameof(PetId))]
        public virtual Pet Pet { get; set; }
    }
}

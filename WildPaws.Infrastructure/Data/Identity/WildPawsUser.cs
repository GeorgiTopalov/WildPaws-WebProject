using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WildPaws.Infrastructure.Data.Identity;

// Add profile data for application users by adding properties to the WildPawsUser class
public class WildPawsUser : IdentityUser
{
    [Required]
    public  string UserName { get; set; }

    [Required]
    public string Password { get; set; }
}


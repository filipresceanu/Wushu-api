using Microsoft.AspNetCore.Identity;

namespace Wushu_api.Models
{
    public class User:IdentityUser
    {
      public ICollection<Match>Matches { get; set; }

    }
}

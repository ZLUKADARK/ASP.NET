using Microsoft.AspNetCore.Identity;
namespace WebApplication1.DAL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public byte[] AvatarImage { get; set; }
    }

}
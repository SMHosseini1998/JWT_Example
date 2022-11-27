using Microsoft.AspNetCore.Identity;

namespace UserManger.Api.Model
{
    public class Role : IdentityRole<string>
    {
        public ICollection<UserRole> UserRoles { get; set; }
    }
}

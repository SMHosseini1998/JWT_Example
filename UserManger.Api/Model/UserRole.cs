using Microsoft.AspNetCore.Identity;

namespace UserManger.Api.Model
{
    public class UserRole : IdentityUserRole<string>
    {
        public User User { get; set; }
        public Role Role { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;

namespace UserManger.Api.Model
{
    public class User : IdentityUser<string>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public bool Locked { get; set; } = false;// true = locked

        public string? PhotoUrl { get; set; }//Nullable<string>
        public ICollection<UserRole> UserRoles { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;

namespace Library_Project.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public Guid MemberId { get; internal set; }
        public string RegistrationDay { get; internal set; }
    }
}

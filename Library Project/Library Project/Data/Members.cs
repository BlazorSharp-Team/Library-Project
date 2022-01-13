using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_Project.Data
{
    public class Members
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z''-']{1,40}$", ErrorMessage = "Karakter nem megengedett")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z''-']{1,40}$", ErrorMessage = "Karakter nem megengedett")]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        public Guid MemberId = Guid.NewGuid();

        public DateTime RegistrationDate = DateTime.Today;
    }
}

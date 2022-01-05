using System.ComponentModel.DataAnnotations;

namespace Library_Project.Data
{
    public class Members
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        public Guid MemberId = Guid.NewGuid();

        public DateTime RegistrationDate { get; set; }
    }
}

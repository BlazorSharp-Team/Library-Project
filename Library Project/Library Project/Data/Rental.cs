using System.ComponentModel.DataAnnotations;

namespace Library_Project.Data
{
    public class Rental
    {
        [Key]
        [Required]
        public int RentalID { get; set; }

        [Required]
        public string RentalMemberName { get; set; }

        [Required]
        public string RentalBookTitle { get; set; }

        public string RentalBookIsbn { get; set; }

        public DateTime RentalDate = DateTime.Today;

        public DateTime ReturnDate = DateTime.Today.AddDays(60);
    }
}

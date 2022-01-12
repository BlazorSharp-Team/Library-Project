using System.ComponentModel.DataAnnotations;

namespace Library_Project.Data
{
    public class Books
    {

        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
           
        [Required]
        public string isbnNumber { get; set; }

        public string Author { get; set; } 
        
        public string Publisher { get; set; }

        [Required]
        public string Category { get; set; }

        public string PublishDate { get; set; }

        [Required]
        public int Quantity { get; set; }

    }
}

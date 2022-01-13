using Library_Project.Data;

namespace Library_Project.Services
{
    public class BookService
    {
        private AppDbContext AppDbContext { get; set; }
        public BookService(AppDbContext _appDbContext)
        {
            AppDbContext = _appDbContext;
        }

        public List<Books> GetAllBooks()
        {
            return AppDbContext.Books.ToList();
        }
    }
}

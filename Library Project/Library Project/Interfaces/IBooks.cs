using Library_Project.Data;

namespace Library_Project.Interfaces
{
    public interface IBooks
    {
        public List<Books> GetBookDetails();
        public void AddBook(Books book);
        public void UpdateBookDetails(Books book);
        public Books GetBookData(int id);
        public void DeleteBook(int id);
    }
}

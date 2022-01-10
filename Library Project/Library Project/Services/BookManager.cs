using Library_Project.Interfaces;
using Library_Project.Data;
using Microsoft.EntityFrameworkCore;

namespace Library_Project.Services
{
    public class BookManager : IBooks
    {
        readonly AppDbContext _dbContext = new();
        public BookManager(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //To Get all book details
        public List<Books> GetBookDetails()
        {
            try
            {
                return _dbContext.Books.ToList();
            }
            catch
            {
                throw;
            }
        }
        //To Add new book record
        public void AddBook(Books book)
        {
            try
            {
                _dbContext.Books.Add(book);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        //To Update the records of a particluar book
        public void UpdateBookDetails(Books book)
        {
            try
            {
                _dbContext.Entry(book).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        //Get the details of a particular book
        public Books GetBookData(int id)
        {
            try
            {
                Books? book = _dbContext.Books.Find(id);
                if (book != null)
                {
                    return book;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }
        //To Delete the record of a particular book
        public void DeleteBook(int id)
        {
            try
            {
                Books? book = _dbContext.Books.Find(id);
                if (book != null)
                {
                    _dbContext.Books.Remove(book);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}

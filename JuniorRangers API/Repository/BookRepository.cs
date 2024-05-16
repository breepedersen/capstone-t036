using JuniorRangers_API.Data;
using JuniorRangers_API.Interfaces;
using JuniorRangers_API.Models;

namespace JuniorRangers_API.Repository
{
    public class BookRepository : IBookRepository
    {
        private DataContext _context;

        public BookRepository(DataContext context) {
            _context = context;
        }
        
        public bool BookExists(int bookId)
        {
            return _context.Books.Any(b => b.BookId == bookId);
        }

        public bool CreateBook(Book book)
        {
            _context.Add(book);
            return Save();
        }

        public bool DeleteBook(Book book)
        {
            _context.Remove(book);
            return Save();
        }

        public Book GetBook(int bookId)
        {
            return _context.Books.Where(b => b.BookId == bookId).FirstOrDefault();
        }

        public ICollection<Book> GetBooks()
        {
            return _context.Books.OrderBy(b => b.BookId).ToList();
        }

        public ICollection<Book> GetBooksByClass(int classId)
        {
            return _context.Books.Where(b => b.Classroom.ClassId == classId).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateBook(Book book)
        {
            _context.Update(book);
            return Save();
        }
    }
}

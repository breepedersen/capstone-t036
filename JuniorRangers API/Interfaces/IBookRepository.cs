using JuniorRangers_API.Models;

namespace JuniorRangers_API.Interfaces
{
    public interface IBookRepository
    {
        ICollection<Book> GetBooks();
        ICollection<Book> GetBooksByClass(int classId);
        Book GetBook(int bookId);
        bool BookExists(int bookId);
        bool CreateBook(Book book);
        bool UpdateBook(Book book);
        bool DeleteBook(Book book);
        bool Save();
    }
}

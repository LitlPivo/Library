using BookStore.Core.Models;

namespace BookStore.Aplication.Services
{
    public interface IBooksServices
    {
        Task<Guid> CreateBook(Book book);
        Task<Guid> DeleteBook(Guid id);
        Task<List<Book>> GetAllBooks();
        Task<Guid> UpdateBook(Guid id, string title, string description, string author, decimal price);
    }
}
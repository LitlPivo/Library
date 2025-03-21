using BookStore.Core.Models;
using bookStore.DataAcess.Repository;

namespace BookStore.Aplication.Services
{
    public class BooksServices : IBooksServices
    {
        private readonly IBookReposytory _bookReposytory;

        public BooksServices(IBookReposytory bookReposytory)
        {
            _bookReposytory = bookReposytory;
        }

        public async Task<List<Book>> GetAllBooks()
        {
            return await _bookReposytory.Get();
        }

        public async Task<Guid> CreateBook(Book book)
        {
            return await _bookReposytory.Create(book);
        }

        public async Task<Guid> UpdateBook(Guid id, string title, string description, string author, decimal price)
        {
            return await _bookReposytory.Update(id, title, description, author, price);
        }

        public async Task<Guid> DeleteBook(Guid id)
        {
            return await _bookReposytory.Delete(id);
        }
    }
}

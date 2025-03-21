using Microsoft.EntityFrameworkCore;
using BookStore.Core.Models;
using bookStore.DataAcess.Entities;
namespace bookStore.DataAcess.Repository
{
    public class BookReposytory : IBookReposytory
    {
        private readonly BookStoreDbContext _context;

        public BookReposytory(BookStoreDbContext context)
        {
            _context = context;
        }
        public async Task<List<Book>> Get()
        {
            var bookEntityes = await _context.Book
                .AsNoTracking()
                .ToListAsync();
            var books = bookEntityes
                .Select(b => Book.Create(b.Id, b.Title, b.Description, b.Author, b.Price).Book)
                .ToList();

            return books;
        }
        public async Task<Guid> Create(Book book)
        {
            var bookEntity = new BookEntity
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                Author = book.Author,
                Price = book.Price
            };
            await _context.Book.AddAsync(bookEntity);
            await _context.SaveChangesAsync();

            return bookEntity.Id;
        }

        public async Task<Guid> Update(Guid id, string title, string description, string author, decimal price)
        {
            await _context.Book
                .Where(b => b.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(b => b.Title, b => title)
                    .SetProperty(b => b.Description, b => description)
                    .SetProperty(b => b.Author, b => author)
                    .SetProperty(b => b.Price, b => price)
                    );
            return id;
        }
        public async Task<Guid> Delete(Guid id)
        {
            await _context.Book
                .Where(b => b.Id == id)
                .ExecuteDeleteAsync();
            return id;
        }
    }
}

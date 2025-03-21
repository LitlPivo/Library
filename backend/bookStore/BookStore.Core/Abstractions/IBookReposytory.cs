using BookStore.Core.Models;

namespace bookStore.DataAcess.Repository
{
    public interface IBookReposytory
    {
        Task<Guid> Create(Book book);
        Task<Guid> Delete(Guid id);
        Task<List<Book>> Get();
        Task<Guid> Update(Guid id, string title, string description, string author, decimal price);
    }
}
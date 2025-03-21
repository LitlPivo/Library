namespace bookStore.API.Contracts
{
    public record BooksResponce(Guid Id, string Title, string Description, string Author, decimal price);
}

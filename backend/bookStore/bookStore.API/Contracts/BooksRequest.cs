namespace bookStore.API.Contracts
{
    public record BooksRequest(string Title, string Description, string Author, decimal price);
}

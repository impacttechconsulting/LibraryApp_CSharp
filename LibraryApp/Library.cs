namespace LibraryApp;

public class Library
{
    private List<Book> books = new List<Book>();

    public void AddBook(Book book)
    {
        books.Add(book);
        Console.WriteLine($"Added book: {book}");
    }

    public bool RemoveBook(string isbn)
    {
        var book = books.FirstOrDefault(b => b.ISBN == isbn);
        if (book != null)
        {
            books.Remove(book);
            Console.WriteLine($"Removed book: {book}");
            return true;
        }
        Console.WriteLine($"Book with ISBN {isbn} not found.");
        return false;
    }

    public List<Book> SearchByTitle(string title)
    {
        return books.Where(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public List<Book> SearchByAuthor(string author)
    {
        return books.Where(b => b.Author.Contains(author, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public List<Book> GetAllBooks()
    {
        return new List<Book>(books);
    }

    public int Count => books.Count;
}

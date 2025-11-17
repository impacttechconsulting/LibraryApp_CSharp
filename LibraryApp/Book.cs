namespace LibraryApp;

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public int Year { get; set; }

    public Book(string title, string author, string isbn, int year)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
        Year = year;
    }

    public override string ToString()
    {
        return $"'{Title}' by {Author} (ISBN: {ISBN}, Year: {Year})";
    }
}

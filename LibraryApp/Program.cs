using LibraryApp;

Console.WriteLine("=== Library Management System ===\n");

var library = new Library();

// Add some sample books
library.AddBook(new Book("The Great Gatsby", "F. Scott Fitzgerald", "978-0743273565", 1925));
library.AddBook(new Book("To Kill a Mockingbird", "Harper Lee", "978-0061120084", 1960));
library.AddBook(new Book("1984", "George Orwell", "978-0451524935", 1949));
library.AddBook(new Book("Pride and Prejudice", "Jane Austen", "978-0141439518", 1813));

Console.WriteLine($"\nTotal books in library: {library.Count}");

// Display all books
Console.WriteLine("\n--- All Books in Library ---");
foreach (var book in library.GetAllBooks())
{
    Console.WriteLine(book);
}

// Search by author
Console.WriteLine("\n--- Searching for books by 'Orwell' ---");
var orwellBooks = library.SearchByAuthor("Orwell");
foreach (var book in orwellBooks)
{
    Console.WriteLine(book);
}

// Search by title
Console.WriteLine("\n--- Searching for books with 'Great' in title ---");
var greatBooks = library.SearchByTitle("Great");
foreach (var book in greatBooks)
{
    Console.WriteLine(book);
}

// Remove a book
Console.WriteLine("\n--- Removing a book ---");
library.RemoveBook("978-0451524935");

Console.WriteLine($"\nTotal books in library: {library.Count}");

Console.WriteLine("\n--- All Books in Library (after removal) ---");
foreach (var book in library.GetAllBooks())
{
    Console.WriteLine(book);
}

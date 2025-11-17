namespace LibraryApp.Tests;

public class LibraryTests
{
    [Fact]
    public void AddBook_ShouldIncreaseCount()
    {
        // Arrange
        var library = new Library();
        var book = new Book("Test Book", "Test Author", "123-456", 2024);

        // Act
        library.AddBook(book);

        // Assert
        Assert.Equal(1, library.Count);
    }

    [Fact]
    public void RemoveBook_WithValidISBN_ShouldReturnTrue()
    {
        // Arrange
        var library = new Library();
        var book = new Book("Test Book", "Test Author", "123-456", 2024);
        library.AddBook(book);

        // Act
        var result = library.RemoveBook("123-456");

        // Assert
        Assert.True(result);
        Assert.Equal(0, library.Count);
    }

    [Fact]
    public void RemoveBook_WithInvalidISBN_ShouldReturnFalse()
    {
        // Arrange
        var library = new Library();

        // Act
        var result = library.RemoveBook("999-999");

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void SearchByTitle_ShouldReturnMatchingBooks()
    {
        // Arrange
        var library = new Library();
        library.AddBook(new Book("The Great Adventure", "Author A", "111-111", 2020));
        library.AddBook(new Book("Great Expectations", "Author B", "222-222", 2021));
        library.AddBook(new Book("Another Book", "Author C", "333-333", 2022));

        // Act
        var results = library.SearchByTitle("Great");

        // Assert
        Assert.Equal(2, results.Count);
    }

    [Fact]
    public void SearchByAuthor_ShouldReturnMatchingBooks()
    {
        // Arrange
        var library = new Library();
        library.AddBook(new Book("Book 1", "John Smith", "111-111", 2020));
        library.AddBook(new Book("Book 2", "Jane Smith", "222-222", 2021));
        library.AddBook(new Book("Book 3", "Bob Johnson", "333-333", 2022));

        // Act
        var results = library.SearchByAuthor("Smith");

        // Assert
        Assert.Equal(2, results.Count);
    }

    [Fact]
    public void GetAllBooks_ShouldReturnAllBooks()
    {
        // Arrange
        var library = new Library();
        library.AddBook(new Book("Book 1", "Author 1", "111-111", 2020));
        library.AddBook(new Book("Book 2", "Author 2", "222-222", 2021));

        // Act
        var allBooks = library.GetAllBooks();

        // Assert
        Assert.Equal(2, allBooks.Count);
    }
}

public class BookTests
{
    [Fact]
    public void Book_ShouldInitializeProperties()
    {
        // Arrange & Act
        var book = new Book("Test Title", "Test Author", "123-456", 2024);

        // Assert
        Assert.Equal("Test Title", book.Title);
        Assert.Equal("Test Author", book.Author);
        Assert.Equal("123-456", book.ISBN);
        Assert.Equal(2024, book.Year);
    }

    [Fact]
    public void Book_ToString_ShouldReturnFormattedString()
    {
        // Arrange
        var book = new Book("Test Title", "Test Author", "123-456", 2024);

        // Act
        var result = book.ToString();

        // Assert
        Assert.Contains("Test Title", result);
        Assert.Contains("Test Author", result);
        Assert.Contains("123-456", result);
        Assert.Contains("2024", result);
    }
}
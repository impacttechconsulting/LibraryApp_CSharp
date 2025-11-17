# LibraryApp_CSharp

A sample C# console application demonstrating a simple Library Management System.

## Features

- **Add Books**: Add new books to the library with title, author, ISBN, and publication year
- **Remove Books**: Remove books from the library by ISBN
- **Search Books**: Search for books by title or author
- **List Books**: View all books in the library

## Project Structure

- `LibraryApp/` - Main console application
  - `Book.cs` - Book class with properties
  - `Library.cs` - Library class for managing book collections
  - `Program.cs` - Console interface with sample usage
- `LibraryApp.Tests/` - Unit tests using xUnit

## Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download) or later

## Building the Application

```bash
dotnet build LibraryApp.sln
```

## Running the Application

```bash
dotnet run --project LibraryApp/LibraryApp.csproj
```

## Running Tests

```bash
dotnet test LibraryApp.sln
```

## Example Output

The application demonstrates:
- Adding sample books to the library
- Displaying all books
- Searching for books by author
- Searching for books by title
- Removing a book from the library
- Displaying the updated collection

## License

This is a sample application for educational purposes.

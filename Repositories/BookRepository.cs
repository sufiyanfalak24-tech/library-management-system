using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Repositories
{
    public class BookRepository
    {
        private string filePath;

        // Constructor
        public BookRepository()
        {
            string folderPath = Path.Combine(
                Directory.GetCurrentDirectory(), "Data");

            Directory.CreateDirectory(folderPath);

            filePath = Path.Combine(folderPath, "books.txt");

            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
        }

        // Add book to file
        public void AddBook(Book book)
        {
            string record = book.BookId + "|" +
                            book.Title + "|" +
                            book.Author + "|" +
                            book.Category + "|" +
                            book.IsAvailable;

            File.AppendAllText(filePath, record + Environment.NewLine);
        }

        // Read all books from file
        public List<Book> GetAllBooks()
        {
            List<Book> books = new List<Book>();

            string[] records = File.ReadAllLines(filePath);

            foreach (string record in records)
            {
                string[] data = record.Split('|');

                if (data.Length == 5)
                {
                    Book book = new Book(
                        int.Parse(data[0]),
                        data[1],
                        data[2],
                        data[3],
                        bool.Parse(data[4])
                    );

                    books.Add(book);
                }
            }

            return books;
        }

        // Find book by ID
        public Book GetBookById(int id)
        {
            List<Book> books = GetAllBooks();

            foreach (Book book in books)
            {
                if (book.BookId == id)
                {
                    return book;
                }
            }

            return null;
        }

        // Update book availability
        public void UpdateBookAvailability(int id, bool availability)
        {
            List<Book> books = GetAllBooks();

            foreach (Book book in books)
            {
                if (book.BookId == id)
                {
                    book.IsAvailable = availability;
                }
            }

            string[] records = new string[books.Count];

            for (int i = 0; i < books.Count; i++)
            {
                records[i] = books[i].BookId + "|" +
                             books[i].Title + "|" +
                             books[i].Author + "|" +
                             books[i].Category + "|" +
                             books[i].IsAvailable;
            }

            File.WriteAllLines(filePath, records);
        }
    }
}

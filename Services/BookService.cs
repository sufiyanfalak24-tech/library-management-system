using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories;

namespace LibraryManagementSystem.Services
{
    public class BookService
    {
        private BookRepository bookRepository;

        public BookService()
        {
            bookRepository = new BookRepository();
        }

        // Add a new book
        public string AddBook(Book book)
        {
            Book existingBook = bookRepository.GetBookById(book.BookId);

            if (existingBook != null)
            {
                return "Book ID already exists!";
            }

            bookRepository.AddBook(book);

            return "Book added successfully!";
        }

        // Get all books
        public List<Book> GetAllBooks()
        {
            return bookRepository.GetAllBooks();
        }

        // Search book by ID
        public Book SearchBook(int id)
        {
            return bookRepository.GetBookById(id);
        }

        // Get available books
        public List<Book> GetAvailableBooks()
        {
            List<Book> allBooks = bookRepository.GetAllBooks();

            List<Book> availableBooks = new List<Book>();

            foreach (Book book in allBooks)
            {
                if (book.IsAvailable == true)
                {
                    availableBooks.Add(book);
                }
            }

            return availableBooks;
        }
    }
}

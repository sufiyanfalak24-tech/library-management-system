using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LibraryManagementSystem.Models
{
    public class Book
    {
        // Attributes
        public int BookId;
        public string Title;
        public string Author;
        public string Category;
        public bool IsAvailable;

        // Constructor
        public Book(int id, string title, string author,
                    string category, bool available)
        {
            BookId = id;
            Title = title;
            Author = author;
            Category = category;
            IsAvailable = available;
        }

        // Behaviour
        public override string ToString()
        {
            return "Book ID: " + BookId +
                   "\nTitle: " + Title +
                   "\nAuthor: " + Author +
                   "\nCategory: " + Category +
                   "\nAvailable: " + IsAvailable;
        }
    }
}

using System;
using System.Collections.Generic;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services;

namespace LibraryManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            BookService bookService = new BookService();
            MemberService memberService = new MemberService();
            IssueService issueService = new IssueService();

            Console.WriteLine("================================");
            Console.WriteLine("   LIBRARY MANAGEMENT SYSTEM");
            Console.WriteLine("================================");

            Console.WriteLine("Services initialized successfully!");
            
            int choice = -1;

            while (choice != 0)
            {
                Console.Clear();

                Console.WriteLine("================================");
                Console.WriteLine("    LIBRARY MANAGEMENT SYSTEM");
                Console.WriteLine("================================");

                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. View All Books");
                Console.WriteLine("3. Search Book");
                Console.WriteLine("4. View Available Books");
                Console.WriteLine("5. Register Member");
                Console.WriteLine("6. View All Members");
                Console.WriteLine("7. Search Member");
                Console.WriteLine("8. Issue Book");
                Console.WriteLine("9. Return Book");
                Console.WriteLine("10. View All Issue Records");
                Console.WriteLine("11. View Member's Issued Books");
                Console.WriteLine("0. Exit");

                Console.WriteLine("--------------------------------");
                Console.Write("Enter your choice: ");

                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Add Book selected");
                        AddBook(bookService);
                        break;

                    case 2:
                        Console.WriteLine("View All Books selected");
                        ViewAllBooks(bookService);
                        break;

                    case 3:
                        Console.WriteLine("Search Book selected");
                        SearchBook(bookService);
                        break;

                    case 4:
                        Console.WriteLine("View Available Books selected");
                        ViewAvailableBooks(bookService);
                        break;

                    case 5:
                        Console.WriteLine("Register Member selected");
                        RegisterMember(memberService);
                        break;

                    case 6:
                        Console.WriteLine("View All Members selected");
                        ViewAllMembers(memberService);
                        break;

                    case 7:
                        Console.WriteLine("Search Member selected");
                        SearchMember(memberService);
                        break;

                    case 8:
                        Console.WriteLine("Issue Book selected");
                        IssueBook(issueService);
                        break;

                    case 9:
                        Console.WriteLine("Return Book selected");
                        ReturnBook(issueService);
                        break;

                    case 10:
                        Console.WriteLine("View All Issue Records selected");
                        ViewAllIssues(issueService);
                        break;

                    case 11:
                        Console.WriteLine("View Member's Issued Books selected");
                        ViewMemberIssuedBooks(issueService);
                        break;

                    case 0:
                        Console.WriteLine("Thank you for using the Library System!");
                        break;

                    default:
                        Console.WriteLine("Invalid choice! Try again.");
                        break;
                }

                if (choice != 0)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        static void AddBook(BookService bookService)
        {
            Console.Clear();

            Console.WriteLine("========== ADD NEW BOOK ==========");

            Console.Write("Enter Book ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter Book Title: ");
            string title = Console.ReadLine();

            Console.Write("Enter Author Name: ");
            string author = Console.ReadLine();

            Console.Write("Enter Category: ");
            string category = Console.ReadLine();

            Book book = new Book(id, title, author, category, true);

            string result = bookService.AddBook(book);

            Console.WriteLine("\n" + result);
        }

        static void ViewAllBooks(BookService bookService)
        {
            Console.Clear();

            Console.WriteLine("========== ALL BOOKS ==========");

            List<Book> books = bookService.GetAllBooks();

            if (books.Count == 0)
            {
                Console.WriteLine("No books found!");
            }
            else
            {
                foreach (Book book in books)
                {
                    Console.WriteLine(book);
                    Console.WriteLine("------------------------------");
                }
            }
        }

        static void SearchBook(BookService bookService)
        {
            Console.Clear();

            Console.WriteLine("========== SEARCH BOOK ==========");

            Console.Write("Enter Book ID: ");
            int id = int.Parse(Console.ReadLine());

            Book book = bookService.SearchBook(id);

            if (book == null)
            {
                Console.WriteLine("Book not found!");
            }
            else
            {
                Console.WriteLine("\nBook Found!");
                Console.WriteLine(book);
            }
        }

        static void ViewAvailableBooks(BookService bookService)
        {
            Console.Clear();

            Console.WriteLine("========== AVAILABLE BOOKS ==========");

            List<Book> books = bookService.GetAvailableBooks();

            if (books.Count == 0)
            {
                Console.WriteLine("No available books found!");
            }
            else
            {
                foreach (Book book in books)
                {
                    Console.WriteLine(book);
                    Console.WriteLine("------------------------------");
                }
            }
        }

        static void RegisterMember(MemberService memberService)
        {
            Console.Clear();

            Console.WriteLine("========== REGISTER MEMBER ==========");

            Console.Write("Enter Member ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter Member Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Phone Number: ");
            string phone = Console.ReadLine();

            Console.Write("Enter Email: ");
            string email = Console.ReadLine();

            Member member = new Member(id, name, phone, email);

            string result = memberService.AddMember(member);

            Console.WriteLine("\n" + result);
        }

        static void ViewAllMembers(MemberService memberService)
        {
            Console.Clear();

            Console.WriteLine("========== ALL MEMBERS ==========");

            List<Member> members = memberService.GetAllMembers();

            if (members.Count == 0)
            {
                Console.WriteLine("No members found!");
            }
            else
            {
                foreach (Member member in members)
                {
                    Console.WriteLine(member);
                    Console.WriteLine("------------------------------");
                }
            }
        }

        static void SearchMember(MemberService memberService)
        {
            Console.Clear();

            Console.WriteLine("========== SEARCH MEMBER ==========");

            Console.Write("Enter Member ID: ");
            int id = int.Parse(Console.ReadLine());

            Member member = memberService.SearchMember(id);

            if (member == null)
            {
                Console.WriteLine("Member not found!");
            }
            else
            {
                Console.WriteLine("\nMember Found!");
                Console.WriteLine(member);
            }
        }

        static void IssueBook(IssueService issueService)
        {
            Console.Clear();

            Console.WriteLine("========== ISSUE BOOK ==========");

            Console.Write("Enter Issue ID: ");
            int issueId = int.Parse(Console.ReadLine());

            Console.Write("Enter Book ID: ");
            int bookId = int.Parse(Console.ReadLine());

            Console.Write("Enter Member ID: ");
            int memberId = int.Parse(Console.ReadLine());

            string result = issueService.IssueBook(bookId, memberId, issueId);

            Console.WriteLine("\n" + result);
        }

        static void ReturnBook(IssueService issueService)
        {
            Console.Clear();

            Console.WriteLine("========== RETURN BOOK ==========");

            Console.Write("Enter Issue ID: ");
            int issueId = int.Parse(Console.ReadLine());

            string result = issueService.ReturnBook(issueId);

            Console.WriteLine("\n" + result);
        }

        static void ViewAllIssues(IssueService issueService)
        {
            Console.Clear();

            Console.WriteLine("========== ALL ISSUE RECORDS ==========");

            List<IssueRecord> issues = issueService.GetAllIssues();

            if (issues.Count == 0)
            {
                Console.WriteLine("No issue records found!");
            }
            else
            {
                foreach (IssueRecord issue in issues)
                {
                    Console.WriteLine(issue);
                    Console.WriteLine("--------------------------------");
                }
            }
        }

        static void ViewMemberIssuedBooks(IssueService issueService)
        {
            Console.Clear();

            Console.WriteLine("========== MEMBER'S ISSUED BOOKS ==========");

            Console.Write("Enter Member ID: ");
            int memberId = int.Parse(Console.ReadLine());

            List<Book> books = issueService.GetMemberIssuedBooks(memberId);

            if (books.Count == 0)
            {
                Console.WriteLine("This member has no issued books!");
            }
            else
            {
                foreach (Book book in books)
                {
                    Console.WriteLine(book);
                    Console.WriteLine("------------------------------");
                }
            }
        }
    }
}

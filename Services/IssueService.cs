using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories;

namespace LibraryManagementSystem.Services
{
    public class IssueService
    {
        private BookRepository bookRepository;
        private MemberRepository memberRepository;
        private IssueRepository issueRepository;

        public IssueService()
        {
            bookRepository = new BookRepository();
            memberRepository = new MemberRepository();
            issueRepository = new IssueRepository();
        }

        // Issue a book
        public string IssueBook(int bookId, int memberId, int issueId)
        {
            Book book = bookRepository.GetBookById(bookId);

            if (book == null)
            {
                return "Book does not exist!";
            }

            Member member = memberRepository.GetMemberById(memberId);

            if (member == null)
            {
                return "Member does not exist!";
            }

            if (book.IsAvailable == false)
            {
                return "Book is already issued!";
            }

            IssueRecord existingIssue = issueRepository.GetIssueById(issueId);

            if (existingIssue != null)
            {
                return "Issue ID already exists!";
            }

            IssueRecord issue = new IssueRecord(
                issueId,
                bookId,
                memberId,
                DateTime.Now.ToShortDateString()
            );

            issueRepository.AddIssue(issue);

            bookRepository.UpdateBookAvailability(bookId, false);

            return "Book issued successfully!";
        }

        // Return a book
        public string ReturnBook(int issueId)
        {
            IssueRecord issue = issueRepository.GetIssueById(issueId);

            if (issue == null)
            {
                return "Issue record does not exist!";
            }

            if (issue.IsReturned == true)
            {
                return "Book has already been returned!";
            }

            string returnDate = DateTime.Now.ToShortDateString();

            issueRepository.UpdateIssueReturn(issueId, returnDate);

            bookRepository.UpdateBookAvailability(issue.BookId, true);

            return "Book returned successfully!";
        }

        // Get all issue records
        public List<IssueRecord> GetAllIssues()
        {
            return issueRepository.GetAllIssues();
        }

        // Get books issued to a member
        public List<Book> GetMemberIssuedBooks(int memberId)
        {
            List<Book> issuedBooks = new List<Book>();

            List<IssueRecord> allIssues = issueRepository.GetAllIssues();

            foreach (IssueRecord issue in allIssues)
            {
                if (issue.MemberId == memberId && issue.IsReturned == false)
                {
                    Book book = bookRepository.GetBookById(issue.BookId);

                    if (book != null)
                    {
                        issuedBooks.Add(book);
                    }
                }
            }

            return issuedBooks;
        }
    }
}

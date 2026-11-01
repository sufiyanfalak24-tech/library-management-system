using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LibraryManagementSystem.Models
{
    public class IssueRecord
    {
        // Attributes
        public int IssueId;
        public int BookId;
        public int MemberId;
        public string IssueDate;
        public string ReturnDate;
        public bool IsReturned;

        // Constructor
        public IssueRecord(int issueId, int bookId,
                           int memberId, string issueDate)
        {
            IssueId = issueId;
            BookId = bookId;
            MemberId = memberId;
            IssueDate = issueDate;
            ReturnDate = "Not Returned";
            IsReturned = false;
        }

        // Behaviour
        public override string ToString()
        {
            return "Issue ID: " + IssueId +
                   "\nBook ID: " + BookId +
                   "\nMember ID: " + MemberId +
                   "\nIssue Date: " + IssueDate +
                   "\nReturn Date: " + ReturnDate +
                   "\nReturned: " + IsReturned;
        }
    }
}


using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Repositories
{
    public class IssueRepository
    {
        private string filePath;

        public IssueRepository()
        {
            string folderPath = "Data";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            filePath = folderPath + "/issues.txt";

            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
        }

        // Add a new issue record
        public void AddIssue(IssueRecord issue)
        {
            string record = issue.IssueId + "|" +
                            issue.BookId + "|" +
                            issue.MemberId + "|" +
                            issue.IssueDate + "|" +
                            issue.ReturnDate + "|" +
                            issue.IsReturned;

            File.AppendAllText(filePath, record + Environment.NewLine);
        }

        // Get all issue records
        public List<IssueRecord> GetAllIssues()
        {
            List<IssueRecord> issues = new List<IssueRecord>();

            string[] records = File.ReadAllLines(filePath);

            foreach (string record in records)
            {
                string[] data = record.Split('|');

                if (data.Length == 6)
                {
                    IssueRecord issue = new IssueRecord(
                        int.Parse(data[0]),
                        int.Parse(data[1]),
                        int.Parse(data[2]),
                        data[3]
                    );

                    issue.ReturnDate = data[4];
                    issue.IsReturned = bool.Parse(data[5]);

                    issues.Add(issue);
                }
            }

            return issues;
        }

        // Search issue by ID
        public IssueRecord GetIssueById(int id)
        {
            List<IssueRecord> issues = GetAllIssues();

            foreach (IssueRecord issue in issues)
            {
                if (issue.IssueId == id)
                {
                    return issue;
                }
            }

            return null;
        }

        // Update issue when a book is returned
        public void UpdateIssueReturn(int id, string returnDate)
        {
            List<IssueRecord> issues = GetAllIssues();

            foreach (IssueRecord issue in issues)
            {
                if (issue.IssueId == id)
                {
                    issue.ReturnDate = returnDate;
                    issue.IsReturned = true;
                }
            }

            string[] records = new string[issues.Count];

            for (int i = 0; i < issues.Count; i++)
            {
                records[i] = issues[i].IssueId + "|" +
                             issues[i].BookId + "|" +
                             issues[i].MemberId + "|" +
                             issues[i].IssueDate + "|" +
                             issues[i].ReturnDate + "|" +
                             issues[i].IsReturned;
            }

            File.WriteAllLines(filePath, records);
        }
    }
}
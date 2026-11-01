using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Repositories
{
    public class MemberRepository
    {
        private string filePath;

        public MemberRepository()
        {
            string folderPath = "Data";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            filePath = folderPath + "/members.txt";

            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
        }

        // Add a new member
        public void AddMember(Member member)
        {
            string record = member.MemberId + "|" +
                            member.Name + "|" +
                            member.PhoneNumber + "|" +
                            member.Email;

            File.AppendAllText(filePath, record + Environment.NewLine);
        }

        // Get all members
        public List<Member> GetAllMembers()
        {
            List<Member> members = new List<Member>();

            string[] records = File.ReadAllLines(filePath);

            foreach (string record in records)
            {
                string[] data = record.Split('|');

                if (data.Length == 4)
                {
                    Member member = new Member(
                        int.Parse(data[0]),
                        data[1],
                        data[2],
                        data[3]
                    );

                    members.Add(member);
                }
            }

            return members;
        }

        // Search member by ID
        public Member GetMemberById(int id)
        {
            List<Member> members = GetAllMembers();

            foreach (Member member in members)
            {
                if (member.MemberId == id)
                {
                    return member;
                }
            }

            return null;
        }
    }
}


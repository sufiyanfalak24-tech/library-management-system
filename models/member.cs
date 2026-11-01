using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace LibraryManagementSystem.Models
{
    public class Member
    {
        // Attributes
        public int MemberId;
        public string Name;
        public string PhoneNumber;
        public string Email;

        // Constructor
        public Member(int id, string name,
                      string phone, string email)
        {
            MemberId = id;
            Name = name;
            PhoneNumber = phone;
            Email = email;
        }

        // Behaviour
        public override string ToString()
        {
            return "Member ID: " + MemberId +
                   "\nName: " + Name +
                   "\nPhone: " + PhoneNumber +
                   "\nEmail: " + Email;
        }
    }
}

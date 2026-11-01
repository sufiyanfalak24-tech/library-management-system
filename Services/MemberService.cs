using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories;

namespace LibraryManagementSystem.Services
{
    public class MemberService
    {
        private MemberRepository memberRepository;

        public MemberService()
        {
            memberRepository = new MemberRepository();
        }

        // Register a new member
        public string AddMember(Member member)
        {
            Member existingMember =
                memberRepository.GetMemberById(member.MemberId);

            if (existingMember != null)
            {
                return "Member ID already exists!";
            }

            memberRepository.AddMember(member);

            return "Member registered successfully!";
        }

        // Get all members
        public List<Member> GetAllMembers()
        {
            return memberRepository.GetAllMembers();
        }

        // Search member by ID
        public Member SearchMember(int id)
        {
            return memberRepository.GetMemberById(id);
        }
    }
}

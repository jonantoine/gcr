﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCR.Core.Entities;
using GCR.Core.Repositories;
using GCR.Core.Services;

namespace GCR.Business.Services
{
    public class MemberService : IMemberService
    {
        private IMemberRepository memberRepository;

        public MemberService(IMemberRepository repo)
        {
            memberRepository = repo;
        }

        public IEnumerable<Member> Fetch 
        { 
            get 
            { 
                return memberRepository.Query;
            }
        }

        public Member GetById(int id)
        {
            return memberRepository.Query.SingleOrDefault(a => a.MemberId == id);
        }

        public void SaveMember(Member member)
        {
            if (member.MemberId == 0)
            {
                memberRepository.Create(member);
            }
            else
            {
                memberRepository.Update(member);
            }

            memberRepository.SaveChanges();
        }

        public void DeleteMember(Member member)
        {
            memberRepository.Delete(member);
            memberRepository.SaveChanges();
        }
    }
}
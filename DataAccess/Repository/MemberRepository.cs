using BusinessObject.DataAccess;
using System.Collections.Generic;

namespace DataAccess.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        public Member Login(string email, string password) => MemberDAO.Instance.Login(email, password);

    }
}

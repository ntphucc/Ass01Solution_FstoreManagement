using BusinessObject.DataAccess;
using System.Collections.Generic;

namespace DataAccess.Repositories
{
    public interface IMemberRepository
    {
        public Member Login(string email, string password);
    }
}

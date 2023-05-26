using BusinessObject.DataAccess;
using System.Linq;

namespace DataAccess
{
    public class MemberDAO
    {
        private static MemberDAO instance = null;
        private static readonly object instanceLock = new object();

        private MemberDAO()
        {
        }

        public static MemberDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null) instance = new MemberDAO();
                    return instance;
                }
            }
        }

        public Member Login(string email, string password)
        {
            using (var context = new FstoreContext())
            {
                return context.Members.FirstOrDefault(c => c.Email.Equals(email) && c.Password.Equals(password));
            }
        }
    }
}

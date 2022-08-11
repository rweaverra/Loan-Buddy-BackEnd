using Loan_Buddy_Api.Data;
using System.Data.Entity;

namespace Loan_Buddy_Api
{
    internal static class UsersRepository
    {
        internal static async Task<List<Users>> GetUsers()
        {
            using(var db = new AppDBContext())
            {
                return await db.Users.ToListAsync();
            }
        }
    }
}

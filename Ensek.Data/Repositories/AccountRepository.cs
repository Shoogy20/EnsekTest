using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ensek.Domain;

namespace Ensek.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly EnsekContext _context;
        public AccountRepository(EnsekContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Returns all accounts from the db
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Account> GetAll()
        {
            return _context.Accounts.OrderBy(a => a.AccountId);
        }
    }
}

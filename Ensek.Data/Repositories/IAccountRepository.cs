using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ensek.Domain;

namespace Ensek.Data.Repositories
{
    public interface IAccountRepository
    {
        /// <summary>
        /// Returns all accounts from the db
        /// </summary>
        /// <returns></returns>
        IEnumerable<Account> GetAll();
    }
}

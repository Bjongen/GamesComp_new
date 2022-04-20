using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesCompLogic.Containers
{
    public class AccountContainer
    {
        public List<Account> _accounts = new();

        public IReadOnlyCollection<Account> GetAccounts()
        {
            return _accounts;
        }
        public void CreateAccount(Account account)
        {
            if (_accounts.Contains(account))
            {
                throw new ArgumentException("Account already exists");
            }

            _accounts.Add(account);
        }

        public void DeleteAccount(Account account)
        {
            if (!_accounts.Contains(account))
            {
                throw new ArgumentException("Can not remove non-existing account");
            }

            _accounts.Remove(account);
        }
    }
}

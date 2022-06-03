using GamesCompDAL.IDAL;
using GamesCompInterface.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesCompLogic.Containers
{
    public class AccountContainer
    {
        public List<Account> _accounts;

        private IAccountDAL iAccountDAL;

        public AccountContainer(IAccountDAL iAccountDAL)
        {
            this.iAccountDAL = iAccountDAL;
            _accounts = new List<Account>();
        }

        public IReadOnlyCollection<Account> GetAccounts()
        {
            return _accounts;
        }

        public int DeleteAccount(Account account)
        {
            AccountDto accountDto = new AccountDto()
            {
                Name = account.Name,
                Password = account.Password,
                Email = account.Email,
                PhoneNumber = account.PhoneNumber,
                IsAdmin = account.IsAdmin
            };

            return iAccountDAL.DeleteAccount(accountDto);
        }

        public int CreateAccount(Account account)
        {
            AccountDto accountDto = new AccountDto()
            {
                Name = account.Name,
                Password = account.Password,
                Email = account.Email,
                PhoneNumber = account.PhoneNumber,
                IsAdmin = account.IsAdmin
            };
            _accounts.Add(new Account(accountDto));
            return iAccountDAL.AddAccount(accountDto);
        }

        public bool CheckUserName(Account account)
        {
            List<AccountDto> accountDtos = new();
            accountDtos = iAccountDAL.GetALL().ToList();
            foreach(var accountdto in accountDtos)
            {
                if(accountdto.Name == account.Name)
                {
                    return true;
                }
            }
            return false;
            
        }

        public IList<Account> GetAllAccounts()
        {
            var accountDtos = iAccountDAL.GetALL();
            List<Account> accounts = new();
            foreach(var dto in accountDtos)
            {
                accounts.Add(new Account(dto));
            }

            return _accounts = accounts;
        }
    }
}

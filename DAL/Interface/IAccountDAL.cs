using GamesCompInterface.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesCompDAL.IDAL
{
    public interface IAccountDAL
    {
        AccountDto[] GetALL();
        int AddAccount(AccountDto accountDto);
        int AddAdmin(AccountDto accountDto);
        int DeleteAccount(AccountDto accountDto);
        int EditAccount(AccountDto accountDto);
    }
}

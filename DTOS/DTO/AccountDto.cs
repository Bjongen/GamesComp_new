using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesCompInterface.Dtos
{
    public struct AccountDto
    {
        public int AccountId;
        public string Name;
        public string Password;
        public string Email;
        public string PhoneNumber;
        public bool IsAdmin;
    }
}

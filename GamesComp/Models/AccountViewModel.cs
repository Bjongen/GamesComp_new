using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesComp.Models
{
    public struct AccountViewModel
    {
        public int AccountId;
        public string Name;
        public string Password;
        public string Email;
        public string PhoneNumber;
        public bool IsAdmin;
    }
}

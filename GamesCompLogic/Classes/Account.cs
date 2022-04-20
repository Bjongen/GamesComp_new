using GamesCompInterface.Dtos;
using System;

namespace GamesCompLogic
{
    public class Account
    {
        public int AccountId;
        public string Name;
        public string Password;
        public string Email;
        public string PhoneNumber;
        public bool IsAdmin;

        public Account(int accountId, string name, string password, string email, bool isAdmin)
        {
            AccountId = accountId;
            Name = name;
            Password = password;
            Email = email;
            IsAdmin = isAdmin;
        }

        public Account(int accountId, string name, string password, string email, string phoneNumber, bool isAdmin)
        {
            AccountId = accountId;
            Name = name;
            Password = password;
            Email = email;
            IsAdmin = isAdmin;
            PhoneNumber = phoneNumber;
        }

        public Account(AccountDto accountDto)
        {
            AccountId = accountDto.AccountId;
            Name = accountDto.Name;
            Password = accountDto.Password;
            Email = accountDto.Email;
            PhoneNumber = accountDto.PhoneNumber;
            IsAdmin = accountDto.IsAdmin;
        }

        public AccountDto ToDto()
        {
            return new AccountDto
            {
                AccountId = AccountId,
                Name = Name,
                Password = Password,
                Email = Email,
                PhoneNumber = PhoneNumber,
                IsAdmin = IsAdmin
            };
        }
    }
}

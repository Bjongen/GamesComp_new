using GamesCompInterface.Dtos;
using System;

namespace GamesCompLogic
{
    public class Account
    {
        public int AccountId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsAdmin { get; set; }

        public Account(string name, string password, string email, string phoneNumber, bool isAdmin)
        {
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

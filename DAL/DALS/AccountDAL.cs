using GamesCompDAL.IDAL;
using GamesCompInterface.Dtos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using GamesCompDAL.Exceptions;
namespace DAL
{
    public class AccountDAL : IAccountDAL
    {
        private const string Connectionstring =
            "Data Source=LAPTOP-39NSUQTM\\SQLEXPRESS;Initial Catalog = GamesComp; Integrated Security = True";
        public AccountDto[] GetALL()
        {
            using var connection = new SqlConnection(Connectionstring);
            connection.Open();

            const string sql = "SELECT * FROM [Account]";
            using var cmd = new SqlCommand(sql, connection);

            using SqlDataReader rdr = cmd.ExecuteReader();
            List<AccountDto> accountDtos = new List<AccountDto>();

            while (rdr.Read())
            {
                AccountDto dto = new AccountDto
                {
                    AccountId = Convert.ToInt32(rdr["AccountID"]),
                    Name = Convert.ToString(rdr["UserName"]),
                    Password = Convert.ToString(rdr["Password"]),
                    Email = Convert.ToString(rdr["Email"]),
                    PhoneNumber = Convert.ToString(rdr["PhoneNumber"]),
                    IsAdmin = Convert.ToBoolean(rdr["IsAdmin"])
                };
                accountDtos.Add(dto);
            }
            connection.Close();

            return accountDtos.ToArray();
        }

        public int AddAccount(AccountDto accountDto)
        {
            using var connection = new SqlConnection(Connectionstring);
            connection.Open();

            const string sql = "INSERT INTO [Account] " +
                               "VALUES(@username, @password, @email, @phonenumber, @isadmin)";


            var RowsAffected = 0;
            using (var cmd = new SqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("@username", accountDto.Name);
                cmd.Parameters.AddWithValue("@password", accountDto.Password);
                cmd.Parameters.AddWithValue("@email", accountDto.Email);
                cmd.Parameters.AddWithValue("@phonenumber", accountDto.PhoneNumber);
                cmd.Parameters.AddWithValue("@isadmin", accountDto.IsAdmin);
                try
                {
                RowsAffected = cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    if (ex.Message.Contains("Cannot insert duplicate key row in object 'dbo.Account' with unique index 'Unique_Username'."))
                    {
                        throw new AccountExistsException();
                    }
                    else
                    {
                        throw new Exception(ex.Message);
                    }
                }
                finally
                {
                    connection.Close();
                }
            }
            return RowsAffected;
        }

        public int AddAdmin(AccountDto accountDto)
        {
            using var connection = new SqlConnection(Connectionstring);
            connection.Open();

            const string sql = "INSERT INTO [Account] " +
                               "VALUES(@username, @password, @email, @phonenumber, @isadmin)";

            var RowsAffected = 0;
            using (var cmd = new SqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("@username", accountDto.Name);
                cmd.Parameters.AddWithValue("@password", accountDto.Password);
                cmd.Parameters.AddWithValue("@email", accountDto.Email);
                cmd.Parameters.AddWithValue("@phonenumber", accountDto.PhoneNumber);
                cmd.Parameters.AddWithValue("1", accountDto.IsAdmin);
                RowsAffected = cmd.ExecuteNonQuery();
            }

            connection.Close();
            return RowsAffected;
        }

        public int DeleteAccount(AccountDto accountDto)
        {
            using var connection = new SqlConnection(Connectionstring);
            connection.Open();

            const string sql = "Delete from [Account] " +
                "Where Username = @userame";

            var RowsAffected = 0;
            using (var cmd = new SqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("@username", accountDto.Name);
                RowsAffected = cmd.ExecuteNonQuery();
            }

            connection.Close();
            return RowsAffected;
        }

        public int EditAccount(AccountDto accountDto)
        {
            using var connection = new SqlConnection(Connectionstring);
            connection.Open();

            const string sql = "Update [Account] " +
                "Set [Username] = @username," +
                "[Password] = @password" +
                "[Email] = @email" +
                "[PhoneNumber] = @phonenumber" +
                "Where AccountId = @accountid";

            var RowsAffected = 0;
            using (var cmd = new SqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("accountid", accountDto.AccountId);
                cmd.Parameters.AddWithValue("@username", accountDto.Name);
                cmd.Parameters.AddWithValue("@password", accountDto.Password);
                cmd.Parameters.AddWithValue("@email", accountDto.Email);
                cmd.Parameters.AddWithValue("@phonenumber", accountDto.PhoneNumber);
                RowsAffected = cmd.ExecuteNonQuery();
            }

            connection.Close();
            return RowsAffected;
        }
    }
}

using BLL.Interface.Entities;
using DAL.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
    public static class Mapper
    {
        public static Account ConvertToAccount(this DalAccount dalAccount)
        {
            return (Account)Activator.CreateInstance(
                GetAccountType(dalAccount.AccountType),
                dalAccount.Id,
                dalAccount.FirstName,
                dalAccount.LastName,
                dalAccount.Amount,
                dalAccount.Points,
                dalAccount.Email);
        }

        public static DalAccount ConvertToDalAccount(this Account account)
        {
            return new DalAccount
            {
                AccountType = account.GetType().Name,
                Points = account.Points,
                Amount = account.Amount,
                Id = account.Id,
                FirstName = account.FirstName,
                LastName = account.LastName,
                Email = account.Email
            };
        }

        private static Type GetAccountType(string type)
        {
            if (type.Contains("Gold"))
            {
                return typeof(GoldAccount);
            }

            if (type.Contains("Platinum"))
            {
                return typeof(PlatinumAccount);
            }

            return typeof(BasicAccount);
        }
    }
}

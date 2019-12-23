using BLL.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Interfaces
{
    public interface IAccountService
    {
        Account CreateAccount(AccountType accountType, string firstName, string lastName, decimal amount);
        void AddMoney(Account account, decimal money);
        void AddMoney(string account, decimal money);
        void WithdrawMoney(Account account, decimal money);
        void WithdrawMoney(string accountId, decimal money);
        void CloseAccout(Account account);
        void CloseAccout(string accountId);
        string GetAccount(string accountId);
    }
}

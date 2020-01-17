using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using BLL.Mappers;
using DAL.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ServiceImplementation
{
    public class AccountService : IAccountService
    {
        private const int BaseAccountBonusValue = 1;
        private const int GoldAccountBonusValue = 25;
        private const int PlatinumAccountBonusValue = 100;

        private readonly IAccountGenerateIdNumber _accountGenerateIdNumber;
        private readonly IRepository _accountRepsitory;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="accountRepsitory"></param>
        /// <param name="accountGenerateIdNumber"></param>
        public AccountService(IRepository accountRepsitory, IAccountGenerateIdNumber accountGenerateIdNumber)
        {
            _accountRepsitory = accountRepsitory;
            _accountGenerateIdNumber = accountGenerateIdNumber;
        }

        /// <summary>
        /// Add money to account
        /// </summary>
        /// <param name="account"></param>
        /// <param name="money"></param>
        public void AddMoney(Account account, decimal money)
        {
            if (account is null)
            {
                throw new ArgumentException(nameof(account));
            }

            account.Deposit(money);
            _accountRepsitory.UpdateAccount(account.ConvertToDalAccount());
        }

        public void AddMoney(string accountId, decimal money)
        {
            if (string.IsNullOrEmpty(accountId))
            {
                throw new ArgumentException(nameof(accountId));
            }

            var account = _accountRepsitory.GetAccounts().FirstOrDefault(acc => acc.Id == accountId);
            account.ConvertToAccount().Deposit(money);
            _accountRepsitory.UpdateAccount(account);
        }

        /// <summary>
        /// Withdraw money from account
        /// </summary>
        /// <param name="account"></param>
        /// <param name="money"></param>
        public void WithdrawMoney(Account account, decimal money)
        {
            if (account is null)
            {
                throw new ArgumentException(nameof(account));
            }

            account.Withdraw(money);
            _accountRepsitory.UpdateAccount(account.ConvertToDalAccount());
        }

        public void WithdrawMoney(string accountId, decimal money)
        {
            if (string.IsNullOrEmpty(accountId))
                throw new ArgumentException(nameof(accountId));
            var account = _accountRepsitory.GetAccounts().FirstOrDefault(acc => acc.Id == accountId);
            account.ConvertToAccount().Withdraw(money);
            _accountRepsitory.UpdateAccount(account);
        }
        /// <summary>
        /// Delete account
        /// </summary>
        /// <param name="account"></param>
        public void CloseAccout(Account account)
        {
            if (account is null)
            {
                throw new ArgumentException(nameof(account));
            }

            _accountRepsitory.RemoveAccount(account.ConvertToDalAccount());
        }

        public void CloseAccout(string accountId)
        {
            if (string.IsNullOrEmpty(accountId))
            {
                throw new ArgumentException(nameof(accountId));
            }

            var account = _accountRepsitory.GetAccounts().FirstOrDefault(acc => acc.Id == accountId);
            _accountRepsitory.RemoveAccount(account);
        }


        public string GetAccount(string accountId)
        {
            if (string.IsNullOrWhiteSpace(accountId))
            {
                throw new ArgumentException(nameof(accountId));
            }

            var accounts = _accountRepsitory.GetAccounts();
            var account = accounts.FirstOrDefault(acc => acc.Id == accountId);
            if (account is null)
            {
                throw new ArgumentException($"Account with id {accountId} not found");
            }

            return account.ConvertToAccount().ToString();
        }

        /// <summary>
        /// Create new account
        /// </summary>
        /// <param name="accountType"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public Account CreateAccount(AccountType accountType, string firstName, string lastName, decimal amount)
        {
            var account = CreateAccount(TypeOfAccount(accountType), _accountGenerateIdNumber.GenerateId(), firstName, lastName, amount, GetBonuses(accountType));

            _accountRepsitory.AddAccount(account.ConvertToDalAccount());

            return account;
        }

        public Account CreateAccount(AccountType accountType, string firstName, string lastName, decimal amount, string email, IAccountGenerateIdNumber accountGenerateIdNumber)
        {
            var account = CreateAccount(TypeOfAccount(accountType), accountGenerateIdNumber.GenerateId(), firstName, lastName, amount, GetBonuses(accountType));

            _accountRepsitory.AddAccount(account.ConvertToDalAccount());

            return account;
        }

        #region private
        private Account CreateAccount(Type accountType, string id, string firstName, string lastName, decimal amount,
            int bonusPoints)
        {
            return (Account)Activator.CreateInstance(accountType, id, firstName, lastName, amount, bonusPoints);
        }

        private static int GetBonuses(AccountType accountType)
        {
            switch (accountType)
            {
                case AccountType.Basic:
                    return BaseAccountBonusValue;
                case AccountType.Gold:
                    return GoldAccountBonusValue;
                case AccountType.Platinum:
                    return PlatinumAccountBonusValue;
                default:
                    throw new ArgumentException(nameof(accountType));
            }
        }

        private static Type TypeOfAccount(AccountType accountType)
        {
            switch (accountType)
            {
                case AccountType.Basic:
                    return typeof(BasicAccount);
                case AccountType.Gold:
                    return typeof(GoldAccount);
                case AccountType.Platinum:
                    return typeof(PlatinumAccount);
                default:
                    throw new ArgumentException(nameof(accountType));
            }
        }
        #endregion
    }
}

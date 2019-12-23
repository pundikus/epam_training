using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    public abstract class Account
    {
        #region private fields
        private string _firstName;
        private string _id;
        private string _lastName;
        #endregion
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="amount"></param>
        /// <param name="points"></param>
        protected Account(string id, string firstName, string lastName, decimal amount, int points)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Amount = amount;
            Points = points;
        }

        /// <summary>
        /// Abstract methods that calculate bonus points
        /// </summary>
        /// <param name="bonusValue"></param>
        /// <returns></returns>
        public abstract int CalculatePointsForDeposit(int bonusValue);
        public abstract int CalculatePointsForWithdraw(int bonusValue);
        protected abstract bool IsValidBalance(decimal value);

        /// <summary>
        /// Add money to account and calculate bonuses
        /// </summary>
        /// <param name="money"></param>
        public void Deposit(decimal money)
        {
            if (money <= 0)
            {
                throw new ArgumentException(nameof(money));
            }

            Amount += money;
            Points += CalculatePointsForDeposit(BonusValue);
        }

        /// <summary>
        /// Withdraw money from account and calculate bonuses
        /// </summary>
        /// <param name="money"></param>
        public void Withdraw(decimal money)
        {
            if (money <= 0)
            {
                throw new ArgumentException(nameof(money));
            }

            if (Amount <= money)
            {
                throw new ArgumentException(nameof(money));
            }

            Amount -= money;
            Points -= CalculatePointsForWithdraw(BonusValue);
        }

        #region properties
        public string Id
        {
            get => _id;

            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException();
                _id = value;
            }
        }

        public string FirstName
        {
            get => _firstName;

            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException();
                _firstName = value;
            }
        }

        public string LastName
        {
            get => _lastName;

            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException();
                _lastName = value;
            }
        }

        public decimal Amount { get; set; }
        public int Points { get; set; }
        public int BonusValue { get; set; }
        #endregion
        /// <summary>
        /// Override ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("Account №{0}\n Owner: {1} {2} \n Amount: {3}$  points:{4} ", Id, FirstName, LastName, Amount, Points);
        }
    }

}

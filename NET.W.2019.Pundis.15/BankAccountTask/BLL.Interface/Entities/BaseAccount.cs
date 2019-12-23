using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    public class BasicAccount : Account
    {
        public BasicAccount(string id, string firstName, string lastName, decimal amount, int points)
        : base(id, firstName, lastName, amount, points)
        {
            BonusValue = 1;
        }

        public override string ToString() => "Basic Account" + base.ToString();

        public override int CalculatePointsForDeposit(int bonusValue) => 15 * bonusValue;
        public override int CalculatePointsForWithdraw(int bonusValue) => 15 * bonusValue;

        protected override bool IsValidBalance(decimal value) => value >= 0;
    }
}

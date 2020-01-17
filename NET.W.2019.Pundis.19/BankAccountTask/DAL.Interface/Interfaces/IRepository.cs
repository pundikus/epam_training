using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.Interfaces
{
    public interface IRepository
    {
        void AddAccount(DalAccount account);
        void RemoveAccount(DalAccount account);
        IEnumerable<DalAccount> GetAccounts();
        void UpdateAccount(DalAccount account);
    }
}

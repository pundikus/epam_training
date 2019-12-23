using DAL.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class AccountRepository : IRepository
    {
        #region private_fields
        private readonly string _path;
        private readonly List<DalAccount> _accounts = new List<DalAccount>();
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="path"></param>
        public AccountRepository(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException("Incorrect");
            }

            _path = path;
        }
        #region public_methods
        /// <summary>
        /// Add account to file
        /// </summary>
        /// <param name="account"></param>
        public void AddAccount(DalAccount account)
        {
            if (account is null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            AppendAccountToFile(account);
            _accounts.Add(account);
        }

        /// <summary>
        /// Remove account from file
        /// </summary>
        /// <param name="account"></param>
        public void RemoveAccount(DalAccount account)
        {
            if (account is null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            _accounts.Remove(account);
            AppendAccountsToFile(_accounts);
        }

        /// <summary>
        /// All accounts from file
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DalAccount> GetAccounts()
        {
            List<DalAccount> accounts = new List<DalAccount>();
            using (var binr = new BinaryReader(File.Open(_path, FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read)))
            {
                while (binr.BaseStream.Position != binr.BaseStream.Length)
                {
                    var account = Reader(binr);
                    accounts.Add(account);
                }
            }
            return accounts;
        }

        /// <summary>
        /// Update account, overwrite file
        /// </summary>
        /// <param name="account"></param>
        public void UpdateAccount(DalAccount account)
        {
            if (account is null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            _accounts.Remove(account);
            _accounts.Add(account);
            AppendAccountsToFile(_accounts);
        }
        #endregion

        #region private_methods
        private void AppendAccountToFile(DalAccount account)
        {
            using (var binwr = new BinaryWriter(File.Open(_path, FileMode.Append, FileAccess.Write, FileShare.None), Encoding.UTF8, false))
            {
                Writer(binwr, account);
            }
        }

        private void AppendAccountsToFile(List<DalAccount> accounts)
        {
            using (var binwr = new BinaryWriter(File.Open(_path, FileMode.Create, FileAccess.Write, FileShare.None)))
            {
                foreach (var account in accounts)
                {
                    Writer(binwr, account);
                }
            }
        }

        private static void Writer(BinaryWriter binary, DalAccount account)
        {
            binary.Write(account.Id);
            binary.Write(account.FirstName);
            binary.Write(account.LastName);
            binary.Write(account.Amount);
            binary.Write(account.Points);
        }

        private static DalAccount Reader(BinaryReader binary)
        {
            var id = binary.ReadString();
            var firstName = binary.ReadString();
            var lastName = binary.ReadString();
            var amount = binary.ReadDecimal();
            var points = binary.ReadInt32();

            return new DalAccount
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                Amount = amount,
                Points = points
            };
        }
        #endregion
    }
}

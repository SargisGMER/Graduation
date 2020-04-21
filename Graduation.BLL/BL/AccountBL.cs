using Graduation.BLL.BLContracts;
using Graduation.Entities;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Graduation.DAL.Models;

namespace Graduation.BLL.BL
{
    public class AccountBL : CoreBL, IAccountBL
    {
        public AccountEntity Authentication(string email, string password)
        {
            Account account = UnitOfWork.AccountRepository.GetAll().Where(x => x.Email == email && x.Password == password).FirstOrDefault();

            if (account != null)
            {
                AccountEntity accountEntity = new AccountEntity
                {
                    Id = account.Id,
                    Email = account.Email,
                    Name = account.Name,
                };

                return accountEntity;
            }
            return null;
        }
    }
}

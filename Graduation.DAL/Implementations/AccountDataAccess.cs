using System;
using System.Collections.Generic;
using System.Text;
using Graduation.DAL.Interfaces;
using Graduation.DAL.Models;
using System.Linq;

namespace Graduation.DAL.Implementations
{
    public class AccountDataAccess : IBaseDataAccess<Account>
    {
        private GraduationDBContext graduationDBContext;
        public AccountDataAccess(GraduationDBContext _graduationDBContext)
        {
            graduationDBContext = _graduationDBContext;
        }

        public Account Create(Account item)
        {
            var account = graduationDBContext.Add(item).Entity;
            graduationDBContext.SaveChanges();

            return account;
        }

        public bool DeleteById(int id)
        {
            var user = graduationDBContext.Account.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                try
                {
                    graduationDBContext.Account.Remove(user);
                    graduationDBContext.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {

                    throw new Exception("SaveChanges error in UserCharacters->DeleteById", ex);
                }
            }
            return false;

        }

        public IEnumerable<Account> GetAll()
        {
            return graduationDBContext.Account;
        }

        public Account GetById(int id)
        {
            return graduationDBContext.Account.FirstOrDefault(x => x.Id == id);
        }

        public bool Update(Account item)
        {
            var account = graduationDBContext.Account.FirstOrDefault(x => x.Id == item.Id);

            if (account != null)
            {
                //userCharacter.User = item.User;
                account.Name = item.Name;
                account.Email = item.Email;
                account.Password = item.Password;
                try
                {
                    graduationDBContext.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception("Save changes error in UserCharacters->Update", ex);
                }
            }
            return false;
        }
    }
}

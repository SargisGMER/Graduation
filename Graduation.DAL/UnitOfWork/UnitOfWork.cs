using System;
using System.Collections.Generic;
using System.Text;
using Graduation.DAL.Models;
using Graduation.DAL.Repository;

namespace Graduation.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private GenericRepository<Account> accountRepository;
        private GenericRepository<Character> characterRepository;
        private GenericRepository<Weapons> weaponsRepository;

        private GraduationDBContext context;

        public UnitOfWork()
        {
            context = new GraduationDBContext();
        }

        public GenericRepository<Account> AccountRepository
        {
            get
            {
                if (accountRepository == null)
                    accountRepository = new GenericRepository<Account>(context);
                return accountRepository;
                
            }
        }
        public GenericRepository<Character> CharacterRepository
        {
            get
            {
                if (characterRepository == null)
                    characterRepository = new GenericRepository<Character>(context);
                return characterRepository;

            }
        }

        public GenericRepository<Weapons> WeaponsRepository
        {
            get
            {
                if (weaponsRepository == null)
                    weaponsRepository = new GenericRepository<Weapons>(context);
                return weaponsRepository;

            }
        }
    }
}

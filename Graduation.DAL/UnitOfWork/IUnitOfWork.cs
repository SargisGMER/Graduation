using Graduation.DAL.Models;
using Graduation.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Graduation.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        GenericRepository<Account> AccountRepository { get; }
        GenericRepository<Character> CharacterRepository { get; }
        GenericRepository<Weapons> WeaponsRepository { get; }

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Graduation.DAL.Interfaces;
using Graduation.DAL.Models;
using System.Linq;
namespace Graduation.DAL.Implementations
{
    public class WeaponsDataAccess : IBaseDataAccess<Weapons>
    {
        private GraduationDBContext graduationDBContext;
        public WeaponsDataAccess(GraduationDBContext _graduationDBContext)
        {
            graduationDBContext = _graduationDBContext;
        }

        public Weapons Create(Weapons item)
        {
            var weapon = graduationDBContext.Weapons.Add(item).Entity;
            graduationDBContext.SaveChanges();

            return weapon;
        }

        public bool DeleteById(int id)
        {
            var weapon = graduationDBContext.Weapons.Where(x => x.Id == id).FirstOrDefault();
            try
            {
                if (weapon != null)
                {
                    graduationDBContext.Weapons.Remove(weapon);
                    graduationDBContext.SaveChanges();
                    return true;

                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Save changes error in Weapons->DeleteById", ex);
            }
        }

        public IEnumerable<Weapons> GetAll()
        {
            return graduationDBContext.Weapons;
        }

        public Weapons GetById(int id)
        {
            return graduationDBContext.Weapons.Where(x => x.Id == id).FirstOrDefault();
        }

        public bool Update(Weapons item)
        {
            var weapon = graduationDBContext.Weapons.FirstOrDefault(x => x.Id == item.Id);
            if (weapon != null)
            {
                weapon.WeaponDefaultSkinColor = item.WeaponDefaultSkinColor;
                weapon.WeaponName = item.WeaponName;
                try
                {
                    graduationDBContext.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception("Save changes error in Weapon->Update", ex);
                }
            }
            return false;

        }
    }
}

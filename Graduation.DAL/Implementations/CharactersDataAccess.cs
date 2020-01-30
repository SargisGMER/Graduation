using System;
using System.Collections.Generic;
using System.Text;
using Graduation.DAL.Interfaces;
using Graduation.DAL.Models;
using System.Linq;

namespace Graduation.DAL.Implementations
{
    public class CharactersDataAccess : IBaseDataAccess<Character>
    {
        private GraduationDBContext graduationDBContext;
        public CharactersDataAccess(GraduationDBContext _graduationDBContext)
        {
            graduationDBContext = _graduationDBContext;
        }

        public Character Create(Character item)
        {
            var characters = graduationDBContext.Add(item).Entity;
            graduationDBContext.SaveChanges();

            return characters;
        }

        public bool DeleteById(int id)
        {
            var character = graduationDBContext.Character.FirstOrDefault(x => x.Id == id);
            if (character != null)
            {
                graduationDBContext.Character.Remove(character);
                try
                {
                    graduationDBContext.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {

                    throw new Exception("Save changes error in Characters->DeleteById", ex);
                }
                
            }
            return false;
        }

        public IEnumerable<Character> GetAll()
        {
            return graduationDBContext.Character;
        }

        public Character GetById(int id)
        {
            return graduationDBContext.Character.FirstOrDefault(x => x.Id == id);
        }

        public bool Update(Character item)
        {
            var character = graduationDBContext.Character.FirstOrDefault(x => x.Id == item.Id);
            if (character != null)
            {
                character.CharacterModel = item.CharacterModel;
                character.DefaultSkinColor = item.DefaultSkinColor;
                try
                {
                    graduationDBContext.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {

                    throw new Exception("Save changes error in Characters->Update",ex);
                }
            }
            return false;

        }
    }
}

using System;
using System.Collections.Generic;

namespace Graduation.Entities
{
    public class CharacterEntity
    {
        public CharacterEntity()
        {
        }

        public int Id { get; set; }
        public int AccountId { get; set; }
        public int? WeaponId { get; set; }
        public string CharacterModel { get; set; }
        public string DefaultSkinColor { get; set; }

        public virtual AccountEntity Account { get; set; }
        public virtual WeaponEntity Weapon { get; set; }

    }
}

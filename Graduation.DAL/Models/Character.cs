using System;
using System.Collections.Generic;

namespace Graduation.DAL.Models
{
    public partial class Character
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int? WeaponId { get; set; }
        public string CharacterModel { get; set; }
        public string DefaultSkinColor { get; set; }

        public virtual Account Account { get; set; }
        public virtual Weapons Weapon { get; set; }
    }
}

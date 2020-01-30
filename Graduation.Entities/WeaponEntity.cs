using System;
using System.Collections.Generic;
using System.Text;

namespace Graduation.Entities
{
    public class WeaponEntity
    {
        public WeaponEntity()
        {
            this.CharacterEntities = new List<CharacterEntity>();
        }

        public int Id { get; set; }
        public string WeaponName { get; set; }
        public string WeaponDefaultSkinColor { get; set; }

        public virtual List<CharacterEntity> CharacterEntities { get; set; }
    }
}

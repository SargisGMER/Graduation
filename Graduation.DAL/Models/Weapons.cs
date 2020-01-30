using System;
using System.Collections.Generic;

namespace Graduation.DAL.Models
{
    public partial class Weapons
    {
        public Weapons()
        {
            Character = new HashSet<Character>();
        }

        public int Id { get; set; }
        public string WeaponName { get; set; }
        public string WeaponDefaultSkinColor { get; set; }

        public virtual ICollection<Character> Character { get; set; }
    }
}

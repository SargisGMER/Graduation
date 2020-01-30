using System;
using System.Collections.Generic;
using System.Text;

namespace Graduation.Entities
{
    public class AccountEntity
    {

        public AccountEntity()
        {
            CharacterEntities = new List<CharacterEntity>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual List<CharacterEntity> CharacterEntities { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Graduation.DAL.Models
{
    public partial class Account
    {
        public Account()
        {
            Character = new HashSet<Character>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Character> Character { get; set; }
    }
}

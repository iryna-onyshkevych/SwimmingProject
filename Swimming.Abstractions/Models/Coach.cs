using System;
using System.Collections.Generic;

#nullable disable

namespace Swimming.Models
{
    public partial class Coach
    {
        public Coach()
        {
            Swimmers = new HashSet<Swimmer>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int WorkExperience { get; set; }

        public virtual ICollection<Swimmer> Swimmers { get; set; }
    }
}

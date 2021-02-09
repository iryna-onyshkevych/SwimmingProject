using Swimming.Abstractions.Attributes;
using System;
using System.Collections.Generic;

#nullable disable

namespace Swimming.Abstractions.Models
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
        [WorkExperienceValidation]
        public int WorkExperience { get; set; }

        public virtual ICollection<Swimmer> Swimmers { get; set; }
    }
}

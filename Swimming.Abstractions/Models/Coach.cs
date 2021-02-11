using Swimming.Abstractions.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Swimming.Abstractions.Models
{
    public partial class Coach 
    {
        public Coach()
        {
            Swimmers = new HashSet<Swimmer>();
        }
        [Required]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [WorkExperienceValidation]
        public int WorkExperience { get; set; }

        public virtual ICollection<Swimmer> Swimmers { get; set; }
    }
}

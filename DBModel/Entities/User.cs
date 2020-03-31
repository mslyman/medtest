using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace DBModel
{
    public partial class User : BaseEntity
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string Surname { get; set; }

        public string Patronymic { get; set; }
        
        public GenderEnum Gender { get; set; }

        [Required]
        public string Email { get; set; }             

        [Column(TypeName = "date")]
        public DateTime Birthday { get; set; }

        public string Hobby { get; set; }
        
        public string Phone { get; set; }

        public string Address { get; set; }

    }

    public enum GenderEnum { Male = 1, Female = 2 }
}

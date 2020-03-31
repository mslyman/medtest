using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Dto
{
    public enum GenderEnum { Male = 1, Female = 2 }


    [DataContract]
    public partial class UserDto : BaseDto
    {
        [DataMember]
        [Required(ErrorMessage = "Поле Имя обязательно")]
        public string FirstName { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Поле Фамилия обязательно")]
        public string Surname { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Patronymic { get; set; }

        [DataMember(EmitDefaultValue = false)]        
        public GenderEnum Gender { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Поле E-mail обязательно")]
        public string Email { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public DateTime Birthday { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Hobby { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Phone { get; set; }

        [DataMember(EmitDefaultValue = false)]       
        public string Address { get; set; }
    }
}

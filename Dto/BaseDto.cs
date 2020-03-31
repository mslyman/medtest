using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Dto
{
    [DataContract]
    public class BaseDto
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public DateTime DateUpdated { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public bool IsDeleted { get; set; }
    }
}

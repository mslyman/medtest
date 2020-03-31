using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace DBModel
{
    [DataContract]
    public partial class BaseEntity
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public DateTime DateUpdated { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public bool IsDeleted { get; set; }
    }
}

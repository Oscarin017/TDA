using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace TDA.Entities
{
    [DataContract]
    class Log
    {
        [DataMember]
        public long ID { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public long? Usuario { get; set; }
    }
}

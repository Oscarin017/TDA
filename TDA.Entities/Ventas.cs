using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace TDA.Entities
{
    [DataContract]
    public class Ventas
    {
        [DataMember]
        public long ID { get; set; }
        [DataMember]
        public Decimal? Total { get; set; }
        [DataMember]
        public DateTime? Fecha { get; set; }
        [DataMember]
        public long? Cliente { get; set; }
        [DataMember]
        public long? UsuarioVenta { get; set; }
    }
}

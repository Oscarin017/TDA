using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace TDA.Entities
{
    [DataContract]
    public class Configuraciones
    {
        [DataMember]
        public long ID { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public decimal? Valor { get; set; }
        [DataMember]
        public bool? Activo { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace TDA.Entities
{
    [DataContract]
    public class Resultado
    {
        [DataMember]
        public bool Realizado { get; set; }
        [DataMember]
        public bool ErrorDB { get; set; }
        [DataMember]
        public bool YaExiste { get; set; }
        [DataMember]
        public bool Referencia { get; set; }
        [DataMember]
        public string Mensaje { get; set; }
        // Campo cuando se requiere saber el id con el que se guardo el registro
        [DataMember]
        public long IdGuardado { get; set; }
    }
}

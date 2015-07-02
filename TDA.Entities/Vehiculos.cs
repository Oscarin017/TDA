using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace TDA.Entities
{
    [DataContract]
    public class Vehiculos
    {
        [DataMember]
        public long ID { get; set; }
        [DataMember]
        public string NoSerie { get; set; }
        [DataMember]
        public long? Modelo { get; set; }
        [DataMember]
        public string ModeloNombre { get; set; }
        [DataMember]
        public long? Marca { get; set; }
        [DataMember]
        public string MarcaNombre { get; set; }
        [DataMember]
        public string Color { get; set; }
        [DataMember]
        public int? Ano { get; set; }
        [DataMember]
        public string Responsable { get; set; }
        [DataMember]
        public string NumeroIdentificacion { get; set; }
        [DataMember]
        public long? TipoIdentificacion { get; set; }
        [DataMember]
        public long? UsuarioAlta { get; set; }
        [DataMember]
        public long? UsuarioMod { get; set; }
        [DataMember]
        public DateTime? FechaAlta { get; set; }
        [DataMember]
        public DateTime? FechaMod { get; set; }
    }
}

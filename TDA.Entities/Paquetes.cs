using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace TDA.Entities
{
    [DataContract]
    public class Paquetes
    {
        public Paquetes()
        {
            Nombre = DefaultValues.defString;
            ParaGrupoCliente = DefaultValues.defbool;
            Activo = DefaultValues.defbool;
        }

        [DataMember]
        public long ID { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public decimal? Precio { get; set; }
        [DataMember]
        public bool? ParaGrupoCliente { get; set; }
        [DataMember]
        public string ParaGrupoClienteNombre { get; set; }
        [DataMember]
        public bool? Activo { get; set; }
        [DataMember]
        public string ActivoNombre { get; set; }
        [DataMember]
        public DateTime? FechaInicio { get; set; }
        [DataMember]
        public DateTime? FechaFin { get; set; }
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

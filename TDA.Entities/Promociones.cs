using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace TDA.Entities
{
    [DataContract]
    public class Promociones
    {
        [DataMember]
        public long ID { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public int? Tipo { get; set; }
        [DataMember]
        public decimal? Valor { get; set; }
        [DataMember]
        public int? Comprar { get; set; }
        [DataMember]
        public int? Pagar { get; set; }
        [DataMember]
        public bool? Activo { get; set; }
        [DataMember]
        public DateTime? FechaInicio { get; set; }
        [DataMember]
        public DateTime? FechaFin { get; set; }
        [DataMember]
        public bool? ParaPaquete { get; set; }
        [DataMember]
        public bool? ParaTipoProducto { get; set; }
        [DataMember]
        public bool? ParaProducto { get; set; }
        [DataMember]
        public bool? ParaGrupoCliente { get; set; }
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

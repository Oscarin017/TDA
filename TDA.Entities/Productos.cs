using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace TDA.Entities
{
    [DataContract]
    public class Productos
    {
        public Productos()
        {
            TipoProducto = DefaultValues.deflong;
            Proveedor = DefaultValues.deflong;
            Codigo = DefaultValues.defString;
            Descripcion = DefaultValues.defString;
        }

        [DataMember]
        public long ID { get; set; }
        [DataMember]
        public string Codigo { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public decimal? PrecioVenta { get; set; }
        [DataMember]
        public decimal? PrecioCompra { get; set; }
        [DataMember]
        public string Observaciones { get; set; }
        [DataMember]
        public bool? Servicio { get; set; }
        [DataMember]
        public decimal? IVA { get; set; }
        [DataMember]
        public bool? IVAExcento { get; set; }
        [DataMember]
        public long? TipoProducto { get; set; }
        [DataMember]
        public string TipoProductoNombre { get; set; }
        [DataMember]
        public string ProveedorNombre { get; set; }
        [DataMember]
        public string ProveedorApellido { get; set; }
        [DataMember]
        public string ProveedorApellido2 { get; set; }
        [DataMember]
        public long? Proveedor { get; set; }
        [DataMember]
        public long? UsuarioAlta { get; set; }
        [DataMember]
        public long? UsuarioMod { get; set; }
        [DataMember]
        public DateTime? FechaAlta { get; set; }
        [DataMember]
        public DateTime? FechaMod { get; set; }
        [DataMember]
        public bool GridBit { get; set; }
    }
}

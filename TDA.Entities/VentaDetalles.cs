using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace TDA.Entities
{
    [DataContract]
    public class VentaDetalles
    {
        [DataMember]
        public long ID { get; set; }
        [DataMember]
        public decimal Subtotal { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public string Color { get; set; }
        [DataMember]
        public long? Venta { get; set; }
        [DataMember]
        public long? Producto { get; set; }
        [DataMember]
        public long? Vehiculo { get; set; }
        [DataMember]
        public long? Paquete { get; set; }
        [DataMember]
        public long? Promocion { get; set; }
    }
}

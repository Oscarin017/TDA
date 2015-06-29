﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace TDA.Entities
{
    [DataContract]
    public class PromocionTipoProductos
    {
        [DataMember]
        public long ID { get; set; }
        [DataMember]
        public long? Promocion { get; set; }
        [DataMember]
        public long? TipoProducto { get; set; }
    }
}

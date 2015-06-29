﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace TDA.Entities
{
    [DataContract]
    public class Clientes
    {
        [DataMember]
        public long ID { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Apellido { get; set; }
        [DataMember]
        public string Apellido2 { get; set; }
        [DataMember]
        public string RFC { get; set; }
        [DataMember]
        public string Calle { get; set; }
        [DataMember]
        public string NumeroInterior { get; set; }
        [DataMember]
        public string NumeroExterior { get; set; }
        [DataMember]
        public string Colonia { get; set; }
        [DataMember]
        public int? CP { get; set; }
        [DataMember]
        public string Localidad { get; set; }
        [DataMember]
        public string Ciudad { get; set; }
        [DataMember]
        public string Telefono { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public long? Estado { get; set; }
        [DataMember]
        public long? GrupoCliente { get; set; }
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

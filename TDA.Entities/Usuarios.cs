﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace TDA.Entities
{
    [DataContract]
    public class Usuarios
    {
        public Usuarios()
        {
            Rol = DefaultValues.deflong;
            Alias = DefaultValues.defString;
        }

        [DataMember]
        public long ID { get; set; }
        [DataMember]
        public string Alias { get; set; }
        [DataMember]
        public string Contraseña { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public long? Rol { get; set; }
        [DataMember]
        public string RolNombre { get; set; }
        [DataMember]
        public long? Empleado { get; set; }
        [DataMember]
        public long? UsuarioAlta { get; set; }
        [DataMember]
        public DateTime? FechaAlta { get; set; }
        [DataMember]
        public long? UsuarioMod { get; set; }
        [DataMember]
        public DateTime? FechaMod { get; set; }

    }
}

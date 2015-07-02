using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace TDA.Entities
{
    [DataContract]
    public class Empleados
    {
        

        public Empleados()
        {
            Nombre = DefaultValues.defString;
            Apellido = DefaultValues.defString;
            CURP = DefaultValues.defString;
            Pais = DefaultValues.deflong;
            Estado = DefaultValues.deflong;
            Ciudad = DefaultValues.defString;
        }


        [DataMember]
        public long ID { get; set; }
        [DataMember]
        public string RFC  { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Apellido { get; set; }
        [DataMember]
        public string Apellido2 { get; set; }
        [DataMember]
        public string Calle { get; set; }
        [DataMember]
        public string NumeroInterior { get; set; }
        [DataMember]
        public string NumeroExterior { get; set; }
        [DataMember]
        public string Colonia { get; set; }
        [DataMember]
        public int?  CP { get; set; }
        [DataMember]
        public string Localidad { get; set; }
        [DataMember]
        public string Ciudad { get; set; }
        [DataMember]
        public string Telefono { get; set; }
        [DataMember]
        public string  Email { get; set; }
        [DataMember]
        public string CURP { get; set; }
        [DataMember]
        public string NSS { get; set; }
        [DataMember]
        public decimal? Salario { get; set; }
        [DataMember]
        public long? BaseSalario { get; set; }
        [DataMember]
        public long? Estado { get; set; }
        [DataMember]
        public long? UsuarioAlta { get; set; }
        [DataMember]
        public long? UsuarioMod { get; set; }
        [DataMember]
        public DateTime? FechaAlta { get; set; }
        [DataMember]
        public DateTime? FechaMod { get; set; }
        [DataMember]
        public long? Pais { get; set; }

    }
}

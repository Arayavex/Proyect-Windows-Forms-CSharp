using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abastecedor_Estrella
{
    class Cliente
    {
        public Persona InfPersona { get; set; }
        public String Correo { get; set; }
        public Direccion InfDireccion { get; set; }
        public int Edad { get; set; }
        public Credito Tarjeta { get; set; }

        public Cliente(Persona infPersona, string correo, Direccion infDireccion, int edad, Credito tarjeta)
        {
            InfPersona = infPersona;
            Correo = correo;
            InfDireccion = infDireccion;
            Edad = edad;
            Tarjeta = tarjeta;
        }
    }
}

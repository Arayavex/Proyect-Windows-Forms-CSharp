using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abastecedor_Estrella
{
    class Persona
    {
        public int IdPersona { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public int Telefono { get; set; }

        public Persona(int idPersona, string nombre, string apellido, int telefono)
        {
            IdPersona = idPersona;
            Nombre = nombre;
            Apellido = apellido;
            Telefono = telefono;
        }
    }
}

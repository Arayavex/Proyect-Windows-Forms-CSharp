using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abastecedor_Estrella
{
    enum enumEstadoMensajero{ Disponible, Transito}

    class Mensajero
    {
        public Persona infPersona { get; set; }
        public enumEstadoMensajero estadoMensajero { get; set; }

        public Mensajero(Persona infPersona, enumEstadoMensajero estadoMensajero)
        {
            this.infPersona = infPersona;
            this.estadoMensajero = estadoMensajero;
        }
    }
}

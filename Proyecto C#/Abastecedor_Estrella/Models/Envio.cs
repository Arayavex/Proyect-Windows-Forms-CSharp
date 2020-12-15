using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abastecedor_Estrella
{
    enum enumEstadoEnvio
    {
        Preparando, Retirando, Camino, Entregado
    }
    class Envio
    {
        public Orden infOrden { get; set; }
        public Mensajero infMensajero { get; set; }
        public enumEstadoEnvio estadoEnvio { get; set; }

        public Envio(Orden infOrden, Mensajero infMensajero, enumEstadoEnvio estadoEnvio)
        {
            this.infOrden = infOrden;
            this.infMensajero = infMensajero;
            this.estadoEnvio = estadoEnvio;
        }
    }


}

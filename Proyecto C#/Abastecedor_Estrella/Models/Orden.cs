using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abastecedor_Estrella
{
    enum enumTipoPago
    {
        Efectivo, Tarjeta
    }
    enum enumEstadoOrden
    { 
        Procesada, Enviada, Completa
    }
    class Orden
    {
        public int idOrden { get; set; }
        public Cliente infCliente { get; set; }
        public List<Producto> productos { get; set; }
        public double precioTotal { get; set; }
        public enumTipoPago tipoPago { get; set; }
        public enumEstadoOrden estadoOrden { get; set; }
        public DateTime Fecha { get; set; }

        public Orden(int idOrden, Cliente infCliente, List<Producto> productos, double precioTotal, enumTipoPago tipoPago, enumEstadoOrden estadoOrden, DateTime fecha)
        {
            this.idOrden = idOrden;
            this.infCliente = infCliente;
            this.productos = productos;
            this.precioTotal = precioTotal;
            this.tipoPago = tipoPago;
            this.estadoOrden = estadoOrden;
            Fecha = fecha;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abastecedor_Estrella
{
    public class Producto
    {
        public int idProducto { get; set; }
        public int cantidad { get; set; }
        public String descripcion { get; set; }
        public double precio { get; set; }

        public Producto(int idProducto, int cantidad, string descripcion, double precio)
        {
            this.idProducto = idProducto;
            this.cantidad = cantidad;
            this.descripcion = descripcion;
            this.precio = precio;
        }

    }
}

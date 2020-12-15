using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abastecedor_Estrella
{
    class Direccion
    {
        String Provincia { get; set; }
        String Canton { get; set; }
        String Distrito { get; set; }
        String Detalle { get; set; }

        public Direccion(string provincia, string canton, string distrito, string detalle)
        {
            Provincia = provincia;
            Canton = canton;
            Distrito = distrito;
            Detalle = detalle;
        }
    }
}

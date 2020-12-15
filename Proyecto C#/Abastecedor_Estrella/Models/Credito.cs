using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abastecedor_Estrella
{
    enum enumProveedorTarjeta { Visa, MasterCard }
    class Credito
    {
        public int NumTarjeta { get; set; }
        public DateTime FecVencimiento { get; set; }
        public int Codigo { get; set; }
        public enumProveedorTarjeta Proveedor { get; set; }

        public Credito(int numTarjeta, DateTime fecVencimiento, int codigo, enumProveedorTarjeta proveedor)
        {
            NumTarjeta = numTarjeta;
            FecVencimiento = fecVencimiento;
            Codigo = codigo;
            Proveedor = proveedor;
        }
    }
}

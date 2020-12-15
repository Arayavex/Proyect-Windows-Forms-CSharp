using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Abastecedor_Estrella
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

             Login LoginForm = new Login();
               LoginForm.Show();
              Application.Run(); 


            /** Form_Productos productos = new Form_Productos();
             productos.Show();
             Application.Run();**/

            /** Dash_Admin admin = new Dash_Admin();
             admin.Show();
             Application.Run();**/


          /**  Form form = new Forms_Paises();
            form.Show();
            Application.Run();**/

        }
    }
}

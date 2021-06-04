using System;
using System.Collections.Generic;
using System.Text;
using EntidadesCompartidas;

namespace Persistencia
{
    internal class Conexion
    {
        public static string Cnn()
        {
            return "Data Source=.; Initial Catalog = TiendaCrediYi; Integrated Security = true;";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Persistencia;

namespace Logica
{
    public class FabricaLogica
    {
        public static ILogicaCliente getLogicaCliente()
        {
            return (LogicaCliente.GetInstancia());
        }

        public static ILogicaCompraCabezal getLogicaCompraCabezal()
        {
            return (LogicaCompraCabezal.GetInstancia());
        }

        public static ILogicaProducto getLogicaProducto()
        {
            return (LogicaProducto.GetInstancia());
        }

        public static ILogicaEmpleado GetLogicaEmpleado()
        {
            return (LogicaEmpleado.GetInstancia());
        }

    }
}

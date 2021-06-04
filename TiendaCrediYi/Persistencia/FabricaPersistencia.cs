using System;
using System.Collections.Generic;
using System.Text;

namespace Persistencia
{
    public class FabricaPersistencia
    {
        public static IPersistenciaCliente getPersistenciaCliente()
        {
            return (PersistenciaCliente.GetInstancia());
        }

        public static IPersistenciaCompraCabezal getPersistenciaCompraCabezal()
        {
            return (PersistenciaCompraCabezal.GetInstancia());
        }

        public static IPersistenciaProducto getPersistenciaProducto()
        {
            return (PersistenciaProducto.GetInstancia());
        }

        public static IPersistenciaEmpleado GetPersistenciaEmpleado()
        {
            return (PersistenciaEmpleado.GetInstancia());
        }

    }
}

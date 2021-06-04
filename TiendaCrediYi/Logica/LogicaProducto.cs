using System;
using System.Collections.Generic;
using System.Text;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    internal class LogicaProducto:ILogicaProducto
    {
        //Patron singleton 
        private static LogicaProducto _instancia = null;
        private LogicaProducto() { }

        public static LogicaProducto GetInstancia()

        {
            if (_instancia == null)
                _instancia = new LogicaProducto();
            return _instancia;
        }

        public Producto BuscarProducto(int pIdProducto)
        {
            IPersistenciaProducto producto= FabricaPersistencia.getPersistenciaProducto();
            return (producto.BuscarProducto(pIdProducto));
        }

        public List<Producto> ListarProducto()
        {
            return FabricaPersistencia.getPersistenciaProducto().ListarProducto();
        }

    }
}

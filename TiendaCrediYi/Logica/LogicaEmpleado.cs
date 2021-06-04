using System;
using System.Collections.Generic;
using System.Text;
using Persistencia;
using EntidadesCompartidas;

namespace Logica
{
    internal class LogicaEmpleado: ILogicaEmpleado
    {
        //Patron singleton 
        private static LogicaEmpleado _instancia = null;
        private LogicaEmpleado() { }

        public static LogicaEmpleado GetInstancia()

        {
            if (_instancia == null)
                _instancia = new LogicaEmpleado();
            return _instancia;
        }

        public Empleado Logueo(int pDocumento, string pContrasena)
        {
            IPersistenciaEmpleado Empleado = FabricaPersistencia.GetPersistenciaEmpleado();
            return (Empleado.Logueo(pDocumento, pContrasena));
        }
        
    }
}

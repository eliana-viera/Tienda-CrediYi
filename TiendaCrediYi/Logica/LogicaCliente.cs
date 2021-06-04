using System;
using System.Collections.Generic;
using System.Text;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    internal class LogicaCliente:ILogicaCliente
    {
        //Patron singleton 
        private static LogicaCliente _instancia = null;
        private LogicaCliente() { }

        public static LogicaCliente GetInstancia()

        {
            if (_instancia == null)
                _instancia = new LogicaCliente();
            return _instancia;
        }

        public Cliente BuscarCliente(int pIdCliente)
        {
            IPersistenciaCliente _cliente = FabricaPersistencia.getPersistenciaCliente();
            return (_cliente.BuscarCliente(pIdCliente));
        }

        public Cliente BuscarClienteXDoc(int pDoc)
        {
            IPersistenciaCliente _cliente = FabricaPersistencia.getPersistenciaCliente();
            return (_cliente.BuscarClienteXCedula(pDoc));
        }
    }
}

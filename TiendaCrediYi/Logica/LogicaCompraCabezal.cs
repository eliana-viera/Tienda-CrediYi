using System;
using System.Collections.Generic;
using System.Text;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    internal class LogicaCompraCabezal:ILogicaCompraCabezal
    {
        //Patron singleton 
        private static LogicaCompraCabezal _instancia = null;
        private LogicaCompraCabezal() { }

        public static LogicaCompraCabezal GetInstancia()

        {
            if (_instancia == null)
                _instancia = new LogicaCompraCabezal();
            return _instancia;
        }

        public void AgregarCompraCabezal(CompraCabezal pComp)
        {
            if (pComp.Fecha >= DateTime.Now.Date)
                FabricaPersistencia.getPersistenciaCompraCabezal().AgregarCompraCabezal(pComp);
            else
                throw new Exception("La fecha debe ser mayor o igual a la de hoy.");
        }

        public List<CompraCabezal> ListarCompraCabezal()
        {
            IPersistenciaCompraCabezal _cabezal = FabricaPersistencia.getPersistenciaCompraCabezal();
            return _cabezal.ListarCompraCabezal();
        }

        public List<CompraCabezal> ListarCompraCliente(int pdoc)
        {
            IPersistenciaCompraCabezal _cabezal = FabricaPersistencia.getPersistenciaCompraCabezal();
            return _cabezal.ListarCompraCliente(pdoc);
        }

        public CompraCabezal BuscarCabezal(int pIdCabezal)
        {
            IPersistenciaCompraCabezal _cabezal = FabricaPersistencia.getPersistenciaCompraCabezal();
            return (_cabezal.BuscarCabezal(pIdCabezal));
        }
    }
}

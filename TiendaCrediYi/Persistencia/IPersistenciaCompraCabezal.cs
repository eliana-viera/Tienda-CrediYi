using System;
using System.Collections.Generic;
using System.Text;
using EntidadesCompartidas;

namespace Persistencia
{
    public interface IPersistenciaCompraCabezal
    {
        void AgregarCompraCabezal(CompraCabezal pComp);
        CompraCabezal BuscarCabezal(int pIdCabezal);
        List<CompraCabezal> ListarCompraCabezal();
        List<CompraCabezal> ListarCompraCliente(int pdoc);
    }
}

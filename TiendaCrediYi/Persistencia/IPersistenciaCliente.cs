using System;
using System.Collections.Generic;
using System.Text;
using EntidadesCompartidas;

namespace Persistencia
{
    public interface IPersistenciaCliente
    {
        Cliente BuscarCliente(int pIdCliente);

        Cliente BuscarClienteXCedula(int pDocumento);
    }
}

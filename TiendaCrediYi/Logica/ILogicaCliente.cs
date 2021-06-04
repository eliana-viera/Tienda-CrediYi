using System;
using System.Collections.Generic;
using System.Text;
using EntidadesCompartidas;

namespace Logica
{
    public interface ILogicaCliente
    {
        Cliente BuscarCliente(int pIdCliente);

        Cliente BuscarClienteXDoc(int pDoc);
    }
}

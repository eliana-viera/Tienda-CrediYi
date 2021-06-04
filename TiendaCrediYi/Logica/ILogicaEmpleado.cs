using System;
using System.Collections.Generic;
using System.Text;
using EntidadesCompartidas;

namespace Logica
{
    public interface ILogicaEmpleado
    {
        Empleado Logueo(int pDocumento, string pContrasena);
    }
}

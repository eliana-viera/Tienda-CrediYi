using System;
using System.Collections.Generic;
using System.Text;
using EntidadesCompartidas;

namespace Persistencia
{
    public interface IPersistenciaEmpleado
    {
        Empleado Logueo(int pDocumento, string pContrasena);
    }
}

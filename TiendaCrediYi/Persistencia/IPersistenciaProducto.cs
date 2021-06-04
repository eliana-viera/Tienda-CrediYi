using System;
using System.Collections.Generic;
using System.Text;
using EntidadesCompartidas;

namespace Persistencia
{
    public interface IPersistenciaProducto
    {
        Producto BuscarProducto(int pIdProducto);
        List<Producto> ListarProducto();
    }
}

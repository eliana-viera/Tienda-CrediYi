using System;
using System.Collections.Generic;
using System.Text;
using EntidadesCompartidas;

namespace Logica
{
    public interface ILogicaProducto
    {
        Producto BuscarProducto(int pIdProducto);
        List<Producto> ListarProducto();
    }
}

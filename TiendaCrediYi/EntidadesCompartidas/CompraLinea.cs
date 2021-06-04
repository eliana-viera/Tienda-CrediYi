using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesCompartidas
{
    public class CompraLinea
    {
        private int idLinea;
        private Producto producto;
        private int cantidad;

        public int IdLinea
        {
            get { return idLinea; }
            set { idLinea = value; }
        }

        public Producto Producto
        {
            get { return producto; }
            set { producto = value; }
        }

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public CompraLinea(Producto pProducto, int pCantidad)
        {
            Producto = pProducto;
            Cantidad = pCantidad;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesCompartidas
{
    public class Producto
    {
        private int idProducto;
        private string descripcion;
        private decimal importe;

        public int IdProducto
        {
            get { return idProducto; }
            set { idProducto = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public decimal Importe
        {
            get { return importe; }
            set { importe = value; }
        }

        public Producto(int pIdProducto, string pDescripcion, decimal pImporte)
        {
            IdProducto = pIdProducto;
            Descripcion = pDescripcion;
            Importe = pImporte;
        }
    }
}
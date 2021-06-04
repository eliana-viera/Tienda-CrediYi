using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesCompartidas
{
    public class CompraCabezal
    {
        private int idCabezal;
        private string serie;
        private int numero;
        private Cliente cliente;
        private DateTime fecha;
        private decimal totalCompra;

        private List<CompraLinea> lineas;

        public int IdCabezal
        {
            get { return idCabezal; }
            set { idCabezal = value; }
        }

        public string Serie
        {
            get { return serie; }
            set { serie = value; }
        }

        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }
        public Cliente Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public decimal TotalCompra
        {
            get { return totalCompra; }
        }
        public decimal calcTotalCompra()
        {
            decimal total = 0;

            foreach (CompraLinea compLinea in Lineas)
            {
                total += compLinea.Producto.Importe * compLinea.Cantidad;
            }
            return total;
        }
        public List<CompraLinea> Lineas
        {
            get { return lineas; }
            set
            {
                lineas = value;
                totalCompra = calcTotalCompra();
            }
        }
        public CompraCabezal(int pIdCabezal, string pSerie, int pNum, Cliente pCliente, DateTime pFecha, List<CompraLinea> plineas)
        {
            IdCabezal = pIdCabezal;
            Serie = pSerie;
            Numero = pNum;
            Cliente = pCliente;
            Fecha = pFecha;
            Lineas = plineas;
        }

    }
}
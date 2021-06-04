using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.html;
using System.Web.UI.HtmlControls;
using System.IO;

namespace SitioWeb
{
    public partial class ReporteCompras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Empleado Emp = (Empleado)Session["EmpleadoLogueado"];

            if (Emp == null)
            {
                Response.Redirect("index.aspx");
            }

            List<CompraCabezal> listaCabezal = FabricaLogica.getLogicaCompraCabezal().ListarCompraCabezal();
 
            var resultado = (from listaC in listaCabezal
                             from p in listaC.Lineas
                             select new
                             {
                                Serie = listaC.Serie,
                                Numero = listaC.Numero,
                                Cliente = listaC.Cliente.Nombre,
                                Producto = p.Producto.Descripcion,
                                Fecha = listaC.Fecha.Date,
                                Total = listaC.TotalCompra
                             }).ToList();

            gvCompras.DataSource = resultado;
            gvCompras.DataBind();
        }


        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session["EmpleadoLogueado"] = null;
            Response.Redirect("index.aspx");
        }  










        public override void VerifyRenderingInServerForm(Control control)
        {
           
        }

        protected void btnPDF_Click(object sender, EventArgs e)
        {
           
        }

       

    }
}
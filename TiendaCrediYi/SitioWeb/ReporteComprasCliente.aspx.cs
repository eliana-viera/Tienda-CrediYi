using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;

namespace SitioWeb
{
    public partial class ReporteComprasCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Empleado Emp = (Empleado)Session["EmpleadoLogueado"];

            if (Emp == null)
            {
                Response.Redirect("index.aspx");
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {

                Cliente cli = FabricaLogica.getLogicaCliente().BuscarClienteXDoc(Convert.ToInt32(txtCliente.Text));

                if (cli != null)
                {

                    List<CompraCabezal> listaC = FabricaLogica.getLogicaCompraCabezal().ListarCompraCliente(Convert.ToInt32(txtCliente.Text));

                    if (listaC.Count != 0)
                    {
                        gvCompras.DataSource = listaC;
                        gvCompras.DataBind();
                    }
                    else
                    {
                        lblError.Text = "El cliente no tiene compras generadas";
                    }
                }
                else
                {
                    lblError.Text = "El cliente no existe";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }

        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCliente.Text = "";
            gvCompras.DataSource = null;
            gvCompras.DataBind();
            gvDetalle.DataSource = null;
            gvDetalle.DataBind();
            lblError.Text = "";

        }

        protected void gvCompras_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(gvCompras.SelectedRow.Cells[1].Text);
                    
                CompraCabezal cabezal = FabricaLogica.getLogicaCompraCabezal().BuscarCabezal(id);
 
                if(cabezal != null)
                 {
                    gvDetalle.DataSource = cabezal.Lineas;
                    gvDetalle.DataBind();
                }
            }
               catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session["EmpleadoLogueado"] = null;
            Response.Redirect("index.aspx");
        }
    }
}
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
    public partial class RegistroCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

           if (!IsPostBack)
           {
               Empleado Emp = (Empleado)Session["EmpleadoLogueado"];

               if (Emp == null)
               {
                   Response.Redirect("index.aspx");
               }

               lblError.Text = "";

               List<Producto> prod = FabricaLogica.getLogicaProducto().ListarProducto();

               Session["Producto"] = prod;

               ddlProducto.DataSource = prod;
               ddlProducto.DataTextField = "Descripcion";
               ddlProducto.DataValueField = "IdProducto";
               ddlProducto.DataBind();
           }

        }

        protected void LimpiarFormulario()
        {
            CldFecha.SelectedDate = DateTime.Today;
            txtSerie.Text = "";
            txtNumero.Text = "";
            TxtCantidad.Text = "";
            txtCliente.Text = "";
            gvProductos.DataSource = null;
            gvProductos.DataBind();
            BtnAgregar.Enabled = false;

            Session["Lineas"] = null;
        }

        protected void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            int _codProd;
            int _cantidad;
            CompraLinea _linea;
            List<CompraLinea> Listalineas;

            Listalineas = (List<CompraLinea>)Session["Lineas"];

            if (Listalineas == null)
            {
                Listalineas = new List<CompraLinea>();
            }

            List<Producto> articulos = (List<Producto>)Session["Producto"];

            try
            {
                _codProd = Convert.ToInt32(ddlProducto.SelectedValue);
                _cantidad = Convert.ToInt32(TxtCantidad.Text);

                Producto _producto = FabricaLogica.getLogicaProducto().BuscarProducto(_codProd);

                if (_producto == null)
                {
                    throw new Exception("El producto no existe");
                }
                else
                {
                    foreach (CompraLinea L in Listalineas)
                    {
                        if (L.Producto.IdProducto == _codProd)
                        {

                            return; 
                        }
                    }

                    _linea = new CompraLinea(_producto, _cantidad);

                    Listalineas.Add(_linea);

                    Session["Lineas"] = Listalineas;

                    gvProductos.DataSource = Listalineas;
                    gvProductos.DataBind();
                }
            
                BtnAgregar.Enabled = true;
                TxtCantidad.Text = "";
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }


        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            string _serie = txtSerie.Text.ToUpper().Trim();
            int _numeroSerie = Convert.ToInt32(txtNumero.Text);
            DateTime _fecha = Convert.ToDateTime(CldFecha.SelectedDate);;
            Cliente _cli = null;
            List<CompraLinea> ListaC = (List<CompraLinea>)Session["Lineas"];
            CompraCabezal C;

            try
            {
                _cli = FabricaLogica.getLogicaCliente().BuscarClienteXDoc(Convert.ToInt32(txtCliente.Text));
               
                if (txtCliente.Text.Length <= 0 )
                {
                    lblError.Text = "Debe ingresar un cliente";
                    return;
                }

                if (_cli == null)
                {
                    lblError.Text = "El cliente no existe";
                    return;
                }
                else
                {
                    C = new CompraCabezal(0, _serie, _numeroSerie, _cli, _fecha, ListaC);
                    FabricaLogica.getLogicaCompraCabezal().AgregarCompraCabezal(C);
                    lblError.ForeColor = System.Drawing.Color.Green;
                    lblError.Text = "Alta con éxito";

                    LimpiarFormulario();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void BtnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        protected void gvProductos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txtCliente_TextChanged(object sender, EventArgs e)

        {

  
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session["EmpleadoLogueado"] = null;
            Response.Redirect("index.aspx");
        }
    }
}
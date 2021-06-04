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
    public partial class InicioEmpleado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Empleado Emp = (Empleado)Session["EmpleadoLogueado"];

            if (Emp == null)
            {
                Response.Redirect("index.aspx");
            }
        }
    }
}
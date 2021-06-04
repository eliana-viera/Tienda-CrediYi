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
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BtnIngresar_Click(object sender, EventArgs e)
        {
            int Cedula = 0;
            string Contrasena = "";

            if (txtCedula.Text.Trim().Length != 0)
            {
                try
                {
                    Cedula = Convert.ToInt32(txtCedula.Text);
                    if (Cedula < 10000000 || txtCedula.Text.Trim().Length != 8)
                    {
                        lblError.Text = "La cedula debe tener 8 caracteres";
                        return;
                    }
                }
                catch
                {
                    lblError.Text = "La Cedula debe ser numérica";
                    return;
                }
            }
            else
            {
                lblError.Text = "Ingrese una Cedula";
                return;
            }

            if (txtContrasena.Text.Trim().Length != 0)
            {
                Contrasena = txtContrasena.Text;
            }
            else
            {
                lblError.Text = "Ingrese la contraseña";
                return;
            }


            try
            {
                Empleado _Emp = null;
                _Emp = FabricaLogica.GetLogicaEmpleado().Logueo(Cedula, Contrasena);

                Session["EmpleadoLogueado"] = _Emp;

                 if (_Emp != null)
                {
                    Response.Redirect("InicioEmpleado.aspx");
                }
                else
                {
                    lblError.Text = "Cedula y/o contraseña incorrectas";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

    }
}
using SistemasIIITHEGYM.BussinesLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemasIIITHEGYM
{
    public partial class ConsultarCobrodeCuotaEmpleado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                panelconsulta.Visible = true;
                paneldatosdecobro.Visible = false;
                panelconsulta.Focus();
            }
            if (Session["inicio"] != null)
            {
                //declaramos una variale sesion para mantener el dato del usuario
                string usuario = (string)Session["Usuario"];
                lblusuario.Text = "Bienvenido/a " + (String)Session["inicio"];

            }
            else
            {
                //si no se ha iniciado sesion me manda al inicio
                //Response.Redirect("InicioLogin.aspx");
            }
        }

        protected void btnconsultar_Click(object sender, EventArgs e)
        {
            try
            {
                TheGym k = new TheGym
                {
                    ClienteCuota = tbbusqueda.Text
                };

                DataTable dt = k.GetCuota();
                if (dt.Rows.Count > 0)
                {
                    gridcuota.DataSource = dt;
                    gridcuota.DataBind();
                    lblerror.Text = "";
                }
                else
                {
                    lblerror.Text = "No se encontraron coincidencias";
                }
            }
            catch (Exception ex)
            {

                lblerror.Text=ex.Message.ToString();
            }

        }
    }
}
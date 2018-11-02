using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SistemasIIITHEGYM.BussinesLayer;
using System.Data;

namespace SistemasIIITHEGYM
{
    public partial class InicioGerente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            panelcobrodeplanes.Visible = false;
            panelproductos.Visible = false;
            if (Session["inicio"] != null)
            {
                //declaramos una variale sesion para mantener el dato del usuario
                string usuario = (string)Session["Usuario"];
                lblusuario.Text = "Bienvenido/a " + (String)Session["inicio"];
                /*if (Request.Params["parametro"] != null)
                {
                    //para que el label capte el nombre y apellido enviado desde el form de acceso
                    lblmensajebienvenida.Text = "Bienvenido " + Request.Params["parametro"];
                }
                else
                {
                    //si no, muestra un mensaje de bienvenida solamente
                    lblmensajebienvenida.Text = "Bienvenido";
                }
                */

            }
            else
            {
                //si no se ha iniciado sesion me manda al inicio
                //Response.Redirect("InicioLogin.aspx");
            }

            TheGym k = new TheGym();
            DataTable dt = k.GetAllPlanEstadistica();
            lblplanes.Text = dt.Rows[0][0].ToString();


            DataTable dt1 = k.GetAsistenciaEstadistica();
            lblasistencias.Text = dt1.Rows[0][0].ToString();
        }

        protected void btnverestadisticascobro_Click(object sender, EventArgs e)
        {
            panelcobrodeplanes.Visible = true;
            panelproductos.Visible = false;
        }

        protected void btnverestadisticaventasproducto_Click(object sender, EventArgs e)
        {
            panelproductos.Visible = true;
            panelcobrodeplanes.Visible = false;
        }
    }
}
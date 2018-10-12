using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemasIIITHEGYM
{
    public partial class RegistrarOrdendeCompraGerente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //aqui debemos verificar si la apertura de caja esta hecha o no, si no redireccionamos con estos
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#modal-redirect').modal('show');", true);
                // Response.AddHeader("REFRESH", "3;URL=AperturadeCajaEmpleado.aspx");
                //tbnombre.Enabled = false;
                //btnconsultar.Enabled =false;
                //si no, me manda a la pagina de apertura de caja a los 3 segundos



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
                panelseleccionarproveedor.Visible = true;
                panelregistrarorden.Visible = false;
            }
        }

        protected void gridcliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelseleccionarproveedor.Visible = false;
            panelregistrarorden.Visible = true;
        }
    }
}
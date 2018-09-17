using SistemasIIITHEGYM.BussinesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemasIIITHEGYM
{
    public partial class RegistrarSucursalGerente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
        }

        protected void btnregistrar_Click(object sender, EventArgs e)
        {
            //string Nombre;
            //string Direccion;
            //int Telefono;

            //Nombre = tbnombre.Text;
            //Direccion = tbdireccion.Text;
            //Telefono = Convert.ToInt16(tbtelefono.Text);

            TheGym k = new TheGym
            {
                NombreSucursal = tbnombre.Text,
                //falta lo de la direccion
                TelefonoSucursal = Convert.ToInt64(tbtelefono.Text)
            };

            k.AddNewSucursal();


            tbnombre.Text = string.Empty;
            tbtelefono.Text = string.Empty;
        }
    }
}
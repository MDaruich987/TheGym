using SistemasIIITHEGYM.BussinesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemasIIITHEGYM
{
    public partial class RegistrarClienteEmpleado : System.Web.UI.Page
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

            //Configuracion para registrar cliente en la base de datos
            //Creo el objeto k
            TheGym k = new TheGym
            {
                NombreCliente = tbnombre.Text,
                ApellidoCliente = tbapellido.Text,
                EmailCliente = tbemail.Text,
                FechaCliente = tbfechadenacimiento.Text,
                TelefonoCliente = tbtelefono.Text,
               //falta la parte del domicilio
            };

            try
            {
                k.AddNewCliente();
                lblerror.Text = ("Cliente registrado con éxito.");

            }
            catch
            {

            }
            tbnombre.Text = string.Empty;
            tbapellido.Text = string.Empty;
            tbfechadenacimiento.Text = string.Empty;
            tbemail.Text = string.Empty;
            //daltan algunos

        }

        protected void btncancelar_Click1(object sender, EventArgs e)
        {

        }
    }
    }

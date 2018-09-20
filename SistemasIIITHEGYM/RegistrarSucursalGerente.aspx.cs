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
    public partial class RegistrarSucursalGerente : System.Web.UI.Page
    {
        static bool flag = true;

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

            if (flag == true)
            {
                CargarLocalidades();
                flag = false;
            }
            
        }

        public void CargarLocalidades()
        {
            try
            {
                TheGym k = new TheGym();
                DataTable dt = new DataTable();
                dt = k.GetAllLocalidades();
                if (dt.Rows.Count > 0)
                {
                    ddllocalidad.DataTextField = "Nombre";
                    ddllocalidad.DataValueField = "CodigoPostal";
                    ddllocalidad.DataSource = dt;
                    ddllocalidad.DataBind();
                }
            }
            catch (Exception ex)
            {

                lblerror.Text=ex.Message.ToString();
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
                CalleSucursal = tbcalle.Text,
                BarrioSucursal = tbbarrio.Text,
                NumeroSucursal = tbnumerocasa.Text,
                FKLocalidadSucursal = ddllocalidad.SelectedValue,
                TelefonoSucursal = Convert.ToInt64(tbtelefono.Text)
            };

            k.AddNewSucursal();

            ddllocalidad.ClearSelection();
            tbcalle.Text = string.Empty;
            tbbarrio.Text = string.Empty;
            tbnumerocasa.Text = string.Empty;
            tbnombre.Text = string.Empty;
            tbtelefono.Text = string.Empty;
            lblerror.Text = "Sucursal registrada con exito!.";
        }
    }
}
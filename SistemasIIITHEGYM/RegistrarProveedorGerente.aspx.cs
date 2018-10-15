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
    public partial class RegistrarProveedorGerente : System.Web.UI.Page
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

            CargarLocalidades();
        }

        public void CargarLocalidades()
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

        protected void btnregistrar_Click(object sender, EventArgs e)
        {
            TheGym k = new TheGym
            {
                NombreProveedor = tbnombre.Text,
                CUITProveedor= tbcuit.Text,
                EmailProveedor = tbemail.Text,
                RepresentanteProveedor= tbrepresentante.Text,
                TelefonoProveedor = tbtelefono.Text,
                CalleProveedor = tbcalle.Text,
                NumCasaProveedor = tbnumerocasa.Text,
                FKLocalidadProveedor=ddllocalidad.SelectedValue,
            };
            try
            {
                k.AddNewProveedor();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#modal-default').modal('show');", true);

            }
            catch (Exception ex)
            {
                lblerror.Text = ex.Message.ToString();
            }
         

            tbnombre.Text = string.Empty;
            tbcuit.Text = string.Empty;
            tbrepresentante.Text = string.Empty;
            tbemail.Text = string.Empty;
            tbcalle.Text = string.Empty;
            tbnumerocasa.Text = string.Empty;
            tbtelefono.Text = string.Empty;
            ddllocalidad.ClearSelection();
            
        }
    }
}
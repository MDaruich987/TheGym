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
    public partial class RegistrarActividadesEmpleado : System.Web.UI.Page
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

            if (!IsPostBack)
            {
                GetProfesores();
                GetSucursales();
            }

        }

        private void GetProfesores()
        {
            TheGym k = new TheGym();
            DataTable dt = k.GetProfesores();
            if (dt.Rows.Count > 0)
            {
                ddlprofesor.DataValueField = "Id_empleado";
                ddlprofesor.DataTextField = "Profesor";
                ddlprofesor.DataSource = dt;
                ddlprofesor.DataBind();

            }
        }

        private void GetSucursales()
        {
            TheGym k = new TheGym();
            DataTable dt = k.GetSucursales();
            if (dt.Rows.Count > 0)
            {
                ddlsucursal.DataValueField = "Id_sucursal";
                ddlsucursal.DataTextField = "Nombre";
                ddlsucursal.DataSource = dt;
                ddlsucursal.DataBind();
            }
        }

        protected void btnregistrar_Click(object sender, EventArgs e)
        {
            TheGym k = new TheGym
            {
                NombreActividad = tbnombre.Text,
                ProfesorActividad = ddlprofesor.SelectedValue,
                SucursalActividad = ddlsucursal.SelectedValue,
                CuposActividad = ddlcupos.SelectedValue,
                DescripcionActividad = tbdescripcion.Text
            };

            try
            {
                k.AddNewActividad();
                lblerror.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#modal-default').modal('show');", true);
                tbnombre.Text = string.Empty;
                tbdescripcion.Text = string.Empty;

                ddlcupos.ClearSelection();
                ddlprofesor.ClearSelection();
                ddlsucursal.ClearSelection();

            }
            catch
            {
                lblerror.Text = "Error al registrar Actividad.";
            }


        }
    }
}
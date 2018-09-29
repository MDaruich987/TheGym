using SistemasIIITHEGYM.BussinesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemasIIITHEGYM
{
    public partial class ConsultarEjercicioEntrenador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //la primera vez que se carga la página
                //muestra el panel de  busqueda, no el de edicion
                panelgeneral.Focus();
                panelregistro.Visible = false;

                //lblmensajebienvenida.Text = Session["inicio"].ToString();
                //si efectivamente se ha iniciado sesión
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
        }

        protected void gridejercicios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                panelgeneral.Visible = false;
                panelregistro.Visible = true;
                panelregistro.Focus();
            }
            catch (Exception ex)
            {

                lblerror.Text=ex.Message.ToString();
            }
        }

        protected void btneditar_Click(object sender, EventArgs e)
        {

            if (btneditar.Text == "Editar")
            {
                //significa que estaba viendo y ahora quiere editar
                //habilitamos los controles
                btneditar.Text = "Guardar";
                btneditar.CausesValidation = true;
                btnVolver.Text = "Cancelar";
                btnVolver.Visible = true;



            }
            else
            {
                //aqui va el codigo para registrar los cambios

             }

            }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            //significa que estaba viendo y ahora vuelve a la busqueda
            btneditar.CausesValidation = false;
            btnVolver.CausesValidation = false;
            panelgeneral.Visible = true;
            panelregistro.Visible = false;
            panelgeneral.Focus();
            lblerror.Text = "";
            btneditar.Text = "Editar";
            btnVolver.Text = "Volver";
        }
    }


    }

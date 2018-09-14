using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemasIIITHEGYM
{
    public partial class ConsultarSucursal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //la primera vez que se carga la página
                //muestra el panel de  busqueda, no el de edicion
                panelconsulta.Focus();
                paneledicion.Visible = false;
            }
        }

        protected void btnconsultar_Click(object sender, EventArgs e)
        {

        }

        protected void btneditar_Click(object sender, EventArgs e)
        {
            if (btneditar.Text == "Editar")
            {
                //significa que estaba viendo los campos y ahora quiere editar
                //mandamos todos los valores de los campos al panel de edicion
            }
            else
            {
                //aqui va el codigo para registrar los cambios
            }
        }

        protected void btnvolver_Click(object sender, EventArgs e)
        {
            //significa que estaba viendo y ahora vuelve a la busqueda
            btneditar.CausesValidation = false;
            btnvolver.CausesValidation = false;
            panelconsulta.Visible = true;
            paneledicion.Visible = false;
            panelconsulta.Focus();
            lblerror.Text = "";
            btneditar.Text = "Editar";
            btnvolver.Text = "Volver";
        }

        protected void gridplanes_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cuando seleccionamos una fila del grid
            try
            {
                //mostrar un panel y ocultar otro
                panelconsulta.Visible = false;
                paneledicion.Visible = true;
                paneledicion.Focus();
                //codigo para cargar los valores de la fila en los textbox del panel de edicion

            }
            catch (Exception ex)
            {

                lblerror.Text = ex.Message.ToString();
            }
        }
    }
}
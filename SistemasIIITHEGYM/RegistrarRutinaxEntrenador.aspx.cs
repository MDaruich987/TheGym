using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemasIIITHEGYM
{
    public partial class RegistrarRutinaxEntrenador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            panelconsulta.Visible = true;
            paneledicion.Visible = false;
        }

        protected void btnconsultar_Click(object sender, EventArgs e)
        {

        }

        protected void btnañadir_Click(object sender, EventArgs e)
        {

        }

        protected void btnregistrar_Click(object sender, EventArgs e)
        {
            //mensaje de exito de registro
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#modal-default').modal('show');", true);
        }

        protected void btncancelar_Click(object sender, EventArgs e)
        {
            

        }

        protected void griddetallerutina_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelconsulta.Visible = false;
            paneledicion.Visible = false;
        }
    }
}
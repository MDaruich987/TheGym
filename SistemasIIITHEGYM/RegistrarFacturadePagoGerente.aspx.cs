using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemasIIITHEGYM
{
    public partial class RegistrarFacturadePagoGerente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnregistrar_Click(object sender, EventArgs e)
        {
            //mensaje de exito
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#modal-default').modal('show');", true);
        }

        protected void btncancelar_Click(object sender, EventArgs e)
        {

        }

        protected void btnserviciopopup_Click(object sender, EventArgs e)
        {

        }

        protected void btnordencomprapopup_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#modal-ordencompra').modal('show');", true);
        }
    }
}
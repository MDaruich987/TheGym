using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemasIIITHEGYM
{
    public partial class ConsultarFacturadePagoGerente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnconsultar_Click(object sender, EventArgs e)
        {

        }

        protected void gridfactura_SelectedIndexChanged(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#modal-detalle').modal('show');", true);
        }

        protected void griddetallefactura_SelectedIndexChanged(object sender, EventArgs e)
        {
            //este es el grid del modal del popup
        }
    }
}
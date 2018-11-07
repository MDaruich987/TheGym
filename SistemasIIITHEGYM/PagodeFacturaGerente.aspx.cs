using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemasIIITHEGYM
{
    public partial class PagodeFacturaGerente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#modal-Detalle').modal('show');", true);
        }

        protected void btnconsultar_Click(object sender, EventArgs e)
        {

        }

        protected void Pagofactura_Click(object sender, EventArgs e)
        {
            //boton del modal que registra el pago de la facura
        }

        protected void gridfacturas_SelectedIndexChanged(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#modal-Detalle').modal('show');", true);
        }

        protected void griddetallefactura_SelectedIndexChanged(object sender, EventArgs e)
        {
            //grid que muestra el detalle de la factura del popup
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemasIIITHEGYM
{
    public partial class RegistrarFacturadeVentaEmpleado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            generarPDF.Visible = false;
            btnuevaFactura.Visible = false;
        }

        protected void botonconsultarproductos_Click(object sender, EventArgs e)
        {

        }

        protected void gvproductos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void tbcliente_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnañadirproductomodal_Click(object sender, EventArgs e)
        {

        }

        protected void btnañadirproducto_Click(object sender, EventArgs e)
        {
          ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#modal-añadirproductos').modal('show');", true);

        }

        protected void btncancelar_Click(object sender, EventArgs e)
        {

        }

        protected void generarPDF_Click(object sender, EventArgs e)
        {

        }

        protected void btnuevaorden_Click(object sender, EventArgs e)
        {
            btnregistrar.Visible = true;
            btncancelar.Visible = true;
            generarPDF.Visible = false;
            btnuevaFactura.Visible = false;
        }

        protected void griddetallefactura_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void griddetallefactura_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void btnregistrar_Click(object sender, EventArgs e)
        {




            //ocultamos el resto de los botones
            btnregistrar.Visible = false;
            btncancelar.Visible = false;
            generarPDF.Visible = true;
            btnuevaFactura.Visible=true;
        }

        protected void btnseleccioncliente_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#modal-cliente').modal('show');", true);
        }
    }
}
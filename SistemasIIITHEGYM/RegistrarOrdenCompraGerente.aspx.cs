using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemasIIITHEGYM
{
    public partial class RegistrarOrdenCompraGerente : System.Web.UI.Page
    {
        //para saber si se ha asignado el nombre del proveedor al label
       // static bool flagproveedor = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            //el panel no se debe habilitar hasta que seleccionemos un proveedor
            //updetalleorden.Visible = false;
        }

        protected void btnselecproveedor_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#modal-proveedor').modal('show');", true);
        }

        protected void tbproveedor_TextChanged(object sender, EventArgs e)
        {
            //habilitamos el panel de detalle recien al seleccionar un proveedor
            //updetalleorden.Visible = true;
        }

        protected void btnañadirproducto_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#modal-añadirproducto').modal('show');", true);
        }

        protected void botonconsultarproductos_Click(object sender, EventArgs e)
        {
            //este es el boton consultar del modal de productos
        }

        protected void btnañadirproductomodal_Click(object sender, EventArgs e)
        {
            //este es el boton para añadir un producto desde el modal 
        }

        protected void btnconsultarproveedorgrid_Click(object sender, EventArgs e)
        {
            //este es el boton consultar proveedor del modal de proveedores
        }

        protected void gvproveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            //este es el grid de proveedores del modal
        }

        protected void griddetallefactura_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //este es el row deleting del grid detalle de factura
        }
    }
}
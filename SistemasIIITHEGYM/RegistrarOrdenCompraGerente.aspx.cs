using SistemasIIITHEGYM.BussinesLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemasIIITHEGYM
{
    public partial class RegistrarOrdenCompraGerente : System.Web.UI.Page
    {
        static string id;
        static string nom;
        static bool flag = false;

        //para saber si se ha asignado el nombre del proveedor al label
       // static bool flagproveedor = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            //el panel no se debe habilitar hasta que seleccionemos un proveedor
            //updetalleorden.Visible = false;

            if (flag == true)
            {
                tbproveedor.Text = nom;
            }

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
            if (tbnombreproductos.Text == "")
            {

            }
            else
            {
                lblerrorproductosmodal.Text = "Ingrese un producto";
            }
        }

        protected void btnañadirproductomodal_Click(object sender, EventArgs e)
        {
            //este es el boton para añadir un producto desde el modal 
        }

        protected void btnconsultarproveedorgrid_Click(object sender, EventArgs e)
        {
            //este es el boton consultar proveedor del modal de proveedores
            try
            {
                if (tbnombreproveedor.Text != string.Empty)
                {
                    TheGym k2 = new TheGym
                    {
                        NombreProveedorBusc = tbnombreproveedor.Text
                    };
                    DataTable dt2 = new DataTable();
                    dt2 = k2.GetProveedorNom();
                    if (dt2.Rows.Count > 0)
                    {
                        lblerrorbuscarmodalproveedor.Text = string.Empty;
                        lblerrorbuscarmodalproveedor.Visible = false;
                        gvproveedoresmodal.DataSource = dt2;
                        gvproveedoresmodal.DataBind();
                        gvproveedoresmodal.Visible = true;
                        lblerrorbuscarmodalproveedor.Visible = true;
                    }
                    else
                    {
                        DataTable dt1 = new DataTable();
                        gvproveedoresmodal.DataSource = dt1;
                        gvproveedoresmodal.DataBind();
                        gvproveedoresmodal.Visible = false;
                        lblerrorbuscarmodalproveedor.Text = "No se encontro proveedor";
                        lblerrorbuscarmodalproveedor.Visible = true;
                    }
                }
                else
                {
                    lblerrorbuscarmodalproveedor.Text = "Ingrese un valor";
                    lblerrorbuscarmodalproveedor.Visible = true;
                }

            }
            catch
            {
                lblerrorbuscarmodalproveedor.Text = "Error general";
                lblerrorbuscarmodalproveedor.Visible = true;
            }
        }

        protected void gvproveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            nom= gvproveedoresmodal.SelectedRow.Cells[1].Text;
            tbproveedor.Text = gvproveedoresmodal.SelectedRow.Cells[1].Text;
            id = gvproveedoresmodal.SelectedRow.Cells[0].Text;
           
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#modal-proveedor').modal('hide');", true);
            flag = true;
            tbproveedor.Text = nom;
            //Page_Load(sender,e);

            ScriptManager.RegisterStartupScript(this, typeof(Page), "jsKeys", "javascript:Forzar();", true);

        }

        protected void griddetallefactura_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //este es el row deleting del grid detalle de factura
        }
    }
}
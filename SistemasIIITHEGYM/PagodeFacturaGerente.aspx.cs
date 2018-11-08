using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SistemasIIITHEGYM.BussinesLayer;
using System.Data;

namespace SistemasIIITHEGYM
{
    public partial class PagodeFacturaGerente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#modal-Detalle').modal('show');", true);
            if (!IsPostBack)
            {
                CargarTipoComprobante();
                CargarProveedores();
            }
            
        }

        protected void CargarProveedores()
        {
            lblerror.Visible = false;
            TheGym k = new TheGym();
            DataTable dt = new DataTable();
            dt = k.GetProveedores();
            if (dt.Rows.Count > 0)
            {
                ddlProveedor.DataTextField = "Nombre";
                ddlProveedor.DataValueField = "Id_proveedor";
                ddlProveedor.DataSource = dt;
                ddlProveedor.DataBind();
                ddlProveedor.Items.Insert(0, "--Seleccione--");
            }
            else
            {
                lblerror.Visible = true;
                lblerror.Text = "No se encontraron servicios";
            }
        }



        protected void CargarTipoComprobante()
        {
            lblerror.Visible = false;
            TheGym k = new TheGym();
            DataTable dt = new DataTable();
            dt = k.GetTipoMovimiento();
            if (dt.Rows.Count > 0)
            {
                ddlTipoComprobante.DataTextField = "Nombre";
                ddlTipoComprobante.DataValueField = "Id_tipocomprobante";
                ddlTipoComprobante.DataSource = dt;
                ddlTipoComprobante.DataBind();
                ddlTipoComprobante.Items.Insert(0, "--Seleccione--");
            }
            else
            {
                lblerror.Visible = true;
                lblerror.Text = "No se encontraron tipos de comprobantes";
            }
        }

        protected void btnconsultar_Click(object sender, EventArgs e)
        {
            lblerror.Visible = false;
            if (ddlTipoComprobante.SelectedItem.Text != "--Seleccione--")
            {
                if(ddlTipoComprobante.SelectedItem.Text != "Factura Proveedor")
                {
                    TheGym k = new TheGym
                    {
                        FacturaFKTipoComp = ddlTipoComprobante.SelectedValue
                    };
                    DataTable dt = new DataTable();
                     

                }
                else
                {

                }
            }
            else
            {
                lblerror.Visible = true;
                lblerror.Text = "Seleccione un tipo de comprobante";
            }
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

        protected void ddlTipoComprobante_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ddlTipoComprobante_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTipoComprobante.SelectedItem.Text == "Factura Proveedor")
            {
                ddlProveedor.Visible = true;
            }
            else
            {
                ddlProveedor.Visible = false;
                ddlProveedor.ClearSelection();
            }
        }
    }
}
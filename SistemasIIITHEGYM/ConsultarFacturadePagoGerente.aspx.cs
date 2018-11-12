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
    public partial class ConsultarFacturadePagoGerente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProveedores();
                CargarServicios();
                CargarTipoComprobante();
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


        protected void CargarServicios()
        {
            lblerror.Visible = false;
            TheGym k = new TheGym();
            DataTable dt = new DataTable();
            dt = k.GetServicios();
            if (dt.Rows.Count > 0)
            {
                ddlServicio.DataTextField = "Nombre";
                ddlServicio.DataValueField = "Id_servicio";
                ddlServicio.DataSource = dt;
                ddlServicio.DataBind();
                ddlServicio.Items.Insert(0, "--Seleccione--");
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
                if (ddlTipoComprobante.SelectedItem.Text == "Factura Proveedor")
                {
                    if (ddlProveedor.SelectedItem.Text != "--Seleccione--")
                    {
                        TheGym k = new TheGym
                        {
                            FacturaFKTipoComp = ddlTipoComprobante.SelectedValue,
                            FacturaIDProv = ddlProveedor.SelectedValue
                        };
                        DataTable dt = new DataTable();
                        dt = k.GetFacturaAllTipoProv();
                        if (dt.Rows.Count > 0)
                        {
                            grid.DataSource = dt;
                            grid.DataBind();
                            grid.Visible = true;
                        }
                        else
                        {
                            lblerror.Visible = true;
                            lblerror.Text = "No hay factura de ese Proveedor.";
                            grid.Dispose();
                            grid.Visible = false;
                        }

                    }
                    else
                    {
                        TheGym k = new TheGym
                        {
                            FacturaFKTipoComp = ddlTipoComprobante.SelectedValue
                        };
                        DataTable dt = new DataTable();
                        dt = k.GetFacturaAllTipoProveedor();
                        if (dt.Rows.Count > 0)
                        {
                            grid.DataSource = dt;
                            grid.DataBind();
                            grid.Visible = true;
                        }
                        else
                        {
                            lblerror.Visible = true;
                            lblerror.Text = "No hay factura de Proveedor.";
                            grid.Dispose();
                            grid.Visible = false;
                        }
                    }

                }
                else
                {
                    if (ddlTipoComprobante.SelectedItem.Text == "Factura Servicio")
                    {
                        if (ddlServicio.SelectedItem.Text != "--Seleccione--")
                        {
                            TheGym k = new TheGym
                            {
                                FacturaFKServicio = ddlServicio.SelectedValue,
                                FacturaFKTipoComp = ddlTipoComprobante.SelectedValue
                            };
                            DataTable dt = new DataTable();
                            dt = k.GetFacturaAllTipoServicio();
                            if (dt.Rows.Count > 0)
                            {
                                grid.DataSource = dt;
                                grid.DataBind();
                                grid.Visible = true;
                            }
                            else
                            {
                                lblerror.Visible = true;
                                lblerror.Text = "No hay factura de ese Servicio.";
                                grid.Dispose();
                                grid.Visible = false;
                            }
                        }
                        else
                        {
                            TheGym k = new TheGym
                            {
                                FacturaFKTipoComp = ddlTipoComprobante.SelectedValue
                            };
                            DataTable dt = new DataTable();
                            dt = k.GetFacturaAllTipoServicios();
                            if (dt.Rows.Count > 0)
                            {
                                grid.DataSource = dt;
                                grid.DataBind();
                                grid.Visible = true;
                            }
                            else
                            {
                                lblerror.Visible = true;
                                lblerror.Text = "No hay factura de Servicio.";
                                grid.Dispose();
                                grid.Visible = false;
                            }
                        }
                    }
                    else
                    {
                        TheGym k = new TheGym
                        {
                            FacturaFKTipoComp = ddlTipoComprobante.SelectedValue
                        };
                        DataTable dt = new DataTable();
                        dt = k.GetFacturaAllTipo();
                        if (dt.Rows.Count > 0)
                        {
                            grid.DataSource = dt;
                            grid.DataBind();
                            grid.Visible = true;
                        }
                        else
                        {
                            lblerror.Visible = true;
                            lblerror.Text = "No hay factura de Otro.";
                            grid.Dispose();
                            grid.Visible = false;
                        }
                    }
                }
            }
            else
            {
                lblerror.Visible = true;
                lblerror.Text = "Seleccione un tipo de comprobante";
            }
        }

        protected void gridfactura_SelectedIndexChanged(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#modal-detalle').modal('show');", true);
        }

        protected void griddetallefactura_SelectedIndexChanged(object sender, EventArgs e)
        {
            //este es el grid del modal del popup
        }

        protected void ddlTipoComprobante_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTipoComprobante.SelectedItem.Text == "Factura Proveedor")
            {
                LblFiltro.Visible = true;
                ddlProveedor.Visible = true;
                LblProveedor.Visible = true;
                LblServicio.Visible = false;
                ddlServicio.Visible = false;
                ddlServicio.ClearSelection();
            }
            else
            {
                if (ddlTipoComprobante.SelectedItem.Text == "Factura Servicio")
                {
                    LblFiltro.Visible = true;
                    LblServicio.Visible = true;
                    ddlServicio.Visible = true;
                    ddlProveedor.Visible = false;
                    LblProveedor.Visible = false;
                    ddlProveedor.ClearSelection();
                }
                else
                {
                    LblFiltro.Visible = false;
                    LblServicio.Visible = false;
                    ddlServicio.Visible = false;
                    ddlServicio.ClearSelection();
                    ddlProveedor.Visible = false;
                    LblProveedor.Visible = false;
                    ddlProveedor.ClearSelection();
                }
            }
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SistemasIIITHEGYM.BussinesLayer;

namespace SistemasIIITHEGYM
{
    public partial class RegistrarFacturadePagoGerente : System.Web.UI.Page
    {
        static string id;
        static string nom;
        static string idOrden;
        static string Total;
        static string IdSucursal;
        static DataTable Tabla;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTipoComprobante();
                CargarServicios();
                CargarProveedores();
                lblFecha.Text = DateTime.Today.ToShortDateString();
                lblhora.Text = DateTime.Now.ToShortTimeString();
                lblnombreusuario.Text = (String)Session["inicio"];

                nom = (String)Session["Usuario"];

                if (nom != null)
                {
                    lblsucursal.Text = EncontrarIdSuc(nom);
                    id = EncontrarIdEmpleado(nom);
                    IdSucursal = EncontrarIdSuc1(nom);
                }
                else
                {
                    lblsucursal.Text = "Central";
                    id = "1";
                    IdSucursal = "3";
                }
                

            }
        }

        protected string EncontrarIdEmpleado(string aux)
        {
            string id;
            TheGym k = new TheGym
            {
                emailbusadm = aux
            };
            DataTable dt = new DataTable();
            dt = k.GetIDemp();
            if (dt.Rows.Count > 0)
            {
                id = dt.Rows[0][0].ToString();
                return id;
            }
            else
            {
                return "1";
            }
        }

        

        protected string EncontrarIdSuc(string aux)
        {
            string nombre;
            TheGym k = new TheGym
            {
                emailbusadm = aux
            };
            DataTable dt = new DataTable();
            dt = k.GetSucEmailEmpleado();
            if (dt.Rows.Count > 0)
            {
                nombre = dt.Rows[0][1].ToString();
                return nombre;
            }
            else
            {
                return "Central";
            }
        }


        protected string EncontrarIdSuc1(string aux)
        {
            string nombre;
            TheGym k = new TheGym
            {
                emailbusadm = aux
            };
            DataTable dt = new DataTable();
            dt = k.GetSucEmailEmpleado();
            if (dt.Rows.Count > 0)
            {
                nombre = dt.Rows[0][0].ToString();
                return nombre;
            }
            else
            {
                return "1";
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

        protected void CargarServicios()
        {
            lblerror.Visible = false;
            TheGym k = new TheGym();
            DataTable dt = new DataTable();
            dt = k.GetServicios();
            if (dt.Rows.Count > 0)
            {
                ddlservicio.DataTextField = "Nombre";
                ddlservicio.DataValueField = "Id_servicio";
                ddlservicio.DataSource = dt;
                ddlservicio.DataBind();
                ddlservicio.Items.Insert(0, "--Seleccione--");
            }
            else
            {
                lblerror.Visible = true;
                lblerror.Text = "No se encontraron servicios";
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


        protected void btnregistrar_Click(object sender, EventArgs e)
        {
            lblerror.Visible = false;
            if(ddlTipoComprobante.SelectedItem.Text != "--Seleccione--")
            {
                if (ddlTipoComprobante.SelectedItem.Text == "Factura Servicio" && ddlservicio.SelectedItem.Text != "--Seleccione--" && tbmonto.Text != string.Empty)
                {
                    TheGym k = new TheGym
                    {
                        FacturaFKTipoComp = ddlTipoComprobante.SelectedValue,
                        FacturaFKServicio = ddlservicio.SelectedValue,
                        FacturaMonto = tbmonto.Text,
                        FacturaFecha = lblFecha.Text,
                        FacturaFKEmpleado = id
                    };

                    try
                    {
                        k.AddFacturaPagoServicio();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#modal-default').modal('show');", true);
                    }
                    catch
                    {
                        lblerror.Visible = true;
                        lblerror.Text = "Error al cargar factura de servicio";
                    }
                }
                else
                {
                    if(ddlTipoComprobante.SelectedItem.Text == "Factura Proveedor" && tbordencompra.Text != string.Empty)
                    {
                        TheGym k = new TheGym
                        {
                            FacturaIDOrden = tbordencompra.Text,
                            FacturaFKTipoComp = ddlTipoComprobante.SelectedValue,
                            FacturaMonto = tbmonto.Text,
                            FacturaFecha = lblFecha.Text,
                            FacturaFKEmpleado = id
                        };

                        try
                        {
                            k.AddFacturaPagoProveedor();
                            k.FacturaIDSucursal = IdSucursal;
                            for (int i = 0; i < Tabla.Rows.Count; i++)
                            {
                                k.FacturaProducto = Tabla.Rows[i][0].ToString();
                                k.FacturaCantidad = Tabla.Rows[i][2].ToString();

                                DataTable dt = new DataTable();
                                dt = k.ProductoEnDeposito();

                                if (dt.Rows.Count > 0)
                                {
                                    k.ActualizaStockOrden();
                                }
                                else
                                {
                                    k.AddProductoADeposito();
                                }
                            }
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#modal-default').modal('show');", true);
                        }
                        catch
                        {
                            lblerror.Visible = true;
                            lblerror.Text = "Error al cargar factura de Proveedor";
                        }
                    }
                    else
                    {
                        if(ddlTipoComprobante.SelectedItem.Text == "Otros" && tbmonto.Text != string.Empty)
                        {
                            TheGym k = new TheGym
                            {
                                FacturaIDOrden = "",
                                FacturaFKTipoComp = ddlTipoComprobante.SelectedValue,
                                FacturaFKServicio = "",
                                FacturaMonto = tbmonto.Text,
                                FacturaFecha = lblFecha.Text,
                                FacturaFKEmpleado = id
                            };

                            try
                            {
                                k.AddFacturaPagoOtros();
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#modal-default').modal('show');", true);
                            }
                            catch
                            {
                                lblerror.Visible = true;
                                lblerror.Text = "Error al cargar factura de Otros";
                            }
                        }
                        else
                        {
                            lblerror.Visible = true;
                            lblerror.Text = "Error general";
                        }
                    }
                }
            }
            else
            {
                lblerror.Text = "Seleccione un tipo de comprobante!";
            }
            //mensaje de exito
            tbmonto.Text = string.Empty;
            tbmonto.ReadOnly = true;
            LblOrdenCompra.Visible = false;
            tbordencompra.Text = string.Empty;
            tbordencompra.Visible = false;
            btnordencomprapopup.Visible = false;
            LblServicios.Visible = false;
            ddlservicio.Visible = false;
            ddlTipoComprobante.ClearSelection();
            griddetalleordenmodal.Dispose();
            griddetalleordenmodal.Visible = false;
            gridordenmodal.Dispose();
            gridordenmodal.Visible = false;

        }

        protected void btncancelar_Click(object sender, EventArgs e)
        {
            tbmonto.Text = string.Empty;
            tbmonto.ReadOnly = true;
            LblOrdenCompra.Visible = false;
            tbordencompra.Text = string.Empty;
            tbordencompra.Visible = false;
            btnordencomprapopup.Visible = false;
            LblServicios.Visible = false;
            ddlservicio.Visible = false;
            ddlTipoComprobante.ClearSelection();
            griddetalleordenmodal.Dispose();
            griddetalleordenmodal.Visible = false;
            gridordenmodal.Dispose();
            gridordenmodal.Visible = false;
        }

        protected void btnserviciopopup_Click(object sender, EventArgs e)
        {

        }

        protected void btnordencomprapopup_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#modal-ordencompra').modal('show');", true);
        }

        protected void ddlTipoComprobante_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Convert.ToString(ddlTipoComprobante.SelectedItem) == "Factura Servicio")
            {
                tbmonto.ReadOnly = false;
                LblServicios.Visible = true;
                ddlservicio.Visible = true;
                LblOrdenCompra.Visible = false;
                tbordencompra.Visible = false;
                btnordencomprapopup.Visible = false;
            }
            else
            {
                if(Convert.ToString(ddlTipoComprobante.SelectedItem)=="Factura Proveedor")
                {
                    tbmonto.ReadOnly = true;
                    LblServicios.Visible = false;
                    ddlservicio.Visible = false;
                    LblOrdenCompra.Visible = true;
                    tbordencompra.Visible = true;
                    btnordencomprapopup.Visible = true;
                }
                else
                {
                    tbmonto.ReadOnly = false;
                    LblServicios.Visible = false;
                    ddlservicio.Visible = false;
                    LblOrdenCompra.Visible = false;
                    tbordencompra.Visible = false;
                    btnordencomprapopup.Visible = false;
                }
            }
        }

        protected void btnconsultarodenmodel_Click(object sender, EventArgs e)
        {
            lblerrorordenmodal.Visible = false;
            if (ddlProveedor.SelectedItem.Text != "--Seleccione--")
            {
                TheGym k = new TheGym
                {
                    FacturaIDProv = ddlProveedor.SelectedValue
                };
                DataTable dt = new DataTable();
                dt = k.GetOrdenDeProv();

                if (dt.Rows.Count > 0)
                {
                    gridordenmodal.DataSource = dt;
                    gridordenmodal.DataBind();
                    gridordenmodal.Visible = true;
                }
                else
                {
                    lblerrorordenmodal.Visible = true;
                    lblerrorordenmodal.Text = "Sin ordenes de compra para ese proveedor";
                    DataTable dt1 = new DataTable();
                    gridordenmodal.DataSource = dt1;
                    gridordenmodal.DataBind();
                    gridordenmodal.Dispose();
                    gridordenmodal.Visible = false;
                }

            }
            else
            {
                lblerrorordenmodal.Visible = true;
                lblerrorordenmodal.Text = "Seleccione un proveedor";
                DataTable dt1 = new DataTable();
                gridordenmodal.DataSource = dt1;
                gridordenmodal.DataBind();
                gridordenmodal.Dispose();
                gridordenmodal.Visible = false;
            }
        }

        protected void ddlProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void gridordenmodal_SelectedIndexChanged(object sender, EventArgs e)
        {
            Total = gridordenmodal.SelectedRow.Cells[2].Text;
            tbmonto.Text = Total;
            idOrden = gridordenmodal.SelectedRow.Cells[0].Text;
            tbordencompra.Text = idOrden;
            TheGym k = new TheGym()
            {
                FacturaIDOrden = idOrden
            };
            DataTable dt = new DataTable();
            dt = k.GetDetOrden();
            if (dt.Rows.Count>0)
            {
                Tabla = dt;
                griddetalleordenmodal.DataSource = dt;
                griddetalleordenmodal.DataBind();
                griddetalleordenmodal.Visible = true;
            }
            else
            {
                DataTable dt1 = new DataTable();
                griddetalleordenmodal.DataSource = dt1;
                griddetalleordenmodal.DataBind();
                griddetalleordenmodal.Dispose();
                griddetalleordenmodal.Visible = false;
            }
        }
    }
}
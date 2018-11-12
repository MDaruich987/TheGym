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
        static string orden;


        protected void Page_Load(object sender, EventArgs e)
        {
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#modal-Detalle').modal('show');", true);
            if (!IsPostBack)
            {
                if (Session["inicio"] != null)
                {
                    //declaramos una variale sesion para mantener el dato del usuario
                    string usuario = (string)Session["Usuario"];
                    lblusuario.Text = "Bienvenido/a " + (String)Session["inicio"];
                    /*if (Request.Params["parametro"] != null)
                    {
                        //para que el label capte el nombre y apellido enviado desde el form de acceso
                        lblmensajebienvenida.Text = "Bienvenido " + Request.Params["parametro"];
                    }
                    else
                    {
                        //si no, muestra un mensaje de bienvenida solamente
                        lblmensajebienvenida.Text = "Bienvenido";
                    }
                    */

                }
                else
                {
                    //si no se ha iniciado sesion me manda al inicio
                    //Response.Redirect("InicioLogin.aspx");
                }

                CargarTipoComprobante();
                CargarProveedores();
                CargarServicios();
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
                if(ddlTipoComprobante.SelectedItem.Text == "Factura Proveedor")
                {
                    if(ddlProveedor.SelectedItem.Text != "--Seleccione--")
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

        protected void Pagofactura_Click(object sender, EventArgs e)
        {
            string DetCaja;
            Lblerror1.Visible = false;
            //boton del modal que registra el pago de la facura
            if (ddlTipoComprobante.SelectedItem.Text == "Factura Proveedor")
            {
                try
                {
                    TheGym k = new TheGym
                    {
                        FechaIdDetCaja = DateTime.Now.ToShortDateString()
                    };
                    DataTable dt = new DataTable();
                    dt = k.GetEstadoDetCaja();
                    if (dt.Rows.Count == 0)
                    {
                        DataTable dt1 = new DataTable();
                        dt1 = k.GetEstadoDetCajaAP();
                       // DetCaja = dt.Rows[0][6].ToString();

                        if (dt1.Rows.Count == 1)
                        {
                            DetCaja = dt1.Rows[0][6].ToString();
                            TheGym k1 = new TheGym
                            {
                               
                                FacturaMonto = tbtotalFactura.Text,
                                FacturaConcepto = "Factura Proveedor",
                                FacturaDetCaja = DetCaja,
                                FacturaHora = DateTime.Now.ToShortTimeString(),
                                FacturaIDFact = tbIdFact.Text,
                                FacturaIDOrden = orden
                            };
                            try
                            {
                                k1.PagarFacturaProveedor();
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#modal-Detalle').modal('hide');", true);
                                grid.Dispose();
                                grid.Visible = false;
                                LblFiltro.Visible = false;
                                LblServicio.Visible = false;
                                ddlServicio.ClearSelection();
                                ddlServicio.Visible = false;
                                LblProveedor.Visible = false;
                                ddlProveedor.Visible = false;
                                ddlProveedor.ClearSelection();
                                ddlTipoComprobante.ClearSelection();
                                tbConcepto.Text = string.Empty;
                                tbFecha.Text = string.Empty;
                                tbIdFact.Text = string.Empty;
                                tbTipo.Text = string.Empty;
                                tbtotalFactura.Text = string.Empty;
                                lblerror.Visible = true;
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#modal-exito').modal('show');", true);
                                lblerror.Text = "Pago Registrado Exitosamente!";
                            }
                            catch (Exception ex)
                            {

                                lblerror.Text = ex.Message.ToString();
                            }
                            
                           
                        }
                        else
                        {
                            Lblerror1.Visible = true;
                            Lblerror1.Text = "Caja No Abierta";
                        }


                    }
                    else
                    {
                        Lblerror1.Visible = true;
                        Lblerror1.Text = "Caja Cerrada";
                    }
                }
                catch (Exception ex)
                {
                    Lblerror1.Visible = true;
                    Lblerror1.Text = ex.Message.ToString(); 
                }
               
            }
            else
            {
                if(ddlTipoComprobante.SelectedItem.Text == "Factura Servicio")
                {
                    try
                    {
                        TheGym k = new TheGym
                        {
                            FechaIdDetCaja = DateTime.Today.ToShortDateString()
                        };
                        DataTable dt = new DataTable();
                        dt = k.GetEstadoDetCaja();
                        if (dt.Rows.Count == 0)
                        {
                            DataTable dt1 = new DataTable();
                            dt1 = k.GetEstadoDetCajaAP();
                            //DetCaja = dt.Rows[0][6].ToString();

                            if (dt1.Rows.Count == 1)
                            {
                                DetCaja = dt1.Rows[0][6].ToString();
                                TheGym k1 = new TheGym
                                {
                                    FacturaMonto = tbtotalFactura.Text,
                                    FacturaConcepto = "Factura Servicio",
                                    FacturaDetCaja = DetCaja,
                                    FacturaHora = DateTime.Now.ToShortTimeString(),
                                    FacturaIDFact = tbIdFact.Text,
                                };
                                k1.PagarFacturaServicio();
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#modal-Detalle').modal('hide');", true);
                                grid.Dispose();
                                grid.Visible = false;
                                LblFiltro.Visible = false;
                                LblServicio.Visible = false;
                                ddlServicio.ClearSelection();
                                ddlServicio.Visible = false;
                                LblProveedor.Visible = false;
                                ddlProveedor.Visible = false;
                                ddlProveedor.ClearSelection();
                                ddlTipoComprobante.ClearSelection();
                                tbConcepto.Text = string.Empty;
                                tbFecha.Text = string.Empty;
                                tbIdFact.Text = string.Empty;
                                tbTipo.Text = string.Empty;
                                tbtotalFactura.Text = string.Empty;
                                lblerror.Visible = true;
                                lblerror.Text = "Pago Registrado Exitosamente!";
                            }
                            else
                            {
                                Lblerror1.Visible = true;
                                Lblerror1.Text = "Caja No Abierta";
                            }


                        }
                        else
                        {
                            Lblerror1.Visible = true;
                            Lblerror1.Text = "Caja Cerrada";
                        }
                    }
                    catch
                    {
                        Lblerror1.Visible = true;
                        Lblerror1.Text = "Error al pagar Factura Servicio";
                    }
                }

                else
                {
                    TheGym k = new TheGym
                    {
                        FechaIdDetCaja = DateTime.Today.ToShortDateString()
                    };
                    DataTable dt = new DataTable();
                    dt = k.GetEstadoDetCaja();
                    if (dt.Rows.Count == 0)
                    {
                        DataTable dt1 = new DataTable();
                        dt1 = k.GetEstadoDetCajaAP();
                        //DetCaja = dt.Rows[0][6].ToString();

                        if (dt1.Rows.Count == 1)
                        {
                            DetCaja = dt1.Rows[0][6].ToString();
                            TheGym k1 = new TheGym
                            {
                                FacturaMonto = tbtotalFactura.Text,
                                FacturaConcepto = "Otros",
                                FacturaDetCaja = DetCaja,
                                FacturaHora = DateTime.Now.ToShortTimeString(),
                                FacturaIDFact = tbIdFact.Text,
                            };
                            k1.PagarFacturaServicio();
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#modal-Detalle').modal('hide');", true);
                            grid.Dispose();
                            grid.Visible = false;
                            LblFiltro.Visible = false;
                            LblServicio.Visible = false;
                            ddlServicio.ClearSelection();
                            ddlServicio.Visible = false;
                            LblProveedor.Visible = false;
                            ddlProveedor.Visible = false;
                            ddlProveedor.ClearSelection();
                            ddlTipoComprobante.ClearSelection();
                            tbConcepto.Text = string.Empty;
                            tbFecha.Text = string.Empty;
                            tbIdFact.Text = string.Empty;
                            tbTipo.Text = string.Empty;
                            tbtotalFactura.Text = string.Empty;
                            lblerror.Visible = true;
                            lblerror.Text = "Pago Registrado Exitosamente!";

                        }
                        else
                        {
                            Lblerror1.Visible = true;
                            Lblerror1.Text = "Caja No Abierta";
                        }


                    }
                    else
                    {
                        Lblerror1.Visible = true;
                        Lblerror1.Text = "Caja Cerrada";
                    }
                
            }

            }


        }

        protected void gridfacturas_SelectedIndexChanged(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#modal-Detalle').modal('show');", true);
            //Mostrar el detalle en texboxs y mostrar el boton pagar!!!
            lblIdFact.Visible = false;
            tbIdFact.Text = string.Empty;
            tbTipo.Visible = false;
            lblTipo.Visible = false;
            tbTipo.Text = string.Empty;
            lblConcepto.Visible = false;
            tbConcepto.Visible = false;
            tbConcepto.Text = string.Empty;
            lblFecha.Visible = false;
            tbFecha.Visible = false;
            tbFecha.Text = string.Empty;
            if(ddlTipoComprobante.SelectedItem.Text == "Factura Proveedor")
            {
                if (ddlProveedor.SelectedItem.Text != "--Seleccione--")
                {
                    lblIdFact.Visible = true;
                    tbIdFact.Visible = true;
                    tbIdFact.Text = grid.SelectedRow.Cells[1].Text;
                    lblTipo.Visible = true;
                    tbTipo.Visible = true;
                    tbTipo.Text = "Factura Proveedor";
                    lblConcepto.Visible = true;
                    tbConcepto.Visible = true;
                    tbConcepto.Text = "Proveeedor " + ddlProveedor.SelectedItem.Text + " Orden :" + grid.SelectedRow.Cells[3].Text;
                    lblFecha.Visible = true;
                    tbFecha.Visible = true;
                    tbFecha.Text = grid.SelectedRow.Cells[2].Text;
                    tbtotalFactura.Text = grid.SelectedRow.Cells[4].Text;
                    orden = grid.SelectedRow.Cells[3].Text;
                }
                else
                {
                    lblIdFact.Visible = true;
                    tbIdFact.Visible = true;
                    tbIdFact.Text = grid.SelectedRow.Cells[2].Text;
                    lblTipo.Visible = true;
                    tbTipo.Visible = true;
                    tbTipo.Text = "Factura Proveedor";
                    lblConcepto.Visible = true;
                    tbConcepto.Visible = true;
                    tbConcepto.Text = "Proveeedor " + grid.SelectedRow.Cells[3].Text;
                    lblFecha.Visible = true;
                    tbFecha.Visible = true;
                    tbFecha.Text = grid.SelectedRow.Cells[5].Text;
                    tbtotalFactura.Text = grid.SelectedRow.Cells[6].Text;
                    orden = grid.SelectedRow.Cells[4].Text;
                }
            }
            else
            {
                if(ddlTipoComprobante.SelectedItem.Text == "Factura Servicio")
                {
                    if (ddlServicio.SelectedItem.Text != "--Seleccione--")
                    {
                        lblIdFact.Visible = true;
                        tbIdFact.Visible = true;
                        tbIdFact.Text = grid.SelectedRow.Cells[2].Text;
                        lblTipo.Visible = true;
                        tbTipo.Visible = true;
                        tbTipo.Text = "Factura Servicio";
                        lblConcepto.Visible = true;
                        tbConcepto.Visible = true;
                        tbConcepto.Text = "Servicio " + ddlServicio.SelectedItem.Text;
                        lblFecha.Visible = true;
                        tbFecha.Visible = true;
                        tbFecha.Text = grid.SelectedRow.Cells[3].Text;
                        tbtotalFactura.Text = grid.SelectedRow.Cells[4].Text;
                    }
                    else
                    {
                        lblIdFact.Visible = true;
                        tbIdFact.Visible = true;
                        tbIdFact.Text = grid.SelectedRow.Cells[2].Text;
                        lblTipo.Visible = true;
                        tbTipo.Visible = true;
                        tbTipo.Text = grid.SelectedRow.Cells[1].Text;
                        lblConcepto.Visible = true;
                        tbConcepto.Visible = true;
                        tbConcepto.Text = "Servicio de " + grid.SelectedRow.Cells[3].Text;
                        lblFecha.Visible = true;
                        tbFecha.Visible = true;
                        tbFecha.Text = grid.SelectedRow.Cells[4].Text;
                        tbtotalFactura.Text = grid.SelectedRow.Cells[5].Text;
                    }
                }
                else
                {
                    lblIdFact.Visible = true;
                    tbIdFact.Visible = true;
                    tbIdFact.Text = grid.SelectedRow.Cells[2].Text;
                    lblTipo.Visible = true;
                    tbTipo.Visible = true;
                    tbTipo.Text = "Otros";
                    lblConcepto.Visible = true;
                    tbConcepto.Visible = true;
                    tbConcepto.Text = "Otros Servicios";
                    lblFecha.Visible = true;
                    tbFecha.Visible = true;
                    tbFecha.Text = grid.SelectedRow.Cells[3].Text;
                    tbtotalFactura.Text = grid.SelectedRow.Cells[4].Text;
                }
            }
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
                LblFiltro.Visible = true;
                ddlProveedor.Visible = true;
                LblProveedor.Visible = true;
                LblServicio.Visible = false;
                ddlServicio.Visible = false;
                ddlServicio.ClearSelection();
            }
            else
            {
                if(ddlTipoComprobante.SelectedItem.Text == "Factura Servicio")
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

        protected void ddlServicio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
    }
}
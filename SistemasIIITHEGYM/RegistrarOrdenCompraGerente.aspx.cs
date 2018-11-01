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
        static DataTable Tabla = new DataTable();
        static DataColumn Column;

        //para saber si se ha asignado el nombre del proveedor al label
        // static bool flagproveedor = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            //el panel no se debe habilitar hasta que seleccionemos un proveedor
            //updetalleorden.Visible = false;
            if (!IsPostBack)
            {
                Column = new DataColumn();
                Column.DataType = System.Type.GetType("System.Int32");
                Column.ColumnName = "Id_producto";
                Tabla.Columns.Add(Column);
                Column = new DataColumn();
                Column.DataType = System.Type.GetType("System.String");
                Column.ColumnName = "Nombre";
                Tabla.Columns.Add(Column);
                Column = new DataColumn();
                Column.DataType = System.Type.GetType("System.Int32");
                Column.ColumnName = "Cantidad";
                Tabla.Columns.Add(Column);
                Column = new DataColumn();
                Column.DataType = System.Type.GetType("System.Double");
                Column.ColumnName = "Precio";
                Tabla.Columns.Add(Column);
                Column = new DataColumn();
                Column.DataType = System.Type.GetType("System.Double");
                Column.ColumnName = "SubTotal";
                Tabla.Columns.Add(Column);

                lblFecha.Text = DateTime.Today.ToShortDateString();
                lblhora.Text = DateTime.Now.ToShortTimeString();
                lblempleado.Text = (String)Session["usuario"];
            }

            if (flag == true)
            {
                tbproveedor.Text = nom;

            }

        }

        protected void btnselecproveedor_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#modal-proveedor').modal('show');", true);
            flag = true;
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
            if (tbnombreproductos.Text != "" || id != null)
            {
                tbcantidad.Enabled = false;
                try
                {
                    TheGym k = new TheGym
                    {
                        emailbusadm = (String)Session["Usuario"]
                    };
                    DataTable dt = new DataTable();
                    //dt = k.GetSucEmailEmpleado();

                    k.ProductName = tbnombreproductos.Text;
                    k.idproveedor = id;
                    //k.NumeroSucursal = dt.Rows[0][0].ToString();


                    DataTable dt2 = new DataTable();
                    dt2 = k.GetProductPorProveedor();

                    if (dt2.Rows.Count > 0)
                    {
                        Label1.Visible = false;
                        gvproductos.DataSource = dt2;
                        gvproductos.DataBind();
                        gvproductos.Visible = true;
                    }
                    else
                    {
                        Label1.Text = "No se encontro el producto";
                        Label1.Visible = true;
                        DataTable dt3 = new DataTable();
                        gvproductos.DataSource = dt3;
                        gvproductos.DataBind();
                        gvproductos.Visible = false;
                    }


                }
                catch
                {
                    Label1.Text = "Error General";
                    Label1.Visible = false;
                }
                tbnombreproductos.Text = string.Empty;
            }
            else
            {
                lblerrorproductosmodal.Text = "Ingrese un producto";
            }
        }

        protected void btnañadirproductomodal_Click(object sender, EventArgs e)
        {
            if (tbcantidad.Text != "" && Convert.ToInt32(tbcantidad.Text) != 0)
            {
                Lblerror1.Visible = false;
                DataRow fila = Tabla.NewRow();
                fila[0] = Convert.ToInt32(gvproductos.SelectedRow.Cells[0].Text);
                fila[1] = gvproductos.SelectedRow.Cells[1].Text;
                fila[2] = tbcantidad.Text;
                fila[3] = Convert.ToDouble(gvproductos.SelectedRow.Cells[2].Text);
                fila[4] = Convert.ToDouble(gvproductos.SelectedRow.Cells[2].Text) * Convert.ToInt32(tbcantidad.Text);
                try
                {
                    Tabla.Rows.Add(fila);
                    griddetallefactura.DataSource = Tabla;
                    griddetallefactura.DataBind();
                    griddetallefactura.Visible = true;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#modal-añadirproducto').modal('hide');", true);
                    gvproductos.Visible = false;
                    tbcantidad.Text = "";
                    tbcantidad.Enabled = false;
                    btnañadirproductomodal.Enabled = false;
                }
                catch (Exception ex)
                {
                    Lblerror1.Text = ex.Message;
                    Lblerror1.Visible = true;
                }
            }
            else
            {
                Lblerror1.Text = "Ingrese una cantidad";
                Lblerror1.Visible = true;
            }
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
            nom = gvproveedoresmodal.SelectedRow.Cells[1].Text;
            //tbproveedor.Text = gvproveedoresmodal.SelectedRow.Cells[1].Text;
            id = gvproveedoresmodal.SelectedRow.Cells[0].Text;

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#modal-proveedor').modal('hide');", true);
            flag = true;
            //tbproveedor.Text = nom;
            //Page_Load(sender,e);
            CargarProv();

            //ScriptManager.RegisterStartupScript(this, typeof(Page), "jsKeys", "javascript:Forzar();", true);

        }

        protected void CargarProv()
        {
            tbproveedor.Text = nom;

        }

        protected void griddetallefactura_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Tabla.Rows.RemoveAt(e.RowIndex);
            griddetallefactura.DataSource = Tabla;
            griddetallefactura.DataBind();
        }

        protected void gvproductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbcantidad.Enabled = true;
            btnañadirproductomodal.Enabled = true;
        }

        protected void griddetallefactura_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnregistrar_Click(object sender, EventArgs e)
        {
            if (griddetallefactura.Columns.Count > 0)
            {
                Label1.Visible = false;
                double total = 0;
                double subtotal = 0;
                string idorden;

                for (int i = 0; i < griddetallefactura.Rows.Count; i++)
                {
                    subtotal = Convert.ToDouble(Tabla.Rows[i][4]);
                    total = total + subtotal;
                }
                if (griddetallefactura.Rows.Count > 0)
                {
                    try
                    {
                        if ((String)Session["Usuario"] != null)
                        {
                            Label1.Visible = false;
                            TheGym k = new TheGym
                            {
                                emailbusadm = (String)Session["Usuario"],
                            };

                            DataTable dt = new DataTable();
                            dt = k.GetIDemp();

                            if (dt.Rows.Count > 0)
                            {
                                k.fkempleadoorden = dt.Rows[0][0].ToString();
                                k.fkproveedororden = id;
                                k.fechaorden = lblFecha.Text;
                                k.horaorden = lblhora.Text;
                                k.totalorden = Convert.ToString(total);

                                DataTable dt1 = new DataTable();
                                dt1 = k.AddOrdenCompra();

                                idorden = dt1.Rows[0][0].ToString();

                                for (int i = 0; i < griddetallefactura.Rows.Count; i++)
                                {
                                    k.fkorden = idorden;
                                    k.fkproducto = Tabla.Rows[i][0].ToString();
                                    k.cantidadorden = Tabla.Rows[i][2].ToString();
                                    k.precioorden = Tabla.Rows[i][3].ToString();

                                    k.AddDetOrden();
                                }


                            }
                            else
                            {
                                Label1.Text = "Empleado no encontrado";
                                Label1.Visible = true;
                            }
                        }
                        else
                        {
                            TheGym k = new TheGym();
                            k.fkempleadoorden = "1";
                            k.fkproveedororden = id;
                            k.fechaorden = lblFecha.Text;
                            k.horaorden = lblhora.Text;
                            k.totalorden = Convert.ToString(total);

                            DataTable dt1 = new DataTable();
                            dt1 = k.AddOrdenCompra();

                            idorden = dt1.Rows[0][0].ToString();

                            for (int i = 0; i < griddetallefactura.Rows.Count; i++)
                            {
                                k.fkorden = idorden;
                                k.fkproducto = Tabla.Rows[i][0].ToString();
                                k.cantidadorden = Tabla.Rows[i][2].ToString();
                                k.precioorden = Tabla.Rows[i][3].ToString();

                                k.AddDetOrden();
                            }

                        }

                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#modal-default').modal('show');", true);

                        //btnPDF.Visible = true;
                        //btnPDF.Enabled = true;

                        //panelseleccionarproveedor.Visible = true;
                        //panelregistrarorden.Visible = false;
                        DataTable dtaux = new DataTable();
                        griddetallefactura.DataSource = dtaux;
                        griddetallefactura.DataBind();
                        griddetallefactura.Dispose();
                        griddetallefactura.Visible = false;
                        griddetallefactura.DataSource = dtaux;
                        griddetallefactura.DataBind();
                        griddetallefactura.Dispose();
                        griddetallefactura.Visible = false;
                        gvproductos.DataSource = dtaux;
                        gvproductos.DataBind();
                        gvproductos.Dispose();
                        gvproductos.Visible = false;
                        tbcantidad.Text = string.Empty;
                        tbcantidad.Enabled = false;
                        tbcantidad.Text = string.Empty;
                        lblempleado.Text = string.Empty;
                        lblhora.Text = string.Empty;
                        tbproveedor.Text = string.Empty;
                        lblFecha.Text = string.Empty;
                        tbnombreproveedor.Text = string.Empty;
                        lblerror.Text = string.Empty;
                        tbnombreproductos.Text = string.Empty;
                        lblerror.Text = string.Empty;
                        Lblerror1.Text = string.Empty;
                        lblerror.Visible = false;
                        lblerror.Visible = false;
                        Lblerror1.Visible = false;


                    }
                    catch (Exception ex)
                    {
                        Label1.Visible = true;
                        Label1.Text = ex.Message.ToString();
                    }
                }

                else
                {
                    Label1.Text = "Agregar productos a la Orden";
                    Label1.Visible = true;
                }
            }
        }
        }   
}
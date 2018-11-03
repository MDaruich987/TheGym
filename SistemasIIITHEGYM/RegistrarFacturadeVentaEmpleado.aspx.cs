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
    public partial class RegistrarFacturadeVentaEmpleado : System.Web.UI.Page
    {
        static DataTable Tabla = new DataTable();
        static DataColumn Column;
        static bool flag = false;
        static string id;
        static string email;
        static string nom;
        static string suc;

        protected void Page_Load(object sender, EventArgs e)
        {
            generarPDF.Visible = false;
            btnuevaFactura.Visible = false;

            lblFecha.Text = DateTime.Today.ToShortDateString();
            lblhora.Text = DateTime.Now.ToShortTimeString();
            lblempleado.Text = (String)Session["inicio"];
            email = (String)Session["Usuario"];

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

                

                if(email != null)
                {
                    DataTable dt = new DataTable();
                    TheGym k = new TheGym
                    {
                        emailbusadm = email
                    };
                    dt = k.GetSucEmailEmpleado();
                    suc = dt.Rows[0][0].ToString();
                }
                else
                {
                    suc = "3";
                }

            }

            if (flag == true)
            {
                tbnombrcliente.Text = nom;

            }

        }

        protected void btnconsultarclientemodal_Click(object sender, EventArgs e)
        {
            if (tbnombrcliente.Text != string.Empty)
            {
                lblerrorconsultarclientemodal.Visible = false;
                TheGym k = new TheGym()
                {
                    NombreClienteBusc = tbnombrcliente.Text
                };
                DataTable dt = new DataTable();
                dt = k.GetClienteNom();

                if (dt.Rows.Count > 0)
                {
                    gvclientemodal.DataSource = dt;
                    gvclientemodal.DataBind();
                    gvclientemodal.Visible = true;
                }
                else
                {
                    lblerrorconsultarclientemodal.Visible = true;
                    lblerrorconsultarclientemodal.Text = "No se encontro el cliente";
                }


            }
            else
            {
                lblerrorconsultarclientemodal.Visible = true;
                lblerrorconsultarclientemodal.Text = "Ingrese el nombre de un cliente";
            }
        }

        protected void gvproductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbcantidad.Enabled = true;
            btnañadirproductomodal.Enabled = true;
        }

        protected void tbcliente_TextChanged(object sender, EventArgs e)
        {

        }


        protected void botonconsultarproductos_Click(object sender, EventArgs e)
        {
            if (tbnombreproductos.Text != string.Empty)
            {
                lblerrorproductosmodal.Visible = false;
                try
                {
                    TheGym k = new TheGym
                    {
                        NombreProdBusc = tbnombreproductos.Text,
                        SucBuscProd = suc
                    };

                    DataTable dt = new DataTable();
                    dt = k.GetProductoVenta();

                    if (dt.Rows.Count > 0)
                    {
                        gvproductos.DataSource = dt;
                        gvproductos.DataBind();
                        gvproductos.Visible = true;
                    }
                    else
                    {
                        lblerrorproductosmodal.Visible = true;
                        lblerrorproductosmodal.Text = "No se encontro el producto";
                        gvproductos.DataSource = dt;
                        gvproductos.DataBind();
                        gvproductos.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    lblerrorproductosmodal.Visible = true;
                    lblerrorproductosmodal.Text = ex.Message.ToString();
                }
            }
            else
            {
                lblerrorproductosmodal.Visible = true;
                lblerrorproductosmodal.Text = "Ingrese el nombre de un producto";

            }
        }
        

        protected void btnañadirproductomodal_Click(object sender, EventArgs e)
        {
            if (tbcantidad.Text != string.Empty && Convert.ToInt32(tbcantidad.Text) != 0 && Convert.ToInt32(tbcantidad.Text)>0)
            {
                if (griddetallefactura.Rows.Count > 0)
                {
                    for (int i = 0; i < griddetallefactura.Rows.Count; i++)
                    {
                        if (griddetallefactura.Rows[i].Cells[0].Text != gvproductos.SelectedRow.Cells[0].Text)
                        {
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
                                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#modal-añadirproducto').modal('hide');", true);
                                gvproductos.Visible = false;
                                tbcantidad.Text = "";
                                tbcantidad.Enabled = false;
                                btnañadirproductomodal.Enabled = false;
                                tbnombreproductos.Text = string.Empty;
                            }
                            catch (Exception ex)
                            {
                                Lblerror1.Text = ex.Message;
                                Lblerror1.Visible = true;
                            }
                        }
                        else
                        {
                            Lblerror1.Visible = true;
                            Lblerror1.Text = "Producto ya añadido";
                        }
                    }
                }
                else
                {
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
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#modal-añadirproducto').modal('hide');", true);
                        gvproductos.Visible = false;
                        tbcantidad.Text = "";
                        tbcantidad.Enabled = false;
                        btnañadirproductomodal.Enabled = false;
                        tbnombreproductos.Text = string.Empty;
                    }
                    catch (Exception ex)
                    {
                        Lblerror1.Text = ex.Message;
                        Lblerror1.Visible = true;
                    }
                }
                
            }
            else
            {
                Lblerror1.Visible = true;
                Lblerror1.Text = "Ingrese una cantidad valida";
            }
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
            Tabla.Rows.RemoveAt(e.RowIndex);
            griddetallefactura.DataSource = Tabla;
            griddetallefactura.DataBind();
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
            //flag = true;
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void gvclientemodal_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbcliente.Text = gvclientemodal.SelectedRow.Cells[2].Text + ", " + gvclientemodal.SelectedRow.Cells[1].Text;
            id = gvclientemodal.SelectedRow.Cells[0].Text;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#modal-cliente').modal('hide');", true);
        }
    }
}
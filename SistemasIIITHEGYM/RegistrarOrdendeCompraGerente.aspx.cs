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
    public partial class RegistrarOrdendeCompraGerente : System.Web.UI.Page
    {
        static string id;
        static DataTable data = new DataTable();

        static bool flag = true;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //aqui debemos verificar si la apertura de caja esta hecha o no, si no redireccionamos con estos
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#modal-redirect').modal('show');", true);
                // Response.AddHeader("REFRESH", "3;URL=AperturadeCajaEmpleado.aspx");
                //tbnombre.Enabled = false;
                //btnconsultar.Enabled =false;
                //si no, me manda a la pagina de apertura de caja a los 3 segundos



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
                panelseleccionarproveedor.Visible = true;
                panelregistrarorden.Visible = false;

                if (flag == true)
                {
                    data.Columns.Add("ID",typeof(int));
                    data.Columns.Add("Nombre", typeof(string));
                    data.Columns.Add("Cantidad", typeof(int));
                    data.Columns.Add("Precio", typeof(double));
                    flag = false;

                }

            }

        }

        


        protected void gridcliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelseleccionarproveedor.Visible = false;
            panelregistrarorden.Visible = true;

            lblFecha.Text = DateTime.Today.ToShortDateString();
            lblhora.Text = DateTime.Now.ToShortTimeString();

            lblproveedor.Text = gridcliente.SelectedRow.Cells[1].Text;
           

            id = gridcliente.SelectedRow.Cells[0].Text;

            TheGym k = new TheGym();
            DataTable dt2 = new DataTable();
            dt2 = k.GetLastOrden();
            if (dt2.Rows.Count > 0)
            {
                string aux = dt2.Rows[0][0].ToString();
                if(dt2.Rows[0][0].ToString() != "")
                {
                    lblnroOrden.Text = Convert.ToString(Convert.ToInt32(dt2.Rows[0][0].ToString()) + 1);
                }
                else
                {
                    lblnroOrden.Text = "1";
                }
            }
            else
            {
                lblerror.Text = "Error al encontrar ultima Orden de Compra";
                lblerror.Visible = true;
            }

            LblEmpleado.Text = (String)Session["inicio"];


        }

        protected void btnconsultar_Click(object sender, EventArgs e)
        {
            
            try
            {
                if(TextBox1.Text != string.Empty)
                {
                    TheGym k2 = new TheGym
                    {
                        NombreProveedorBusc = TextBox1.Text
                    };
                    DataTable dt2 = new DataTable();
                    dt2 = k2.GetProveedorNom();
                    if (dt2.Rows.Count > 0)
                    {
                        lblerror0.Text = string.Empty;
                        lblerror0.Visible = false;
                        gridcliente.DataSource = dt2;
                        gridcliente.DataBind();
                        gridcliente.Visible = true;
                    }
                    else
                    {
                        DataTable dt1 = new DataTable();
                        gridcliente.DataSource = dt1;
                        gridcliente.DataBind();
                        gridcliente.Visible = false;
                        lblerror0.Text = "No se encontro proveedor";
                        lblerror0.Visible = true;
                    }
                }
                else
                {
                    lblerror0.Text = "Ingrese un valor";
                    lblerror0.Visible = true;
                }
                
            }
            catch
            {
                lblerror0.Text = "Error general";
                lblerror0.Visible = true;
            }
        }

        protected void btnconsultar_Click1(object sender, EventArgs e)
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

                k.ProductName = tbnombre.Text;
                k.idproveedor = id;
                //k.NumeroSucursal = dt.Rows[0][0].ToString();
                

                DataTable dt2 = new DataTable();
                dt2 = k.GetProductPorProveedor();

                if (dt2.Rows.Count > 0)
                {
                    Label1.Visible = false;
                    gridproductos.DataSource = dt2;
                    gridproductos.DataBind();
                    gridproductos.Visible = true;
                }
                else
                {
                    Label1.Text = "No se encontro el producto";
                    Label1.Visible = true;
                    DataTable dt3 = new DataTable();
                    gridproductos.DataSource = dt3;
                    gridproductos.DataBind();
                    gridproductos.Visible = false;
                }


            }
            catch
            {
                Label1.Text = "Error General";
                Label1.Visible = false;
            }
            tbnombre.Text = string.Empty;
        }

        protected void btnregistrar_Click(object sender, EventArgs e)
        {
            double total = 0;
            double subtotal = 0;
            int cant = 0;
            double precio = 0;
            string idorden;

            for (int i = 0; i < griddetallefactura.Rows.Count; i++)
            {
                cant = Convert.ToInt32(data.Rows[i][2]);
                precio = Convert.ToDouble(data.Rows[i][3]);
                subtotal = cant * precio;
                total = total + subtotal;
            }

            if (griddetallefactura.Rows.Count > 0)
            {
                try
                {
                    if ((String)Session["Usuario"] != null)
                    {
                        lblerror2.Visible = false;
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
                                k.fkproducto = data.Rows[i][0].ToString();
                                k.cantidadorden = data.Rows[i][2].ToString();
                                k.precioorden = data.Rows[i][3].ToString();

                                k.AddDetOrden();
                            }


                        }
                        else
                        {
                            lblerror2.Text = "Empleado no encontrado";
                            lblerror2.Visible = true;
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
                            k.fkproducto = data.Rows[i][0].ToString();
                            k.cantidadorden = data.Rows[i][2].ToString();
                            k.precioorden = data.Rows[i][3].ToString();

                            k.AddDetOrden();
                        }

                    }

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#modal-default').modal('show');", true);

                    panelseleccionarproveedor.Visible = true;
                    panelregistrarorden.Visible = false;
                    DataTable dtaux = new DataTable();
                    gridcliente.DataSource = dtaux;
                    gridcliente.DataBind();
                    gridcliente.Dispose();
                    gridcliente.Visible = false;
                    griddetallefactura.DataSource = dtaux;
                    griddetallefactura.DataBind();
                    griddetallefactura.Dispose();
                    griddetallefactura.Visible = false;
                    gridproductos.DataSource = dtaux;
                    gridproductos.DataBind();
                    gridproductos.Dispose();
                    gridproductos.Visible = false;
                    tbcantidad.Text = string.Empty;
                    tbcantidad.Enabled = false;
                    tbnombre.Text = string.Empty;
                    LblEmpleado.Text = string.Empty;
                    lblnroOrden.Text = string.Empty;
                    lblhora.Text = string.Empty;
                    lblproveedor.Text = string.Empty;
                    lblFecha.Text = string.Empty;
                    TextBox1.Text = string.Empty;
                    lblerror.Text = string.Empty;
                    lblerror0.Text = string.Empty;
                    lblerror1.Text = string.Empty;
                    lblerror2.Text = string.Empty;
                    lblerror.Visible = false;
                    lblerror0.Visible = false;
                    lblerror1.Visible = false;
                    lblerror2.Visible = false;


                }
                catch (Exception ex)
                {
                    lblerror2.Visible = true;
                    lblerror2.Text = ex.Message.ToString();
                }

            }
            else
            {
                lblerror2.Text = "Seleccione productos con cantidad";
                lblerror2.Visible = true;
            }
        }

        protected void gridproductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string nom;
            //int id;
            //int cant;


            //nom = gridproductos.SelectedRow.Cells[1].Text;
            //id = Convert.ToInt32(gridproductos.SelectedRow.Cells[0].Text);
            //cant = Convert.ToInt32(tbcantidad.Text);

            tbcantidad.Enabled = true;
            btnañadir.Enabled = true;
        }

        protected void btnañadir_Click(object sender, EventArgs e)
        {
            string nom;
            int id;
            int cant;
            double precio;
            bool bandera = true;

            id = Convert.ToInt32(gridproductos.SelectedRow.Cells[0].Text);

            for (int i = 0; i < griddetallefactura.Rows.Count; i++)
            {
                if(id == Convert.ToInt32(data.Rows[i][0].ToString()))
                {
                    bandera = false;
                }
            }


            if (bandera == true)
            {
                if (tbcantidad.Text != "" && Convert.ToInt32(tbcantidad.Text) > 0)
                {
                    lblerror1.Visible = false;
                    nom = gridproductos.SelectedRow.Cells[1].Text;
                    id = Convert.ToInt32(gridproductos.SelectedRow.Cells[0].Text);
                    cant = Convert.ToInt32(tbcantidad.Text);
                    precio = Convert.ToDouble(gridproductos.SelectedRow.Cells[2].Text);

                    DataRow linea;
                    linea = data.NewRow();
                    linea["ID"] = id;
                    linea["Nombre"] = nom;
                    linea["Cantidad"] = Convert.ToInt32(cant);
                    linea["Precio"] = precio;
                    data.Rows.Add(linea);

                    if (data.Rows.Count > 0)
                    {
                        lblerror1.Visible = false;
                        griddetallefactura.DataSource = data;
                        griddetallefactura.DataBind();
                        griddetallefactura.Visible = true;
                        lblDetCompra.Visible = true;
                    }
                    else
                    {
                        lblerror1.Text = "Ingrese productos";
                        lblerror1.Visible = true;
                    }

                }
                else
                {
                    lblerror1.Text = "Ingrese una cantidad valida";
                    lblerror1.Visible = true;
                }
            }
            else
            {
                lblerror1.Text = "Producto ya agregado";
                lblerror1.Visible = true;
            }
            tbcantidad.Text = string.Empty;
            
        }

        protected void griddetallefactura_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void griddetallefactura_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            data.Rows.RemoveAt(e.RowIndex);
            griddetallefactura.DataSource = data;
            griddetallefactura.DataBind();
        }

        protected void btncancelar_Click(object sender, EventArgs e)
        {
           
            
            DataTable dt = new DataTable();
            gridcliente.DataSource = dt;
            gridcliente.DataBind();
            //gridcliente.Dispose();
            gridcliente.Visible = false;
            griddetallefactura.DataSource = dt;
            griddetallefactura.DataBind();
            //griddetallefactura.Dispose();
            griddetallefactura.Visible = false;
            gridproductos.DataSource = dt;
            gridproductos.DataBind();
            //gridproductos.Dispose();
            gridproductos.Visible = false;
            tbcantidad.Text = string.Empty;
            tbcantidad.Enabled = false;
            tbnombre.Text = string.Empty;
            LblEmpleado.Text = string.Empty;
            lblnroOrden.Text = string.Empty;
            lblhora.Text = string.Empty;
            lblproveedor.Text = string.Empty;
            lblFecha.Text = string.Empty;
            TextBox1.Text = string.Empty;
            lblerror.Text = string.Empty;
            lblerror0.Text = string.Empty;
            lblerror1.Text = string.Empty;
            lblerror2.Text = string.Empty;
            lblerror.Visible = false;
            lblerror0.Visible = false;
            lblerror1.Visible = false;
            lblerror2.Visible = false;

            panelregistrarorden.Visible = false;
            panelseleccionarproveedor.Visible = true;
        }
    }
}
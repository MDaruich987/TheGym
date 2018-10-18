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
        }

        protected void btnregistrar_Click(object sender, EventArgs e)
        {
            if (griddetallefactura.Rows.Count > 0)
            {
                //Codigo
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



            if (tbcantidad.Text != "" && Convert.ToInt32(tbcantidad.Text) > 0)
            {
                lblerror1.Visible = false;
                nom = gridproductos.SelectedRow.Cells[1].Text;
                id = Convert.ToInt32(gridproductos.SelectedRow.Cells[0].Text);
                cant = Convert.ToInt32(tbcantidad.Text);

                DataRow linea;
                linea = data.NewRow();
                linea["ID"] = id;
                linea["Nombre"] = nom;
                linea["Cantidad"] = Convert.ToInt32(cant);
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

        protected void griddetallefactura_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void griddetallefactura_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            data.Rows.RemoveAt(e.RowIndex);
            griddetallefactura.DataSource = data;
            griddetallefactura.DataBind();
        }
    }
}
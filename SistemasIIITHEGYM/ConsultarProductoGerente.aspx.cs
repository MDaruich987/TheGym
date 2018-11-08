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
    public partial class ConsultarProductoGerente : System.Web.UI.Page
    {
        static string id;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProveedores();
                panelconsulta.Visible = true;
                paneldatosdecobro.Visible = false;
                panelconsulta.Focus();
                if (Session["inicio"] != null)
                {
                    //declaramos una variale sesion para mantener el dato del usuario
                    string usuario = (string)Session["Usuario"];
                    lblusuario.Text = "Bienvenido/a " + (String)Session["inicio"];
                    tbdescripcion.Enabled = false;
                    TextBox1.Enabled = false;
                    ddlProveedor.Enabled = false;
                    tbprecio.Enabled = false;
                    //tbstock.Enabled = false;
                    //tbstockminimo.Enabled = false;
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
            }
            else
            {
                lblerror.Visible = true;
                lblerror.Text = "No se encontraron servicios";
            }
        }


        protected void btneditar_Click(object sender, EventArgs e)
        {
            if (btneditar.Text == "Editar")
            {

                tbdescripcion.Enabled = true;
                TextBox1.Enabled = true;
                //TextBox2.Enabled = false;
                tbprecio.Enabled = true;
                tbprecio0.Enabled = true;
                //tbstock.Enabled = true;
                //tbstockminimo.Enabled = true;

                btneditar.Text = "Guardar";
                btneditar.CausesValidation = true;
                btnvolver.Text = "Cancelar";
                btnvolver.Visible = true;
                //significa que estaba viendo los campos y ahora quiere editar
                //mandamos todos los valores de los campos al panel de edicion
            }
            else
            {
                btneditar.CausesValidation = false;
                try
                {
                    TheGym k = new TheGym
                    {
                        NombreProducto = TextBox1.Text,
                        FKproveedor = ddlProveedor.SelectedValue,
                        PrecioCompra = tbprecio.Text,
                        PrecioVenta = tbprecio0.Text,
                        DescripcionProducto = tbdescripcion.Text,
                        IdProducto = id
                    };
                    k.GetUpProducto();

                    TextBox1.Text = string.Empty;
                    ddlProveedor.ClearSelection();
                    tbprecio.Text=string.Empty;
                    tbprecio0.Text = string.Empty;
                    tbdescripcion.Text = string.Empty;
                    TextBox1.Enabled = false;
                    ddlProveedor.Enabled = false;
                    tbprecio.Enabled = false;
                    tbprecio0.Enabled = false;
                    tbdescripcion.Enabled = false;
                    btneditar.Text = "Editar";
                }
                catch
                {
                    lblerror.Text = "Error al actualizar Producto";
                }

            }
        }

        protected void btnvolver_Click(object sender, EventArgs e)
        {
            //significa que estaba viendo y ahora vuelve a la busqueda
            if (btnvolver.Text=="Volver")
            { 
            btneditar.CausesValidation = false;
            btnvolver.CausesValidation = false;
            paneldatosdecobro.Visible = true;
            panelconsulta.Visible = false;
            gvproductos.Dispose();
            gvproductos.DataBind();
            paneldatosdecobro.Focus();
            lblerror.Text = "";
            btneditar.Text = "Editar";
            btnvolver.Text = "Volver";
            }
            else
            {
                panelconsulta.Visible = true;
                paneldatosdecobro.Visible = false;

            }
            gvproductos.Dispose();
            gvproductos.Visible = false;

        }


        protected void gvproductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlProveedor.Enabled = false;
            //cuando seleccionamos una fila del grid
            try
            {
                //mostrar un panel y ocultar otro
                panelconsulta.Visible = false;
                paneldatosdecobro.Visible = true;
                paneledicion.Focus();
                //codigo para cargar los valores de la fila en los textbox del panel de edicion
                TheGym k = new TheGym()
                {
                    IdProducto = gvproductos.SelectedRow.Cells[0].Text
                };
                id = k.IdProducto;
                DataTable dt = k.GetoneProducto();
                if (dt.Rows.Count > 0)
                {
                    TextBox1.Text =dt.Rows[0][1].ToString();
                    tbdescripcion.Text = dt.Rows[0][2].ToString();
                    ddlProveedor.SelectedValue = dt.Rows[0][3].ToString();
                    tbprecio.Text = dt.Rows[0][4].ToString();
                    tbprecio0.Text = dt.Rows[0][5].ToString();

                    TextBox1.Enabled = false;
                    tbdescripcion.Enabled = false;
                    ddlProveedor.Enabled = false;
                    tbprecio.Enabled = false;
                    tbprecio0.Enabled = false;

                }


            }
            catch (Exception ex)
            {

                lblerror.Text = ex.Message.ToString();
            }
        }

        protected void btnconsultar_Click(object sender, EventArgs e)
        {
            TheGym k = new TheGym
            {
                NombreProducto = TextBox1.Text
            };
            DataTable dt = k.GetProducto();

            if (dt.Rows.Count > 0)
            {
                gvproductos.DataSource = dt;
                gvproductos.DataBind();
            }
            else
            {
                lblerror.Text = "No se encontro el Producto";
            }


        }

        protected void gvproductos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
    }


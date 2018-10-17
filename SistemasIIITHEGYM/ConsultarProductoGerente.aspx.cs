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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                panelconsulta.Visible = true;
                paneldatosdecobro.Visible = false;
                panelconsulta.Focus();
                if (Session["inicio"] != null)
                {
                    //declaramos una variale sesion para mantener el dato del usuario
                    string usuario = (string)Session["Usuario"];
                    lblusuario.Text = "Bienvenido/a " + (String)Session["inicio"];
                    tbdescripcion.Enabled = false;
                    tbnombre.Enabled = false;
                    ddlproveedor.Enabled = false;
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

        protected void btneditar_Click(object sender, EventArgs e)
        {
            if (btneditar.Text == "Editar")
            {

                tbdescripcion.Enabled = true;
                tbnombre.Enabled = true;
                ddlproveedor.Enabled = true;
                tbprecio.Enabled = true;
                //tbstock.Enabled = true;
                //tbstockminimo.Enabled = true;

                btneditar.Text = "Guardar";
                //significa que estaba viendo los campos y ahora quiere editar
                //mandamos todos los valores de los campos al panel de edicion
            }
        }

        protected void btnvolver_Click(object sender, EventArgs e)
        {
            //significa que estaba viendo y ahora vuelve a la busqueda
        }

        protected void gvproductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cuando seleccionamos una fila del grid
            try
            {
                //mostrar un panel y ocultar otro
                panelconsulta.Visible = false;
                paneledicion.Visible = true;
                paneledicion.Focus();
                //codigo para cargar los valores de la fila en los textbox del panel de edicion

               

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
    }

}
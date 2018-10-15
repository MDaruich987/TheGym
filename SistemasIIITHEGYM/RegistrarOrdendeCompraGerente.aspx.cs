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
            }
        }

        protected void gridcliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelseleccionarproveedor.Visible = false;
            panelregistrarorden.Visible = true;
        }

        protected void btnconsultar_Click(object sender, EventArgs e)
        {
            try
            {
                TheGym k = new TheGym
                {
                    NombreProveedorBusc = TextBox1.Text
                };
                DataTable dt = new DataTable();
                dt = k.GetProveedorNom();
                if (dt.Rows.Count > 0)
                {
                    lblerror0.Text = string.Empty;
                    lblerror0.Visible = false;
                    gridcliente.DataSource = dt;
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
            catch
            {
                lblerror0.Text = "Error general";
                lblerror0.Visible = true;
            }
        }
    }
}
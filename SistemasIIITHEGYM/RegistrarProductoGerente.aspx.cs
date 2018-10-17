using SistemasIIITHEGYM.BussinesLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;


namespace SistemasIIITHEGYM
{
    public partial class RegistrarProductoGerente : System.Web.UI.Page
    {
        static bool flag = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["inicio"] != null)
            {
                //declaramos una variale sesion para mantener el dato del usuario
                string usuario = (string)Session["Usuario"];
                lblusuario.Text = "Bienvenido/a " + (String)Session["inicio"];

            }
            else
            {
                //si no se ha iniciado sesion me manda al inicio
                //Response.Redirect("InicioLogin.aspx");
            }

            if (flag == true)
            {
                GetProveedores();
                flag = false;
            }

        }
        private void GetProveedores()
             {
                        TheGym k = new TheGym();
                        DataTable dt = k.GetProveedores();
                        if (dt.Rows.Count > 0)
                        {
                            ddlproveedor.DataValueField = "Id_proveedor";
                            ddlproveedor.DataTextField = "Nombre";
                            ddlproveedor.DataSource = dt;
                            ddlproveedor.DataBind();

                        }
                    }
        protected void btnregistrar_Click(object sender, EventArgs e)
        {
            TheGym k = new TheGym
            {
                NombreProducto = tbnombre.Text,
                FKproveedor = ddlproveedor.SelectedValue,
                DescripcionProducto = tbdescripcion.Text,
                PrecioCompra = tbprecio.Text,
                PrecioVenta = tbprecio0.Text
            };
            try
            {
                k.AddProducto();
                this.Page.Response.Write("<script language='JavaScript'>window.alert('Ejercicio registrado con éxito');</script>");
                Label1.Text = "Producto Registrado";
                Label1.Visible = true;
                tbnombre.Text = String.Empty;
                ddlproveedor.ClearSelection();
                tbdescripcion.Text = string.Empty;
                tbprecio.Text = string.Empty;
                tbprecio0.Text = string.Empty;

            }
            catch (Exception ex) 
            {
                Label1.Text = ex.Message.ToString();
                Label1.Visible = true;
            }

            

        }

        protected void btncancelar_Click(object sender, EventArgs e)
        {
            tbnombre.Text = String.Empty;
            ddlproveedor.ClearSelection();
            tbdescripcion.Text = string.Empty;
            tbprecio.Text = string.Empty;
            tbprecio0.Text = string.Empty;
        }
    }
}
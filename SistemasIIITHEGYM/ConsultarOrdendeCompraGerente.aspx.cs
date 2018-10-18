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
    public partial class ConsultarOrdendeCompraGerente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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

            }
        }

        protected void btnconsultar_Click(object sender, EventArgs e)
        {
            //hay dos paneles: el de consulta que tiene todo el buscar orden de compra y motrar los datos
            //principales de la cabecera en un gridview y despies al seleccionar un elemento de este 
            //se deberia activar el paneldetalle con el detalle de esa orden de compra seleccionada

            try
            {
                if (tbnombre.Text != string.Empty)
                {
                    TheGym k2 = new TheGym
                    {
                        NombreProveedorBusc = tbnombre.Text
                    };
                    DataTable dt2 = new DataTable();
                    dt2 = k2.GetProveedorNom();
                    if (dt2.Rows.Count > 0)
                    {
                        lblerrorproveedor.Text = string.Empty;
                        lblerrorproveedor.Visible = false;
                        gridproveedor.DataSource = dt2;
                        gridproveedor.DataBind();
                        gridproveedor.Visible = true;
                        lblProveedor.Visible = true;
                    }
                    else
                    {
                        DataTable dt1 = new DataTable();
                        gridproveedor.DataSource = dt1;
                        gridproveedor.DataBind();
                        gridproveedor.Visible = false;
                        lblerrorproveedor.Text = "No se encontro proveedor";
                        lblerrorproveedor.Visible = true;
                    }
                }
                else
                {
                    lblerrorproveedor.Text = "Ingrese un nombre valido";
                    lblerrorproveedor.Visible = true;
                }

            }
            catch
            {
                lblerrorproveedor.Text = "Error general";
                lblerrorproveedor.Visible = true;
            }

        }

        protected void gridproveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblerrorgridprov.Visible = false;
                LblOrden.Visible = true;
                TheGym k = new TheGym
                {
                    idproveedor = gridproveedor.SelectedRow.Cells[0].Text
                };
                DataTable dt = new DataTable();
                dt = k.GetOrdenIDprov();
                if (dt.Rows.Count > 0)
                {
                    gridorden.DataSource = dt;
                    gridorden.DataBind();
                    gridorden.Visible = true;
                }
                else
                {
                    gridorden.DataSource = dt;
                    gridorden.DataBind();
                    gridorden.Visible = false;
                    lblerrorgridprov.Visible = true;
                    lblerrorgridprov.Text = "No se encontraron ordenes de compra";
                }

            }
            catch
            {
                lblerrorgridprov.Visible = true;
                lblerrorgridprov.Text = "Error General";
            }
        }
    }
}
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
    public partial class ConsultarFacturadeVentaEmpleado : System.Web.UI.Page
    {
        static DataTable Tabla = new DataTable();

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
            gridfacturadeventa.Dispose();
            gridfacturadeventa.Visible = false;
            lblerrorfactura.Visible = false;
            if(Convert.ToDateTime(TextBox1.Text) < Convert.ToDateTime(TextBox2.Text) && Convert.ToDateTime(TextBox2.Text) <= DateTime.Today.Date)
            {
                TheGym k = new TheGym
                {
                    FacturaDesde = TextBox1.Text,
                    FacturaHasta = TextBox2.Text
                };
                DataTable dt = new DataTable();
                dt = k.GetFacturaVentaFecha();
                Tabla = dt;
                if (dt.Rows.Count > 0)
                {
                    gridfactura.DataSource = dt;
                    gridfactura.DataBind();
                    gridfactura.Visible = true;
                }
                else
                {
                    lblerrorfactura.Visible = true;
                    lblerrorfactura.Text = "No hay facturas en las fechas seleccionadas";
                }
            }
            else
            {
                lblerrorfactura.Visible = true;
                lblerrorfactura.Text = "Ingrese Fechas validas";
            }
        }

        protected void gridfactura_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                TheGym k = new TheGym
                {
                    FacturaIDFact = gridfactura.SelectedRow.Cells[1].Text
                };
                DataTable dt = new DataTable();
                dt = k.GetDetalleFactura();
                if(dt.Rows.Count > 0)
                {
                    paneldetalle.Visible = true;
                    gridfacturadeventa.DataSource = dt;
                    gridfacturadeventa.DataBind();
                    gridfacturadeventa.Visible = true;
                }
                else
                {
                    lblerrorfactura.Visible = true;
                    lblerrorfactura.Text = "Sin Detalle";
                }

            }
            catch
            {
                lblerrorfactura.Visible = true;
                lblerrorfactura.Text = "Error al recuperar datos de Detalle";
            }
        }

        protected void gridfactura_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridfactura.PageIndex = e.NewPageIndex;
            gridfactura.DataSource = Tabla;
            gridfactura.DataBind();
        }
    }
}
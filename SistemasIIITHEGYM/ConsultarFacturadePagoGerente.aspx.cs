using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemasIIITHEGYM
{
    public partial class ConsultarFacturadePagoGerente : System.Web.UI.Page
    {
        static DataTable TablaFactura = new DataTable();
        static DataTable TablaDetalle = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

            

            if (!IsPostBack)
            {
                //la primera vez que se carga la página
                //muestra el panel de  busqueda, no el de edicion
                //lblmensajebienvenida.Text = Session["inicio"].ToString();
                //si efectivamente se ha iniciado sesión
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
            }

        }

        protected void btnconsultar_Click(object sender, EventArgs e)
        {

        }

        protected void gridfactura_SelectedIndexChanged(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#modal-detalle').modal('show');", true);
        }

        protected void griddetallefactura_SelectedIndexChanged(object sender, EventArgs e)
        {
            //este es el grid del modal del popup
        }

        protected void griddetallefactura_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //para que se pagine
            //griddetallefactura.PageIndex = e.NewPageIndex;
            //griddetallefactura.DataSource = TablaDetalle;
            //griddetallefactura.DataBind();
        }

        protected void gridfactura_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            //para que se pagine
            //gridfactura.PageIndex = e.NewPageIndex;
            //gridfactura.DataSource = TablaFactura ;
            //gridfactura.DataBind();
        }
    }
}
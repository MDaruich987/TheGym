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
    public partial class ConsultarDeposito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //la primera vez que se carga la página
                //muestra el panel de  busqueda, no el de edicion
                paneledicion.Visible = true;
                panelconsulta.Focus();
                paneledicion.Visible = false;

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

        protected void gridsucursales_SelectedIndexChanged(object sender, EventArgs e)
        {
            //mostramos el panel de edicion, que es donde se verán los productos en stock en esa sucursal
            //aqui se puede buscar por productos tambien
            panelconsulta.Visible = false;
            paneledicion.Visible = true;

        }

        protected void btnconsultar_Click(object sender, EventArgs e)
        {
            //aqui se debe buscar sobre el gridview de propiedas por productos


            gridsucursales.Visible = true;

            TheGym k = new TheGym();
            k.NomSucBuscar = tbnombre.Text;
            DataTable dt = k.GetOneSucursal();

            if (dt.Rows.Count > 0)
            {
                gridsucursales.DataSource = dt;
                gridsucursales.DataBind();
                gridsucursales.Focus();
            }

        }

        protected void gridsucursales_SelectedIndexChanged1(object sender, EventArgs e)
        {

            try
            {
                paneledicion.Visible = true;
                panelconsulta.Visible = false;
                paneledicion.Focus();
                griddepositoproductos.Visible = true;


                TheGym k = new TheGym
                {
                    NombreDepositoBusc = "",
                    IdDep = griddepositoproductos.SelectedRow.Cells[0].Text
                };

                DataTable dt1 = new DataTable();
                dt1 = k.GetAllDatosDeposito();

                if (dt1.Rows.Count > 0)
                {
                    griddepositoproductos.DataSource = dt1;
                    griddepositoproductos.DataBind();
                    griddepositoproductos.Focus();
                }
            }
            catch (Exception ex)
            {
                lblerrorsucursales.Text = ex.Message.ToString();
            }
        }

    }
}
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
    public partial class ConsultarMovimientos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //la primera vez que se carga la página
                //muestra el panel de  busqueda, no el de edicion
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
            gridplanes.Visible = false;
            DataTable emp = new DataTable();
            gridplanes.DataSource = emp;
            gridplanes.DataBind();
            if (DateTime.Compare(Convert.ToDateTime(tbbusqueda.Text),DateTime.Now.Date) <= 0)
            {
                lblerror.Visible = false;
                TheGym k = new TheGym
                {
                    FechaCaja = tbbusqueda.Text.ToString()
                };
                DataTable dt = new DataTable();
                dt = k.GetMovimientoCaja();
                if (dt.Rows.Count > 0)
                {
                    gridplanes.DataSource = dt;
                    gridplanes.DataBind();
                    gridplanes.Visible = true;
                }
                else
                {
                    lblerror.Visible = true;
                    lblerror.Text = "Sin movimientos en la fecha";
                }
            }
            else
            {
                lblerror.Visible = true;
                lblerror.Text = "Seleccione una fecha posterior o igual a la actual.";
            }
            

        }
    }
}
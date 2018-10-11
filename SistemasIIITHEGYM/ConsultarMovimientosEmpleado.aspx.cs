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
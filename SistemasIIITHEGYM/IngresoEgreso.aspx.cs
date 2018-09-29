using SistemasIIITHEGYM.BussinesLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemasIIITHEGYM
{
    public partial class IngresoEgreso : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            lblerror.Text = string.Empty;
            btnregistrar.Visible = false;
            lblerror.Visible = false;
            Label1.Visible = false;
        }

        protected void btnregistrar_Click(object sender, EventArgs e)
        {

            TheGym k = new TheGym
            {
                IDIngresoCliente = tbid.Text
            };

            DataTable dt = k.ConsultarVencimiento();

            if (dt.Rows.Count > 0)
            {
                k.IDSucIngreso = "2";
                k.AddIngresoCliente();
                lblerror.Text = "Cuotas al dia, bienvenido!";
            }
            else
            {
                lblerror.Text = "Cuota vencida";
            }
           
        }

        protected void btnverificar_Click(object sender, EventArgs e)
        {

            TheGym k = new TheGym
            {
                IDIngresoCliente = tbid.Text
            };

            DataTable dt = k.GetOneCliente();

            if (dt.Rows.Count > 0)
            {
                lblerror.Visible = false;
                Label1.Visible = true;
                Label1.Text = dt.Rows[0][0].ToString();
                btnregistrar.Visible = true;
            }
            else
            {
                lblerror.Visible = true;
                lblerror.Text = "Error de usuario";

            }

        }
    }
}
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

            };


            //CODIGO COPIADO DE INGRESO EGRESO EMPLEADO
            //try
            //{
            //    TheGym k = new TheGym
            //    {
            //        IDEmpleadoIngreso = tbid.Text,
            //        EstadoIngresoEmpleado = estado,

            //    };
            //    k.AddIngresoEmpleado();
            //    lblerror.Text = "se efectuó el registro";
            //    Label1.Text = "";
            //    btnregistrar.Visible = false;


            //}
            //catch (Exception ex)
            //{

            //    lblerror.Text = ex.Message.ToString();
            //}
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemasIIITHEGYM
{
    public partial class AperturadeCajaEmpleado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnregistrar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(tbmonto.Text) > 0)
            {
                //verificamos que el monto sea postivo
                //bloque try-catch por cualquier error de la base de datos
                try
                {

                }
                catch (Exception ex)
                {

                    lblerror.Text = ex.Message.ToString();
                }
            }
            else
            {
                //el monto no es positivo
                lblerror.Text = "El monto ingresado debe ser positivo";
            }
        }
    }
}
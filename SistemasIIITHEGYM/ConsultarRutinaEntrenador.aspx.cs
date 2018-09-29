using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemasIIITHEGYM
{
    public partial class ConsultarRutinaEntrenador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //mostramos solo el panel de busqueda
                panelconsulta.Visible = true;
                paneledicion.Visible = false;
                panelconsulta.Focus();
            }
            
        }

        protected void gridfichaderutina_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ocultamos el panel de busqueda y mostramos el de edicion
            //aqui debemos llenar los valores de los controles con el elemento seleccionado
            panelconsulta.Visible = false;
            paneledicion.Visible = true;
            paneledicion.Focus();
        }
    }
}
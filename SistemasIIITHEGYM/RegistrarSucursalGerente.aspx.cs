using SistemasIIITHEGYM.BussinesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemasIIITHEGYM
{
    public partial class RegistrarSucursalGerente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnregistrar_Click(object sender, EventArgs e)
        {
            //string Nombre;
            //string Direccion;
            //int Telefono;

            //Nombre = tbnombre.Text;
            //Direccion = tbdireccion.Text;
            //Telefono = Convert.ToInt16(tbtelefono.Text);

            TheGym k = new TheGym
            {
                NombreSucursal = tbnombre.Text,
                //falta lo de la direccion
                TelefonoSucursal = Convert.ToInt64(tbtelefono.Text)
            };

            k.AddNewSucursal();


            tbnombre.Text = string.Empty;
            tbtelefono.Text = string.Empty;
        }
    }
}
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
    public partial class RegistrarCobroPlanEmpleado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //la primera vez que se carga la página
                //muestra el panel de  busqueda, no el de edicion
                paneldatosdecobro.Visible = false;
                panelseleccioncliente.Focus();
                panelseleccioncliente.Visible = true;
                //Response.Write("<script>window.alert('Bienvenido');</script>");
                //preguntamos si no se realizo la apertura de caja del día en el 5==5
                //if (5==5){
                //Response.Write("<script>window.alert('No se realizó la apertura de caja del día. Debe registrar una primero');</script>" + "<script>window.setTimeout(location.href='AperturadeCajaEmpleado.aspx', 2000);</script>");
                    //si no, me manda a la pagina de apertura de caja
               // }
            }
        }

        protected void btnconsultar_Click(object sender, EventArgs e)
        {
            gridclientes.Visible = true;

            TheGym k = new TheGym();
            k.NombreClienteBusc = tbnombre.Text;
            DataTable dt = k.GetClienteNom();
            if (dt.Rows.Count > 0)
            {
                gridclientes.DataSource = dt;
                gridclientes.DataBind();
                gridclientes.Focus();
            }
        }

        protected void gridclientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            // cuando seleccionamos una fila del grid
            try
            {
                //mostrar un panel y ocultar otro
                panelseleccioncliente.Visible = false;
                paneldatosdecobro.Visible = true;
                paneldatosdecobro.Focus();
                //codigo para cargar los valores de la fila en los textbox del panel de edicion

            }
            catch (Exception ex)
            {

                lblerror.Text = ex.Message.ToString();
            }
        }

        protected void btnregistrar_Click(object sender, EventArgs e)
        {


            //mensaje de registro exitoso
            this.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert ('El cobro se ha registrado exitosamente');</script>");
        }

        protected void btncancelar_Click(object sender, EventArgs e)
        {
            panelseleccioncliente.Visible = true;
            panelseleccioncliente.Focus();
            paneldatosdecobro.Visible = false;
            tbnombre.Text = "";
        }
    }
}
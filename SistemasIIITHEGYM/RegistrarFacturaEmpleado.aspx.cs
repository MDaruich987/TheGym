using SistemasIIITHEGYM.BussinesLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemasIIITHEGYM
{
    public partial class RegistrarFacturaEmpleado : System.Web.UI.Page
    {
        static string IDcliente;
        SqlConnection conex = new SqlConnection(ConfigurationManager.ConnectionStrings["MiConec"].ConnectionString.ToString());
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                //consultar si ya se realizó la apertura de caja
                //abrimos la conexion
                conex.Open();
                //creamos un comando sql, le pasamos la consulta a enviar a la base de datos y la conexion
                SqlCommand com = new SqlCommand("select Monto from DetalleCaja where Convert(varchar(10),Fecha,103)=@Fecha", conex);
                //con el @ parametrizamos nuestros elementos, y ahora le agregamos el valor
                com.Parameters.AddWithValue("@Fecha", DateTime.Now.ToShortDateString());
                //creamos un objetosql data adapter y le pasamos nuestro comando sql
                SqlDataAdapter dap = new SqlDataAdapter(com);
                //creamos un data table 
                DataTable dat = new DataTable();
                //para llenarlo con los datos de la tabla desde el data adapter
                dap.Fill(dat);
                //lblusuario.Text = dat.Rows[0][0].ToString()+ dat.Rows[0][1].ToString()+ dat.Rows[0][2].ToString();
                //evaluamos si la consulta nos devuelve filas quiere decir que si hay un elemento que coincida
                if (dat.Rows.Count==0){
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#modal-redirect').modal('show');", true);
                    //Response.AddHeader("REFRESH", "3;URL=AperturadeCajaEmpleado.aspx");
                    //tbnombre.Enabled = false;
                    //btnconsultar.Enabled =false;
                    //si no, me manda a la pagina de apertura de caja a los 3 segundos
                    }
                else
                {
                    //si la apertura esta registrada, habilitamos la busqueda
                    tbnombre.Enabled = true;
                    btnconsultar.Enabled = true;
                }
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
                panelseleccionarcliente.Visible = true;
                panelregistrarfactura.Visible = false;
            }
            

        }


        protected void btnconsultar_Click(object sender, EventArgs e)
        {
            TheGym k = new TheGym();
            k.NombreClienteBusc = tbnombre.Text;
            DataTable dt = k.GetClienteNom();
            if (dt.Rows.Count > 0)
            {
                gridcliente.DataSource = dt;
                gridcliente.DataBind();
                gridcliente.Focus();
            }

        }

        protected void gridcliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //setear hora y fecha en los lbl
                lblFecha.Text = DateTime.Now.ToShortDateString();
                lblhora.Text = DateTime.Now.ToShortTimeString();
                //calculamos cual seria el nro de esta factura
                SqlCommand com = new SqlCommand("select MAX(Id_factura)+1 from Factura", conex);
                //creamos un objetosql data adapter y le pasamos nuestro comando sql
                SqlDataAdapter dap = new SqlDataAdapter(com);
                //creamos un data table 
                DataTable dat = new DataTable();
                //para llenarlo con los datos de la tabla desde el data adapter
                dap.Fill(dat);
                //lblusuario.Text = dat.Rows[0][0].ToString()+ dat.Rows[0][1].ToString()+ dat.Rows[0][2].ToString();
                //obtenemos el numero de factura
                lblnrofactura.Text = dat.Rows[0][0].ToString();
                IDcliente = gridcliente.SelectedRow.Cells[0].Text;
                lblcliente.Text = gridcliente.SelectedRow.Cells[2].Text +", "+ gridcliente.SelectedRow.Cells[1].Text;
            }
            catch (Exception ex)
            {

                lblerror0.Text = ex.Message.ToString();
            }
           
        }
    }
}
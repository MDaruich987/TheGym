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
        public static bool flag=false;

        public static string nombre;
        public static string apellido;

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

            lblFecha.Text = DateTime.Now.ToShortDateString();
            lblhora.Text = DateTime.Now.ToShortTimeString();
            
            //lblnombreusuario.Text = apellido + ", " +nombre;
            
            //lblnombreusuario.Text = gridclientes.SelectedRow.Cells[1].Text;

            if (flag == false)
            {
                GetAllPlan();
                GetAllMedioPago();
                flag = true;
            }
            
        }

        private void GetAllPlan()
        {
            TheGym k = new TheGym();
            DataTable dt = new DataTable();
            dt = k.GetAllPlans();
            if (dt.Rows.Count > 0)
            {
                //DdlPlan.Items.Add("Seleccione...");
                //DdlPlan.DataSource = dt;
                ddlplan.DataTextField = "Nombre";
                ddlplan.DataValueField = "Precio";

                ddlplan.DataSource = dt;
                ddlplan.DataBind();
                // DdlPlan.Items.Add("Seleccione...");
                ddlplan.Items.Insert(0, "Seleccione...");

            }
        }


        private void GetAllMedioPago()
        {
            TheGym k = new TheGym();
            DataTable dt = new DataTable();
            dt = k.GetAllMedioPago();
            if (dt.Rows.Count > 1)
            {
                ddlformadepago.DataTextField = "descripcion";
                ddlformadepago.DataValueField = "id_formapago";
                ddlformadepago.DataSource = dt;
                ddlformadepago.DataBind();
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

            flag = true;
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
                tbmonto.ReadOnly = true;
                TbComprobante.Visible = false;
                lblComprobante.Visible = false;
                //codigo para cargar los valores de la fila en los textbox del panel de edicion

            }
            catch (Exception ex)
            {

                lblerror.Text = ex.Message.ToString();
            }

            nombre = gridclientes.SelectedRow.Cells[0].Text;
            apellido = gridclientes.SelectedRow.Cells[1].Text;
            lblnombreusuario.Text = apellido + ", " + nombre;

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

        protected void ddlformadepago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlformadepago.SelectedItem.Text == "Efectivo")
            {
                lblComprobante.Visible = false;
                TbComprobante.Visible = false;
            }
            else
            {
                lblComprobante.Visible = true;
                TbComprobante.Visible = true;
            }
        }

        protected void ddlplan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlplan.SelectedItem.Text != "Seleccione...")
            {
                tbmonto.Text = ddlplan.SelectedItem.Value.ToString();
             
            }
            else
            {
                tbmonto.Text = string.Empty;
            }
        }
    }
}
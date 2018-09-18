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

        static string aux;

        public static string nombre;
        public static string apellido;
        public static string id;

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
                ddlplan.DataValueField = "Id_plan";

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

            nombre = gridclientes.SelectedRow.Cells[1].Text;
            apellido = gridclientes.SelectedRow.Cells[2].Text;
            id = gridclientes.SelectedRow.Cells[0].Text;
            lblnombreusuario.Text = apellido + ", " + nombre;

        }

        protected void btnregistrar_Click(object sender, EventArgs e)
        {
            string ID;
            int auxiliar;
            DateTime auxiliar1;
            DataTable dt = new DataTable();
            TheGym k = new TheGym
            {
                FechaIdDetCaja = lblFecha.Text
            };
            dt = k.GetEstadoDetCaja();
            if (dt.Rows.Count < 1)
            {
                //dt = ;
                //ID = Session["IdSession"]; GetIdDetCaja
                //ID = 3;
                DataTable dt1 = new DataTable();
                dt1 = k.GetEstadoDetCajaAP();
                if (dt1.Rows.Count > 0)
                {
                    DataTable dt2 = new DataTable();
                    dt2 = k.GetIdDetCaja();
                    ID = dt2.Rows[0][0].ToString();
                    k.FKDetCajaMov = ID;
                    k.FKFormaPagoMov = ddlformadepago.SelectedValue.ToString();
                    k.EstadoMov = "Ingreso";
                    k.ComprobanteMov = TbComprobante.Text;
                    k.MontoMov = tbmonto.Text;
                    k.ConceptoMov = "Pago Plan";
                    k.HoraMov = Convert.ToString(DateTime.Now.TimeOfDay);

                    k.AddMovimientoCaja();

                    k.FechaCuota = lblFecha.Text;
                    k.FK_clienteCuota = id;
                    k.FK_planCuota = ddlplan.SelectedValue.ToString();
                    k.MontoCuota = tbmonto.Text;
                    DataTable aux1 = new DataTable();
                    k.IDPlanVencimiento = ddlplan.SelectedValue;
                    aux1 = k.GetVencimiento();
                    auxiliar = Convert.ToInt32(aux1.Rows[0][0].ToString());
                    auxiliar1 = Convert.ToDateTime(lblFecha.Text).AddDays(auxiliar);
                    k.VencimientoCuota = Convert.ToString(auxiliar1);
                    k.AddCuota();

                    this.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert ('El cobro se ha registrado exitosamente');</script>");

                    tbmonto.Text = string.Empty;
                    TbComprobante.Text = string.Empty;
                    lblComprobante.Visible = false;
                    TbComprobante.Visible = false;
                    ddlformadepago.ClearSelection();
                    ddlplan.ClearSelection();

                    panelseleccioncliente.Visible = true;
                    panelseleccioncliente.Focus();
                    paneldatosdecobro.Visible = false;
                    tbnombre.Text = "";


                }
                else
                {
                    lblerror.Visible = true;
                    lblerror.Text = "Caja No Abierta";
                    lblerror.ForeColor = System.Drawing.Color.Red;
                }

            }
            else
            {
                lblerror.Visible = true;
                lblerror.Text = "Caja Cerrada";
                lblerror.ForeColor = System.Drawing.Color.Red;
            }

            //mensaje de registro exitoso
            //this.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert ('El cobro se ha registrado exitosamente');</script>");
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
            //.Visible = true;
            //DdlMedioPago.Visible = true;
            //GetAllMedioPago();
            aux = ddlplan.SelectedValue;
            if (aux != "Seleccione...")
            {
                TheGym k = new TheGym
                {
                    IdPlanMonto = aux
                };
                DataTable dt = new DataTable();
                dt = k.GetTotalPlan();
                tbmonto.Text = dt.Rows[0][0].ToString();
            }
            else
            {
                tbmonto.Text = "";
                //LblMedioPago.Visible = false;
                //DdlMedioPago.Visible = false;
            }
        }
    }
}
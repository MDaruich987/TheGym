using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using SistemasIIITHEGYM.BussinesLayer;


namespace SistemasIIITHEGYM
{
    public partial class CierredeCajaEmpleado : System.Web.UI.Page
    {
        private static string id;
        private static string IdSuc;
        //cadena mili
        SqlConnection conex = new SqlConnection("Data Source=DESKTOP-T2J3I6L;Initial Catalog=TheGym;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            //formato fecha
            lblFecha.Text = DateTime.Now.ToShortDateString();
            //formato dia
            lblhora.Text = DateTime.Now.ToString("hh:mm tt");
            lblestadocaja1.Text = "Cierre";
            id = "3";
            lblnombreusuario.Text = id;
            //lblmensajebienvenida.Text = Session["inicio"].ToString();
            //si efectivamente se ha iniciado sesión
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

            CargaSucursal();
        }
        private void CargaSucursal()
        {
            TheGym k = new TheGym
            {
                IdEmpleadoCargaSuc = id
            };
            DataTable dt = k.GetAllSucursal();
            lblsucursal.Text = dt.Rows[0][0].ToString();
            IdSuc = dt.Rows[0][1].ToString();
        }

        protected void btnregistrar_Click(object sender, EventArgs e)
        {
            string fecha;
            string id1;
            //
            if (Convert.ToInt32(tbmonto.Text) > 0)
            {
                //verificamos que el monto sea postivo
                //bloque try-catch por cualquier error de la base de datos
                try
                {
                                             //aca va todo el codigo
                    try
                    {

                        fecha = lblFecha.Text;

                        TheGym k = new TheGym
                        {
                            FechaIdDetCaja = fecha
                        };

                        DataTable dt = new DataTable();
                        dt = k.GetEstadoDetCaja();

                        //preguntamos si ya hay un cierre hecho 
                        if (dt.Rows.Count == 0)
                        {
                            dt = k.GetIdDetCaja();
                            id1 = dt.Rows[0][0].ToString();
                            k.FK_det_caja = id1;
                            DataTable dt1 = new DataTable();
                            dt1 = k.CierreDeCaja();

                            //mostrar movimientos del dia en el gridview
                            if (dt1.Rows.Count > 0)
                            {
                                gridmovimientos.DataSource = dt1;
                                gridmovimientos.DataBind();
                                tbmonto.Visible = true;
                                tbmonto.Visible = true;
                                tbmonto.Text = gridmovimientos.Rows[0].Cells[0].Text;
                                tbmonto.Enabled = false;
                            }
                            else
                            {
                                lblerror.Text = "Error en movimientos de caja";
                            }

                            k.Monto = tbmonto.Text;
                            k.FK_empleado = id;
                            k.CierreCajaDet();

                        }
                        else
                        {
                            //si da mayor a 0, viee para acá
                            lblerror.Text = "Caja ya cerrada";
                        }
                    }               
                    catch (Exception ex)
                    {

                        lblerror.Text = ex.Message.ToString();
                    }

                                    //
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
            //cierre comprobar positivos

           



        }
    }


}
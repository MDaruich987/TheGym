using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SistemasIIITHEGYM.BussinesLayer;
using System.Data;
using System.Data.SqlClient;


namespace SistemasIIITHEGYM
{
    public partial class AperturadeCajaEmpleado : System.Web.UI.Page
    {

        private static string id;
        private static string IdSuc;
        //cadena mili
        SqlConnection conex = new SqlConnection("Data Source=DESKTOP-TN40SE1\\SQLEXPRESS;Initial Catalog=TheGym;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToShortDateString();
            lblhora.Text = DateTime.Now.ToShortTimeString();
            lblusuario.Text = "USUARIO";
            id = "3";
            //lblmensajebienvenida.Text = Session["inicio"].ToString();
            //si efectivamente se ha iniciado sesión
            if (Session["inicio"] != null)
            {
                //declaramos una variale sesion para mantener el dato del usuario
                string usuario = (string)Session["Usuario"];
                lblusuario.Text = "Bienvenido/a " + (String)Session["inicio"];
                lblusuario.Text = (string)Session["Usuario"];
                lblnombreusuario.Text = "";
                lblsucursal.Text = "";
                lblestadocaja.Text = "";
                lblerror.Text = "";
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

            //CODIGO COPIADO 

            //try
            //{
            //    //abrimos la conexion
            //    conex.Open();
            //    //creamos un comando sql, le pasamos la consulta a enviar a la base de datos y la conexion
            //    SqlCommand com = new SqlCommand("select * from DetalleCaja where Fecha = convert(date, getdate())", conex);
            //    //creamos un objetosql data adapter y le pasamos nuestro comando sql
            //    SqlDataAdapter dap = new SqlDataAdapter(com);
            //    //creamos un data table 
            //    DataTable dat = new DataTable();
            //    //para llenarlo con los datos de la tabla desde el data adapter
            //    dap.Fill(dat);
            //    //lblusuario.Text = dat.Rows[0][0].ToString()+ dat.Rows[0][1].ToString()+ dat.Rows[0][2].ToString();
            //    //evaluamos si la consulta nos devuelve filas quiere decir que si hay un elemento que coincida
            //    if (dat.Rows.Count >= 1)
            //    {
            //        //si al contar las filas del data table tenemos uno, el login es correcto
            //        //verificamos si es un admin o empleado
            //        if (dat.Rows[0][0].ToString() == "3" | dat.Rows[0][0].ToString() == "4" | dat.Rows[0][0].ToString() == "5" | dat.Rows[0][0].ToString() == "6")
            //        {
            //            lblerror.Text = "Ya se realizó la apertura de caja diaria.";
            //        }
            //    }
            //    else
            //    {
            //        if (tbmonto.Text == string.Empty)
            //        {
            //            lblerror.Text = "Se debe ingresar un monto";
            //            lblerror.Visible = true;
            //        }
            //        else
            //        {
            //            TheGym k = new TheGym
            //            {
            //                FK_empleado = id,
            //                Estadocaja = lblestadocaja.Text,
            //                FechaCaja = lblFecha.Text,
            //                Monto = tbmonto.Text
            //            };

            //            k.AperturaDeCaja();

            //            lblerror.Text = "Apertura de caja diaria realizada.";
            //        }
            //    }

            //}
            //catch (Exception ex)
            //{
            //    lblerror.Text = ex.Message.ToString();

            //}

            //CODIGO QUE YA ESTABA

            if (Convert.ToInt32(tbmonto.Text) > 0)
            {
                //verificamos que el monto sea postivo
                //bloque try-catch por cualquier error de la base de datos
                try
                {
                    try
                    {
                        //abrimos la conexion
                        conex.Open();
                        //creamos un comando sql, le pasamos la consulta a enviar a la base de datos y la conexion
                        SqlCommand com = new SqlCommand("select * from DetalleCaja where Fecha = convert(date, getdate())", conex);
                        //creamos un objetosql data adapter y le pasamos nuestro comando sql
                        SqlDataAdapter dap = new SqlDataAdapter(com);
                        //creamos un data table 
                        DataTable dat = new DataTable();
                        //para llenarlo con los datos de la tabla desde el data adapter
                        dap.Fill(dat);
                        //lblusuario.Text = dat.Rows[0][0].ToString()+ dat.Rows[0][1].ToString()+ dat.Rows[0][2].ToString();
                        //evaluamos si la consulta nos devuelve filas quiere decir que si hay un elemento que coincida
                        if (dat.Rows.Count >= 1)
                        {
                            //si al contar las filas del data table tenemos uno, el login es correcto
                            //verificamos si es un admin o empleado
                            if (dat.Rows[0][0].ToString() == "3" | dat.Rows[0][0].ToString() == "4" | dat.Rows[0][0].ToString() == "5" | dat.Rows[0][0].ToString() == "6")
                            {
                                lblerror.Text = "Ya se realizó la apertura de caja diaria.";
                            }
                        }
                        else
                        {
                            if (tbmonto.Text == string.Empty)
                            {
                                lblerror.Text = "Se debe ingresar un monto";
                                lblerror.Visible = true;
                            }
                            else
                            {
                                TheGym k = new TheGym
                                {
                                    FK_empleado = id,
                                    Estadocaja = lblestadocaja.Text,
                                    FechaCaja = lblFecha.Text,
                                    Monto = tbmonto.Text
                                };

                                k.AperturaDeCaja();

                                this.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert ('Apertura de caja registrada exitosamente');</script>");
                                tbmonto.Enabled = false;
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        lblerror.Text = ex.Message.ToString();

                    }
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
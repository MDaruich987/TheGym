using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace SistemasIIITHEGYM
{
    public partial class IngresoEgresoEmpleado : System.Web.UI.Page
    {
        
        //coneccion base david
        SqlConnection conex = new SqlConnection("Data Source=DESKTOP-TN40SE1\\SQLEXPRESS;Initial Catalog=TheGym;Integrated Security=True;");
        //coneccion base mica
        //coneccion base mili
        //coneccion base cami
        //coneccion base maxi

        //conectar tambien en las propiedades del sqldatasource a donde dice conecction string con la base de cada uno
        static string estado = "Ingreso";

        protected void Page_Load(object sender, EventArgs e)
        {
            //lblerror.Text = string.Empty;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {   //registra el estado
                conex.Open();
                SqlDataSource2.InsertParameters["codigo"].DefaultValue = tbid.Text;
                SqlDataSource2.InsertParameters["estado"].DefaultValue = estado;
                SqlDataSource2.Insert();
                lblerror.Text = "se efectuó el registro";
                Label1.Text = "";
                conex.Close();
                Button1.Visible = false;
            }
            catch (Exception ex)
            {

                lblerror.Text = ex.Message.ToString();
            }
        }

        protected void btnverificar_Click(object sender, EventArgs e)
        {
            try
            {
                conex.Open();
                SqlCommand asist = new SqlCommand("select * from Asistencia where FK_empleado=@Id_empleado and Fecha= CONVERT(date,GETDATE()) and Estado='Ingreso'", conex);
                asist.Parameters.AddWithValue("Id_empleado", Convert.ToInt32(tbid.Text));
                SqlDataAdapter da = new SqlDataAdapter(asist);
                DataTable dat = new DataTable();
                da.Fill(dat);
                SqlCommand egres = new SqlCommand("select * from Asistencia where FK_empleado=@Id_emp and Fecha= CONVERT(date,GETDATE()) and Estado='Egreso'", conex);
                egres.Parameters.AddWithValue("Id_emp", Convert.ToInt32(tbid.Text));
                SqlDataAdapter re = new SqlDataAdapter(egres);
                DataTable egr = new DataTable();
                re.Fill(egr);


                if (dat.Rows.Count >= 1)
                {
                    if (egr.Rows.Count == 0)
                    {
                        //Hubo un ingreso en el dia.se registra como egreso
                        Button1.Text = "Registrar Egreso";
                        Button1.Visible = true;
                        estado = "Egreso";
                        lblerror.Text = "";

                    }
                    else
                    {
                        //Ya hubo un egreso en el dia.avisa al empleado que ya ingreso
                        lblerror.Text = "Empleado ya ingreso";
                    }


                }
                else
                {
                    //No hubo un ingreso en el dia.se registra como ingreso
                    Button1.Text = "Registrar Ingreso";
                    Button1.Visible = true;
                    estado = "Ingreso";
                    lblerror.Text = "";
                }


                //Muestra el nombre del empleado
                SqlDataSource1.SelectParameters["codigo"].DefaultValue = tbid.Text;
                SqlDataSource1.DataSourceMode = SqlDataSourceMode.DataReader;
                SqlDataReader registros;
                registros = (SqlDataReader)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
                if (registros.Read())
                {
                    Label1.Text = "Nombre:" +
                    registros["Empleado"] + "<br>";
                }

                else
                {
                    Label1.Text = "No existe el empleado";
                    Button1.Visible = false;
                    lblerror.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblerror.Text = ex.Message.ToString();
                
            }
             


            finally
            {

                conex.Close();
            }
        }
    }
    }

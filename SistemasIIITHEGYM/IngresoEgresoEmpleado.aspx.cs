using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using SistemasIIITHEGYM.BussinesLayer;

namespace SistemasIIITHEGYM
{
    public partial class IngresoEgresoEmpleado : System.Web.UI.Page
    {
        
       
        static string estado = "Ingreso";

        protected void Page_Load(object sender, EventArgs e)
        {
            lblerror.Text = string.Empty;
            Button1.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                TheGym k = new TheGym
                {
                    IDEmpleadoIngreso = tbid.Text,
                    EstadoIngresoEmpleado = estado,

                };
                k.AddIngresoEmpleado();
                lblerror.Text = "Se efectuó el registro";
                Label1.Text = "";
                Button1.Visible = false;

                
            }
            catch (Exception ex)
            {

                lblerror.Text = ex.Message.ToString();
            }
        }

        protected void btnverificar_Click(object sender, EventArgs e)
        {
            TheGym k = new TheGym
            {
                IDEmpleadoIngreso = tbid.Text
            };

            DataTable dtI = new DataTable();
            dtI = k.GetIngresoEmpleado();
            DataTable dtE = new DataTable();
            dtE= k.GetEgresoEmpleado();

            if(dtI.Rows.Count>= 1)
            {
                if (dtE.Rows.Count == 0)
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
                    lblerror.Text = "Empleado ya ingreso durante el dia";
                    
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


            DataTable dt = new DataTable();
            dt = k.IngresoNombreEmp();
            if (dt.Rows.Count > 0)
            {
                Label1.Text = "Nombre: " + dt.Rows[0][0].ToString() + " \n Hora: " + dt.Rows[0][1].ToString();
                
            }
            else
            {
                Label1.Text = "No existe el empleado";
                Button1.Visible = false;
                lblerror.Text = "";
                
            }

        }
               
    }
    }

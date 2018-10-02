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
    public partial class RegistrarRutinaEntrenador : System.Web.UI.Page
    {
        static bool flag = true;

        protected void Page_Load(object sender, EventArgs e)
        {
            gridejerciciosrutina.Focus();
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


            if (flag == true)
            {
                cargargrupomuscular();
                flag = false;
            }
            

        }

        protected void btnregistrar_Click(object sender, EventArgs e)
        {

        }

        protected void btnañadir_Click(object sender, EventArgs e)
        {

        }

       
    
        protected void Button1_Click(object sender, EventArgs e)
        {
            TheGym k = new TheGym
            {
                DNICliente = tbdnicliente.Text,
                
            };
            k.AddIngresoEmpleado();
            DataTable dt = new DataTable();
            dt = k.GetTodosClientesNombres();
            if (dt.Rows.Count > 0)
            {
                Label1.Text = "Nombre: " + dt.Rows[0][0].ToString() + " \n Apellido: " + dt.Rows[0][1].ToString() + " \n DNI: " + dt.Rows[0][3].ToString();

            }
            else
            {
                Label1.Text = "No existe el empleado";
            }
        }

        private void cargargrupomuscular()
        {
            TheGym k = new TheGym();
            DataTable dt = new DataTable();
            dt = k.GetGruposMusculares();
            ddlgrupomuscular.DataSource = dt;
            ddlgrupomuscular.DataValueField = "Id_grupo";
            ddlgrupomuscular.DataTextField = "Nombre";
            ddlgrupomuscular.DataBind();
            
        }

      

        protected void ddlgrupomuscular_SelectedIndexChanged1(object sender, EventArgs e)
        {
            TheGym k = new TheGym
            {
                FK_Grupo = ddlgrupomuscular.Text
            };
            DataTable dt = new DataTable();
            dt = k.GetEjercicosxGrupo();
            ddlejercicio.DataSource = dt;
            ddlejercicio.DataValueField = "Id_ejercicio";
            ddlejercicio.DataTextField = "Nombre";
            ddlejercicio.DataBind();
        }
    }
}
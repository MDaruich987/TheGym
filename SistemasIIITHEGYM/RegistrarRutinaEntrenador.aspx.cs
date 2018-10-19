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

        static string   idcliente;

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

            if (IsPostBack == false)
            {
                DataTable Tabla = new DataTable();
                Tabla.Columns.Add("Grupo_muscular");
                Tabla.Columns.Add("Ejercicio");
                Tabla.Columns.Add("Id_ejercicio");
                Tabla.Columns.Add("Serie");
                Tabla.Columns.Add("Rep");
                Tabla.Columns.Add("Dia");
                gridejerciciosrutina.DataSource = Tabla;
                gridejerciciosrutina.DataBind();
                Session["Datos"] = Tabla;

                cargargrupomuscular();
                getallprofesores();


            }

            if (flag == true)
            {
                cargargrupomuscular();
                getallprofesores();
                flag = false;

            }

            //ddlgrupomuscular.Visible = false;
            //ddlejercicio.Visible = false;
            //lbseries.Visible = false;
            //lbrrepeticiones.Visible = false;
            //lbdias.Visible = false;
            Dia.Text = DateTime.Now.ToString("dd/MM/yyyy");



        }

        protected void btnregistrar_Click(object sender, EventArgs e)
        {
            try
            {


                string idrutina;

                DataTable aux1 = new DataTable();

                TheGym k = new TheGym
                {
                    NombreRutina = tbnombre.Text,
                    IDEmpleado = ddlprofesores.SelectedValue,
                    IDCliete = idcliente
                    
                };


                aux1 = k.AddRutina();


                idrutina = aux1.Rows[0][0].ToString();



                for (int i = 0; i < gridejerciciosrutina.Rows.Count; i++)
                {


                    TheGym q = new TheGym
                    {
                        IDRutina = idrutina,
                        IDEjercicio = gridejerciciosrutina.Rows[i].Cells[2].Text,
                        Serie = gridejerciciosrutina.Rows[i].Cells[3].Text,
                        Repeticion = gridejerciciosrutina.Rows[i].Cells[4].Text,
                        Dia = gridejerciciosrutina.Rows[i].Cells[5].Text
                        

                    };
                    

                
                    q.AddDetalleRutina();

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#modal-default').modal('show');", true);
                }
            }
            catch (Exception ex)
            {

                lblerror.Text = ex.Message.ToString();
            }
        }

        protected void btnañadir_Click(object sender, EventArgs e)
        {
          

            DataTable Tabla = new DataTable();
            Tabla = (DataTable)Session["Datos"];
            Tabla.Rows.Add(ddlgrupomuscular.SelectedItem, ddlejercicio.SelectedItem,ddlejercicio.Text,
            lbseries.Text, lbrrepeticiones.Text, lbdias.Text);
            gridejerciciosrutina.DataSource = Tabla;
            gridejerciciosrutina.DataBind();
            Session["Datos"] = Tabla;
            
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

        private void getallprofesores()
        {
            TheGym k = new TheGym();
            DataTable dt = new DataTable();
            dt = k.GetProfesores();
            ddlprofesores.DataSource = dt;
            ddlprofesores.DataValueField = "Id_empleado";
            ddlprofesores.DataTextField = "Profesor";
            ddlprofesores.DataBind();

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

       

       

        protected void Button1_Click1(object sender, EventArgs e)
        {
            TheGym k = new TheGym
            {
                DNICliente = tbdnicliente.Text,

            };
            DataTable dt = new DataTable();
            dt = k.GetTodosClientesNombres();
            if (dt.Rows.Count > 0)
            {
                Label1.Text = "Nombre: " + dt.Rows[0][0].ToString() + "// Apellido: " + dt.Rows[0][1].ToString() + "  ID: " + dt.Rows[0][2].ToString();
                idcliente = dt.Rows[0][2].ToString();
                //ddlgrupomuscular.Visible = true;
                //ddlejercicio.Visible = true;
                //lbseries.Visible = true;
                //lbrrepeticiones.Visible = true;
                //lbdias.Visible = true;
            }
            else
            {
                Label1.Text = "No existe el empleado";
            }
        }

        protected void ddlprofesores_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btncancelar_Click(object sender, EventArgs e)
        {
            //falta modificar
            Response.Redirect("InicioEntrenador.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            TheGym k = new TheGym
            {
                NombreRutina = tbnombre.Text,

            };
            DataTable dt = new DataTable();
            dt = k.GetRutinaNombre();
            if (dt.Rows.Count > 0)
            {
                Verificar.Text = "Ya Existe una rutina con este nombre, elija un nuevo nombre";
            }
            else
            {
                Verificar.Text = "Puede usar este nombre";
            }
        }

        
    }
}

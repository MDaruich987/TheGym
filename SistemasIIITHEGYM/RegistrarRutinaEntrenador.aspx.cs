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
    public partial class RegistrarRutinaxEntrenador : System.Web.UI.Page


    {

        static bool flag = true;

        

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                //mostramos solo el panel de busqueda
                panelconsulta.Visible = true;
                paneledicion.Visible = false;
                panelconsulta.Focus();
                griddetallerutina.DataBind();
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
                lblentrenador.Text = (string)Session["inicio"];
                lblentrenador.Visible = true;
                lblemail.Text = (string)Session["usuario"];
                lblemail.Visible = true;
                TheGym k = new TheGym
                {
                    emailbusadm = lblemail.Text,

                };

                DataTable dt = new DataTable();
                dt = k.GetAdmNomAp();
                lblentrenadordni.Text = Convert.ToString(dt.Rows[0][0]);

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
                griddetallerutina.DataSource = Tabla;
                griddetallerutina.DataBind();
                Session["Datos"] = Tabla;


                cargargrupomuscular();
                //getallprofesores();


            }

            if (flag == true)
            {
                cargargrupomuscular();
                //getallprofesores();
                flag = false;

            }

            //ddlgrupomuscular.Visible = false;
            //ddlejercicio.Visible = false;
            //lbseries.Visible = false;
            //lbrrepeticiones.Visible = false;
            //lbdias.Visible = false;
            lbldia.Text = DateTime.Now.ToString("dd/MM/yyyy");

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

        protected void btnconsultar_Click(object sender, EventArgs e)
        {
            TheGym k = new TheGym
            {
                ApellidoCliente = tbapellido.Text,

            };

            DataTable dt = new DataTable();
            dt = k.GetClientesRutina();
            if (dt.Rows.Count > 0)
            {
                gridclientes.DataSource = dt;
                gridclientes.DataBind();
                gridclientes.Focus();
                lblerror.Text = "";

            }
            else
            {
                lblerror.Text = "No existe cliente con ese apellido";
            }
        }

        protected void btnañadir_Click(object sender, EventArgs e)
        {
            DataTable Tabla = new DataTable();
            Tabla = (DataTable)Session["Datos"];
            Tabla.Rows.Add(ddlgrupomuscular.SelectedItem, ddlejercicio.SelectedItem, ddlejercicio.Text,
            lbseries.Text, lbrrepeticiones.Text, lbdias.Text);
            griddetallerutina.DataSource = Tabla;
            griddetallerutina.DataBind();
            Session["Datos"] = Tabla;
        }

        protected void btnregistrar_Click(object sender, EventArgs e)
        {
            try
            {


                string idrutina;

                DataTable aux1 = new DataTable();

                TheGym k = new TheGym
                {
                    NombreRutina = tbnombrerutina.Text,
                    IDEmpleado = lblentrenadordni.Text,
                    IDCliete = lblid.Text

                };


                aux1 = k.AddRutina();


                idrutina = aux1.Rows[0][0].ToString();



                for (int i = 0; i < griddetallerutina.Rows.Count; i++)
                {


                    TheGym q = new TheGym
                    {
                        IDRutina = idrutina,
                        IDEjercicio = griddetallerutina.Rows[i].Cells[2].Text,
                        Serie = griddetallerutina.Rows[i].Cells[3].Text,
                        Repeticion = griddetallerutina.Rows[i].Cells[4].Text,
                        Dia = griddetallerutina.Rows[i].Cells[5].Text


                    };



                    q.AddDetalleRutina();

                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#modal-default').modal('show');", true);
                }
                //mensaje de exito de registro
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#modal-default').modal('show');", true);
            }
            catch (Exception ex)
            {

                lblerror.Text = ex.Message.ToString();
            }



            //vuelvo a vaciar datos
            tbnombrerutina.Text = null;
            //significa que estaba viendo y ahora vuelve a la busqueda
            btnañadir.CausesValidation = false;
            btnregistrar.CausesValidation = false;
            btncancelar.CausesValidation = false;
            panelconsulta.Visible = true;
            paneledicion.Visible = false;
            panelconsulta.Focus();
            lblerror.Text = "";
            griddetallerutina.DataBind();


        }

        protected void btncancelar_Click(object sender, EventArgs e)
        {
            btnañadir.CausesValidation = false;
            btnregistrar.CausesValidation = false;
            btncancelar.CausesValidation = false;
            panelconsulta.Visible = true;
            paneledicion.Visible = false;
            panelconsulta.Focus();
            lblerror.Text = "";
            griddetallerutina.DataBind();
            tbapellido.Text = "";
            gridclientes.DataBind();
            //Response.Redirect("InicioEntrenador.aspx");
        }

        protected void griddetallerutina_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        
            
        }

        protected void ddlgrupomuscular_SelectedIndexChanged(object sender, EventArgs e)
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

        protected void gridclientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelconsulta.Visible = false;
            paneledicion.Visible = true;
            paneledicion.Focus();


            lblnombre.Text = gridclientes.SelectedRow.Cells[1].Text;
            lblapellido.Text = gridclientes.SelectedRow.Cells[2].Text;
            lblid.Text = gridclientes.SelectedRow.Cells[0].Text;
        }
    }
}
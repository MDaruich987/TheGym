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
    public partial class ConsultarRutinaEntrenador : System.Web.UI.Page
    {
        static bool flag = true;
        static DataTable detalle = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //mostramos solo el panel de busqueda
                panelconsulta.Visible = true;
                paneledicion.Visible = false;
                panelconsulta.Focus();
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


            }

            if (flag == true)
            {
                cargargrupomuscular();
                //cargarclientes();
                flag = false;

            }
        }

        protected void gridfichaderutina_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ocultamos el panel de busqueda y mostramos el de edicion
            //aqui debemos llenar los valores de los controles con el elemento seleccionado
            panelconsulta.Visible = false;
            paneledicion.Visible = true;
            paneledicion.Focus();

            TextBox2.Text = gridfichaderutina.SelectedRow.Cells[1].Text;

            TheGym k = new TheGym
            {
                IDRutina = gridfichaderutina.SelectedRow.Cells[0].Text

            };

            Label2.Text = "";
            DataTable dt = new DataTable();
            dt = k.GetDetalleRutina();
            detalle = dt;
            if (dt.Rows.Count > 0)
            {
                gridejerciciosrutina.DataSource = dt;
                gridejerciciosrutina.DataBind();
                gridejerciciosrutina.Focus();
                

            }
            else
            {
                lblerror.Text = "";
            }

        }

        

        //private void cargarclientes()
        //{
        //    TheGym k = new TheGym();
        //    DataTable dt = new DataTable();
        //    dt = k.GetAllClientes();
        //    ddlcliente.DataSource = dt;
        //    ddlcliente.DataValueField = "Id_Cliente";
        //    ddlcliente.DataTextField = "Nombre";
        //    ddlcliente.DataBind();

        //}

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
                NombreRutina = tbnombre.Text,

            };
            
            DataTable dt = new DataTable();
            dt = k.GetRutina();
            if (dt.Rows.Count > 0)
            {
                gridfichaderutina.DataSource = dt;
                gridfichaderutina.DataBind();
                gridfichaderutina.Focus();
                TextBox1.Text = tbnombre.Text;
                lblerror.Text = "";
                
            }
            else
            {
                lblerror.Text = "No existe rutina con este nombre";
            }
        }

        protected void ddlgrupomuscular_SelectedIndexChanged(object sender, EventArgs e)
        {
            TheGym k = new TheGym
            {
                FK_Grupo = ddlgrupomuscular.SelectedValue
            };
            DataTable dt = new DataTable();
            dt = k.GetEjercicosxGrupo();
            ddlejercicio.DataSource = dt;
            ddlejercicio.DataValueField = "Id_ejercicio";
            ddlejercicio.DataTextField = "Nombre";
            ddlejercicio.DataBind();
        }



        protected void btneditarejercicio_Click(object sender, EventArgs e)
        {
            DataTable Tabla = new DataTable();
            Tabla = (DataTable)Session["Datos"];
            detalle.Rows.Add(ddlgrupomuscular.SelectedItem, ddlejercicio.SelectedItem, ddlejercicio.Text,
            lbseries.Text, lbrrepeticiones.Text, lbdias.Text);
            gridejerciciosrutina.DataSource = detalle;
            gridejerciciosrutina.DataBind();
            Session["Datos"] = Tabla;


        }

       

       

        protected void btncancelar_Click(object sender, EventArgs e)
        {
            //significa que estaba viendo y ahora vuelve a la busqueda
            btneditarejercicio.CausesValidation = false;
            btneditarRutina.CausesValidation = false;
            btncancelar.CausesValidation = false;
            panelconsulta.Visible = true;
            paneledicion.Visible = false;
            panelconsulta.Focus();
            lblerror.Text = "";
            btneditarejercicio.Text = "Editar";
            btneditarRutina.Text = "Editar";
            btncancelar.Text = "Cancelar";
        }

        protected void gridfichaderutina_RowDeleting1(object sender, GridViewDeleteEventArgs e)
        {
            TheGym k = new TheGym
            {
                IDRutina = gridfichaderutina.Rows[e.RowIndex].Cells[0].Text
            };
            k.InhabilitarRutina();
            DataTable aux = new DataTable();
            gridfichaderutina.DataSource = aux;
            gridfichaderutina.DataBind();
            gridfichaderutina.Visible = false;
            lblerror.Text = "Rutina inhabilitada";
            lblerror.Visible = true;
            tbnombre.Text = "";
        }

        protected void gridejerciciosrutina_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            detalle.Rows.RemoveAt(e.RowIndex);
            gridejerciciosrutina.DataSource = detalle;
            gridejerciciosrutina.DataBind();
        }

        protected void btneditarRutina_Click1(object sender, EventArgs e)
        {
            try
            {


                string idrutina;



                idrutina = gridfichaderutina.SelectedRow.Cells[0].Text;

                TheGym n = new TheGym
                {
                    IDRutina = idrutina
                };
                n.BorrarDetalle();

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

                   
                }

                Label2.Text = "Se Edito correctamente la rutina";
                Label2.Focus();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#modal-default').modal('show');", true);
            }
            catch (Exception ex)
            {

                lblerror.Text = ex.Message.ToString();
            }
        }
    }
}
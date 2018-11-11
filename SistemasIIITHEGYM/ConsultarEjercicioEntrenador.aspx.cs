using SistemasIIITHEGYM.BussinesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SistemasIIITHEGYM
{

    public partial class ConsultarEjercicioEntrenador : System.Web.UI.Page
    {
        static DataTable TablaEjercicio = new DataTable();
        static string idejercicio;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //la primera vez que se carga la página
                //muestra el panel de  busqueda, no el de edicion
                panelgeneral.Focus();
                panelregistro.Visible = false;

                //lblmensajebienvenida.Text = Session["inicio"].ToString();
                //si efectivamente se ha iniciado sesión
                if (Session["inicio"] != null)
                {
                    //declaramos una variale sesion para mantener el dato del usuario
                    string usuario = (string)Session["Usuario"];
                    lblusuario.Text = "Bienvenido/a " + (String)Session["inicio"];

                }
                else
                {
                    //si no se ha iniciado sesion me manda al inicio
                    //Response.Redirect("InicioLogin.aspx");
                }

                GetElementos();
                GetGrupoMuscular();

            }
        }


        private void GetElementos()
        {
            TheGym k = new TheGym();
            DataTable dt = k.GetElementos();
            if (dt.Rows.Count > 0)
            {
                ddlelemento.DataValueField = "id_elemento";
                ddlelemento.DataTextField = "nombre";
                ddlelemento.DataSource = dt;
                ddlelemento.DataBind();

            }
        }
        private void GetGrupoMuscular()
        {
            TheGym k = new TheGym();
            DataTable dt = k.GetGruposMusculares();
            if (dt.Rows.Count > 0)
            {
                ddlgrupomuscular.DataValueField = "id_grupo";
                ddlgrupomuscular.DataTextField = "nombre";
                ddlgrupomuscular.DataSource = dt;
                ddlgrupomuscular.DataBind();

            }
        }

        protected void gridejercicios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                panelgeneral.Visible = false;
                panelregistro.Visible = true;
                panelregistro.Focus();

                idejercicio = gridejercicios.SelectedRow.Cells[0].Text;
                TextBox1.Text = gridejercicios.SelectedRow.Cells[1].Text;
                tbdescripcion.Text = gridejercicios.SelectedRow.Cells[2].Text;
                ddlgrupomuscular.FindControl(gridejercicios.SelectedRow.Cells[3].Text).Focus();
                ddlelemento.SelectedValue = gridejercicios.SelectedRow.Cells[4].ToString();



            }
            catch (Exception ex)
            {

                lblerror.Text = ex.Message.ToString();
            }
        }

        protected void btneditar_Click(object sender, EventArgs e)
        {

            if (btneditar.Text == "Editar")
            {
                //significa que estaba viendo y ahora quiere editar
                //habilitamos los controles
                TextBox1.Enabled = true;
                ddlelemento.Enabled = true;
                ddlgrupomuscular.Enabled = true;
                tbdescripcion.Enabled = true;




                btneditar.Text = "Guardar";
                btneditar.CausesValidation = true;
                btnVolver.Text = "Cancelar";
                btnVolver.Visible = true;



            }
            else
            {
                try
                {
                    TheGym k = new TheGym
                    {
                        IdEjercicio = idejercicio,
                        NombreEjercicio = TextBox1.Text,
                        FKelementos = ddlelemento.SelectedValue,
                        FKgrupomuscular = ddlgrupomuscular.SelectedValue,
                        DescripcionEjercicio = tbdescripcion.Text
                    };

                    k.UpdateEjercicio();

                    TextBox1.Text = string.Empty;
                    ddlelemento.ClearSelection();
                    ddlgrupomuscular.ClearSelection();
                    tbdescripcion.Text = string.Empty;
                    TextBox1.Enabled = false;
                    ddlelemento.Enabled = false;
                    ddlgrupomuscular.Enabled = false;
                    tbdescripcion.Enabled = false;
                    btneditar.Text = "Editar";
                }
                catch
                {
                    lblerror.Text = "Error al actualizar Ejercicio";
                }
                //aqui va el codigo para registrar los cambios



            }

        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            //significa que estaba viendo y ahora vuelve a la busqueda
            btneditar.CausesValidation = false;
            btnVolver.CausesValidation = false;
            panelgeneral.Visible = true;
            panelregistro.Visible = false;
            gridejercicios.Dispose();
            gridejercicios.DataBind();
            panelgeneral.Focus();
            lblerror.Text = "";
            btneditar.Text = "Editar";
            btnVolver.Text = "Volver";
        }



        protected void btnconsultar_Click(object sender, EventArgs e)
        {
            TheGym k = new TheGym
            {
                NombreEjercicio = TextBox1.Text
            };
            DataTable dt = k.GetEjercicio();
            TablaEjercicio = dt;
            if (dt.Rows.Count > 0)
            {
                gridejercicios.DataSource = dt;
                gridejercicios.DataBind();
            }
            else
            {
                lblerror.Text = "No se encontro el Ejercicio";
            }
        }

        protected void gridejercicios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridejercicios.PageIndex = e.NewPageIndex;
            gridejercicios.DataSource = TablaEjercicio;
            gridejercicios.DataBind();
        }
    }


}

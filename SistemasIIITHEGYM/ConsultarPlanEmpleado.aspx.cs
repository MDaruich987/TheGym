using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SistemasIIITHEGYM.BussinesLayer;
using System.Data;

namespace SistemasIIITHEGYM
{
    public partial class ConsultarPlanEmpleado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetActividad();
                //la primera vez que se carga la página
                //muestra el panel de  busqueda, no el de edicion
                panelconsulta.Focus();
                paneledicion.Visible = false;
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
        }

        private void GetActividad()
        {
            TheGym k = new TheGym();
            DataTable dt = k.GetActividades();
            if (dt.Rows.Count > 0)
            {
                ddlactividad.DataValueField = "Id_actividad";
                ddlactividad.DataTextField = "Nombre";
                ddlactividad.DataSource = dt;
                ddlactividad.DataBind();
            }
        }


        protected void btnconsultar_Click(object sender, EventArgs e)
        {
            TheGym k = new TheGym
            {
                Nombreplanins = tbnombre.Text
            };
            DataTable dt = new DataTable();
            dt = k.GetPlans();
            if(dt.Rows.Count > 0)
            {
                lblerror.Visible = false;
                gvplanes.Visible = true;
                gvplanes.DataSource = dt;
                gvplanes.DataBind();
            }
            else
            {
                lblerror.Text = "Plan no encontrado";
                lblerror.Visible = true;
            }

        }

        protected void gvplanes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idplan;
            //cuando seleccionamos una fila del grid
            try
            {
                TextBox1.Text = gvplanes.SelectedRow.Cells[1].Text;
                TextBox2.Text = gvplanes.SelectedRow.Cells[2].Text;
                //mostrar un panel y ocultar otro
                panelconsulta.Visible = false;
                paneledicion.Visible = true;
                paneledicion.Focus();
                lbduración.Enabled = false;
                lbduración0.Enabled = false;
                lbduración.SelectedValue = gvplanes.SelectedRow.Cells[3].Text;
                //codigo para cargar los valores de la fila en los textbox del panel de edicion
                idplan = gvplanes.SelectedRow.Cells[0].Text;
                TheGym k = new TheGym
                {
                    IdPlanBuscar = idplan
                };
                DataTable dt = new DataTable();
                dt = k.GetDetPlans();
                if (dt.Rows.Count > 0)
                {
                    gridactividades0.DataSource = dt;
                    gridactividades0.DataBind();
                    gridactividades0.Visible = true;

                    
                }
                else
                {
                    gridactividades0.Visible = false;
                    DataTable dt1 = new DataTable();
                    gridactividades0.DataSource = dt1;
                    gridactividades0.DataBind();
                }

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
                btnAdd.Enabled = true;
                TextBox1.Enabled = true;
                TextBox2.Enabled = true;
                ddlactividad.Enabled = true;
                lbduración.Enabled = true;
                lbduración0.Enabled = true;

                btneditar.Text = "Guardar";
            
            }
            else
            {
                
            }
        }

        protected void btnvolver_Click(object sender, EventArgs e)
        {
            //significa que estaba viendo y ahora vuelve a la busqueda
                btneditar.CausesValidation = false;
                btnvolver.CausesValidation = false;
                panelconsulta.Visible = true;
                paneledicion.Visible = false;
                panelconsulta.Focus();
            lblerror.Text = "";
            btneditar.Text = "Editar";
            btnvolver.Text = "Volver";
        }

        protected void gvplanes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            TheGym k = new TheGym
            {
                IdPlanBuscar = gvplanes.Rows[e.RowIndex].Cells[0].Text
            };
            k.InhabilitarPlans();
            DataTable aux = new DataTable();
            gvplanes.DataSource = aux;
            gvplanes.DataBind();
            gvplanes.Visible = false;
            lblerror.Text = "Cliente inhabilitado";
            lblerror.Visible = true;
            tbnombre.Text = "";
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            DataTable dt = gridactividades0.DataSource as DataTable;
            DataRow row = dt.NewRow();
            row["ID"] = ddlactividad.SelectedValue.ToString();
            row["Actividad"] = ddlactividad.SelectedItem.ToString();
            row["Dias de la semana"] = lbduración0.SelectedItem.ToString();
            dt.Rows.Add(row);
            gridactividades0.DataSource = dt;

        }
    }
}
using SistemasIIITHEGYM.BussinesLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemasIIITHEGYM
{
    public partial class ConsultarActividadEmpleado : System.Web.UI.Page
    {
        static string idemp;
        static string idsuc;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //la primera vez que se carga la página
                //muestra el panel de  busqueda, no el de edicion
                panelgeneral.Focus();
                panelregistro.Visible = false;
            }
        }

        protected void btnconsultar_Click(object sender, EventArgs e)
        {
            
                TheGym k = new TheGym
                {
                    NombreActividadBuscar = tbnombre.Text
                };

                DataTable dt = k.GetActividad();
                if (dt.Rows.Count > 0)
                {
                    gridactividades.DataSource = dt;
                    gridactividades.DataBind();
                lblerror.Text = "";
            }
                else
                {
                    lblerror.Text = "No se encontraron coincidencias";
                }

        }


        private void GetSucursales()
        {
            TheGym k = new TheGym();
            DataTable dt = k.GetSucursales();
            if (dt.Rows.Count > 0)
            {
                ddlprofesor.DataValueField = "Id_sucursal";
                ddlsucursal.DataTextField = "Nombre";
                ddlsucursal.DataSource = dt;
                ddlsucursal.DataBind();
            }
        }

        private void GetProfesores()
        {
            TheGym k = new TheGym();
            DataTable dt = k.GetProfesores();
            if (dt.Rows.Count > 0)
            {
                ddlprofesor.DataValueField = "Id_empleado";
                ddlprofesor.DataTextField = "Profesor";
                ddlprofesor.DataSource = dt;
                ddlprofesor.DataBind();

            }
        }

        protected void gridactividades_SelectedIndexChanged1(object sender, EventArgs e)
        {
            //cuando seleccionamos una fila del grid
            try
            {
                //mostrar un panel y ocultar otro
                panelgeneral.Visible = false;
                panelregistro.Visible = true;
                panelregistro.Focus();
                //codigo para cargar los valores de la fila en los textbox del panel de edicion
                GetProfesores();
                GetSucursales();
                tbnombreedi.Text = gridactividades.SelectedRow.Cells[1].Text;
                tbdescripcion.Text = gridactividades.SelectedRow.Cells[2].Text;
                //TxbProfesor.Text = gvactividad.SelectedRow.Cells[3].Text;
                ddlsucursal.Items.FindByText(gridactividades.SelectedRow.Cells[4].Text).Selected = true;
                idsuc = ddlsucursal.SelectedValue;
                ddlhorarioinicio.Text = gridactividades.SelectedRow.Cells[5].Text;
                ddlhorariofin.Text = gridactividades.SelectedRow.Cells[6].Text;
                ddlprofesor.ClearSelection();
                ddlprofesor.Items.FindByText(gridactividades.SelectedRow.Cells[3].Text).Selected = true;
                idemp = ddlprofesor.SelectedValue;
                ddlcupos.Text = gridactividades.SelectedRow.Cells[7].Text;

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
                btneditar.Text = "Registrar cambios";
                btneditar.CausesValidation = true;
                btnvolver.Text = "Cancelar";
                btnvolver.Visible = true;
                tbnombreedi.Enabled = true;
                ddlsucursal.Enabled = true;
                tbdescripcion.Enabled = true;
                ddlprofesor.Enabled = true;
                ddlcupos.Enabled = true;
                ddlhorariofin.Enabled = true;
                ddlhorarioinicio.Enabled = true;
            }
            else{
                //aqui va el codigo para registrar los cambios
            }
            
        }

        protected void btnvolver_Click(object sender, EventArgs e)
        {
            //significa que estaba viendo y ahora vuelve a la busqueda
                btneditar.CausesValidation = false;
                btnvolver.CausesValidation = false;
                panelgeneral.Visible = true;
                panelregistro.Visible = false;
                panelgeneral.Focus();
            lblerror.Text = "";
            btneditar.Text = "Editar";
            btnvolver.Text = "Volver";
        }
        }
    }

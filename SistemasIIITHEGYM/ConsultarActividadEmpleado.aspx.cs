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
       

        static string idact;
        static string idsuc;
        static string idemp;

        static bool flag = true;



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


                if (flag == true)
                {
                    GetSucursales();
                    GetProfesores();
                    flag = false;
                }


            }
        }

        protected void btnconsultar_Click(object sender, EventArgs e)
        {
            
            
                TheGym k = new TheGym
                {
                    NombreActividadBuscar = tbnombre.Text
                };

                DataTable dt = k.GetOneActividad();
                if (dt.Rows.Count > 0)
                {
                    gridactividades.DataSource = dt;
                    gridactividades.DataBind();
                    lblerror.Text = "";
                    gridactividades.Visible = true;
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
                ddlsucursal.DataValueField = "Id_sucursal";
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

                idact = gridactividades.SelectedRow.Cells[0].Text;

                TheGym k = new TheGym
                {
                    IDActBuscar = idact
                };

                DataTable dt1 = new DataTable();
                dt1 = k.GetOneActividad2();

                tbnombreedi.Text = dt1.Rows[0][1].ToString();
                tbdescripcion.Text = dt1.Rows[0][7].ToString();
                ddlprofesor.SelectedValue = dt1.Rows[0][4].ToString();
                idemp = ddlprofesor.SelectedValue.ToString();
                ddlsucursal.SelectedValue = dt1.Rows[0][5].ToString();
                //idsuc = ddlsucursal.SelectedValue.ToString();
                idsuc= dt1.Rows[0][5].ToString();
                ddlcupos.SelectedValue = dt1.Rows[0][6].ToString();




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
                btneditar.Text = "Guardar";
                btneditar.CausesValidation = true;
                btnvolver.Text = "Cancelar";
                btnvolver.Visible = true;
                tbnombreedi.Enabled = true;
                ddlsucursal.Enabled = true;
                tbdescripcion.Enabled = true;
                ddlprofesor.Enabled = true;
                ddlcupos.Enabled = true;


            }
            else
            {
                //aqui va el codigo para registrar los cambios
                TheGym k = new TheGym
                {
                    NombreActEdit = tbnombreedi.Text,
                    DescripcionActEdit = tbdescripcion.Text,
                    FKSucuActEdit = ddlsucursal.SelectedValue,
                    FKEmpleadoActEdit = ddlprofesor.SelectedValue,
                    CuposActEdit = ddlcupos.SelectedValue,
                    IDActBuscar = idact,
                    IDSucActBuscar = idsuc, 
                    IDEmpActBuscar = idemp,
                };


                try
                {
                    k.UpdateActividad();
                    lblerror.Text = "Actualizado correctamente";
                    lblerror.Visible = true;

                    tbnombre.Enabled = false;
                    tbdescripcion.Enabled = false;
                    ddlcupos.Enabled = false;
                    ddlprofesor.Enabled = false;
                    ddlsucursal.Enabled = false;


                }
                catch
                {
                    lblerror.Text = "Error al actualizar";
                    lblerror.Visible = true;
                }

            }
            
        }

        protected void btnvolver_Click(object sender, EventArgs e)
        {
            //significa que estaba viendo y ahora vuelve a la busqueda
                btneditar.CausesValidation = false;
                btnvolver.CausesValidation = false;
                panelgeneral.Visible = true;
                panelregistro.Visible = false;
            gridactividades.Dispose();
            gridactividades.DataBind();
            panelgeneral.Focus();
            lblerror.Text = "";
            btneditar.Text = "Editar";
            btnvolver.Text = "Volver";
        }

        protected void gridactividades_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            TheGym k = new TheGym
            {
                IDActBuscar = gridactividades.Rows[e.RowIndex].Cells[0].Text
            };
            k.InhabilitarActividad();
            DataTable aux = new DataTable();
            gridactividades.DataSource = aux;
            gridactividades.DataBind();
            gridactividades.Visible = false;
            lblerror.Text = "Actividad inhabilitado";
            lblerror.Visible = true;
            tbnombre.Text = "";
        }
    }
    }

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
    public partial class ConsultarEmpleadoGerente : System.Web.UI.Page
    {
        static string EditDni;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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

            CargarTipoDocumento();
            CargarLocalidades();
            CargaCargos();
        }

        public void CargarTipoDocumento()
        {
            TheGym k = new TheGym();
            DataTable dt = new DataTable();
            dt = k.GetAllTipoDocumento();
            if (dt.Rows.Count > 0)
            {
                ddltipodedocumento.DataTextField = "Descripcion";
                ddltipodedocumento.DataValueField = "Id_TipoDocumento";
                ddltipodedocumento.DataSource = dt;
                ddltipodedocumento.DataBind();
            }
        }

        public void CargaCargos()
        {
            TheGym k = new TheGym();
            DataTable dt = new DataTable();
            dt = k.GetCargos();
            if (dt.Rows.Count > 0)
            {
                ddlcargo.DataTextField = "Nombre";
                ddlcargo.DataValueField = "Id_cargo";
                ddlcargo.DataSource = dt;
                ddlcargo.DataBind();
            }
        }


        public void CargarLocalidades()
        {
            TheGym k = new TheGym();
            DataTable dt = new DataTable();
            dt = k.GetAllLocalidades();
            if (dt.Rows.Count > 0)
            {
                ddllocalidad.DataTextField = "Nombre";
                ddllocalidad.DataValueField = "CodigoPostal";
                ddllocalidad.DataSource = dt;
                ddllocalidad.DataBind();
            }
        }


        protected void btnconsultar_Click(object sender, EventArgs e)
        {
            TheGym k = new TheGym();
            k.NombreEmpleadoBusc = tbnombre.Text;
            //k.NombreEmpleadoBusc = "";
            DataTable dt1 = new DataTable();
            dt1 = k.GetEmpleadoNom();
            if (dt1.Rows.Count > 0)
            {
                gridempleados.DataSource = dt1;
                gridempleados.DataBind();
                gridempleados.Visible = true;
 
            }
            else
            {
                lblerror.Text = "No se encontraron elementos que coincidan con la busqueda";
            }


            //TextBox1.Text = dt1.Rows[0][0].ToString();
            //tbapellido.Text = dt1.Rows[0][1].ToString();
            //tbnumerodocumento.Text = dt1.Rows[0][2].ToString();
            //tbcalle.Text = dt1.Rows[0][3].ToString();
            //tbnumerocasa.Text = dt1.Rows[0][4].ToString();
            //tbbarrio.Text = dt1.Rows[0][5].ToString();
            //tbemail.Text = dt1.Rows[0][6].ToString();
            //tbfechacontratacion.Text = dt1.Rows[0][7].ToString();
            //tbtelefono.Text = dt1.Rows[0][8].ToString();
            //tbfechadenacimiento.Text = dt1.Rows[0][9].ToString();
            //tbtitulo.Text = dt1.Rows[0][10].ToString();
            //ddlcargo.SelectedValue = dt1.Rows[0][11].ToString();
            //ddltipodedocumento.SelectedValue = dt1.Rows[0][12].ToString();
            //ddllocalidad.SelectedValue = dt1.Rows[0][13].ToString();
            //tbusuario.Text = tbemail.Text;
            //tbcontraseña.Text = tbnumerodocumento.Text;

            //EditDni = tbnumerodocumento.Text;
        }

        protected void btneditar_Click(object sender, EventArgs e)
        {
            if (btneditar.Text == "Editar")
            {
                TextBox1.Enabled = true;
                tbapellido.Enabled = true;
                tbnumerodocumento.Enabled = true;
                tbcalle.Enabled = true;
                tbnumerocasa.Enabled = true;
                tbbarrio.Enabled = true;
                tbemail.Enabled = true;
                tbfechacontratacion.Enabled = true;
                tbtelefono.Enabled = true;
                tbfechadenacimiento.Enabled = true;
                tbtitulo.Enabled = true;
                ddlcargo.Enabled = true;
                ddltipodedocumento.Enabled = true;
                ddllocalidad.Enabled = true;

                btneditar.Text = "Guardar";
                //significa que estaba viendo los campos y ahora quiere editar
                //mandamos todos los valores de los campos al panel de edicion
            }
            else
            {
                TheGym k = new TheGym
                {
                    NombreEmpladoEdit=TextBox1.Text,
                    ApellidoEmpleadoEdit = tbapellido.Text,
                    FechaNacEmpleadoEdit = tbfechadenacimiento.Text,
                    EmailEmpleadoEdit = tbemail.Text,
                    TelefEmpleadoEdit = tbtelefono.Text,
                    DocumentoEmpleadoEdit = tbnumerodocumento.Text,
                    FechaContEmpleadoEdit = tbfechacontratacion.Text,
                    TitulEmpleadoEdit = tbtitulo.Text,
                    FKCargoEmpleadoEdit = ddlcargo.SelectedValue,
                    FKTipoDocEmpleadoEdit = ddltipodedocumento.SelectedValue,
                    CalleEmpleadoEdit = tbcalle.Text,
                    BarrioEmpleadoEdit = tbbarrio.Text,
                    NumeroEmpleadoEdit = tbnumerocasa.Text,
                    FKLocalidadEmpleadoEdit =ddllocalidad.SelectedValue,
                    DNIEditar = EditDni
                };

                try
                {
                    k.UpdateEmpleado();
                    lblerror.Text = "Empleado editado con exito!";
                }
                catch
                {
                    lblerror.Text = "Empleado no editado!";
                }

                TextBox1.Enabled = false;
                tbapellido.Enabled = false;
                tbnumerodocumento.Enabled = false;
                tbcalle.Enabled = false;
                tbnumerocasa.Enabled = false;
                tbbarrio.Enabled = false;
                tbemail.Enabled = false;
                tbfechacontratacion.Enabled = false;
                tbtelefono.Enabled = false;
                tbfechadenacimiento.Enabled = false;
                tbtitulo.Enabled = false;
                ddlcargo.Enabled = false;
                ddltipodedocumento.Enabled = false;
                ddllocalidad.Enabled = false;

                btneditar.Text = "Editar";
                //aqui va el codigo para registrar los cambios
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
            tbnombre.Text = string.Empty;
            gridempleados.Dispose();
            gridempleados.DataBind();
        }

        protected void gridempleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cuando seleccionamos una fila del grid
            try
            {
                //mostrar un panel y ocultar otro
                panelconsulta.Visible = false;
                paneledicion.Visible = true;
                paneledicion.Focus();
                //codigo para cargar los valores de la fila en los textbox del panel de edicion

            }
            catch (Exception ex)
            {

                lblerror.Text = ex.Message.ToString();
            }

            TheGym k = new TheGym
            {
                NombreEmpleadoBusc = "",
                IDEmpleadoBusc = gridempleados.SelectedRow.Cells[0].Text
            };

            DataTable dt1 = new DataTable();
            dt1 = k.GetEmpleadoNom();

            if (dt1.Rows.Count > 0)
            {
                TextBox1.Text = dt1.Rows[0][0].ToString();
                tbapellido.Text = dt1.Rows[0][1].ToString();
                tbnumerodocumento.Text = dt1.Rows[0][2].ToString();
                tbcalle.Text = dt1.Rows[0][3].ToString();
                tbnumerocasa.Text = dt1.Rows[0][4].ToString();
                tbbarrio.Text = dt1.Rows[0][5].ToString();
                tbemail.Text = dt1.Rows[0][6].ToString();
                tbfechacontratacion.Text = dt1.Rows[0][7].ToString();
                tbtelefono.Text = dt1.Rows[0][8].ToString();
                tbfechadenacimiento.Text = dt1.Rows[0][9].ToString();
                tbtitulo.Text = dt1.Rows[0][10].ToString();
                ddlcargo.SelectedValue = dt1.Rows[0][11].ToString();
                ddltipodedocumento.SelectedValue = dt1.Rows[0][12].ToString();
                ddllocalidad.SelectedValue = dt1.Rows[0][13].ToString();
                tbusuario.Text = tbemail.Text;
                tbcontraseña.Text = tbnumerodocumento.Text;

                EditDni = tbnumerodocumento.Text;
            }

            
        }

        protected void gridempleados_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //idcliente search 
            TheGym k = new TheGym
            {
                IDEmpleadoBusc = gridempleados.Rows[e.RowIndex].Cells[0].Text
            };
            k.InhabilitarEmpleado();
            DataTable aux = new DataTable();
            gridempleados.DataSource = aux;
            gridempleados.DataBind();
            gridempleados.Visible = false;
            lblerror.Text = "Cliente inhabilitado";
            lblerror.Visible = true;
            tbnombre.Text = "";
        }
    }
}
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
    public partial class ConsultarClienteEmpleado : System.Web.UI.Page
    {
        public static bool flag = true;

        static string DNIedit;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //la primera vez que se carga la página
                //muestra el panel de  busqueda, no el de edicion
                panelconsulta.Focus();
                paneledicion.Visible = false;

                //lblmensajebienvenida.Text = Session["inicio"].ToString();
                //si efectivamente se ha iniciado sesión
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
                    CargarTipoDocumento();
                    CargarLocalidades();
                    flag = false;
                }

            }
        }

        public void CargarLocalidades()
        {
            try
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
            catch (Exception ex)
            {

                lblerror.Text = ex.Message.ToString() + "carga ddl";
            }

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

        protected void btnconsultar_Click(object sender, EventArgs e)
        {
            gridclientes.Visible = true;
            
            TheGym k = new TheGym();
            k.NombreClienteBusc = tbnombre.Text;
            DataTable dt = k.GetClienteNom();
            if (dt.Rows.Count > 0)
            {
                gridclientes.DataSource = dt;
                gridclientes.DataBind();
                gridclientes.Focus();
            }
        }

        protected void btneditar_Click(object sender, EventArgs e)
        {
            if (btneditar.Text == "Editar")
            {
                //significa que estaba viendo los campos y ahora quiere editar
                //mandamos todos los valores de los campos al panel de edicion
                TextBox1.Enabled = true;
                tbapellido.Enabled = true;
                ddltipodedocumento.Enabled = true;
                tbnumerodocumento.Enabled = true;
                tbfechadenacimiento.Enabled = true;
                ddllocalidad.Enabled = true;
                tbemail.Enabled = true;
                tbtelefono.Enabled = true;
                tbcalle.Enabled = true;
                tbnumerocasa.Enabled = true;
                tbbarrio.Enabled = true;
                btneditar.Text = "Guardar";
            }
            else
            {
                if (btneditar.Text == "Guardar")
                {
                    TheGym k = new TheGym
                    {
                        NombreClienteEditar = TextBox1.Text,
                        ApellidoClienteEditar = tbapellido.Text,
                        EmailClienteEditar = tbemail.Text,
                        FechaClienteEditar = tbfechadenacimiento.Text,
                        TelefonoClienteEditar = tbtelefono.Text,
                        CalleClienteEditar = tbcalle.Text,
                        NumeroClienteEditar = tbnumerocasa.Text,
                        BarrioClienteEditar = tbbarrio.Text,
                        FKLocalidadClienteEditar = ddllocalidad.SelectedValue,
                        FKTipoDocClienteEditar = ddltipodedocumento.SelectedValue,
                        DNIEditar = DNIedit,
                        DNIClienteEditar = tbnumerodocumento.Text
                        //falta la parte del domicilio
                    };

                    k.UpdateCliente();
                    btneditar.Text = "Editar";
                    lblerror.Text = "Cliente Editado con exito!";

                    tbnombre.Enabled = true;
                    tbnombre.Text = "";
                    tbapellido.Enabled = false;
                    tbfechadenacimiento.Enabled = false;
                    tbemail.Enabled = false;
                    tbtelefono.Enabled = false;
                    tbcalle.Enabled = false;
                    tbnumerocasa.Enabled = false;
                    tbbarrio.Enabled = false;
                    TextBox1.Enabled = false;
                    ddllocalidad.Enabled = false;
                    ddltipodedocumento.Enabled = false;
                    tbnumerodocumento.Enabled = false;
                    

                }
            }
        }

        protected void btncancelar_Click(object sender, EventArgs e)
        {
            //significa que estaba viendo y ahora vuelve a la busqueda
            btneditar.CausesValidation = false;
            btncancelar.CausesValidation = false;
            panelconsulta.Visible = true;
            paneledicion.Visible = false;
            panelconsulta.Focus();
            gridclientes.Dispose();
            gridclientes.DataBind();
            lblerror.Text = "";
            btneditar.Text = "Editar";
            btncancelar.Text = "Volver";
        }

        protected void gridclientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cuando seleccionamos una fila del grid
            try
            {
                //mostrar un panel y ocultar otro
                panelconsulta.Visible = false;
                paneledicion.Visible = true;
                paneledicion.Focus();
                //codigo para cargar los valores de la fila en los textbox del panel de edicion

                TheGym k = new TheGym
                {
                    IdClienteSearch = gridclientes.SelectedRow.Cells[0].Text
                };

                DataTable dt = new DataTable();
                dt = k.GetAllDatosCliente();

                TextBox1.Text = dt.Rows[0][1].ToString();
                tbapellido.Text = dt.Rows[0][2].ToString();
                tbfechadenacimiento.Text = Convert.ToDateTime(dt.Rows[0][3]).ToShortDateString();
                tbemail.Text = dt.Rows[0][4].ToString();
                tbtelefono.Text = dt.Rows[0][5].ToString();
                ddltipodedocumento.SelectedValue = dt.Rows[0][8].ToString();
                tbnumerocasa.Text = dt.Rows[0][9].ToString();
                tbcalle.Text = dt.Rows[0][10].ToString();
                tbbarrio.Text = dt.Rows[0][11].ToString();
                tbnumerodocumento.Text = dt.Rows[0][12].ToString();
                ddllocalidad.SelectedValue = dt.Rows[0][13].ToString();
                tbusuario.Text = tbemail.Text;
                tbcontraseña.Text = tbnumerodocumento.Text;

                DNIedit = tbnumerodocumento.Text;


            }
            catch (Exception ex)
            {

                lblerror.Text = ex.Message.ToString();
            }

        }


        public void CargarDatos()
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            tbnombre.ReadOnly = false;
            tbapellido.ReadOnly = false;
            tbfechadenacimiento.ReadOnly = false;
            tbemail.ReadOnly = false;
            tbtelefono.ReadOnly = false;
            tbcalle.ReadOnly = false;
            tbnumerocasa.ReadOnly = false;
            tbbarrio.ReadOnly = false;
        }

        protected void btnregistrar_Click(object sender, EventArgs e)
        {

        }


        protected void gridclientes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //idcliente search 
            TheGym k = new TheGym
            {
                IdClienteSearch = gridclientes.Rows[e.RowIndex].Cells[0].Text
            };
            k.InhabilitarCliente();
            DataTable aux = new DataTable();
            gridclientes.DataSource = aux;
            gridclientes.DataBind();
            gridclientes.Visible = false;
            lblerror.Text = "Cliente inhabilitado";
            lblerror.Visible = true;
            tbnombre.Text = "";
        }
    }
}
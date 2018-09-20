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
    public partial class ConsultarSucursal : System.Web.UI.Page
    {

        static bool flag = true;
        static string ID;

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


                if (flag == true)
                {
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

                lblerror.Text = ex.Message.ToString();
            }

        }


        protected void btnconsultar_Click(object sender, EventArgs e)
        {
            TheGym k = new TheGym
            {
                NomSucBuscar = tbnombre.Text
            };

            DataTable dt = new DataTable();
            dt = k.GetOneSucursal();

            if (dt.Rows.Count > 0)
            {
                gridplanes.DataSource = dt;
                gridplanes.DataBind();
            }

        }

        protected void btneditar_Click(object sender, EventArgs e)
        {
            if (btneditar.Text == "Editar")
            {

                TextBox1.Enabled = true;
                tbtelefono.Enabled = true;
                tbcalle.Enabled = true;
                tbbarrio.Enabled = true;
                tbnumerocasa.Enabled = true;
                ddllocalidad.Enabled = true;

                btneditar.Text = "Guardar";
                




                //significa que estaba viendo los campos y ahora quiere editar
                //mandamos todos los valores de los campos al panel de edicion
            }
            else
            {

                TheGym k = new TheGym
                {
                    IDSucEditar = ID,
                    NombreSucEditar = TextBox1.Text,
                    TelefonoSucEditar = tbtelefono.Text,
                    CalleSucEditar = tbcalle.Text,
                    BarrioSucEditar = tbbarrio.Text,
                    NumeroSucEditar = tbnumerocasa.Text,
                    FKLocSucEditar = ddllocalidad.SelectedValue
                };

                try
                {
                    k.UpdateSucursal();
                    lblerror.Text = "Sucursal editada con exito!.";
                }
                catch
                {
                    lblerror.Text = "Error al actualizar";
                }

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
        }

        protected void gridplanes_SelectedIndexChanged(object sender, EventArgs e)
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
                    IdSucursalCarga = gridplanes.SelectedRow.Cells[0].Text
                };

                DataTable dt1 = new DataTable();

                dt1 = k.GetOneSucursalID();

                ID = dt1.Rows[0][0].ToString(); 
                TextBox1.Text = dt1.Rows[0][1].ToString();
                tbtelefono.Text = dt1.Rows[0][2].ToString();
                tbcalle.Text = dt1.Rows[0][3].ToString();
                tbbarrio.Text = dt1.Rows[0][4].ToString();
                tbnumerocasa.Text = dt1.Rows[0][5].ToString();
                ddllocalidad.SelectedValue = dt1.Rows[0][6].ToString();


                TextBox1.Enabled = false;
                tbtelefono.Enabled = false;
                tbcalle.Enabled = false;
                tbbarrio.Enabled = false;
                tbnumerocasa.Enabled = false;
                ddllocalidad.Enabled = false;

            }
            catch (Exception ex)
            {

                lblerror.Text = ex.Message.ToString();
            }
        }
    }
}
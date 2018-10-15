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
    public partial class ConsultarProveedorGerente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //la primera vez que se carga la página
                //muestra el panel de  busqueda, no el de edicion
                panelconsulta.Focus();
                paneledicion.Visible = false;
                panelconsulta.Visible = true;
                panelconsulta.Focus();

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


        protected void gvproveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            //mostramos el panel de edicion
            paneledicion.Visible = true;
            panelconsulta.Visible = false;

        }

        protected void btnconsultar_Click(object sender, EventArgs e)
        {

            gvproveedores.Visible = true;

            TheGym k = new TheGym();
            k.NombreProveedorBusc = tbnombre.Text;
            DataTable dt = k.GetProveedorNom();
            if (dt.Rows.Count > 0)
            {
                gvproveedores.DataSource = dt;
                gvproveedores.DataBind();
                gvproveedores.Focus();
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
            gvproveedores.Dispose();
            gvproveedores.DataBind();
            lblerror.Text = "";
            btneditar.Text = "Editar";
            btncancelar.Text = "Volver";
        }

        protected void btneditar_Click(object sender, EventArgs e)
        {

            if (btneditar.Text == "Editar")
            {
                TextBox1.Enabled = true;
                tbcuit.Enabled = true;
                tbemail.Enabled = true;
                tbrepresentante.Enabled = true;
                tbtelefono.Enabled = true;
                tbcalle.Enabled = true;
                tbnumerocasa.Enabled = true;
                ddllocalidad.Enabled = true;
                btneditar.Text = "Guardar";
            }
            else
            {
                if (btneditar.Text == "Guardar")
                {
                    TheGym k = new TheGym
                    {
                        NombreProvEdit = TextBox1.Text,
                        CUITProvEdit = tbcuit.Text,
                        EmailProvEdit = tbemail.Text,
                        RepresentanteProvEdit = tbrepresentante.Text,
                        TelProvEdit = tbtelefono.Text,
                        CalleProvEdit = tbcalle.Text,
                        NumCasaProvEdit = tbnumerocasa.Text,
                        FKLocalidadesProvEdit = ddllocalidad.SelectedValue
                    };

                    try
                    {
                        k.UpdateProveedor();
                        lblerror.Text = "Proveedor editado con exito!";
                    }
                    catch
                    {
                        lblerror.Text = "Proveedor no editado!";
                    }

                    TextBox1.Enabled = false;
                    tbcuit.Enabled = false;
                    tbcalle.Enabled = false;
                    tbnumerocasa.Enabled = false;
                    tbemail.Enabled = false;
                    tbtelefono.Enabled = false;
                    tbrepresentante.Enabled = false;
                    ddllocalidad.Enabled = false;

                    btneditar.Text = "Editar";

                }
            }
        }
    }
}
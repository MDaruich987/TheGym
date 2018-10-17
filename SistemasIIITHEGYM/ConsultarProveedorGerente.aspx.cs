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

            try
            {
                    //mostramos el panel de edicion
                paneledicion.Visible = true;
                panelconsulta.Visible = false;
                paneledicion.Focus();
            }
            catch (Exception ex)
            {

                lblerror.Text = ex.Message.ToString();
            }

            ////bolquear edicion
            //TextBox1.Enabled = false;
            //tbcuit.Enabled = false;
            //tbemail.Enabled = false;
            //tbrepresentante.Enabled = false;
            //tbtelefono.Enabled = false;
            //tbcalle.Enabled = false;
            //tbnumerocasa.Enabled = false;
            //ddllocalidad.Enabled = false;

            //codigo para cargar los valores de la fila en los textbox del panel de edicion
            TheGym k = new TheGym
            {
                NombreProveedorBusc = "",
                IdProv = gvproveedores.SelectedRow.Cells[0].Text
            };

            DataTable dt = new DataTable();
            dt = k.GetAllDatosProveedor();


            if (dt.Rows.Count > 0)
            {
                tbnombre.Text = dt.Rows[0][1].ToString();
                tbcuit.Text = dt.Rows[0][2].ToString();
                tbcalle.Text = dt.Rows[0][3].ToString();
                tbnumerocasa.Text = dt.Rows[0][4].ToString();
                ddllocalidad.SelectedValue = dt.Rows[0][5].ToString();
                tbtelefono.Text = dt.Rows[0][6].ToString();
                tbrepresentante.Text = dt.Rows[0][7].ToString();
                tbemail.Text = dt.Rows[0][8].ToString();
            }



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
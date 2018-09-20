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
    public partial class RegistrarPlanEmpleado : System.Web.UI.Page
    {

        static DataTable Tabla = new DataTable();
        static DataTable TablaID = new DataTable();
        static int tam = 0;
        DataRow Row;
        DataColumn Column;
        protected void Page_Load(object sender, EventArgs e)
        {
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
            if (!IsPostBack)
            {
                GetActividad();

                if (tam == 0)
                {
                    Column = new DataColumn();
                    Column.DataType = System.Type.GetType("System.Int32");
                    Column.ColumnName = "Id_actividad";
                    TablaID.Columns.Add(Column);

                    Column = new DataColumn();
                    Column.DataType = System.Type.GetType("System.String");
                    Column.ColumnName = "Nombre Actividad";
                    Tabla.Columns.Add(Column);

                    Column = new DataColumn();
                    Column.DataType = System.Type.GetType("System.Int32");
                    Column.ColumnName = "Dias por Semana";
                    Tabla.Columns.Add(Column);

                    tam = 1;


                }
                //Column = new DataColumn();
                //Column.DataType = System.Type.GetType("System.String");
                //Column.ColumnName = "Nombre Actividad";
                //Tabla.Columns.Add(Column);

                //Column = new DataColumn();
                //Column.DataType = System.Type.GetType("System.Int32");
                //Column.ColumnName = "Dias por Semana";
                //Tabla.Columns.Add(Column);


            }
            this.Page.Response.Write("<script language='JavaScript'>window.alert('Hello');</script>");
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

        protected void btnregistrar_Click(object sender, EventArgs e)
        {
            try
            {

                string idplan;

                DataTable aux1 = new DataTable();

                TheGym k = new TheGym
                {
                    Nombreplanins = tbnombre.Text,
                    duracionplanins = lbduracion.SelectedValue,
                    precioplanins = tbprecio.Text
                };

                k.AddNewPlan();


                aux1 = k.GetLastPlan();

                DataRow fila = aux1.Rows[0];

                idplan = fila[0].ToString();

                int aux = Tabla.Rows.Count;

                for (int i = aux; i > 0; i--)
                {
                    k.FK_plan = idplan;

                    fila = TablaID.Rows[i - 1];

                    k.FK_actividad = fila[0].ToString();

                    fila = Tabla.Rows[i - 1];
                    k.Dias_semanas = fila["Dias por Semana"].ToString();

                    k.AddDetallePlan();

                    Tabla.Rows.RemoveAt(i - 1);
                    TablaID.Rows.RemoveAt(i - 1);

                }

                tbnombre.Text = string.Empty;
                tbprecio.Text = string.Empty;

                griddetalleactividades.Dispose();

            }
            catch (Exception ex)
            {

                lblerror.Text = ex.Message.ToString();
            }
        }

        protected void btncancelar_Click(object sender, EventArgs e)
        {
            tbnombre.Text = "";
            tbprecio.Text = "";
        }

        protected void gridactividades_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void btnañadir_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreact;
                string cantact;
                string idact;

                idact = ddlactividad.SelectedValue;
                nombreact = ddlactividad.SelectedItem.Text;
                cantact = lbclasessemanales.SelectedItem.Text;

                Row = TablaID.NewRow();
                Row["Id_actividad"] = idact;
                TablaID.Rows.Add(Row);

                Row = Tabla.NewRow();
                Row["Nombre Actividad"] = nombreact;
                Row["Dias por Semana"] = cantact;
                Tabla.Rows.Add(Row);

                griddetalleactividades.DataSource = Tabla;
                griddetalleactividades.DataBind();
            }
            catch (Exception ex)
            {

                lblerror.Text=ex.Message.ToString();
            }
            
        }
    }
}
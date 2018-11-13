using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SistemasIIITHEGYM.BussinesLayer;
using System.Data;
using System.Drawing;

namespace SistemasIIITHEGYM
{
    public partial class InicioGerente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {


                panelcobrodeplanes.Visible = false;
                panelproductos.Visible = false;

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

                //TheGym k = new TheGym();
                //DataTable dt = k.GetAllPlanEstadistica();
                //lblplanes.Text = dt.Rows[0][0].ToString();


                //DataTable dt1 = k.GetAsistenciaEstadistica();
                //lblasistencias.Text = dt1.Rows[0][0].ToString();

            }
            catch (Exception ex)
            {
                lblerror.Text = ex.Message.ToString();
            }
        }

        protected void btnverestadisticascobro_Click(object sender, EventArgs e)
        {
            panelcobrodeplanes.Visible = true;
            panelproductos.Visible = false;



            ChartPlan.Visible = true;


        }

        protected void btnverestadisticaventasproducto_Click(object sender, EventArgs e)
        {
            panelproductos.Visible = true;
            panelcobrodeplanes.Visible = false;

            ChartProd.Visible = true;
        }


        protected void ChartPlan_Load1(object sender, EventArgs e)
        {

            TheGym k = new TheGym();
            DataTable dt2 = k.GetPlanChart();
            ChartPlan.DataSource = dt2;

            ChartPlan.Series["Series1"].YValueMembers = "monto total";
            ChartPlan.Series["Series1"].XValueMember = "mes";
            ChartPlan.ChartAreas["ChartArea1"].AxisX.Title = "Meses";
            ChartPlan.ChartAreas["ChartArea1"].AxisY.Title = "Ingresos por planes";
            ChartPlan.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font("Sans Serif", 10, FontStyle.Bold);
            ChartPlan.ChartAreas["ChartArea1"].AxisY.TitleFont = new Font("Sans Serif", 10, FontStyle.Bold);
            ChartPlan.DataBind();
            ChartPlan.Focus();
        }

        protected void ChartProd_Load(object sender, EventArgs e)
        {
            TheGym k = new TheGym();
            DataTable dt3 = k.GetProductoChart();
            ChartProd.DataSource = dt3;

            ChartProd.Series["Series1"].YValueMembers = "monto total";
            ChartProd.Series["Series1"].XValueMember = "Mes";
            ChartProd.ChartAreas["ChartArea1"].AxisX.Title = "Meses";
            ChartProd.ChartAreas["ChartArea1"].AxisY.Title = "Ingresos por ventas";
            ChartProd.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font("Sans Serif", 10, FontStyle.Bold);
            ChartProd.ChartAreas["ChartArea1"].AxisY.TitleFont = new Font("Sans Serif", 10, FontStyle.Bold);
            ChartProd.DataBind();
            ChartProd.Focus();
        }
    }
}
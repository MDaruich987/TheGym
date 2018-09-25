using SistemasIIITHEGYM.BussinesLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//para generar el PDF
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace SistemasIIITHEGYM
{
    public partial class ConsultarCobrodeCuotaEmpleado : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                panelconsulta.Visible = true;
                paneldatosdecobro.Visible = false;
                panelconsulta.Focus();
            }
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
        }

        protected void btnconsultar_Click(object sender, EventArgs e)
        {
            try
            {
                TheGym k = new TheGym
                {
                    ClienteCuota = tbbusqueda.Text
                };

                DataTable dt = k.GetCuota();
                if (dt.Rows.Count > 0)
                {
                    gridcuota.DataSource = dt;
                    gridcuota.DataBind();
                    lblerror.Text = "";
                }
                else
                {
                    lblerror.Text = "No se encontraron coincidencias";
                }
            }
            catch (Exception ex)
            {

                lblerror.Text=ex.Message.ToString();
            }

        }

        protected void gridcuota_SelectedIndexChanged(object sender, EventArgs e)
        {

            //cuando seleccionamos una fila del grid
            panelconsulta.Visible = false;
            paneldatosdecobro.Visible = true;
            paneldatosdecobro.Focus();
            try
            {

                //codigo para cargar los valores de la fila en los textbox del panel de edicion

                string idact = gridcuota.SelectedRow.Cells[1].Text;
                lblerror.Text = idact;

                TheGym k = new TheGym
                {
                    CuotaBusca = idact
                };

                DataTable dt1 = new DataTable();
                dt1 = k.getOneCuota();

                lblnombrecliente.Text = dt1.Rows[0][1].ToString()+", "+dt1.Rows[0][0].ToString();
                lblFecha.Text = dt1.Rows[0][2].ToString();
                lblplan.Text = dt1.Rows[0][3].ToString();
                lblmonto.Text = dt1.Rows[0][4].ToString();
                lblvencimiento.Text = dt1.Rows[0][5].ToString();

            }
            catch (Exception ex)
            {

                lblerror.Text = ex.Message.ToString();
            }
        }

        protected void btnimprimir_Click(object sender, EventArgs e)
        {
            try
            {
                //AQUIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII
                Document doc = new Document(iTextSharp.text.PageSize.A4, 10, 10, 42, 35);
                string path = Server.MapPath("~/PDFs/");
                PdfWriter.GetInstance(doc, new FileStream(path + "/" + lblusuario.Text + ".pdf", FileMode.Create));
                doc.Open();
                //abrimos el documento para escribir
                // Paragraph para = new Paragraph("This is my first line");
                // doc.Add(para);
                doc.NewPage();
                doc.Add(new Paragraph("Hello"));
                Font LineBreak = FontFactory.GetFont("Arial", size: 16);
                string pathImage = Server.MapPath("~/ImagenesSistema/EncabezadoInforme.JPG");
                iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(pathImage);
                Paragraph parrafo2 = new Paragraph(string.Format("               Comprobante de Cuotas"), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 16));
               
                doc.Close();
                //cerramos el documento
                lblerror.Text = "!";
            }
            catch (Exception ex)
            {

                lblerrorimpresion.Text=ex.Message.ToString();
            }

           
        }
    }
}
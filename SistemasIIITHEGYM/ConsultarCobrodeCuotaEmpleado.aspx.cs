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

                lblnombrecliente.Text = dt1.Rows[0][1].ToString()+ " "+dt1.Rows[0][0].ToString();
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
                        //creamos el documento y establecemos el tamaño de pagina y demas formatos
                Document doc = new Document(iTextSharp.text.PageSize.B6, 10, 10, 42, 35);
                //obtenemos la fecha actual para guardar el pdf con ella
                string fecha_actual = DateTime.Now.ToString("dd-MM-yyyy");     
                //obtenemos el nombre del cliente para guardar el pdf con él         
                string nombrearchivo = lblnombrecliente.Text + fecha_actual;
                //creamos un objeto escritor para escribir en el pdf
                PdfWriter writer = PdfWriter.GetInstance(doc,
                            new FileStream(@"C:\Users\Micaela Daruich\Documents\ProyectoGym\SistemasIIITHEGYM\PDFs\"+ nombrearchivo +".pdf", FileMode.Create));
                // le agregamos titulo, creador y abrimos
                doc.AddTitle("Comprobante de Pago de Cuota");
                doc.AddCreator("THEGYM");
                doc.Open();
                // Creamos el tipo de Font que vamos utilizar
                iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
                //añadimos un nuevo párrafo
                doc.Add(new Paragraph(""));
                //creamos la fecha actual para el encabezado del pdf
                DateTime hoy = DateTime.Now.AddDays(0);
                string nombre = Convert.ToString(hoy.ToShortDateString());
                //cambiamos los - por /
                nombre = nombre.Replace('/', '-');
                // Creamos una tabla y le añadimos el dia de hoy y el logo de la marca.
                iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(@"C:\Users\Micaela Daruich\Documents\ProyectoGym\SistemasIIITHEGYM\ImagenesSistema\logoGym.JPG");
                imagen.BorderWidth = 0;
                imagen.ScalePercent(30f);
                imagen.Alignment = Element.ALIGN_RIGHT;
                //agreamos la fecha
                Paragraph fechaActual = new Paragraph(nombre, _standardFont);
                //creamos la tabla para el encabezado
                PdfPTable cabecera = new PdfPTable(2);
                //en la primera celda la fecha
                PdfPCell celda1 = new PdfPCell(fechaActual);
                celda1.Border = 0;
                celda1.HorizontalAlignment = 0;
                celda1.VerticalAlignment = 1;
                cabecera.AddCell(celda1);
                //en la segunda celda la imagen del logo
                PdfPCell celda2 = new PdfPCell(imagen);
                celda2.Border = 0;
                celda2.HorizontalAlignment = 2;
                celda2.VerticalAlignment = 1;
                cabecera.AddCell(celda2);
                //lo añadimos al documento
                doc.Add(cabecera);

                // Insertamos salto de linea
                Paragraph saltoDeLinea = new Paragraph("                                                                                                                                                                                                                                                                                                                                                                                   ");
                doc.Add(saltoDeLinea);

                //Insertamos el titulo del documento
                Paragraph titulo = new Paragraph("Comprobante de Pago", FontFactory.GetFont("Calibri", 18, 3));
                titulo.Alignment = Element.ALIGN_CENTER;
                doc.Add(titulo);

                // Insertamos salto de linea
                Paragraph saltoDeLinea1 = new Paragraph("                                                                                                                                                                                                                                                                                                                                                                                   ");
                doc.Add(saltoDeLinea1);
                ////////////////////////////
                PdfPTable tblPrueba = new PdfPTable(5);
                tblPrueba.WidthPercentage = 86;

                // Configuramos el título de las columnas de la tabla
                PdfPCell clFecha = new PdfPCell(new Phrase("Fecha", _standardFont));
                clFecha.BorderWidth = 0;
                clFecha.BorderWidthBottom = 0.35f;

                PdfPCell clCliente = new PdfPCell(new Phrase("Cliente", _standardFont));
                clCliente.BorderWidth = 0;
                clCliente.BorderWidthBottom = 0.35f;

                PdfPCell clMonto = new PdfPCell(new Phrase("Monto", _standardFont));
                clMonto.BorderWidth = 0;
                clMonto.BorderWidthBottom = 0.35f;

                PdfPCell clPlan = new PdfPCell(new Phrase("Plan", _standardFont));
                clPlan.BorderWidth = 0;
                clPlan.BorderWidthBottom = 0.35f;

                PdfPCell clVencimiento = new PdfPCell(new Phrase("Vencimiento", _standardFont));
                clVencimiento.BorderWidth = 0;
                clVencimiento.BorderWidthBottom = 0.35f;

                // Añadimos las celdas a la tabla
                tblPrueba.AddCell(clFecha);
                tblPrueba.AddCell(clCliente);
                tblPrueba.AddCell(clMonto);
                tblPrueba.AddCell(clPlan);
                tblPrueba.AddCell(clVencimiento);


                // Llenamos la tabla con información
                clFecha = new PdfPCell(new Phrase(lblFecha.Text, _standardFont));
                clFecha.BorderWidth = 0;

                clCliente = new PdfPCell(new Phrase(lblnombrecliente.Text, _standardFont));
                clCliente.BorderWidth = 0;

                clMonto = new PdfPCell(new Phrase(lblmonto.Text, _standardFont));
                clMonto.BorderWidth = 0;

                clPlan = new PdfPCell(new Phrase(lblplan.Text, _standardFont));
                clPlan.BorderWidth = 0;

                clVencimiento = new PdfPCell(new Phrase(lblvencimiento.Text, _standardFont));
                clVencimiento.BorderWidth = 0;
                // Añadimos las celdas a la tabla
                tblPrueba.AddCell(clFecha);
                tblPrueba.AddCell(clCliente);
                tblPrueba.AddCell(clMonto);
                tblPrueba.AddCell(clPlan);
                tblPrueba.AddCell(clVencimiento);

                doc.Add(tblPrueba);

                //cerramos el documento
                doc.Close();
                writer.Close();
                lblerrorimpresion.Text = "Comprobante generado exitosamente";
            }
            catch (Exception ex)
            {

                lblerrorimpresion.Text=ex.Message.ToString();
            }

           
        }
    }
}
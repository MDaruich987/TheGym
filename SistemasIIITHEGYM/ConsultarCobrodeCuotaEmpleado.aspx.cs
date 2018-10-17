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
using iTextSharp.text.html;

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
                /*      //creamos el documento y establecemos el tamaño de pagina y demas formatos
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
              */
                GenerarPDF();
            }
            catch (Exception ex)
            {

                lblerrorimpresion.Text=ex.Message.ToString();
            }

           
        }

        public void GenerarPDF()
        {
            try
            {
                //instanciamos el documento
                Document pdfDoc = new Document(PageSize.A4, 10, 10, 10, 10);
                MemoryStream PDFData = new MemoryStream();
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, PDFData);
                //tipos de fuentes que vamos a utilizar
                var titleFont = FontFactory.GetFont("Arial", 12, Font.BOLD);
                var titleFontBlue = FontFactory.GetFont("Arial", 14, Font.NORMAL, BaseColor.BLUE);
                var boldTableFont = FontFactory.GetFont("Arial", 8, Font.BOLD);
                var bodyFont = FontFactory.GetFont("Arial", 8, Font.NORMAL);
                var EmailFont = FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLUE);
                BaseColor TabelHeaderBackGroundColor = BaseColor.GRAY;

                Rectangle pageSize = writer.PageSize;
                // abrimos el documento para escribir
                pdfDoc.Open();
                //Agregamos los elementos para el documento

                #region Top table
                // creamos la tabla del encabezado
                PdfPTable headertable = new PdfPTable(3);
                headertable.HorizontalAlignment = 0;
                headertable.WidthPercentage = 100;
                headertable.SetWidths(new float[] { 100f, 320f, 100f });  // Establecemos las dimensiones de las columnas
                headertable.DefaultCell.Border = Rectangle.NO_BORDER;
                //headertable.DefaultCell.Border = Rectangle.BOX; //para probar el codigo        

                //colocamos el logo
                iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("~/ImagenesSistema/logoGym.JPG"));
                logo.ScaleToFit(150, 65);

                {
                    PdfPCell pdfCelllogo = new PdfPCell(logo);
                    pdfCelllogo.Border = Rectangle.NO_BORDER;
                    pdfCelllogo.BorderColorBottom = new BaseColor(System.Drawing.Color.Black);
                    pdfCelllogo.BorderWidthBottom = 1f;
                    headertable.AddCell(pdfCelllogo);
                }

                {
                    PdfPCell middlecell = new PdfPCell();
                    middlecell.Border = Rectangle.NO_BORDER;
                    middlecell.BorderColorBottom = new BaseColor(System.Drawing.Color.Black);
                    middlecell.BorderWidthBottom = 1f;
                    headertable.AddCell(middlecell);
                }

                {
                    PdfPTable nested = new PdfPTable(1);
                    nested.DefaultCell.Border = Rectangle.NO_BORDER;
                    PdfPCell nextPostCell1 = new PdfPCell(new Phrase("THE GYM", titleFont));
                    nextPostCell1.Border = Rectangle.NO_BORDER;
                    nested.AddCell(nextPostCell1);
                    PdfPCell nextPostCell2 = new PdfPCell(new Phrase("Salta, Argentina", bodyFont));
                    nextPostCell2.Border = Rectangle.NO_BORDER;
                    nested.AddCell(nextPostCell2);
                    PdfPCell nextPostCell3 = new PdfPCell(new Phrase("Av. Entre Ríos 865", bodyFont));
                    nextPostCell3.Border = Rectangle.NO_BORDER;
                    nested.AddCell(nextPostCell3);
                    PdfPCell nextPostCell4 = new PdfPCell(new Phrase("thegyminfo@gmail.com", EmailFont));
                    nextPostCell4.Border = Rectangle.NO_BORDER;
                    nested.AddCell(nextPostCell4);
                    nested.AddCell("");
                    PdfPCell nesthousing = new PdfPCell(nested);
                    nesthousing.Border = Rectangle.NO_BORDER;
                    nesthousing.BorderColorBottom = new BaseColor(System.Drawing.Color.Black);
                    nesthousing.BorderWidthBottom = 1f;
                    nesthousing.Rowspan = 5;
                    nesthousing.PaddingBottom = 10f;
                    headertable.AddCell(nesthousing);
                }


                PdfPTable Invoicetable = new PdfPTable(3);
                Invoicetable.HorizontalAlignment = 0;
                Invoicetable.WidthPercentage = 100;
                Invoicetable.SetWidths(new float[] { 100f, 320f, 100f });  // establecemos el ancho de las columnas
                Invoicetable.DefaultCell.Border = Rectangle.NO_BORDER;

                {
                    PdfPTable nested = new PdfPTable(1);
                    nested.DefaultCell.Border = Rectangle.NO_BORDER;
                    PdfPCell nextPostCell1 = new PdfPCell(new Phrase("Cliente:", bodyFont));
                    nextPostCell1.Border = Rectangle.NO_BORDER;
                    nested.AddCell(nextPostCell1);
                    PdfPCell nextPostCell2 = new PdfPCell(new Phrase(lblnombrecliente.Text, titleFont));
                    nextPostCell2.Border = Rectangle.NO_BORDER;
                    nested.AddCell(nextPostCell2);
                    //PdfPCell nextPostCell3 = new PdfPCell(new Phrase("DireccionProveedor", bodyFont));
                    //nextPostCell3.Border = Rectangle.NO_BORDER;
                    //nested.AddCell(nextPostCell3);
                    //PdfPCell nextPostCell4 = new PdfPCell(new Phrase("MailProveedor@hotmail.com", EmailFont));
                    //nextPostCell4.Border = Rectangle.NO_BORDER;
                    //nested.AddCell(nextPostCell4);
                    nested.AddCell("");
                    PdfPCell nesthousing = new PdfPCell(nested);
                    nesthousing.Border = Rectangle.NO_BORDER;
                    //nesthousing.BorderColorBottom = new BaseColor(System.Drawing.Color.Black);
                    //nesthousing.BorderWidthBottom = 1f;
                    nesthousing.Rowspan = 5;
                    nesthousing.PaddingBottom = 10f;
                    Invoicetable.AddCell(nesthousing);
                }

                {
                    PdfPCell middlecell = new PdfPCell();
                    middlecell.Border = Rectangle.NO_BORDER;
                    //middlecell.BorderColorBottom = new BaseColor(System.Drawing.Color.Black);
                    //middlecell.BorderWidthBottom = 1f;
                    Invoicetable.AddCell(middlecell);
                }


                {
                    PdfPTable nested = new PdfPTable(1);
                    nested.DefaultCell.Border = Rectangle.NO_BORDER;
                    PdfPCell nextPostCell1 = new PdfPCell(new Phrase("COMPROBANTE DE PAGO", titleFont));
                    nextPostCell1.Border = Rectangle.NO_BORDER;
                    nested.AddCell(nextPostCell1);
                    PdfPCell nextPostCell2 = new PdfPCell(new Phrase("Fecha de Pago: " + DateTime.Now.ToShortDateString(), bodyFont));
                    nextPostCell2.Border = Rectangle.NO_BORDER;
                    nested.AddCell(nextPostCell2);
                    PdfPCell nextPostCell3 = new PdfPCell(new Phrase("Fecha de Vigencia: " + DateTime.Now.AddDays(30).ToShortDateString(), bodyFont));
                    nextPostCell3.Border = Rectangle.NO_BORDER;
                    nested.AddCell(nextPostCell3);
                    nested.AddCell("");
                    PdfPCell nesthousing = new PdfPCell(nested);
                    nesthousing.Border = Rectangle.NO_BORDER;
                    //nesthousing.BorderColorBottom = new BaseColor(System.Drawing.Color.Black);
                    //nesthousing.BorderWidthBottom = 1f;
                    nesthousing.Rowspan = 5;
                    nesthousing.PaddingBottom = 10f;
                    Invoicetable.AddCell(nesthousing);
                }


                pdfDoc.Add(headertable);
                Invoicetable.PaddingTop = 10f;

                pdfDoc.Add(Invoicetable);
                #endregion

                #region Items Table
                //Create body table
                PdfPTable itemTable = new PdfPTable(3);

                itemTable.HorizontalAlignment = 0;
                itemTable.WidthPercentage = 100;
                itemTable.SetWidths(new float[] { 5, 50, 10});  // then set the column's __relative__ widths
                itemTable.SpacingAfter = 40;
                itemTable.DefaultCell.Border = Rectangle.BOX;
                PdfPCell cell1 = new PdfPCell(new Phrase("Nº", boldTableFont));
                cell1.BackgroundColor = TabelHeaderBackGroundColor;
                cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                itemTable.AddCell(cell1);
                PdfPCell cell2 = new PdfPCell(new Phrase("Plan", boldTableFont));
                cell2.BackgroundColor = TabelHeaderBackGroundColor;
                cell2.HorizontalAlignment = 1;
                itemTable.AddCell(cell2);
                PdfPCell cell3 = new PdfPCell(new Phrase("Precio", boldTableFont));
                cell3.BackgroundColor = TabelHeaderBackGroundColor;
                cell3.HorizontalAlignment = Element.ALIGN_CENTER;
                itemTable.AddCell(cell3);
                //PdfPCell cell4 = new PdfPCell(new Phrase("Precio por unidad", boldTableFont));
                //cell4.BackgroundColor = TabelHeaderBackGroundColor;
                //cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                //itemTable.AddCell(cell4);
                //PdfPCell cell5 = new PdfPCell(new Phrase("TOTAL", boldTableFont));
                //cell5.BackgroundColor = TabelHeaderBackGroundColor;
                //cell5.HorizontalAlignment = Element.ALIGN_CENTER;
                //itemTable.AddCell(cell5);
                //foreach (DataRow row in dt.Rows)
                {
                    PdfPCell numberCell = new PdfPCell(new Phrase("1", bodyFont));
                    numberCell.HorizontalAlignment = 1;
                    numberCell.PaddingLeft = 10f;
                    numberCell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                    itemTable.AddCell(numberCell);

                    var _phrase = new Phrase();
                    _phrase.Add(new Chunk(lblplan.Text, EmailFont));
                    PdfPCell descCell = new PdfPCell(_phrase);
                    descCell.HorizontalAlignment = 0;
                    descCell.PaddingLeft = 10f;
                    descCell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                    itemTable.AddCell(descCell);

                    PdfPCell qtyCell = new PdfPCell(new Phrase(lblmonto.Text, bodyFont));
                    qtyCell.HorizontalAlignment = 1;
                    qtyCell.PaddingLeft = 10f;
                    qtyCell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                    itemTable.AddCell(qtyCell);

                }
                //footer tabla
                PdfPCell totalAmtCell1 = new PdfPCell(new Phrase(""));
                totalAmtCell1.Border = Rectangle.LEFT_BORDER | Rectangle.TOP_BORDER;
                itemTable.AddCell(totalAmtCell1);
                PdfPCell totalAmtCell2 = new PdfPCell(new Phrase(""));
                totalAmtCell2.Border = Rectangle.TOP_BORDER; //Rectangle.NO_BORDER; //Rectangle.TOP_BORDER;
                itemTable.AddCell(totalAmtCell2);
                PdfPCell totalAmtCell3 = new PdfPCell(new Phrase(""));
                totalAmtCell3.Border = Rectangle.TOP_BORDER; //Rectangle.NO_BORDER; //Rectangle.TOP_BORDER;
                itemTable.AddCell(totalAmtCell3);
                //PdfPCell totalAmtStrCell = new PdfPCell(new Phrase("Total", boldTableFont));
                //totalAmtStrCell.Border = Rectangle.TOP_BORDER;   //Rectangle.NO_BORDER; //Rectangle.TOP_BORDER;
                //totalAmtStrCell.HorizontalAlignment = 1;
                //itemTable.AddCell(totalAmtStrCell);
                //PdfPCell totalAmtCell = new PdfPCell(new Phrase(lblmonto.Text, boldTableFont));
                //totalAmtCell.HorizontalAlignment = 1;
                //itemTable.AddCell(totalAmtCell);

                PdfPCell cell = new PdfPCell(new Phrase("***NOTA: El plan tiene vigencia únicamente por el tiempo estipulado en este comprobante", bodyFont));
                cell.Colspan = 5;
                cell.HorizontalAlignment = 1;
                itemTable.AddCell(cell);
                pdfDoc.Add(itemTable);
                #endregion

                PdfContentByte cb = new PdfContentByte(writer);


                BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, true);
                cb = new PdfContentByte(writer);
                cb = writer.DirectContent;
                cb.BeginText();
                cb.SetFontAndSize(bf, 8);
                cb.SetTextMatrix(pageSize.GetLeft(120), 20);
                cb.ShowText("@TheGym todos los derechos reservados");
                cb.EndText();

                //Movemos el puntero y dibujamos una linea para separa el resto del documento del footer
                cb.MoveTo(40, pdfDoc.PageSize.GetBottom(50));
                cb.LineTo(pdfDoc.PageSize.Width - 40, pdfDoc.PageSize.GetBottom(50));
                cb.Stroke();

                //cerramos el PDF
                pdfDoc.Close();
                DownloadPDF(PDFData);

            }
            catch (Exception ex)
            {
                lblerrorimpresion.Text = ex.Message.ToString();
            }
        }

        #region--Download PDF
        protected void DownloadPDF(System.IO.MemoryStream PDFData)
        {
            // Clear response content & headers
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.ContentType = "application/pdf";
            HttpContext.Current.Response.Charset = string.Empty;
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.Public);
            HttpContext.Current.Response.AddHeader("Content-Disposition", string.Format("attachment;filename=PAGOPLAN-{0}.pdf", "ComprobanteNº"));
            HttpContext.Current.Response.OutputStream.Write(PDFData.GetBuffer(), 0, PDFData.GetBuffer().Length);
            HttpContext.Current.Response.OutputStream.Flush();
            //HttpContext.Current.Response.End();
            HttpContext.Current.Response.OutputStream.Close();
            //HttpContext.Current.Response.End();
            
        }
        #endregion
    }
}
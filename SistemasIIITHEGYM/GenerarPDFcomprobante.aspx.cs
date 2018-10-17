using iTextSharp.text;
using iTextSharp.text.html;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemasIIITHEGYM
{
    public partial class GenerarPDFcomprobante : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GenerarPDF();
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
                BaseColor TabelHeaderBackGroundColor = WebColors.GetRGBColor("#EEEEEE");

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
                logo.ScaleToFit(100, 15);

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
                    PdfPCell nextPostCell3 = new PdfPCell(new Phrase("Dirección", bodyFont));
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
                    PdfPCell nextPostCell1 = new PdfPCell(new Phrase("PARA:", bodyFont));
                    nextPostCell1.Border = Rectangle.NO_BORDER;
                    nested.AddCell(nextPostCell1);
                    PdfPCell nextPostCell2 = new PdfPCell(new Phrase("NombreProveedor", titleFont));
                    nextPostCell2.Border = Rectangle.NO_BORDER;
                    nested.AddCell(nextPostCell2);
                    PdfPCell nextPostCell3 = new PdfPCell(new Phrase("DireccionProveedor", bodyFont));
                    nextPostCell3.Border = Rectangle.NO_BORDER;
                    nested.AddCell(nextPostCell3);
                    PdfPCell nextPostCell4 = new PdfPCell(new Phrase("MailProveedor@hotmail.com", EmailFont));
                    nextPostCell4.Border = Rectangle.NO_BORDER;
                    nested.AddCell(nextPostCell4);
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
                    PdfPCell nextPostCell1 = new PdfPCell(new Phrase("ORDEN DE COMPRA", titleFontBlue));
                    nextPostCell1.Border = Rectangle.NO_BORDER;
                    nested.AddCell(nextPostCell1);
                    PdfPCell nextPostCell2 = new PdfPCell(new Phrase("Fecha1: " + DateTime.Now.ToShortDateString(), bodyFont));
                    nextPostCell2.Border = Rectangle.NO_BORDER;
                    nested.AddCell(nextPostCell2);
                    PdfPCell nextPostCell3 = new PdfPCell(new Phrase("Fecha Límite: " + DateTime.Now.AddDays(30).ToShortDateString(), bodyFont));
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
                PdfPTable itemTable = new PdfPTable(5);

                itemTable.HorizontalAlignment = 0;
                itemTable.WidthPercentage = 100;
                itemTable.SetWidths(new float[] { 5, 40, 10, 20, 25 });  // then set the column's __relative__ widths
                itemTable.SpacingAfter = 40;
                itemTable.DefaultCell.Border = Rectangle.BOX;
                PdfPCell cell1 = new PdfPCell(new Phrase("Nº", boldTableFont));
                cell1.BackgroundColor = TabelHeaderBackGroundColor;
                cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                itemTable.AddCell(cell1);
                PdfPCell cell2 = new PdfPCell(new Phrase("Producto", boldTableFont));
                cell2.BackgroundColor = TabelHeaderBackGroundColor;
                cell2.HorizontalAlignment = 1;
                itemTable.AddCell(cell2);
                PdfPCell cell3 = new PdfPCell(new Phrase("Cantidad", boldTableFont));
                cell3.BackgroundColor = TabelHeaderBackGroundColor;
                cell3.HorizontalAlignment = Element.ALIGN_CENTER;
                itemTable.AddCell(cell3);
                PdfPCell cell4 = new PdfPCell(new Phrase("Precio por unidad", boldTableFont));
                cell4.BackgroundColor = TabelHeaderBackGroundColor;
                cell4.HorizontalAlignment = Element.ALIGN_CENTER;
                itemTable.AddCell(cell4);
                PdfPCell cell5 = new PdfPCell(new Phrase("TOTAL", boldTableFont));
                cell5.BackgroundColor = TabelHeaderBackGroundColor;
                cell5.HorizontalAlignment = Element.ALIGN_CENTER;
                itemTable.AddCell(cell5);
                //foreach (DataRow row in dt.Rows)
                {
                    PdfPCell numberCell = new PdfPCell(new Phrase("@ID", bodyFont));
                    numberCell.HorizontalAlignment = 1;
                    numberCell.PaddingLeft = 10f;
                    numberCell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                    itemTable.AddCell(numberCell);

                    var _phrase = new Phrase();
                    _phrase.Add(new Chunk("@desc 1", EmailFont));
                    _phrase.Add(new Chunk("@desc 2", bodyFont));
                    PdfPCell descCell = new PdfPCell(_phrase);
                    descCell.HorizontalAlignment = 0;
                    descCell.PaddingLeft = 10f;
                    descCell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                    itemTable.AddCell(descCell);

                    PdfPCell qtyCell = new PdfPCell(new Phrase("@cant", bodyFont));
                    qtyCell.HorizontalAlignment = 1;
                    qtyCell.PaddingLeft = 10f;
                    qtyCell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                    itemTable.AddCell(qtyCell);

                    PdfPCell amountCell = new PdfPCell(new Phrase("@precio", bodyFont));
                    amountCell.HorizontalAlignment = 1;
                    amountCell.PaddingLeft = 10f;
                    amountCell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                    itemTable.AddCell(amountCell);

                    PdfPCell totalamtCell = new PdfPCell(new Phrase("@total", bodyFont));
                    totalamtCell.HorizontalAlignment = 1;
                    totalamtCell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;

                    //agregamos la fila a la tabla

                    itemTable.AddCell(totalamtCell);

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
                PdfPCell totalAmtStrCell = new PdfPCell(new Phrase("Total", boldTableFont));
                totalAmtStrCell.Border = Rectangle.TOP_BORDER;   //Rectangle.NO_BORDER; //Rectangle.TOP_BORDER;
                totalAmtStrCell.HorizontalAlignment = 1;
                itemTable.AddCell(totalAmtStrCell);
                PdfPCell totalAmtCell = new PdfPCell(new Phrase("@totalgeneral", boldTableFont));
                totalAmtCell.HorizontalAlignment = 1;
                itemTable.AddCell(totalAmtCell);

                PdfPCell cell = new PdfPCell(new Phrase("***NOTA: Se acepta hasta un cargo del 1.5% en el periodo de 30 days. ***", bodyFont));
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
                cb.ShowText("Invoice was created on a computer and is valid without the signature and seal. ");
                cb.EndText();

                //Movemos el puntero y dibujamos una linea para separa el resto del documento del footer
                cb.MoveTo(40, pdfDoc.PageSize.GetBottom(50));
                cb.LineTo(pdfDoc.PageSize.Width - 40, pdfDoc.PageSize.GetBottom(50));
                cb.Stroke();

                //cerramos el PDF
                pdfDoc.Close();
                DownloadPDF(PDFData);

            }
            catch(Exception ex)
            {
                Label1.Text = ex.Message.ToString();
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
            HttpContext.Current.Response.Cache.SetCacheability(System.Web.HttpCacheability.Public);
            HttpContext.Current.Response.AddHeader("Content-Disposition", string.Format("attachment;filename=PROVEEDOR-{0}.pdf", "OrdendeCompraNº"));
            HttpContext.Current.Response.OutputStream.Write(PDFData.GetBuffer(), 0, PDFData.GetBuffer().Length);
            HttpContext.Current.Response.OutputStream.Flush();
            HttpContext.Current.Response.OutputStream.Close();
            HttpContext.Current.Response.End();
        }
        #endregion
    }

}
using iTextSharp.text;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using SistemasIIITHEGYM.BussinesLayer;
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
    public partial class GenerarReportesGerente : System.Web.UI.Page
    {

        static DataTable detalle = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                gridreportes.DataBind();
                paneldetalle.Visible = false;
                panelreporte.Visible = true;
            }


            if (IsPostBack == false)
            {
                DataTable Tabla = new DataTable();
                //Tabla.Columns.Add("ID_MovimientoCaja");
                Tabla.Columns.Add("descripcion");
                Tabla.Columns.Add("Monto");
                Tabla.Columns.Add("Capital");
                Tabla.Columns.Add("Concepto");
                Tabla.Columns.Add("Comprobante");
                Tabla.Columns.Add("Dia");
                gridreportes.DataSource = Tabla;
                gridreportes.DataBind();
                Session["Datos"] = Tabla;


                //cargarconceptos();



            }
            //cargarconceptos();
            gridreportes.Visible = false;



        }

        //private void cargarconceptos()
        //{

        //    TheGym k = new TheGym
        //    {
        //        Estado = ddlcapital.Text
        //    };
        //    DataTable dt = new DataTable();
        //    dt = k.GetConceptos();
        //    DataRow fila = dt.NewRow();
        //    fila[0] = "Total";
        //    dt.Rows.Add(fila);
        //    ddlconcepto.DataSource = dt;
        //    //ddlplan.DataValueField = "Id_concepto";
        //    ddlconcepto.DataTextField = "Concepto";
        //    ddlconcepto.DataBind();

        //}





        protected void btnaplicar_Click(object sender, EventArgs e)
        {
            if (ddlconcepto.SelectedItem.Text == "Total")
            {
                TheGym q = new TheGym
                {
                    Capital = ddlcapital.SelectedItem.Text,
                    FechaIn = TextBox1.Text,
                    FechaFin = TextBox2.Text,

                };

                DataTable dt1 = new DataTable();
                dt1 = q.GetReporteDineroConceptoTotal();
                

                gridreportes.Visible = true;
                if (dt1.Rows.Count > 0)
                {
                    gridreportes.DataSource = dt1;
                    gridreportes.DataBind();
                    gridreportes.Focus();
                    Label1.Text = "";
                    detalle = q.GetReporteDineroConceptoTotal();

                    TheGym r = new TheGym
                    {
                        
                        FechaIn = TextBox1.Text,
                        FechaFin = TextBox2.Text,

                    };

                    
                    DataTable dt3 = new DataTable();
                    dt3 = r.GetSumTotal();

                    tbtotal.Text = dt3.Rows[0][1].ToString();


                }
                else
                {
                    Label1.Text = "No existen datos";
                    gridreportes.DataBind();
                }

                paneldetalle.Visible = true;

            }
            else
            {
                TheGym w = new TheGym
                {
                    
                    Estado = ddlconcepto.SelectedItem.Text,
                    FechaIn = TextBox1.Text,
                    FechaFin = TextBox2.Text,

                };

                DataTable dt2 = new DataTable();
                dt2 = w.GetReporteDineroConcepto();
                
                gridreportes.Visible = true;
                if (dt2.Rows.Count > 0)
                {
                    gridreportes.DataSource = dt2;
                    gridreportes.DataBind();
                    gridreportes.Focus();
                    Label1.Text = "";
                    detalle = w.GetReporteDineroConcepto();


                    TheGym r = new TheGym
                    {
                        Estado = ddlconcepto.SelectedItem.Text,
                        FechaIn = TextBox1.Text,
                        FechaFin = TextBox2.Text,

                    };

                    DataTable dt3 = new DataTable();
                    dt3 = r.GetSumTotalConcepto();

                    if (ddlcapital.Text == "Ingreso")
                    {
                        tbingreso.Text = dt3.Rows[0][1].ToString();
                        tbtotal.Text = dt3.Rows[0][1].ToString();
                    }
                    else
                    {
                        tbegreso.Text = dt3.Rows[0][1].ToString();
                        tbtotal.Text = dt3.Rows[0][1].ToString();
                    }

                    paneldetalle.Visible = true;
                    //tbtotal.Text = dt3.Rows[0][1].ToString();

                }
                else
                {
                    Label1.Text = "No existen datos";
                    gridreportes.DataBind();
                };
            }



           
           
        }

        protected void btncancelar_Click1(object sender, EventArgs e)
        {
            Response.Redirect("InicioGerente.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            gridreportes.DataBind();
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox1.Focus();
            tbegreso.Text = "";
            tbingreso.Text = "";
            tbtotal.Text = "";
            detalle = null;
            gridreportes.Visible = false;

        }


        //protected void gridreportes_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        //{
        //    gridreportes.PageIndex = e.NewPageIndex;
        //    gridreportes.DataSource = detalle;
        //    gridreportes.DataBind();


        //}

        protected void ddlcapital_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlcapital.Text == "Ingreso")
            {
                tbingreso.Visible = true;
                tbegreso.Visible = false;
                tbtotal.Visible = true;


            }
            else
            {
                if (ddlcapital.Text == "Egreso")
                {
                    tbegreso.Visible = true;
                    tbingreso.Visible = false;
                    tbtotal.Visible = true;

                }
                else
                {
                    tbingreso.Visible = true;
                    tbegreso.Visible = true;
                    tbtotal.Visible = true;

                }

            }

            TheGym k = new TheGym
            {
                Estado = ddlcapital.Text
            };
            DataTable dt = new DataTable();
            dt = k.GetConceptos();
            DataRow fila = dt.NewRow();
            fila[0] = "Total";
            dt.Rows.Add(fila);
            ddlconcepto.DataSource = dt;
            //ddlplan.DataValueField = "Id_concepto";
            ddlconcepto.DataTextField = "Concepto";
            ddlconcepto.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GenerarPDF(detalle, TextBox1.Text, TextBox2.Text, tbtotal.Text);

        }



       

        protected void gridreportes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridreportes.Visible = true;
            gridreportes.PageIndex = e.NewPageIndex;
            gridreportes.DataSource = detalle;
            gridreportes.DataBind();

        }

        public void GenerarPDF(DataTable dt, string fechainicio, string fechafin, string total/*, string proveedor*/)
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
                    PdfPCell nextPostCell3 = new PdfPCell(new Phrase("Av. Entre Rios 865", bodyFont));
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
                    PdfPCell nextPostCell1 = new PdfPCell(new Phrase("REPORTE DE FINANZAS", titleFont));
                    nextPostCell1.Border = Rectangle.NO_BORDER;
                    nested.AddCell(nextPostCell1);
                    PdfPCell nextPostCell2 = new PdfPCell(new Phrase("", titleFont));
                    nextPostCell2.Border = Rectangle.NO_BORDER;
                    nested.AddCell(nextPostCell2);
                    PdfPCell nextPostCell3 = new PdfPCell(new Phrase("", bodyFont));
                    nextPostCell3.Border = Rectangle.NO_BORDER;
                    nested.AddCell(nextPostCell3);
                    PdfPCell nextPostCell4 = new PdfPCell(new Phrase("", EmailFont));
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
                    PdfPCell nextPostCell1 = new PdfPCell(new Phrase("Fecha del Reporte: " + DateTime.Now.ToShortDateString(), bodyFont));
                    nextPostCell1.Border = Rectangle.NO_BORDER;
                    nested.AddCell(nextPostCell1);
                    PdfPCell nextPostCell2 = new PdfPCell(new Phrase("Fecha Inicio: " + fechainicio, bodyFont));
                    nextPostCell2.Border = Rectangle.NO_BORDER;
                    nested.AddCell(nextPostCell2);
                    PdfPCell nextPostCell3 = new PdfPCell(new Phrase("Fecha Fin: " + fechafin, bodyFont));
                    nextPostCell3.Border = Rectangle.NO_BORDER;
                    nested.AddCell(nextPostCell3);
                    //PdfPCell nextPostCell4 = new PdfPCell(new Phrase("Fecha del Reporte: " + DateTime.Now.ToShortDateString(), bodyFont));
                    //nextPostCell4.Border = Rectangle.NO_BORDER;
                    //nested.AddCell(nextPostCell4);
                    //nested.AddCell("");
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
                PdfPTable itemTable = new PdfPTable(6);

                itemTable.HorizontalAlignment = 0;
                itemTable.WidthPercentage = 100;
                itemTable.SetWidths(new float[] { 10, 10, 10, 10, 10, 10 });  // then set the column's __relative__ widths
                itemTable.SpacingAfter = 40;
                itemTable.DefaultCell.Border = Rectangle.BOX;
                PdfPCell cell1 = new PdfPCell(new Phrase("Forma de Pago", boldTableFont));
                cell1.BackgroundColor = TabelHeaderBackGroundColor;
                cell1.HorizontalAlignment = 1;
                itemTable.AddCell(cell1);
                PdfPCell cell2 = new PdfPCell(new Phrase("Monto", boldTableFont));
                cell2.BackgroundColor = TabelHeaderBackGroundColor;
                cell2.HorizontalAlignment = 1;
                itemTable.AddCell(cell2);
                PdfPCell cell3 = new PdfPCell(new Phrase("Capital", boldTableFont));
                cell3.BackgroundColor = TabelHeaderBackGroundColor;
                cell3.HorizontalAlignment = 1;
                itemTable.AddCell(cell3);
                PdfPCell cell4 = new PdfPCell(new Phrase("Concepto", boldTableFont));
                cell4.BackgroundColor = TabelHeaderBackGroundColor;
                cell4.HorizontalAlignment = 1;
                itemTable.AddCell(cell4);
                PdfPCell cell5 = new PdfPCell(new Phrase("Comprobante", boldTableFont));
                cell5.BackgroundColor = TabelHeaderBackGroundColor;
                cell5.HorizontalAlignment = 1;
                itemTable.AddCell(cell5);
                PdfPCell cell6 = new PdfPCell(new Phrase("Día", boldTableFont));
                cell6.BackgroundColor = TabelHeaderBackGroundColor;
                cell6.HorizontalAlignment = 1;
                itemTable.AddCell(cell6);

                foreach (DataRow row in dt.Rows)
                {
                    //instanciamos variables para los elementos del datatable
                    string formadepago = row[0].ToString();
                    string monto = row[1].ToString();
                    string estado = row[2].ToString();
                    string concepto = row[3].ToString();
                    string comprobante = row[4].ToString();
                    string día = row[5].ToString();

                    //insertamos en la tabla la forma de pago
                    PdfPCell numberCell = new PdfPCell(new Phrase(formadepago, bodyFont));
                    numberCell.HorizontalAlignment = 1;
                    numberCell.PaddingLeft = 10f;
                    numberCell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                    itemTable.AddCell(numberCell);
                    //insertamos en la tabla el monto
                    PdfPCell numberCell1 = new PdfPCell(new Phrase(monto, bodyFont));
                    numberCell1.HorizontalAlignment = 1;
                    numberCell1.PaddingLeft = 10f;
                    numberCell1.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                    itemTable.AddCell(numberCell1);
                    //insertamos en la tabla la estado
                    PdfPCell numberCell2 = new PdfPCell(new Phrase(estado, bodyFont));
                    numberCell2.HorizontalAlignment = 1;
                    numberCell2.PaddingLeft = 10f;
                    numberCell2.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                    itemTable.AddCell(numberCell2);
                    //insertamos en la tabla la conceptp
                    PdfPCell numberCell3 = new PdfPCell(new Phrase(concepto, bodyFont));
                    numberCell3.HorizontalAlignment = 1;
                    numberCell3.PaddingLeft = 10f;
                    numberCell3.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                    itemTable.AddCell(numberCell3);
                    //insertamos en la tabla la comprobante
                    PdfPCell numberCell4 = new PdfPCell(new Phrase(comprobante, bodyFont));
                    numberCell4.HorizontalAlignment = 1;
                    numberCell4.PaddingLeft = 10f;
                    numberCell4.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                    itemTable.AddCell(numberCell4);
                    //insertamos en la tabla la dia
                    PdfPCell numberCell5 = new PdfPCell(new Phrase(día, bodyFont));
                    numberCell5.HorizontalAlignment = 1;
                    numberCell5.PaddingLeft = 10f;
                    numberCell5.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                    itemTable.AddCell(numberCell5);

                }
                //pie de tabla
                //PdfPCell totalAmtCell1 = new PdfPCell(new Phrase(""));
                //totalAmtCell1.Border = Rectangle.LEFT_BORDER | Rectangle.TOP_BORDER;
                //itemTable.AddCell(totalAmtCell1);
                //PdfPCell totalAmtCell2 = new PdfPCell(new Phrase(""));
                //totalAmtCell2.Border = Rectangle.TOP_BORDER; //Rectangle.NO_BORDER; //Rectangle.TOP_BORDER;
                //itemTable.AddCell(totalAmtCell2);
                //PdfPCell totalAmtCell3 = new PdfPCell(new Phrase(""));
                //totalAmtCell3.Border = Rectangle.TOP_BORDER; //Rectangle.NO_BORDER; //Rectangle.TOP_BORDER;
                //itemTable.AddCell(totalAmtCell3);
                //PdfPCell totalAmtStrCell = new PdfPCell(new Phrase("Total", boldTableFont));
                //totalAmtStrCell.Border = Rectangle.TOP_BORDER;   //Rectangle.NO_BORDER; //Rectangle.TOP_BORDER;
                //totalAmtStrCell.HorizontalAlignment = 1;
                //itemTable.AddCell(totalAmtStrCell);
                //PdfPCell totalAmtCell = new PdfPCell(new Phrase("TOTAL", boldTableFont));
                //totalAmtCell.HorizontalAlignment = 1;
                //itemTable.AddCell(totalAmtCell);

                PdfPCell cell = new PdfPCell(new Phrase("TOTAL = " + total, titleFont));
                cell.Colspan = 6;
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
                cb.ShowText("USO EXCLUSIVO PARA PERSONAL DE GERENCIA");
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
                Label1.Text = ex.Message.ToString();
            }
        }

        #region--Download PDF
        protected void DownloadPDF(System.IO.MemoryStream PDFData)
        {
            try
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
                //HttpContext.Current.Response.End();
            }
            catch (Exception ex)
            {

                Label1.Text = ex.Message.ToString();
            }

        }
        #endregion
    }
}
using iTextSharp.text;
using iTextSharp.text.html;
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
    public partial class RegistrarCobroPlanEmpleado : System.Web.UI.Page
    {
        public static bool flag=false;

        static string aux;

        public static string nombre;
        public static string apellido;
        public static string id;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAllMedioPago();
                GetAllPlan();
                btngenerarcomprobante.Visible = false;
                btnvolver.Visible = false;
                
                //la primera vez que se carga la página
                //muestra el panel de  busqueda, no el de edicion
                paneldatosdecobro.Visible = false;
                panelseleccioncliente.Focus();
                panelseleccioncliente.Visible = true;
                //Response.Write("<script>window.alert('Bienvenido');</script>");
                //preguntamos si no se realizo la apertura de caja del día en el 5==5
                //if (5==5){
                //Response.Write("<script>window.alert('No se realizó la apertura de caja del día. Debe registrar una primero');</script>" + "<script>window.setTimeout(location.href='AperturadeCajaEmpleado.aspx', 2000);</script>");
                //si no, me manda a la pagina de apertura de caja
                // }
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

            lblFecha.Text = DateTime.Now.ToShortDateString();
            lblhora.Text = DateTime.Now.ToShortTimeString();
            
            //lblnombreusuario.Text = apellido + ", " +nombre;
            
            //lblnombreusuario.Text = gridclientes.SelectedRow.Cells[1].Text;

            if (flag == false)
            {
                GetAllPlan();
                GetAllMedioPago();
                flag = true;
            }
            
        }

        private void GetAllPlan()
        {
            try
            {
                TheGym k = new TheGym();
                DataTable dt = new DataTable();
                dt = k.GetAllPlans();
                if (dt.Rows.Count > 0)
                {
                    //DdlPlan.Items.Add("Seleccione...");
                    //DdlPlan.DataSource = dt;
                    ddlplan.DataTextField = "Nombre";
                    ddlplan.DataValueField = "Id_plan";

                    ddlplan.DataSource = dt;
                    ddlplan.DataBind();
                    // DdlPlan.Items.Add("Seleccione...");
                    ddlplan.Items.Insert(0, "Seleccione...");

                }
            }
            catch (Exception ex)
            {

                Label1.Text=ex.Message.ToString();
            }

        }


        private void GetAllMedioPago()
        {
            TheGym k = new TheGym();
            DataTable dt = new DataTable();
            dt = k.GetAllMedioPago();
            if (dt.Rows.Count > 1)
            {
                ddlformadepago.DataTextField = "descripcion";
                ddlformadepago.DataValueField = "id_formapago";
                ddlformadepago.DataSource = dt;
                ddlformadepago.DataBind();
            }
        }

        protected void btnconsultar_Click(object sender, EventArgs e)
        {
            try
            {
                gridclientes.Visible = true;

                TheGym k = new TheGym();
                k.NombreClienteBusc = tbnombre.Text;
                DataTable dt = k.GetClienteNom();
                if (dt.Rows.Count > 0)
                {
                    gridclientes.DataSource = dt;
                    gridclientes.DataBind();
                    gridclientes.Focus();
                    lblerror.Text = "";
                }
                else
                {
                    lblerror.Text = "No se encontraron clientes relacionados";
                }

                flag = true;
            }
            catch (Exception ex)
            {

                lblerror.Text = ex.Message.ToString();
            }
            
        }

        protected void gridclientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            // cuando seleccionamos una fila del grid
            try
            {
                //mostrar un panel y ocultar otro
                panelseleccioncliente.Visible = false;
                paneldatosdecobro.Visible = true;
                paneldatosdecobro.Focus();
                tbmonto.ReadOnly = true;
                TbComprobante.Visible = false;
                lblComprobante.Visible = false;
                //codigo para cargar los valores de la fila en los textbox del panel de edicion

            }
            catch (Exception ex)
            {

                lblerror.Text = ex.Message.ToString();
            }

            nombre = gridclientes.SelectedRow.Cells[1].Text;
            apellido = gridclientes.SelectedRow.Cells[2].Text;
            id = gridclientes.SelectedRow.Cells[0].Text;
            lblnombreusuario.Text = apellido + ", " + nombre;

        }

        protected void btnregistrar_Click(object sender, EventArgs e)
        {
            try
            {
                string ID;
                int auxiliar;
                DateTime auxiliar1;
                DataTable dt = new DataTable();
                TheGym k = new TheGym
                {
                    FechaIdDetCaja = lblFecha.Text
                };
                dt = k.GetEstadoDetCaja();
                if (dt.Rows.Count < 1)
                {
                    //dt = ;
                    //ID = Session["IdSession"]; GetIdDetCaja
                    //ID = 3;
                    DataTable dt1 = new DataTable();
                    dt1 = k.GetEstadoDetCajaAP();
                    if (dt1.Rows.Count > 0)
                    {
                        DataTable dt2 = new DataTable();
                        dt2 = k.GetIdDetCaja();
                        ID = dt2.Rows[0][0].ToString();
                        k.FKDetCajaMov = ID;
                        k.FKFormaPagoMov = ddlformadepago.SelectedValue.ToString();
                        k.EstadoMov = "Ingreso";
                        k.ComprobanteMov = TbComprobante.Text;
                        k.MontoMov = tbmonto.Text;
                        k.ConceptoMov = "Pago Plan";
                        k.HoraMov = Convert.ToString(DateTime.Now.TimeOfDay);

                        k.AddMovimientoCaja();

                        k.FechaCuota = lblFecha.Text;
                        k.FK_clienteCuota = id;
                        k.FK_planCuota = ddlplan.SelectedValue.ToString();
                        k.MontoCuota = tbmonto.Text;
                        DataTable aux1 = new DataTable();
                        k.IDPlanVencimiento = ddlplan.SelectedValue;
                        aux1 = k.GetVencimiento();
                        auxiliar = Convert.ToInt32(aux1.Rows[0][0].ToString());
                        auxiliar1 = Convert.ToDateTime(lblFecha.Text).AddDays(auxiliar);
                        k.VencimientoCuota = Convert.ToString(auxiliar1);
                        k.AddCuota();

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#modal-default').modal('show');", true);
                        Label1.Text = "El cobro se ha registrado exitosamente!";
                        btngenerarcomprobante.Visible = true;
                        btnregistrar.Visible = false;
                        btngenerarcomprobante.Visible = true;
                        btncancelar.Visible = false;
                        btnvolver.Visible = true;
                        tbmonto.Text = string.Empty;
                        TbComprobante.Text = string.Empty;
                        lblComprobante.Visible = false;
                        TbComprobante.Visible = false;
                        ddlformadepago.ClearSelection();
                        ddlplan.ClearSelection();

                        //panelseleccioncliente.Visible = true;
                        //panelseleccioncliente.Focus();
                        //paneldatosdecobro.Visible = false;
                        //tbnombre.Text = "";


                    }
                    else
                    {
                        lblerror.Visible = true;
                        lblerror.ForeColor = System.Drawing.Color.Red;
                        gridclientes.Enabled = false;
                        btnregistrar.Enabled = false;
                        Label1.Text= "Caja No Abierta";
                    }

                }
                else
                {
                    lblerror.Visible = true;
                    lblerror.Text = "Caja Cerrada";
                    lblerror.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {

                lblerror.Text=ex.Message.ToString();
            }
          


        }

        protected void btncancelar_Click(object sender, EventArgs e)
        {
            panelseleccioncliente.Visible = true;
            panelseleccioncliente.Focus();
            paneldatosdecobro.Visible = false;
            tbnombre.Text = "";
        }

        protected void ddlformadepago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlformadepago.SelectedItem.Text == "Efectivo")
            {
                lblComprobante.Visible = false;
                TbComprobante.Visible = false;
            }
            else
            {
                lblComprobante.Visible = true;
                TbComprobante.Visible = true;
            }
        }

        protected void ddlplan_SelectedIndexChanged(object sender, EventArgs e)
        {
            //.Visible = true;
            //DdlMedioPago.Visible = true;
            //GetAllMedioPago();
            aux = ddlplan.SelectedValue;
            if (aux != "Seleccione...")
            {
                TheGym k = new TheGym
                {
                    IdPlanMonto = aux
                };
                DataTable dt = new DataTable();
                dt = k.GetTotalPlan();
                tbmonto.Text = dt.Rows[0][0].ToString();
            }
            else
            {
                tbmonto.Text = "";
                //LblMedioPago.Visible = false;
                //DdlMedioPago.Visible = false;
            }
        }

        protected void btngenerarcomprobante_Click(object sender, EventArgs e)
        {
            string lblnombrecliente = "";
            string lblplan = "";
            string lblmonto = "";
            string lblvencimiento = "";

            try
            {
                TheGym k = new TheGym
                {
                    ClienteCuota = ""
                };
                DataTable dt1 = new DataTable();
                dt1 = k.GetLastCuota();

                DataTable dt = k.GetLastCuota();
                if (dt.Rows.Count > 0)
                {
                   lblnombrecliente = dt1.Rows[0][1].ToString() + " " + dt1.Rows[0][0].ToString();
                   lblplan = dt1.Rows[0][3].ToString();
                   lblmonto = dt1.Rows[0][4].ToString();
                   lblvencimiento = dt1.Rows[0][5].ToString();
                    GenerarPDF(lblnombrecliente, lblmonto, lblplan);
                    
            }
            }
            catch (Exception ex)
            {

                Label1.Text = ex.Message.ToString();
            }


        }

        protected void btnvolver_Click(object sender, EventArgs e)
        {
            paneldatosdecobro.Visible = false;
            panelseleccioncliente.Visible = true;
            gridclientes.Dispose();
            gridclientes.DataBind();
        }

        public void GenerarPDF(string CLIENTE, string MONTO, string PLAN)
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
                    PdfPCell nextPostCell2 = new PdfPCell(new Phrase(CLIENTE, titleFont));
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
                itemTable.SetWidths(new float[] { 5, 50, 10 });  // then set the column's __relative__ widths
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
                    _phrase.Add(new Chunk(PLAN, EmailFont));
                    PdfPCell descCell = new PdfPCell(_phrase);
                    descCell.HorizontalAlignment = 0;
                    descCell.PaddingLeft = 10f;
                    descCell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                    itemTable.AddCell(descCell);

                    PdfPCell qtyCell = new PdfPCell(new Phrase(MONTO, bodyFont));
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
                lblerror.Text = ex.Message.ToString();
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
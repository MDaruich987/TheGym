using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SistemasIIITHEGYM.BussinesLayer;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.text.html;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;

namespace SistemasIIITHEGYM
{
    public partial class RegistrarOrdendeCompraGerente : System.Web.UI.Page
    {
        SqlConnection conex = new SqlConnection(ConfigurationManager.ConnectionStrings["MiConec"].ConnectionString.ToString());
        static string id;
        static DataTable data = new DataTable();

        static bool flag = true;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //aqui debemos verificar si la apertura de caja esta hecha o no, si no redireccionamos con estos
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#modal-redirect').modal('show');", true);
                // Response.AddHeader("REFRESH", "3;URL=AperturadeCajaEmpleado.aspx");
                //tbnombre.Enabled = false;
                //btnconsultar.Enabled =false;
                //si no, me manda a la pagina de apertura de caja a los 3 segundos



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
                panelseleccionarproveedor.Visible = true;
                panelregistrarorden.Visible = false;

                if (flag == true)
                {
                    data.Columns.Add("ID",typeof(int));
                    data.Columns.Add("Nombre", typeof(string));
                    data.Columns.Add("Cantidad", typeof(int));
                    data.Columns.Add("Precio", typeof(double));
                    flag = false;

                }

            }

        }

        


        protected void gridcliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelseleccionarproveedor.Visible = false;
            panelregistrarorden.Visible = true;

            lblFecha.Text = DateTime.Today.ToShortDateString();
            lblhora.Text = DateTime.Now.ToShortTimeString();

            lblproveedor.Text = gridcliente.SelectedRow.Cells[1].Text;
           

            id = gridcliente.SelectedRow.Cells[0].Text;

            TheGym k = new TheGym();
            DataTable dt2 = new DataTable();
            dt2 = k.GetLastOrden();
            if (dt2.Rows.Count > 0)
            {
                string aux = dt2.Rows[0][0].ToString();
                if(dt2.Rows[0][0].ToString() != "")
                {
                    lblnroOrden.Text = Convert.ToString(Convert.ToInt32(dt2.Rows[0][0].ToString()) + 1);
                }
                else
                {
                    lblnroOrden.Text = "1";
                }
            }
            else
            {
                lblerror.Text = "Error al encontrar ultima Orden de Compra";
                lblerror.Visible = true;
            }

            LblEmpleado.Text = (String)Session["inicio"];


        }

        protected void btnconsultar_Click(object sender, EventArgs e)
        {
            
            try
            {
                if(TextBox1.Text != string.Empty)
                {
                    TheGym k2 = new TheGym
                    {
                        NombreProveedorBusc = TextBox1.Text
                    };
                    DataTable dt2 = new DataTable();
                    dt2 = k2.GetProveedorNom();
                    if (dt2.Rows.Count > 0)
                    {
                        lblerror0.Text = string.Empty;
                        lblerror0.Visible = false;
                        gridcliente.DataSource = dt2;
                        gridcliente.DataBind();
                        gridcliente.Visible = true;
                    }
                    else
                    {
                        DataTable dt1 = new DataTable();
                        gridcliente.DataSource = dt1;
                        gridcliente.DataBind();
                        gridcliente.Visible = false;
                        lblerror0.Text = "No se encontro proveedor";
                        lblerror0.Visible = true;
                    }
                }
                else
                {
                    lblerror0.Text = "Ingrese un valor";
                    lblerror0.Visible = true;
                }
                
            }
            catch
            {
                lblerror0.Text = "Error general";
                lblerror0.Visible = true;
            }
        }

        protected void btnconsultar_Click1(object sender, EventArgs e)
        {
            tbcantidad.Enabled = false;
            try
            {
                TheGym k = new TheGym
                {
                    emailbusadm = (String)Session["Usuario"]
                };
                DataTable dt = new DataTable();
                //dt = k.GetSucEmailEmpleado();

                k.ProductName = tbnombre.Text;
                k.idproveedor = id;
                //k.NumeroSucursal = dt.Rows[0][0].ToString();
                

                DataTable dt2 = new DataTable();
                dt2 = k.GetProductPorProveedor();

                if (dt2.Rows.Count > 0)
                {
                    Label1.Visible = false;
                    gridproductos.DataSource = dt2;
                    gridproductos.DataBind();
                    gridproductos.Visible = true;
                }
                else
                {
                    Label1.Text = "No se encontro el producto";
                    Label1.Visible = true;
                    DataTable dt3 = new DataTable();
                    gridproductos.DataSource = dt3;
                    gridproductos.DataBind();
                    gridproductos.Visible = false;
                }


            }
            catch
            {
                Label1.Text = "Error General";
                Label1.Visible = false;
            }
            tbnombre.Text = string.Empty;
        }

        protected void btnregistrar_Click(object sender, EventArgs e)
        {
            double total = 0;
            double subtotal = 0;
            int cant = 0;
            double precio = 0;
            string idorden;

            for (int i = 0; i < griddetallefactura.Rows.Count; i++)
            {
                cant = Convert.ToInt32(data.Rows[i][2]);
                precio = Convert.ToDouble(data.Rows[i][3]);
                subtotal = cant * precio;
                total = total + subtotal;
            }

            if (griddetallefactura.Rows.Count > 0)
            {
                try
                {
                    if ((String)Session["Usuario"] != null)
                    {
                        lblerror2.Visible = false;
                        TheGym k = new TheGym
                        {
                            emailbusadm = (String)Session["Usuario"],
                        };

                        DataTable dt = new DataTable();
                        dt = k.GetIDemp();

                        if (dt.Rows.Count > 0)
                        {
                            k.fkempleadoorden = dt.Rows[0][0].ToString();
                            k.fkproveedororden = id;
                            k.fechaorden = lblFecha.Text;
                            k.horaorden = lblhora.Text;
                            k.totalorden = Convert.ToString(total);

                            DataTable dt1 = new DataTable();
                            dt1 = k.AddOrdenCompra();

                            idorden = dt1.Rows[0][0].ToString();

                            for (int i = 0; i < griddetallefactura.Rows.Count; i++)
                            {
                                k.fkorden = idorden;
                                k.fkproducto = data.Rows[i][0].ToString();
                                k.cantidadorden = data.Rows[i][2].ToString();
                                k.precioorden = data.Rows[i][3].ToString();

                                k.AddDetOrden();
                            }


                        }
                        else
                        {
                            lblerror2.Text = "Empleado no encontrado";
                            lblerror2.Visible = true;
                        }
                    }
                    else
                    {
                        TheGym k = new TheGym();
                        k.fkempleadoorden = "1";
                        k.fkproveedororden = id;
                        k.fechaorden = lblFecha.Text;
                        k.horaorden = lblhora.Text;
                        k.totalorden = Convert.ToString(total);

                        DataTable dt1 = new DataTable();
                        dt1 = k.AddOrdenCompra();

                        idorden = dt1.Rows[0][0].ToString();

                        for (int i = 0; i < griddetallefactura.Rows.Count; i++)
                        {
                            k.fkorden = idorden;
                            k.fkproducto = data.Rows[i][0].ToString();
                            k.cantidadorden = data.Rows[i][2].ToString();
                            k.precioorden = data.Rows[i][3].ToString();

                            k.AddDetOrden();
                        }

                    }

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#modal-default').modal('show');", true);

                    panelseleccionarproveedor.Visible = true;
                    panelregistrarorden.Visible = false;
                    DataTable dtaux = new DataTable();
                    gridcliente.DataSource = dtaux;
                    gridcliente.DataBind();
                    gridcliente.Dispose();
                    gridcliente.Visible = false;
                    griddetallefactura.DataSource = dtaux;
                    griddetallefactura.DataBind();
                    griddetallefactura.Dispose();
                    griddetallefactura.Visible = false;
                    gridproductos.DataSource = dtaux;
                    gridproductos.DataBind();
                    gridproductos.Dispose();
                    gridproductos.Visible = false;
                    tbcantidad.Text = string.Empty;
                    tbcantidad.Enabled = false;
                    tbnombre.Text = string.Empty;
                    LblEmpleado.Text = string.Empty;
                    lblnroOrden.Text = string.Empty;
                    lblhora.Text = string.Empty;
                    lblproveedor.Text = string.Empty;
                    lblFecha.Text = string.Empty;
                    TextBox1.Text = string.Empty;
                    lblerror.Text = string.Empty;
                    lblerror0.Text = string.Empty;
                    lblerror1.Text = string.Empty;
                    lblerror2.Text = string.Empty;
                    lblerror.Visible = false;
                    lblerror0.Visible = false;
                    lblerror1.Visible = false;
                    lblerror2.Visible = false;


                }
                catch (Exception ex)
                {
                    lblerror2.Visible = true;
                    lblerror2.Text = ex.Message.ToString();
                }

            }
            else
            {
                lblerror2.Text = "Seleccione productos con cantidad";
                lblerror2.Visible = true;
            }
        }

        protected void gridproductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string nom;
            //int id;
            //int cant;


            //nom = gridproductos.SelectedRow.Cells[1].Text;
            //id = Convert.ToInt32(gridproductos.SelectedRow.Cells[0].Text);
            //cant = Convert.ToInt32(tbcantidad.Text);

            tbcantidad.Enabled = true;
            btnañadir.Enabled = true;
        }

        protected void btnañadir_Click(object sender, EventArgs e)
        {
            string nom;
            int id;
            int cant;
            double precio;
            bool bandera = true;

            id = Convert.ToInt32(gridproductos.SelectedRow.Cells[0].Text);

            for (int i = 0; i < griddetallefactura.Rows.Count; i++)
            {
                if(id == Convert.ToInt32(data.Rows[i][0].ToString()))
                {
                    bandera = false;
                }
            }


            if (bandera == true)
            {
                if (tbcantidad.Text != "" && Convert.ToInt32(tbcantidad.Text) > 0)
                {
                    lblerror1.Visible = false;
                    nom = gridproductos.SelectedRow.Cells[1].Text;
                    id = Convert.ToInt32(gridproductos.SelectedRow.Cells[0].Text);
                    cant = Convert.ToInt32(tbcantidad.Text);
                    precio = Convert.ToDouble(gridproductos.SelectedRow.Cells[2].Text);

                    DataRow linea;
                    linea = data.NewRow();
                    linea["ID"] = id;
                    linea["Nombre"] = nom;
                    linea["Cantidad"] = Convert.ToInt32(cant);
                    linea["Precio"] = precio;
                    data.Rows.Add(linea);

                    if (data.Rows.Count > 0)
                    {
                        lblerror1.Visible = false;
                        griddetallefactura.DataSource = data;
                        griddetallefactura.DataBind();
                        griddetallefactura.Visible = true;
                        lblDetCompra.Visible = true;
                    }
                    else
                    {
                        lblerror1.Text = "Ingrese productos";
                        lblerror1.Visible = true;
                    }

                }
                else
                {
                    lblerror1.Text = "Ingrese una cantidad valida";
                    lblerror1.Visible = true;
                }
            }
            else
            {
                lblerror1.Text = "Producto ya agregado";
                lblerror1.Visible = true;
            }
            tbcantidad.Text = string.Empty;
            
        }

        protected void griddetallefactura_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void griddetallefactura_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            data.Rows.RemoveAt(e.RowIndex);
            griddetallefactura.DataSource = data;
            griddetallefactura.DataBind();
        }

        protected void btncancelar_Click(object sender, EventArgs e)
        {
           
            
            DataTable dt = new DataTable();
            gridcliente.DataSource = dt;
            gridcliente.DataBind();
            //gridcliente.Dispose();
            gridcliente.Visible = false;
            griddetallefactura.DataSource = dt;
            griddetallefactura.DataBind();
            //griddetallefactura.Dispose();
            griddetallefactura.Visible = false;
            gridproductos.DataSource = dt;
            gridproductos.DataBind();
            //gridproductos.Dispose();
            gridproductos.Visible = false;
            tbcantidad.Text = string.Empty;
            tbcantidad.Enabled = false;
            tbnombre.Text = string.Empty;
            LblEmpleado.Text = string.Empty;
            lblnroOrden.Text = string.Empty;
            lblhora.Text = string.Empty;
            lblproveedor.Text = string.Empty;
            lblFecha.Text = string.Empty;
            TextBox1.Text = string.Empty;
            lblerror.Text = string.Empty;
            lblerror0.Text = string.Empty;
            lblerror1.Text = string.Empty;
            lblerror2.Text = string.Empty;
            lblerror.Visible = false;
            lblerror0.Visible = false;
            lblerror1.Visible = false;
            lblerror2.Visible = false;

            panelregistrarorden.Visible = false;
            panelseleccionarproveedor.Visible = true;
        }

        public void GenerarPDF(DataTable dt, string fecha, string hora, string total, string proveedor, string direccion, string Email)
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
                    PdfPCell nextPostCell1 = new PdfPCell(new Phrase("PARA:", bodyFont));
                    nextPostCell1.Border = Rectangle.NO_BORDER;
                    nested.AddCell(nextPostCell1);
                    PdfPCell nextPostCell2 = new PdfPCell(new Phrase(proveedor, titleFont));
                    nextPostCell2.Border = Rectangle.NO_BORDER;
                    nested.AddCell(nextPostCell2);
                    PdfPCell nextPostCell3 = new PdfPCell(new Phrase(direccion, bodyFont));
                    nextPostCell3.Border = Rectangle.NO_BORDER;
                    nested.AddCell(nextPostCell3);
                    PdfPCell nextPostCell4 = new PdfPCell(new Phrase(Email, EmailFont));
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
                    PdfPCell nextPostCell2 = new PdfPCell(new Phrase("Fecha: " + DateTime.Now.ToShortDateString(), bodyFont));
                    nextPostCell2.Border = Rectangle.NO_BORDER;
                    nested.AddCell(nextPostCell2);
                    PdfPCell nextPostCell3 = new PdfPCell(new Phrase("Fecha Emisión: " + fecha, bodyFont));
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
                PdfPTable itemTable = new PdfPTable(2);

                itemTable.HorizontalAlignment = 0;
                itemTable.WidthPercentage = 100;
                itemTable.SetWidths(new float[] { 40, 10 });  // then set the column's __relative__ widths
                itemTable.SpacingAfter = 40;
                itemTable.DefaultCell.Border = Rectangle.BOX;
                PdfPCell cell1 = new PdfPCell(new Phrase("Producto", boldTableFont));
                cell1.BackgroundColor = TabelHeaderBackGroundColor;
                cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                itemTable.AddCell(cell1);
                PdfPCell cell2 = new PdfPCell(new Phrase("Cantidad", boldTableFont));
                cell2.BackgroundColor = TabelHeaderBackGroundColor;
                cell2.HorizontalAlignment = 1;
                itemTable.AddCell(cell2);
                foreach (DataRow row in dt.Rows)
                {
                    //instanciamos variables para los elementos del datatable
                    string productonombre = row[0].ToString();
                    string cantidadproducto = row[1].ToString();
                    //insertamos en la tabla el nombre
                    PdfPCell numberCell = new PdfPCell(new Phrase(productonombre, bodyFont));
                    numberCell.HorizontalAlignment = 1;
                    numberCell.PaddingLeft = 10f;
                    numberCell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                    itemTable.AddCell(numberCell);
                    //insertamos en la tabla la cantidad
                    var _phrase = new Phrase();
                    _phrase.Add(new Chunk(cantidadproducto, EmailFont));
                    PdfPCell descCell = new PdfPCell(_phrase);
                    descCell.HorizontalAlignment = 0;
                    descCell.PaddingLeft = 10f;
                    descCell.Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER;
                    itemTable.AddCell(descCell);

                }
                //pie de tabla
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
                //PdfPCell totalAmtCell = new PdfPCell(new Phrase("TOTAL", boldTableFont));
                //totalAmtCell.HorizontalAlignment = 1;
                //itemTable.AddCell(totalAmtCell);

                PdfPCell cell = new PdfPCell(new Phrase("***NOTA: Se acepta hasta un cargo del 0.5% en el periodo de 30 days. ***", bodyFont));
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
                cb.ShowText("Esta factura es válida como comprobante de solicitud de reposición");
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

        protected void btnPDF_Click(object sender, EventArgs e)
        {
            try { 
            // abrimos la conexion
            conex.Open();
            //creamos un comando sql, le pasamos la consulta a enviar a la base de datos y la conexion
            SqlCommand com = new SqlCommand("select oc.Fecha, oc.Hora,oc.Total, p.Nombre, p.Calle+' '+CONVERT(varchar(10), p.Numero) as 'Direccion', p.Email, oc.Id_orden   from OrdenCompra oc inner join Empleado e on oc.FK_empleado=e.Id_Empleado  inner join Proveedor p on oc.FK_proveedor = Id_proveedor where oc.Id_orden = (Select MAX(Id_orden) from OrdenCompra)", conex);
            //con el @ parametrizamos nuestros elementos, y ahora le agregamos el valor
           // com.Parameters.AddWithValue("@nick", usuario);
            //primero pasamos el nombre del parametro y luego valor que tendra
           // com.Parameters.AddWithValue("@con", contraseña);
            //creamos un objetosql data adapter y le pasamos nuestro comando sql
            SqlDataAdapter dap = new SqlDataAdapter(com);
            //creamos un data table 
            DataTable dat = new DataTable();
            //para llenarlo con los datos de la tabla desde el data adapter
            dap.Fill(dat);
            //lblusuario.Text = dat.Rows[0][0].ToString()+ dat.Rows[0][1].ToString()+ dat.Rows[0][2].ToString();
            //evaluamos si la consulta nos devuelve filas quiere decir que si hay un elemento que coincida
            if (dat.Rows.Count == 1)
            {
                string fecha = dat.Rows[0][0].ToString();
                string hora= dat.Rows[0][1].ToString();
                string total= dat.Rows[0][2].ToString();
                string proveedor= dat.Rows[0][3].ToString();
                string direccion= dat.Rows[0][4].ToString();
                string email= dat.Rows[0][5].ToString();
                string idorden= dat.Rows[0][6].ToString();

                SqlCommand com2 = new SqlCommand("select p.Nombre, do.Cantidad from DetalleOrden do inner join Producto p on do.FK_producto=p.Id_producto where FK_orden = @IdOrden", conex);
                //con el @ parametrizamos nuestros elementos, y ahora le agregamos el valor
                com.Parameters.AddWithValue("@IdOrden", idorden);
                //primero pasamos el nombre del parametro y luego valor que tendra
                // com.Parameters.AddWithValue("@con", contraseña);
                //creamos un objetosql data adapter y le pasamos nuestro comando sql
                SqlDataAdapter dap2 = new SqlDataAdapter(com2);
                //creamos un data table 
                DataTable dat2 = new DataTable();
                //para llenarlo con los datos de la tabla desde el data adapter
                dap.Fill(dat2);
                if (dat2.Rows.Count >= 1)
                {
                    GenerarPDF(dat2, fecha,hora,total,proveedor,direccion,email);
                }
                else
                {
                    lblerror.Text = "No se encontraron filas";
                }
            }
            else
            {
                lblerror.Text = "Error al recuperar Orden";
            }

            }
            catch(Exception ex)
            {
                lblerror.Text = ex.Message.ToString();
            }

        }
    }
}
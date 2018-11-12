using iTextSharp.text;
using iTextSharp.text.html;
using iTextSharp.text.pdf;
using SistemasIIITHEGYM.BussinesLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemasIIITHEGYM
{
   
    public partial class RegistrarOrdenCompraGerente : System.Web.UI.Page
    {
        SqlConnection conex = new SqlConnection(ConfigurationManager.ConnectionStrings["MiConec"].ConnectionString.ToString());
        static string id;
        static string nom;
        static bool flag = false;
        static DataTable Tabla = new DataTable();
        static DataColumn Column;

        //para saber si se ha asignado el nombre del proveedor al label
        // static bool flagproveedor = true;
        protected void Page_Load(object sender, EventArgs e)
        {

           generarPDFssss.Enabled = false;
            //el panel no se debe habilitar hasta que seleccionemos un proveedor
            //updetalleorden.Visible = false;
            if (!IsPostBack)
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

                generarPDF.Visible = false;
                Column = new DataColumn();
                Column.DataType = System.Type.GetType("System.Int32");
                try
                {
                    Column.ColumnName = "Id_producto";
                    Tabla.Columns.Add(Column);
                    Column = new DataColumn();
                    Column.DataType = System.Type.GetType("System.String");
                    Column.ColumnName = "Nombre";
                    Tabla.Columns.Add(Column);
                    Column = new DataColumn();
                    Column.DataType = System.Type.GetType("System.Int32");
                    Column.ColumnName = "Cantidad";
                    Tabla.Columns.Add(Column);
                    Column = new DataColumn();
                    Column.DataType = System.Type.GetType("System.Double");
                    Column.ColumnName = "Precio";
                    Tabla.Columns.Add(Column);
                    Column = new DataColumn();
                    Column.DataType = System.Type.GetType("System.Double");
                    Column.ColumnName = "SubTotal";
                    Tabla.Columns.Add(Column);
                }
                catch (Exception)
                {

                    
                }               
                

                lblFecha.Text = DateTime.Today.ToShortDateString();
                lblhora.Text = DateTime.Now.ToShortTimeString();
                lblempleado.Text = (String)Session["usuario"];
            }

            if (flag == true)
            {
                tbproveedor.Text = nom;

            }

        }

        protected void btnselecproveedor_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#modal-proveedor').modal('show');", true);
            flag = true;
        }

        protected void tbproveedor_TextChanged(object sender, EventArgs e)
        {
            //habilitamos el panel de detalle recien al seleccionar un proveedor
            //updetalleorden.Visible = true;
        }

        protected void btnañadirproducto_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#modal-añadirproducto').modal('show');", true);
        }

        protected void botonconsultarproductos_Click(object sender, EventArgs e)
        {
            //este es el boton consultar del modal de productos
            if (tbnombreproductos.Text != "" || id != null)
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

                    k.ProductName = tbnombreproductos.Text;
                    k.idproveedor = id;
                    //k.NumeroSucursal = dt.Rows[0][0].ToString();


                    DataTable dt2 = new DataTable();
                    dt2 = k.GetProductPorProveedor();

                    if (dt2.Rows.Count > 0)
                    {
                        Label1.Visible = false;
                        gvproductos.DataSource = dt2;
                        gvproductos.DataBind();
                        gvproductos.Visible = true;
                    }
                    else
                    {
                        Label1.Text = "No se encontro el producto";
                        Label1.Visible = true;
                        DataTable dt3 = new DataTable();
                        gvproductos.DataSource = dt3;
                        gvproductos.DataBind();
                        gvproductos.Visible = false;
                    }


                }
                catch
                {
                    Label1.Text = "Error General";
                    Label1.Visible = false;
                }
                tbnombreproductos.Text = string.Empty;
            }
            else
            {
                lblerrorproductosmodal.Text = "Ingrese un producto";
            }
        }

        protected void btnañadirproductomodal_Click(object sender, EventArgs e)
        {
            if (tbcantidad.Text != "" && Convert.ToInt32(tbcantidad.Text) > 0)
            {
                Lblerror1.Visible = false;
                DataRow fila = Tabla.NewRow();
                fila[0] = Convert.ToInt32(gvproductos.SelectedRow.Cells[0].Text);
                fila[1] = gvproductos.SelectedRow.Cells[1].Text;
                fila[2] = tbcantidad.Text;
                fila[3] = Convert.ToDouble(gvproductos.SelectedRow.Cells[2].Text);
                fila[4] = Convert.ToDouble(gvproductos.SelectedRow.Cells[2].Text) * Convert.ToInt32(tbcantidad.Text);
                try
                {
                    Tabla.Rows.Add(fila);
                    griddetallefactura.DataSource = Tabla;
                    griddetallefactura.DataBind();
                    griddetallefactura.Visible = true;
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#modal-añadirproducto').modal('hide');", true);
                    gvproductos.Visible = false;
                    tbcantidad.Text = "";
                    tbcantidad.Enabled = false;
                    btnañadirproductomodal.Enabled = false;
                    tbnombreproductos.Text = string.Empty;
                }
                catch (Exception ex)
                {
                    Lblerror1.Text = "ingrese una cantidad valida";
                    Lblerror1.Visible = true;
                }
            }
            else
            {
                Lblerror1.Text = "Ingrese una cantidad";
                Lblerror1.Visible = true;
            }
        }

        protected void btnconsultarproveedorgrid_Click(object sender, EventArgs e)
        {
            //este es el boton consultar proveedor del modal de proveedores
            try
            {
                if (tbnombreproveedor.Text != string.Empty)
                {
                    TheGym k2 = new TheGym
                    {
                        NombreProveedorBusc = tbnombreproveedor.Text
                    };
                    DataTable dt2 = new DataTable();
                    dt2 = k2.GetProveedorNom();
                    if (dt2.Rows.Count > 0)
                    {
                        lblerrorbuscarmodalproveedor.Text = string.Empty;
                        lblerrorbuscarmodalproveedor.Visible = false;
                        gvproveedoresmodal.DataSource = dt2;
                        gvproveedoresmodal.DataBind();
                        gvproveedoresmodal.Visible = true;
                        lblerrorbuscarmodalproveedor.Visible = true;
                    }
                    else
                    {
                        DataTable dt1 = new DataTable();
                        gvproveedoresmodal.DataSource = dt1;
                        gvproveedoresmodal.DataBind();
                        gvproveedoresmodal.Visible = false;
                        lblerrorbuscarmodalproveedor.Text = "No se encontro proveedor";
                        lblerrorbuscarmodalproveedor.Visible = true;
                    }
                }
                else
                {
                    lblerrorbuscarmodalproveedor.Text = "Ingrese un valor";
                    lblerrorbuscarmodalproveedor.Visible = true;
                }

            }
            catch
            {
                lblerrorbuscarmodalproveedor.Text = "Error general";
                lblerrorbuscarmodalproveedor.Visible = true;
            }
        }

        protected void gvproveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            nom = gvproveedoresmodal.SelectedRow.Cells[1].Text;
            //tbproveedor.Text = gvproveedoresmodal.SelectedRow.Cells[1].Text;
            id = gvproveedoresmodal.SelectedRow.Cells[0].Text;

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#modal-proveedor').modal('hide');", true);
            flag = true;
            //tbproveedor.Text = nom;
            //Page_Load(sender,e);
            CargarProv();

            //ScriptManager.RegisterStartupScript(this, typeof(Page), "jsKeys", "javascript:Forzar();", true);

        }

        protected void CargarProv()
        {
            tbproveedor.Text = nom;

        }

        protected void griddetallefactura_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Tabla.Rows.RemoveAt(e.RowIndex);
            griddetallefactura.DataSource = Tabla;
            griddetallefactura.DataBind();
        }

        protected void gvproductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbcantidad.Enabled = true;
            btnañadirproductomodal.Enabled = true;
        }

        protected void griddetallefactura_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnregistrar_Click(object sender, EventArgs e)
        {
            
            if (griddetallefactura.Columns.Count > 0)
                {
                    Label1.Visible = false;
                    double total = 0;
                    double subtotal = 0;
                    string idorden;

                    for (int i = 0; i < griddetallefactura.Rows.Count; i++)
                    {
                        subtotal = Convert.ToDouble(Tabla.Rows[i][4]);
                        total = total + subtotal;
                    }
                    if (griddetallefactura.Rows.Count > 0)
                    {
                        try
                        {
                            if ((String)Session["Usuario"] != null)
                            {
                                Label1.Visible = false;
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
                                        k.fkproducto = Tabla.Rows[i][0].ToString();
                                        k.cantidadorden = Tabla.Rows[i][2].ToString();
                                        k.precioorden = Tabla.Rows[i][3].ToString();

                                        k.AddDetOrden();
                                    ///////
                                    }


                                }
                                else
                                {
                                    Label1.Text = "Empleado no encontrado";
                                    Label1.Visible = true;
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
                                    k.fkproducto = Tabla.Rows[i][0].ToString();
                                    k.cantidadorden = Tabla.Rows[i][2].ToString();
                                    k.precioorden = Tabla.Rows[i][3].ToString();

                                    k.AddDetOrden();
                                }
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#modal-compraregistrada').modal('show');", true);
                            btnregistrar.Visible = false;
                            btncancelar.Visible = false;

                        }

                            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#modal-default').modal('show');", true);

                            //btnPDF.Visible = true;
                            //btnPDF.Enabled = true;

                            //panelseleccionarproveedor.Visible = true;
                            //panelregistrarorden.Visible = false;
                            DataTable dtaux = new DataTable();
                            griddetallefactura.DataSource = dtaux;
                            griddetallefactura.DataBind();
                            griddetallefactura.Dispose();
                            griddetallefactura.Visible = false;
                            griddetallefactura.DataSource = dtaux;
                            griddetallefactura.DataBind();
                            griddetallefactura.Dispose();
                            griddetallefactura.Visible = false;
                            gvproductos.DataSource = dtaux;
                            gvproductos.DataBind();
                            gvproductos.Dispose();
                            gvproductos.Visible = false;
                            tbcantidad.Text = string.Empty;
                            tbcantidad.Enabled = false;
                            tbcantidad.Text = string.Empty;
                            lblempleado.Text = string.Empty;
                            lblhora.Text = string.Empty;
                            tbproveedor.Text = string.Empty;
                            lblFecha.Text = string.Empty;
                            tbnombreproveedor.Text = string.Empty;
                            lblerror.Text = string.Empty;
                            tbnombreproductos.Text = string.Empty;
                            lblerror.Text = string.Empty;
                            Lblerror1.Text = string.Empty;
                            lblerror.Visible = false;
                            lblerror.Visible = false;
                            Lblerror1.Visible = false;
                        btnregistrar.Enabled = false;
                        btncancelar.Enabled = false;
                        generarPDF.Visible = true;

                    }
                        catch (Exception ex)
                        {
                            Label1.Visible = true;
                            Label1.Text = ex.Message.ToString();
                        }
                    }

                    else
                    {
                        Label1.Text = "Agregar productos a la Orden";
                        Label1.Visible = true;
                    }
                }
            
            
        }

        protected void btncancelar_Click(object sender, EventArgs e)
        {
            //limpiar todos los campos y grid
            griddetallefactura.DataBind();
            griddetallefactura.Dispose();
            griddetallefactura.Visible = false;
            gvproductos.DataBind();
            gvproductos.Dispose();
            gvproductos.Visible = false;
            tbcantidad.Text = string.Empty;
            tbcantidad.Enabled = false;
            tbcantidad.Text = string.Empty;
            tbnombreproductos.Text = string.Empty;
            tbproveedor.Text = string.Empty;
            lblhora.Text = string.Empty;
            lblempleado.Text = string.Empty;
            lblFecha.Text = string.Empty;
            Lblerror1.Text = string.Empty;
            lblerror.Text = string.Empty;
        }

        public void GenerarPDF(DataTable dt, string fecha, string hora, string total, string proveedor)
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
                    string productonombre = row[1].ToString();
                    string cantidadproducto = row[0].ToString();
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
                lblerrorPDF.Text = ex.Message.ToString();
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

                lblerrorPDF.Text=ex.Message.ToString();
            }
            
        }
        #endregion

        protected void generarPDF_Click(object sender, EventArgs e)
        {
            GenerarPDF(Tabla, lblFecha.Text, lblhora.Text, "", tbproveedor.Text);
        }

        protected void btnuevaorden_Click(object sender, EventArgs e)
        {
            //btnregistrar.Visible = true;
            //btncancelar.Visible = true;
            ////limpiar campos
            //generarPDF.Visible = false;
            //btnuevaorden.Visible = false;
        }

        protected void btnenvioemail_Click(object sender, EventArgs e)
        {
            try
            {
                conex.Open();
                //creamos un comando sql, le pasamos la consulta a enviar a la base de datos y la conexion
                SqlCommand com = new SqlCommand("select Monto from DetalleCaja where Convert(varchar(10),Fecha,103)=@prov", conex);
                //con el @ parametrizamos nuestros elementos, y ahora le agregamos el valor
                com.Parameters.AddWithValue("@prov", nom);
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
                    //Specify senders gmail address
                    string SendersAddress = "thegyminfo@gmail.com";
                    //Specify The Address You want to sent Email To(can be any valid email address)
                    string ReceiversAddress = dat.Rows[0][0].ToString();
                    //Specify The password of gmial account u are using to sent mail(pw of sender@gmail.com)
                    const string SendersPassword = "thegymsistema2018";
                    //Write the subject of ur mail.el asunto
                    const string subject = "THE GYM";
                    //Write the contents of your mail. En la pantalla yo copie lo mismo que el codigo para que sepan que se va a enviar pero solo se puede cambiar desde aca abajo
                    const string body = "Te estamos esperando. Presentando este mail obtene un 20% de descuento.";

                    try
                    {
                        //we will use Smtp client which allows us to send email using SMTP Protocol
                        //i have specified the properties of SmtpClient smtp within{}
                        //gmails smtp server name is smtp.gmail.com and port number is 587
                        SmtpClient smtp = new SmtpClient
                        {
                            Host = "smtp.gmail.com",
                            Port = 587,
                            EnableSsl = true,
                            DeliveryMethod = SmtpDeliveryMethod.Network,
                            Credentials = new NetworkCredential(SendersAddress, SendersPassword),
                            Timeout = 10000
                        };

                        //MailMessage represents a mail message
                        //it is 4 parameters(From,TO,subject,body)

                        MailMessage message = new MailMessage(SendersAddress, ReceiversAddress, subject, body);
                        /*WE use smtp sever we specified above to send the message(MailMessage message)*/

                        smtp.Send(message);
                        lblerrorPDF.Text = ("Envío exitoso!");

                    }

                    catch (Exception ex)
                    {
                        lblerrorPDF.Text = ex.Message.ToString();
                    }
                }
            }
            catch (Exception ex)
            {

                lblerrorPDF.Text=ex.Message.ToString();
            }
             
            
        }
    }
}
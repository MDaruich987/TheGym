﻿using iTextSharp.text;
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

                        this.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert ('El cobro se ha registrado exitosamente');</script>");
                        Label1.Text = "El pago se ha registrado exitosamente!";
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

                    //si se asignan las variables creamos el documento
                    //creamos el documento y establecemos el tamaño de pagina y demas formatos
                    Document doc = new Document(iTextSharp.text.PageSize.B6, 10, 10, 42, 35);
                    //obtenemos la fecha actual para guardar el pdf con ella
                    string fecha_actual = DateTime.Now.ToString("dd-MM-yyyy");
                    //obtenemos el nombre del cliente para guardar el pdf con él         
                    string nombrearchivo = lblnombrecliente + fecha_actual;
                    //creamos un objeto escritor para escribir en el pdf
                    //PdfWriter writer = PdfWriter.GetInstance(doc,
                    //            new FileStream(@"C:\Users\Micaela Daruich\Documents\ProyectoGym\SistemasIIITHEGYM\PDFs\prueba.pdf", FileMode.Create));
                    //Cadena Maxi
                    PdfWriter writer = PdfWriter.GetInstance(doc,
                                new FileStream(@"C:\Users\maxi_\Source\Repos\TheGym4\SistemasIIITHEGYM\PDFs\prueba.pdf", FileMode.Create));
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
                    //iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(@"C:\Users\Micaela Daruich\Documents\ProyectoGym\SistemasIIITHEGYM\ImagenesSistema\logoGym.JPG");
                    //Cadena Maxi
                    iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(@"C:\Users\maxi_\Source\Repos\TheGym4\SistemasIIITHEGYM\ImagenesSistema\logoGym.JPG");
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
                    clFecha = new PdfPCell(new Phrase(nombre, _standardFont));
                    clFecha.BorderWidth = 0;

                    clCliente = new PdfPCell(new Phrase(lblnombrecliente, _standardFont));
                    clCliente.BorderWidth = 0;

                    clMonto = new PdfPCell(new Phrase(lblmonto, _standardFont));
                    clMonto.BorderWidth = 0;

                    clPlan = new PdfPCell(new Phrase(lblplan, _standardFont));
                    clPlan.BorderWidth = 0;

                    clVencimiento = new PdfPCell(new Phrase(lblvencimiento, _standardFont));
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
                    Label1.Text = "Comprobante generado exitosamente";
                }
                else
                {
                    Label1.Text = "No se encontraron coincidencias";
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
    }
}
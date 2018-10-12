using SistemasIIITHEGYM.BussinesLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Reflection;

namespace SistemasIIITHEGYM
{
    public partial class RegistrarFacturaEmpleado : System.Web.UI.Page
    {
        //para el carrito de compras
        static DataTable Tabla = new DataTable();
        static DataTable TablaID = new DataTable();
        static int tam = 0;
        DataRow Row;
        DataColumn Column;
        //variables para añadir el producto
        string idprod;
        string nomprod;
        string preuniprod;
        string cantprod;
        string subtotalprod;
        //para guardar el id del cliente
        static string IDcliente;
        //para el id del empleado 
        static string IDEmpl;
        static string Usuario;
        //para la conexion de las consultas
        SqlConnection conex = new SqlConnection(ConfigurationManager.ConnectionStrings["MiConec"].ConnectionString.ToString());
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                GetAllMedioPago();
                //consultar si ya se realizó la apertura de caja
                //abrimos la conexion
                conex.Open();
                //creamos un comando sql, le pasamos la consulta a enviar a la base de datos y la conexion
                SqlCommand com = new SqlCommand("select Monto from DetalleCaja where Convert(varchar(10),Fecha,103)=@Fecha", conex);
                //con el @ parametrizamos nuestros elementos, y ahora le agregamos el valor
                com.Parameters.AddWithValue("@Fecha", DateTime.Now.ToShortDateString());
                //creamos un objetosql data adapter y le pasamos nuestro comando sql
                SqlDataAdapter dap = new SqlDataAdapter(com);
                //creamos un data table 
                DataTable dat = new DataTable();
                //para llenarlo con los datos de la tabla desde el data adapter
                dap.Fill(dat);
                //lblusuario.Text = dat.Rows[0][0].ToString()+ dat.Rows[0][1].ToString()+ dat.Rows[0][2].ToString();
                //evaluamos si la consulta nos devuelve filas quiere decir que si hay un elemento que coincida
                if (dat.Rows.Count==0){
                   // ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#modal-redirect').modal('show');", true);
                   // Response.AddHeader("REFRESH", "3;URL=AperturadeCajaEmpleado.aspx");
                    //tbnombre.Enabled = false;
                    //btnconsultar.Enabled =false;
                    //si no, me manda a la pagina de apertura de caja a los 3 segundos
                    }
                else
                {
                    //si la apertura esta registrada, habilitamos la busqueda
                    tbnombre.Enabled = true;
                    btnconsultar.Enabled = true;
                }
                    if (Session["inicio"] != null)
                {
                    //declaramos una variale sesion para mantener el dato del usuario
                    Usuario = (string)Session["Usuario"];
                    //buscamos el id del empleado

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
                    Usuario = "";
                }

                //obtenemos el id del empleado
                SqlCommand com3 = new SqlCommand("select Id_empleado from Empleado e inner join Usuario u on  e.Id_empleado=u.FK_empleado where u.Usuario=@Correo", conex);
                //con el @ parametrizamos nuestros elementos, y ahora le agregamos el valor
                com.Parameters.AddWithValue("@Correo", Usuario);
                //creamos un objetosql data adapter y le pasamos nuestro comando sql
                SqlDataAdapter dap3 = new SqlDataAdapter(com3);
                //creamos un data table 
                DataTable dat3 = new DataTable();
                //para llenarlo con los datos de la tabla desde el data adapter
                dap.Fill(dat3);
                //lblusuario.Text = dat.Rows[0][0].ToString()+ dat.Rows[0][1].ToString()+ dat.Rows[0][2].ToString();
                //evaluamos si la consulta nos devuelve filas quiere decir que si hay un elemento que coincida
                if (dat3.Rows.Count> 0)
                {
                    IDEmpl = dat.Rows[0][0].ToString();
                }
                else
                {
                    IDEmpl = "";
                }
                panelseleccionarcliente.Visible = true;
                panelregistrarfactura.Visible = false;
                conex.Close();
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
            TheGym k = new TheGym();
            k.NombreClienteBusc = tbnombre.Text;
            DataTable dt = k.GetClienteNom();
            if (dt.Rows.Count > 0)
            {
                gridcliente.DataSource = dt;
                gridcliente.DataBind();
                gridcliente.Focus();
            }

        }

        protected void gridcliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //setear hora y fecha en los lbl
                lblFecha.Text = DateTime.Now.ToShortDateString();
                lblhora.Text = DateTime.Now.ToShortTimeString();
                IDcliente = gridcliente.SelectedRow.Cells[0].Text;
                lblcliente.Text = gridcliente.SelectedRow.Cells[2].Text + ", " + gridcliente.SelectedRow.Cells[1].Text;
                try
                {
                    //calculamos cual seria el nro de esta factura
                    SqlCommand com2 = new SqlCommand("select MAX(Id_factura)+1 from Factura", conex);
                    //creamos un objetosql data adapter y le pasamos nuestro comando sql
                    SqlDataAdapter dap2 = new SqlDataAdapter(com2);
                    //creamos un data table 
                    DataTable dat2 = new DataTable();
                    //para llenarlo con los datos de la tabla desde el data adapter
                    dap2.Fill(dat2);
                    //lblusuario.Text = dat.Rows[0][0].ToString()+ dat.Rows[0][1].ToString()+ dat.Rows[0][2].ToString();
                    //obtenemos el numero de factura
                    lblnrofactura.Text = dat2.Rows[0][0].ToString();
                    //mostramos el panel de registro y ocultamos el otro
                    panelregistrarfactura.Visible = true;
                    panelseleccionarcliente.Visible = false;
                    panelregistrarfactura.Focus();
                    //llenamos el gridview del carrito
                    if (tam == 0)
                    {
                        Column = new DataColumn();
                        Column.DataType = System.Type.GetType("System.Int32");
                        Column.ColumnName = "Id_producto";
                        TablaID.Columns.Add(Column);

                        Column = new DataColumn();
                        Column.DataType = System.Type.GetType("System.String");
                        Column.ColumnName = "Nombre Producto";
                        Tabla.Columns.Add(Column);

                        Column = new DataColumn();
                        Column.DataType = System.Type.GetType("System.Int32");
                        Column.ColumnName = "Precio por unidad";
                        Tabla.Columns.Add(Column);

                        Column = new DataColumn();
                        Column.DataType = System.Type.GetType("System.Int32");
                        Column.ColumnName = "Cantidad";
                        Tabla.Columns.Add(Column);

                        Column = new DataColumn();
                        Column.DataType = System.Type.GetType("System.Int32");
                        Column.ColumnName = "Subtotal";
                        Tabla.Columns.Add(Column);

                        tam = 1;
                    }
                }
                catch (Exception ex)
                {

                    lblerror0.Text = ex.Message.ToString()+"obtener numero de boleta";
                }
                
            }
            catch (Exception ex)
            {

                lblerror0.Text = ex.Message.ToString();
            }
           
        }

        protected void gridproductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            //habilitamos el tb de cantidad y el boton añadir
            tbcantidad.Enabled = true;
            btnañadir.Enabled = true;
        }

        protected void btnañadir_Click(object sender, EventArgs e)
        {
            if (tbcantidad.Text != "")
            {
                try
                {
                    idprod = gridproductos.SelectedRow.Cells[0].Text;
                    nomprod = gridproductos.SelectedRow.Cells[2].Text;
                    preuniprod = gridproductos.SelectedRow.Cells[3].Text;
                    cantprod = tbcantidad.Text;
                    subtotalprod = (Convert.ToInt32(cantprod) * Convert.ToInt32(preuniprod)).ToString();

                    Row = TablaID.NewRow();
                    Row["Id_producto"] = idprod;
                    TablaID.Rows.Add(Row);

                    Row = Tabla.NewRow();
                    Row["Nombre Producto"] = nomprod;
                    Row["Cantidad"] = cantprod;
                    Row["Subtotal"] = subtotalprod;
                    Tabla.Rows.Add(Row);

                    griddetallefactura.DataSource = Tabla;
                    griddetallefactura.DataBind();
                }
                catch (Exception ex)
                {

                    lblerror.Text = ex.Message.ToString();
                }
            }
            else
            {
                lblerror1.Text = "Debe ingresar una cantidad";
            }
        }

        protected void btnregistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if(lblcliente.Text== "N/N")
                {
                    //ingreso la factura sin el FKcliente
                    DataTable aux1 = new DataTable();

                    TheGym k = new TheGym
                    {
                        FechaFac = lblFecha.Text,
                        HoraFac = lblhora.Text,
                        TotalFac = tbmonto.Text,
                        FKempleadoFac = IDEmpl
                    };

                    k.AddFacturaSinC();
                    /////////////////////////////////////////////////////////////////////////
                    //ahora debo ingresar el detalle de la factura
                    aux1 = k.GetLastPlan();

                    DataRow fila = aux1.Rows[0];

                    idplan = fila[0].ToString();

                    int aux = Tabla.Rows.Count;

                    for (int i = aux; i > 0; i--)
                    {
                        k.FK_plan = idplan;

                        fila = TablaID.Rows[i - 1];

                        k.FK_actividad = fila[0].ToString();

                        fila = Tabla.Rows[i - 1];
                        k.Dias_semanas = fila["Dias por Semana"].ToString();

                        k.AddDetallePlan();

                        Tabla.Rows.RemoveAt(i - 1);
                        TablaID.Rows.RemoveAt(i - 1);

                    }

                    tbnombre.Text = string.Empty;
                    //tbprecio.Text = string.Empty;

                    griddetallefactura.Dispose();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#modal-default').modal('show');", true);
                    griddetallefactura.Dispose();
                    griddetallefactura.DataBind();
                }
                else
                {
                    //ingreso la factura con el FKcliente
                }
                
            }
            catch (Exception ex)
            {

                lblerror.Text = ex.Message.ToString();
            }
        }

        protected void btnnocliente_Click(object sender, EventArgs e)
        {
            //setear hora y fecha en los lbl
            lblFecha.Text = DateTime.Now.ToShortDateString();
            lblhora.Text = DateTime.Now.ToShortTimeString();
            IDcliente = "0";
            lblcliente.Text = "N/N";
            try
            {
                //calculamos cual seria el nro de esta factura
                SqlCommand com2 = new SqlCommand("select MAX(Id_factura)+1 from Factura", conex);
                //creamos un objetosql data adapter y le pasamos nuestro comando sql
                SqlDataAdapter dap2 = new SqlDataAdapter(com2);
                //creamos un data table 
                DataTable dat2 = new DataTable();
                //para llenarlo con los datos de la tabla desde el data adapter
                dap2.Fill(dat2);
                //lblusuario.Text = dat.Rows[0][0].ToString()+ dat.Rows[0][1].ToString()+ dat.Rows[0][2].ToString();
                //obtenemos el numero de factura
                lblnrofactura.Text = dat2.Rows[0][0].ToString();
                //mostramos el panel de registro y ocultamos el otro
                panelregistrarfactura.Visible = true;
                panelseleccionarcliente.Visible = false;
                panelregistrarfactura.Focus();
                //llenamos el gridview del carrito
                if (tam == 0)
                {
                    Column = new DataColumn();
                    Column.DataType = System.Type.GetType("System.Int32");
                    Column.ColumnName = "Id_producto";
                    TablaID.Columns.Add(Column);

                    Column = new DataColumn();
                    Column.DataType = System.Type.GetType("System.String");
                    Column.ColumnName = "Nombre Producto";
                    Tabla.Columns.Add(Column);

                    Column = new DataColumn();
                    Column.DataType = System.Type.GetType("System.Int32");
                    Column.ColumnName = "Precio por unidad";
                    Tabla.Columns.Add(Column);

                    Column = new DataColumn();
                    Column.DataType = System.Type.GetType("System.Int32");
                    Column.ColumnName = "Cantidad";
                    Tabla.Columns.Add(Column);

                    Column = new DataColumn();
                    Column.DataType = System.Type.GetType("System.Int32");
                    Column.ColumnName = "Subtotal";
                    Tabla.Columns.Add(Column);

                    tam = 1;
                }
            }
            catch (Exception ex)
            {

                lblerror.Text = ex.Message.ToString();
            }
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

        protected void btnconsultar_Click1(object sender, EventArgs e)
        {
            try
            {
                lblerror1.Text = "";
                if (tbnombre.Text != "")
                {
                    TheGym k = new TheGym
                    {
                        NomProd = tbnombre.Text
                    };

                    DataTable dt = k.GetBusquedaProductos();
                    if (dt.Rows.Count > 0)
                    {
                        gridproductos.DataSource = dt;
                        gridproductos.DataBind();
                    }
                    else
                    {
                        lblerror.Text = "No se encontraron coincidencias";
                    }
                }
                else
                {
                    Label1.Text = "Inserte un criterio de busqueda";
                }
            }
            catch (Exception ex)
            {

                Label1.Text=ex.Message.ToString();
            }
            
        }
    }

}
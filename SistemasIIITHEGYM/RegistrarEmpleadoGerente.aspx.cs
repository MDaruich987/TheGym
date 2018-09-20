using SistemasIIITHEGYM.BussinesLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace SistemasIIITHEGYM
{
    public partial class RegistrarEmpleadoGerente : System.Web.UI.Page
    {

        static string extention;

        protected void Page_Load(object sender, EventArgs e)
        {
           lblerror.Text = ("");

            if (!IsPostBack)
            {
                GetCargos();
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

            CargarLocalidades();
            CargarTipoDocumento();
            CargarSucursales();

        }

        public void CargarLocalidades()
        {
            TheGym k = new TheGym();
            DataTable dt = new DataTable();
            dt = k.GetAllLocalidades();
            if (dt.Rows.Count > 0)
            {
                ddllocalidad.DataTextField = "Nombre";
                ddllocalidad.DataValueField = "CodigoPostal";
                ddllocalidad.DataSource = dt;
                ddllocalidad.DataBind();
            }
        }

        public void CargarTipoDocumento()
        {
            TheGym k = new TheGym();
            DataTable dt = new DataTable();
            dt = k.GetAllTipoDocumento();
            if (dt.Rows.Count > 0)
            {
                ddltipodedocumento.DataTextField = "Descripcion";
                ddltipodedocumento.DataValueField = "Id_TipoDocumento";
                ddltipodedocumento.DataSource = dt;
                ddltipodedocumento.DataBind();
            }
        }

        public void CargarSucursales()
        {
            TheGym k = new TheGym();
            DataTable dt = new DataTable();
            dt = k.GetSucursales();
            if (dt.Rows.Count > 0)
            {
                ddlSucursal.DataTextField = "Nombre";
                ddlSucursal.DataValueField = "Id_sucursal";
                ddlSucursal.DataSource = dt;
                ddlSucursal.DataBind();
            }
        }


        private void GetCargos()
        {
            TheGym k = new TheGym();
            DataTable dt = k.GetCargos();
            if (dt.Rows.Count > 0)
            {
                ddlcargo.DataValueField = "Id_cargo";
                ddlcargo.DataTextField = "Nombre";
                ddlcargo.DataSource = dt;
                ddlcargo.DataBind();
            }
        }


        private void SaveClienteFoto()
        {
            if (fiupfotografiacliente.PostedFile != null)
            {
                string filename = fiupfotografiacliente.FileName.ToString();
                string fileExt = System.IO.Path.GetExtension(fiupfotografiacliente.FileName);

                extention = fileExt;

                if (filename.Length > 96)
                {
                    lblerror.Text = ("El nomnre de la imagen no debe exceder los 96 caracteres");
                }
                else if (fileExt != ".jpeg" && fileExt != ".jpg" && fileExt != ".png" && fileExt != ".bmp")
                {
                    lblerror.Text = ("Solo se admiten formatos como jpeg, jpg, bmp & png ");
                }
                else if (fiupfotografiacliente.PostedFile.ContentLength > 40000000)
                {
                    lblerror.Text = ("El tamaño de la imagen no debe ser mayor a 40MB !");
                }
                else
                {

                    //fuImage.SaveAs(Server.MapPath("~/ImagenesSistema/" + filename));
                    try
                    {
                        int alto;
                        int ancho;
                        ///////
                        // como no se puede obtener el path directo del upload file, lo que hacemos es guardarla en una carpeta distinta con su tamaño original
                        fiupfotografiacliente.PostedFile.SaveAs(Server.MapPath("~/Uploads/") + fiupfotografiacliente.PostedFile.FileName);
                        System.Drawing.Image img;
                        //importamos la libreria drawing y abrimos la imagen en un bitmap
                        Bitmap imagen = new Bitmap(Server.MapPath("~/Uploads/") + fiupfotografiacliente.PostedFile.FileName);
                        //obtenemos su alto y ancho
                        ancho = imagen.Width;
                        alto = imagen.Height;
                        //la redimensionamos con el metodo resizeImage C:\Users\Mili\Source\Repos\WEBTHEGYM\thegym19-08\Uploads\
                        if (alto > ancho)
                        {
                            img = ResizeImage(imagen, 150, 130);
                        }
                        else
                        {
                            img = ResizeImage(imagen, 150, 150);
                        }

                        img.Save(Server.MapPath("~/ImagenesSistema/") + tbnumerodocumento.Text + ".jpg");
                        ///////
                        lblerror.Text = "El producto se agregó correctamente";
                    }
                    catch (Exception ex)
                    {

                        lblerror.Text = ex.Message.ToString();
                    }
                }
            }

        }

        public static System.Drawing.Image ResizeImage(System.Drawing.Image srcImage, int newWidth, int newHeight)
        {
            using (Bitmap imagenBitmap =
               new Bitmap(newWidth, newHeight, PixelFormat.Format32bppRgb))
            {
                imagenBitmap.SetResolution(
                   Convert.ToInt32(srcImage.HorizontalResolution),
                   Convert.ToInt32(srcImage.HorizontalResolution));

                using (Graphics imagenGraphics =
                        Graphics.FromImage(imagenBitmap))
                {
                    imagenGraphics.SmoothingMode =
                       SmoothingMode.AntiAlias;
                    imagenGraphics.InterpolationMode =
                       InterpolationMode.HighQualityBicubic;
                    imagenGraphics.PixelOffsetMode =
                       PixelOffsetMode.HighQuality;
                    imagenGraphics.DrawImage(srcImage,
                       new Rectangle(0, 0, newWidth, newHeight),
                       new Rectangle(0, 0, srcImage.Width, srcImage.Height),
                       GraphicsUnit.Pixel);
                    MemoryStream imagenMemoryStream = new MemoryStream();
                    imagenBitmap.Save(imagenMemoryStream, ImageFormat.Jpeg);
                    srcImage = System.Drawing.Image.FromStream(imagenMemoryStream);
                }
            }
            return srcImage;
        }

        protected void btnregistrar_Click(object sender, EventArgs e)
        {
            SaveClienteFoto();
            TheGym k = new TheGym
            {
                NombreEmpladoIns = tbnombre.Text,
                ApellidoEmpleadoIns = tbapellido.Text,
                FechaNacEmpleadoIns = tbfechadenacimiento.Text,
                EmailEmpleadoIns = tbemail.Text,
                TelefEmpleadoIns = tbtelefono.Text,
                DocumentoEmpleadoIns = tbnumerodocumento.Text,
                FechaContEmpleadoIns = tbfechacontratacion.Text,
                FotoEmpleadoIns = "~/ImagenesSistema/" + tbnumerodocumento.Text + extention,
                TitulEmpleadoIns = tbtitulo.Text,
                FKCargoEmpleadoIns = ddlcargo.SelectedItem.Value,
                FKTipoDocEmpleadoIns = ddltipodedocumento.SelectedValue,
                FKSucursalEmpleadoIns = ddlSucursal.SelectedValue,
                CalleEmpleadoIns = tbcalle.Text,
                BarrioEmpleadoIns = tbbarrio.Text,
                FKLocalidadEmpleadoIns = ddllocalidad.SelectedValue,
                NumeroEmpleadoIns = tbnumerocasa.Text
            };
            try
            {
                k.AddNewEmpleado();
                lblerror.Text = ("Cliente registrado con éxito.");

                tbnombre.Text = string.Empty;
                tbapellido.Text = string.Empty;
                tbnumerodocumento.Text = string.Empty;
                tbemail.Text = string.Empty;
                tbfechacontratacion.Text = string.Empty;
                tbfechadenacimiento.Text = string.Empty;
                tbtelefono.Text = string.Empty;
                tbtitulo.Text = string.Empty;
                tbcalle.Text = string.Empty;
                tbbarrio.Text = string.Empty;
                tbusuario.Text = string.Empty;
                tbcontraseña.Text = string.Empty;
                ddlcargo.ClearSelection();
                ddllocalidad.ClearSelection();
                ddlSucursal.ClearSelection();
                ddltipodedocumento.ClearSelection();
            }

            catch
            {

                
            }


            //faltamostrarmensajeemergente
        }

        protected void tbnumerodocumento_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void tbemail_TextChanged1(object sender, EventArgs e)
        {
           
        }

        protected void ddlSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void tbemail_TextChanged(object sender, EventArgs e)
        {
            tbusuario.Text = tbemail.Text;
            tbcontraseña.Text = tbnumerodocumento.Text;
            SetFocus(tbtelefono);
        }
    }
}
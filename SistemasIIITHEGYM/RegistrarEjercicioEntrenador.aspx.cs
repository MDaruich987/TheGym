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
    public partial class RegistrarEjercicioEntrenador : System.Web.UI.Page
    {
        static string extention;

        static bool flag = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            //lblmensajebienvenida.Text = Session["inicio"].ToString();
            //si efectivamente se ha iniciado sesión
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

            if (flag == true)
            {
                GetElementos();
                GetGrupoMuscular();
                flag = false;
            }

        }
        private void GetElementos()
        {
            TheGym k = new TheGym();
            DataTable dt = k.GetElementos();
            if (dt.Rows.Count > 0)
            {
                ddlelemento.DataValueField = "id_elemento";
                ddlelemento.DataTextField = "nombre";
                ddlelemento.DataSource = dt;
                ddlelemento.DataBind();

            }
        }
        private void GetGrupoMuscular()
        {
            TheGym k = new TheGym();
            DataTable dt = k.GetGruposMusculares();
            if (dt.Rows.Count > 0)
            {
                ddlgrupomuscular.DataValueField = "id_grupo";
                ddlgrupomuscular.DataTextField = "nombre";
                ddlgrupomuscular.DataSource = dt;
                ddlgrupomuscular.DataBind();

            }
        }
        protected void btnregistrar_Click(object sender, EventArgs e)
        {
            SaveEjercicioFoto();
            TheGym k = new TheGym
            {
                NombreEjercicio = tbnombre.Text,
                FKelementos = ddlelemento.SelectedValue,
                FKgrupomuscular = ddlgrupomuscular.SelectedValue,
                ImagenesEjercicio = "~/ImagenesSistema/" + tbnombre.Text + extention,
                DescripcionEjercicio = tbdescripcion.Text
            };


            try
            {
                k.AddEjercicio();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#modal-default').modal('show');", true);

            }
            catch (Exception ex)
            {
                lblerror.Text = ex.Message.ToString();
            }
            tbnombre.Text = string.Empty;
            ddlelemento.ClearSelection();
            ddlgrupomuscular.ClearSelection();
            tbdescripcion.Text = string.Empty;
        {

        }

    }

    private void SaveEjercicioFoto()
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

                    img.Save(Server.MapPath("~/ImagenesSistema/") + tbnombre.Text + ".jpg");
                    ///////
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
        protected void tbnombre_TextChanged(object sender, EventArgs e)
        {

        }


        protected void fiupfotografiacliente_Load(object sender, EventArgs e)
        {

        }
    }
}
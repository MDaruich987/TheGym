using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SistemasIIITHEGYM.BussinesLayer;
using System.Data;


namespace SistemasIIITHEGYM
{
    public partial class RegistrarHorariodeInstructor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarProfesores();
        }

        public void CargarProfesores()
        {
            TheGym k = new TheGym();
            DataTable dt = new DataTable();
            dt = k.GetProfesores();
            if (dt.Rows.Count > 0)
            {
                ddlProfesor.DataTextField = "Profesor";
                ddlProfesor.DataValueField = "Id_empleado";
                ddlProfesor.DataSource = dt;
                ddlProfesor.DataBind();
            }
        }


        public void CargarActividades()
        {
            TheGym k = new TheGym();
            DataTable dt = new DataTable();
            dt = k.GetActividad();
            if (dt.Rows.Count > 0)
            {
                ddlActividad.DataTextField = "Nombre";
                ddlActividad.DataValueField = "Id_actividad";
                ddlActividad.DataSource = dt;
                ddlActividad.DataBind();
            }
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {

        }
    }
}
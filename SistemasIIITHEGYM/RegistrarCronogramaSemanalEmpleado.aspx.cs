using SistemasIIITHEGYM.BussinesLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemasIIITHEGYM
{
    public partial class RegistrarCronogramaSemanalEmpleado : System.Web.UI.Page
    {
        static public bool flag = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (flag == true)
            {
                GetActividad();
                GetProfesores();
                flag = false;
            }
            if (!IsPostBack)
            {
                DdlLunes.Enabled = false;
                DdlhastaLunes.Enabled = false;
                DdlMartes.Enabled = false;
                DdlhastaMartes.Enabled = false;
                DdlMiercoles.Enabled = false;
                DdlhastaMiercoles.Enabled = false;
                DdlJueves.Enabled = false;
                DdlhastaJueves.Enabled = false;
                DdlViernes.Enabled = false;
                DdlhastaViernes.Enabled = false;
                DdlSabado.Enabled = false;
                DdlhastaSabado.Enabled = false;
            }
        }



        private void GetActividad()
        {
            TheGym k = new TheGym();
            DataTable dt = k.GetActividad();
            if (dt.Rows.Count > 0)
            {
                ddlActividad.DataValueField = "Id_Actividad";
                ddlActividad.DataTextField = "Nombre";
                ddlActividad.DataSource = dt;
                ddlActividad.DataBind();

            }
        }
         private void GetProfesores()
        {
            TheGym k = new TheGym();
            DataTable dt = k.GetProfesores();
            if (dt.Rows.Count > 0)
            {
                ddlProfesor.DataValueField = "Id_empleado";
                ddlProfesor.DataTextField = "Profesor";
                ddlProfesor.DataSource = dt;
                ddlProfesor.DataBind();

            }

        }

        protected void CbLunes_CheckedChanged(object sender, EventArgs e)
        {
            if (CbLunes.Checked)
            {
                DdlLunes.Enabled = true;
                DdlhastaLunes.Enabled = true;
            }
            else
            {
                DdlLunes.Enabled = false;
                DdlhastaLunes.Enabled = false;
            }
        }

        protected void CbMartes_CheckedChanged(object sender, EventArgs e)
        {
            if (CbMartes.Checked)
            {
                DdlMartes.Enabled = true;
                DdlhastaMartes.Enabled = true;
            }
            else
            {
                DdlMartes.Enabled = false;
                DdlhastaMartes.Enabled = false;
            }
        }

        protected void CbMiercoles_CheckedChanged(object sender, EventArgs e)
        {
            if (CbMiercoles.Checked)
            {
                DdlMiercoles.Enabled = true;
                DdlhastaMiercoles.Enabled = true;
            }
            else
            {
                DdlMiercoles.Enabled = false;
                DdlhastaMiercoles.Enabled = false;
            }
        }

        protected void CbJueves_CheckedChanged(object sender, EventArgs e)
        {

            if (CbJueves.Checked)
            {
                DdlJueves.Enabled = true;
                DdlhastaJueves.Enabled = true;
            }
            else
            {
                DdlJueves.Enabled = false;
                DdlhastaJueves.Enabled = false;
            }
        }

        protected void CbViernes_CheckedChanged(object sender, EventArgs e)
        {
            if (CbViernes.Checked)
            {
                DdlViernes.Enabled = true;
                DdlhastaViernes.Enabled = true;
            }
            else
            {
                DdlViernes.Enabled = false;
                DdlhastaViernes.Enabled = false;
            }
        }

        protected void CbSabado_CheckedChanged(object sender, EventArgs e)
        {
            if (CbSabado.Checked)
            {
                DdlhastaSabado.Enabled = true;
                DdlSabado.Enabled = true;
            }
            else
            {
                DdlhastaSabado.Enabled = false;
                DdlSabado.Enabled = false;
            }
        }
        protected void DdlLunes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string seleccion = DdlLunes.SelectedValue;
            int horainicio = Convert.ToInt32(seleccion) + 1;
            while (horainicio < 22)
            {
                DdlhastaLunes.DataTextField = horainicio + ":00";
                DdlhastaLunes.Items.Add(horainicio + ":00");
                horainicio = horainicio + 1;
            }
        }

        protected void DdlMartes_SelectedIndexChanged1(object sender, EventArgs e)
        {
            string seleccion = DdlMartes.SelectedValue;
            int horainicio = Convert.ToInt32(seleccion) + 1;
            while (horainicio < 22)
            {
                DdlhastaMartes.DataTextField = horainicio + ":00";
                DdlhastaMartes.Items.Add(horainicio + ":00");
                horainicio = horainicio + 1;
            }
        }

        protected void DdlMiercoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            string seleccion = DdlMiercoles.SelectedValue;
            int horainicio = Convert.ToInt32(seleccion) + 1;
            while (horainicio < 22)
            {
                DdlhastaMiercoles.DataTextField = horainicio + ":00";
                DdlhastaMiercoles.Items.Add(horainicio + ":00");
                horainicio = horainicio + 1;
            }
        }

        protected void DdlJueves_SelectedIndexChanged(object sender, EventArgs e)
        {
            string seleccion = DdlJueves.SelectedValue;
            int horainicio = Convert.ToInt32(seleccion) + 1;
            while (horainicio < 22)
            {
                DdlhastaJueves.DataTextField = horainicio + ":00";
                DdlhastaJueves.Items.Add(horainicio + ":00");
                horainicio = horainicio + 1;
            }
        }

        protected void DdlViernes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string seleccion = DdlViernes.SelectedValue;
            int horainicio = Convert.ToInt32(seleccion) + 1;
            while (horainicio < 22)
            {
                DdlhastaViernes.DataTextField = horainicio + ":00";
                DdlhastaViernes.Items.Add(horainicio + ":00");
                horainicio = horainicio + 1;
            }
        }

        protected void DdlSabado_SelectedIndexChanged(object sender, EventArgs e)
        {
            string seleccion = DdlSabado.SelectedValue;
            int horainicio = Convert.ToInt32(seleccion) + 1;
            while (horainicio < 22)
            {
                DdlhastaSabado.DataTextField = horainicio + ":00";
                DdlhastaSabado.Items.Add(horainicio + ":00");
                horainicio = horainicio + 1;
            }
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {

        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            ddlActividad.ClearSelection();
            ddlProfesor.ClearSelection();
            CbLunes.Checked = false;
            CbMartes.Checked = false;
            CbMiercoles.Checked = false;
            CbJueves.Checked = false;
            CbViernes.Checked = false;
            CbSabado.Checked = false;
            DdlLunes.ClearSelection();
            DdlMartes.ClearSelection();
            DdlhastaMartes.ClearSelection();
            DdlMiercoles.ClearSelection();
            DdlhastaMiercoles.ClearSelection();
            DdlJueves.ClearSelection();
            DdlhastaJueves.ClearSelection();
            DdlViernes.ClearSelection();
            DdlhastaViernes.ClearSelection();
            DdlSabado.ClearSelection();
            DdlhastaSabado.ClearSelection();
            DdlhastaLunes.ClearSelection();

        }

        protected void DropDownList7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DdlMartes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
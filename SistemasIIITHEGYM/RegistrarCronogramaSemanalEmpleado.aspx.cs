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

        protected void DdlMartes_SelectedIndexChanged(object sender, EventArgs e)
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

            try
            {

                if (CbLunes.Checked == true)
                {
                    TheGym k = new TheGym
                    {
                        fksemana = "1",
                        fkactividad = ddlActividad.SelectedValue,
                        fkprofesor = ddlProfesor.SelectedValue,
                        desdeCronograma = DdlLunes.SelectedItem.Text,
                        hastaCronograma = DdlhastaLunes.SelectedItem.Text

                    };
                    k.AddCronogramaSemanal();
                }
                if (CbMartes.Checked == true)
                {
                    TheGym k = new TheGym
                    {
                        fksemana = "2",
                        fkactividad = ddlActividad.SelectedValue,
                        fkprofesor = ddlProfesor.SelectedValue,
                        desdeCronograma = DdlMartes.SelectedItem.Text,
                        hastaCronograma = DdlhastaMartes.SelectedItem.Text

                    };
                    k.AddCronogramaSemanal();

                }
                if (CbMiercoles.Checked == true)
                {
                    TheGym k = new TheGym
                    {
                        fksemana = "3",
                        fkactividad = ddlActividad.SelectedValue,
                        fkprofesor = ddlProfesor.SelectedValue,
                        desdeCronograma = DdlMiercoles.SelectedItem.Text,
                        hastaCronograma = DdlhastaMiercoles.SelectedItem.Text

                    };
                    k.AddCronogramaSemanal();

                }
                if (CbJueves.Checked == true)
                {
                    TheGym k = new TheGym
                    {
                        fksemana = "4",
                        fkactividad = ddlActividad.SelectedValue,
                        fkprofesor = ddlProfesor.SelectedValue,
                        desdeCronograma = DdlJueves.SelectedItem.Text,
                        hastaCronograma = DdlhastaJueves.SelectedItem.Text

                    };
                    k.AddCronogramaSemanal();

                }
                if (CbViernes.Checked == true)
                {
                    TheGym k = new TheGym
                    {
                        fksemana = "5",
                        fkactividad = ddlActividad.SelectedValue,
                        fkprofesor = ddlProfesor.SelectedValue,
                        desdeCronograma = DdlViernes.SelectedItem.Text,
                        hastaCronograma = DdlhastaViernes.SelectedItem.Text

                    };
                    k.AddCronogramaSemanal();

                }
                if (CbSabado.Checked == true)
                {
                    TheGym k = new TheGym
                    {
                        fksemana = "6",
                        fkactividad = ddlActividad.SelectedValue,
                        fkprofesor = ddlProfesor.SelectedValue,
                        desdeCronograma = DdlSabado.SelectedItem.Text,
                        hastaCronograma = DdlhastaSabado.SelectedItem.Text

                    };
                    k.AddCronogramaSemanal();


                    ddlProfesor.ClearSelection();
                    ddlActividad.ClearSelection();

                }
            }
            catch (Exception ex)
            {

                lblerror.Text = ex.Message.ToString();
            }
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
            DdlhastaLunes.Dispose();
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
            

        }




        protected void DropDownList7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
    }
}

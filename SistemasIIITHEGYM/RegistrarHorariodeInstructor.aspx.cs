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
        static public bool flag = true;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (flag == true)
            {
                CargarProfesores();
                CargarActividades();
                flag = false;
            }
          
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
            try
            {

                if (CbLunes.Checked == true)
                {
                    TheGym k = new TheGym
                    {
                        FKSemanaReg = "1",
                        FKActividadReg = ddlActividad.SelectedValue,
                        FKEmpleadoReg = ddlProfesor.SelectedValue,
                        DesdeReg = DdldeLunes.SelectedItem.Text,
                        HastaReg = DdlhastaLunes.SelectedItem.Text

                    };
                    k.AddCronograma();
                }
                if (CbMartes.Checked == true)
                {
                    TheGym k = new TheGym
                    {
                        FKSemanaReg = "2",
                        FKActividadReg = ddlActividad.SelectedValue,
                        FKEmpleadoReg = ddlProfesor.SelectedValue,
                        DesdeReg = DdldeMartes.SelectedItem.Text,
                        HastaReg = DdlhastaMartes.SelectedItem.Text

                    };
                    k.AddCronograma();
                }
                if (CbMiercoles.Checked == true)
                {
                    TheGym k = new TheGym
                    {
                        FKSemanaReg = "3",
                        FKActividadReg = ddlActividad.SelectedValue,
                        FKEmpleadoReg = ddlProfesor.SelectedValue,
                        DesdeReg = DdldeMiercoles.SelectedItem.Text,
                        HastaReg = DdlhastaMiercoles.SelectedItem.Text

                    };
                    k.AddCronograma();
                }
                if (CbJueves.Checked == true)
                {
                    TheGym k = new TheGym
                    {
                        FKSemanaReg = "4",
                        FKActividadReg = ddlActividad.SelectedValue,
                        FKEmpleadoReg = ddlProfesor.SelectedValue,
                        DesdeReg = DdldeJueves.SelectedItem.Text,
                        HastaReg = DdlhastaJueves.SelectedItem.Text

                    };
                    k.AddCronograma();
                }
                if (CbViernes.Checked == true)
                {
                    TheGym k = new TheGym
                    {
                        FKSemanaReg = "5",
                        FKActividadReg = ddlActividad.SelectedValue,
                        FKEmpleadoReg = ddlProfesor.SelectedValue,
                        DesdeReg = DdldeViernes.SelectedItem.Text,
                        HastaReg = DdlhastaViernes.SelectedItem.Text

                    };
                    k.AddCronograma();
                }
                if (CbSabado.Checked == true)
                {
                    TheGym k = new TheGym
                    {
                        FKSemanaReg = "6",
                        FKActividadReg = ddlActividad.SelectedValue,
                        FKEmpleadoReg = ddlProfesor.SelectedValue,
                        DesdeReg = DdldeSabado.SelectedItem.Text,
                        HastaReg = DdlhastaSabado.SelectedItem.Text

                    };
                    k.AddCronograma();
                    this.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert ('El horario se ha registrado exitosamente');</script>");
                    ddlProfesor.ClearSelection();
                    ddlActividad.ClearSelection();
                }
            }
            catch (Exception ex)
            {

                lblerror.Text=ex.Message.ToString();
            }
        }

        protected void DropDownList7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DdldeMartes_SelectedIndexChanged(object sender, EventArgs e)
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
            DdldeLunes.ClearSelection();
            DdldeMartes.ClearSelection();
            DdlhastaMartes.ClearSelection();
            DdldeMiercoles.ClearSelection();
            DdlhastaMiercoles.ClearSelection();
            DdldeJueves.ClearSelection();
            DdlhastaJueves.ClearSelection();
            DdldeViernes.ClearSelection();
            DdlhastaViernes.ClearSelection();
            DdldeSabado.ClearSelection();
            DdlhastaSabado.ClearSelection();
            DdlhastaLunes.ClearSelection();






        }
    }
}
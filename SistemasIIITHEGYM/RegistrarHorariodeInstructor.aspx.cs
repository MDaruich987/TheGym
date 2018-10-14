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
        int cont=0;
        static public bool flag = true;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (flag == true)
            {
                CargarProfesores();
                flag = false;
            }
            if (!IsPostBack)
            {
                DdldeLunes.Enabled = false;
                DdlhastaLunes.Enabled = false;
                DdldeMartes.Enabled = false;
                DdlhastaMartes.Enabled = false;
                DdldeMiercoles.Enabled = false;
                DdlhastaMiercoles.Enabled = false;
                DdldeJueves.Enabled = false;
                DdlhastaJueves.Enabled = false;
                DdldeViernes.Enabled = false;
                DdlhastaViernes.Enabled = false;
                DdldeSabado.Enabled = false;
                DdlhastaSabado.Enabled = false;
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


        

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
          
            try
            {

                if (CbLunes.Checked == true)
                {
                    TheGym k = new TheGym
                    {
                        FKSemanaReg = "1",
                        
                        FKEmpleadoReg = ddlProfesor.SelectedValue,
                        DesdeReg = DdldeLunes.SelectedItem.Text,
                        HastaReg = DdlhastaLunes.SelectedItem.Text

                    };
                    k.AddCronograma();
                    cont=cont+1;
                }
                if (CbMartes.Checked == true)
                {
                    TheGym k = new TheGym
                    {
                        FKSemanaReg = "2",
                        
                        FKEmpleadoReg = ddlProfesor.SelectedValue,
                        DesdeReg = DdldeMartes.SelectedItem.Text,
                        HastaReg = DdlhastaMartes.SelectedItem.Text

                    };
                    k.AddCronograma();
                    cont = cont + 1;
                }
                if (CbMiercoles.Checked == true)
                {
                    TheGym k = new TheGym
                    {
                        FKSemanaReg = "3",
                        
                        FKEmpleadoReg = ddlProfesor.SelectedValue,
                        DesdeReg = DdldeMiercoles.SelectedItem.Text,
                        HastaReg = DdlhastaMiercoles.SelectedItem.Text

                    };
                    k.AddCronograma();
                    cont = cont + 1;
                }
                if (CbJueves.Checked == true)
                {
                    TheGym k = new TheGym
                    {
                        FKSemanaReg = "4",
                        
                        FKEmpleadoReg = ddlProfesor.SelectedValue,
                        DesdeReg = DdldeJueves.SelectedItem.Text,
                        HastaReg = DdlhastaJueves.SelectedItem.Text

                    };
                    k.AddCronograma();
                    cont = cont + 1;
                }
                if (CbViernes.Checked == true)
                {
                    TheGym k = new TheGym
                    {
                        FKSemanaReg = "5",
                        
                        FKEmpleadoReg = ddlProfesor.SelectedValue,
                        DesdeReg = DdldeViernes.SelectedItem.Text,
                        HastaReg = DdlhastaViernes.SelectedItem.Text

                    };
                    k.AddCronograma();
                    cont = cont + 1;
                }
                if (CbSabado.Checked == true)
                {
                    TheGym k = new TheGym
                    {
                        FKSemanaReg = "6",
                        FKEmpleadoReg = ddlProfesor.SelectedValue,
                        DesdeReg = DdldeSabado.SelectedItem.Text,
                        HastaReg = DdlhastaSabado.SelectedItem.Text

                    };
                    k.AddCronograma();
                    cont = cont + 1;

                    ddlProfesor.ClearSelection();
                    
                }
                if (cont>=1)
                {
                    lblerror.Text = "";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#modal-default').modal('show');", true);

                }
                else
                {
                    lblerror.Text = "Seleccione un dia y horario";
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
            DataTable dt = new DataTable();
            DdlhastaLunes.DataSource = dt;
            DdlhastaLunes.DataBind();
            DdlhastaMartes.DataSource=dt;
            DdlhastaMartes.DataBind();
            DdlhastaMiercoles.DataSource = dt;
            DdlhastaMiercoles.DataBind();
            DdlhastaJueves.DataSource = dt;
            DdlhastaJueves.DataBind();
            DdldeViernes.DataSource = dt;
            DdldeViernes.DataBind();






        }

        protected void CbLunes_CheckedChanged(object sender, EventArgs e)
        {
            if (CbLunes.Checked)
            {
                DdldeLunes.Enabled = true;
                DdlhastaLunes.Enabled = true;
            }
            else
            {
                DdldeLunes.Enabled = false;
                DdlhastaLunes.Enabled = false;
            }
        }

        protected void CbMartes_CheckedChanged(object sender, EventArgs e)
        {
            if (CbMartes.Checked)
            {
                DdldeMartes.Enabled = true;
                DdlhastaMartes.Enabled = true;
            }
            else
            {
                DdldeMartes.Enabled = false;
                DdlhastaMartes.Enabled = false;
            }
        }

        protected void CbMiercoles_CheckedChanged(object sender, EventArgs e)
        {
            if (CbMiercoles.Checked)
            {
                DdldeMiercoles.Enabled = true;
                DdlhastaMiercoles.Enabled = true;
            }
            else
            {
                DdldeMiercoles.Enabled = false;
                DdlhastaMiercoles.Enabled = false;
            }
        }

        protected void CbJueves_CheckedChanged(object sender, EventArgs e)
        {

            if (CbJueves.Checked)
            {
                DdldeJueves.Enabled = true;
                DdlhastaJueves.Enabled = true;
            }
            else
            {
                DdldeJueves.Enabled = false;
                DdlhastaJueves.Enabled = false;
            }
        }

        protected void CbViernes_CheckedChanged(object sender, EventArgs e)
        {
            if (CbViernes.Checked)
            {
                DdldeViernes.Enabled = true;
                DdlhastaViernes.Enabled = true;
            }
            else
            {
                DdldeViernes.Enabled = false;
                DdlhastaViernes.Enabled = false;
            }
        }

        protected void CbSabado_CheckedChanged(object sender, EventArgs e)
        {
            if (CbSabado.Checked)
            {
                DdlhastaSabado.Enabled = true;
                DdldeSabado.Enabled = true;
            }
            else
            {
                DdlhastaSabado.Enabled = false;
                DdldeSabado.Enabled = false;
            }
        }

        protected void DdldeLunes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string seleccion = DdldeLunes.SelectedValue;
            int horainicio = Convert.ToInt32(seleccion)+1;
            while (horainicio<22)
            {
                DdlhastaLunes.DataTextField = horainicio+":00";
                DdlhastaLunes.Items.Add(horainicio + ":00");
                horainicio = horainicio + 1;
            }
        }

        protected void DdldeMartes_SelectedIndexChanged1(object sender, EventArgs e)
        {
            string seleccion = DdldeMartes.SelectedValue;
            int horainicio = Convert.ToInt32(seleccion) + 1;
            while (horainicio < 22)
            {
                DdlhastaMartes.DataTextField = horainicio + ":00";
                DdlhastaMartes.Items.Add(horainicio + ":00");
                horainicio = horainicio + 1;
            }
        }

        protected void DdldeMiercoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            string seleccion = DdldeMiercoles.SelectedValue;
            int horainicio = Convert.ToInt32(seleccion) + 1;
            while (horainicio < 22)
            {
                DdlhastaMiercoles.DataTextField = horainicio + ":00";
                DdlhastaMiercoles.Items.Add(horainicio + ":00");
                horainicio = horainicio + 1;
            }
        }

        protected void DdldeJueves_SelectedIndexChanged(object sender, EventArgs e)
        {
            string seleccion = DdldeJueves.SelectedValue;
            int horainicio = Convert.ToInt32(seleccion) + 1;
            while (horainicio < 22)
            {
                DdlhastaJueves.DataTextField = horainicio + ":00";
                DdlhastaJueves.Items.Add(horainicio + ":00");
                horainicio = horainicio + 1;
            }
        }

        protected void DdldeViernes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string seleccion = DdldeViernes.SelectedValue;
            int horainicio = Convert.ToInt32(seleccion) + 1;
            while (horainicio < 22)
            {
                DdlhastaViernes.DataTextField = horainicio + ":00";
                DdlhastaViernes.Items.Add(horainicio + ":00");
                horainicio = horainicio + 1;
            }
        }

        protected void DdldeSabado_SelectedIndexChanged(object sender, EventArgs e)
        {
            string seleccion = DdldeSabado.SelectedValue;
            int horainicio = Convert.ToInt32(seleccion) + 1;
            while (horainicio < 22)
            {
                DdlhastaSabado.DataTextField = horainicio + ":00";
                DdlhastaSabado.Items.Add(horainicio + ":00");
                horainicio = horainicio + 1;
            }
        }
    }
}
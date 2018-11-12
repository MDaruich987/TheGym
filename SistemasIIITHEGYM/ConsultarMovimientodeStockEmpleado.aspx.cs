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
    public partial class ConsultarMovimientodeStockEmpleado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDeposito();
                gridmovimientostock.Dispose();
                gridmovimientostock.Visible = false;
            }
        }

        protected void btnconsultar_Click(object sender, EventArgs e)
        {
            lblerror.Visible = false;
            try
            {
                if(DropDownList1.SelectedItem.Text != "--Seleccione--")
                {
                    TheGym k = new TheGym
                    {
                        IdDep = DropDownList1.SelectedValue
                    };
                    DataTable dt = new DataTable();
                    dt = k.GetMovimiento();
                    if (dt.Rows.Count > 0)
                    {
                        gridmovimientostock.DataSource = dt;
                        gridmovimientostock.DataBind();
                        gridmovimientostock.Visible = true;
                    }
                    else
                    {
                        lblerror.Visible = true;
                        lblerror.Text = "Sin Movimientos";
                    }
                }
                else
                {
                    lblerror.Visible = true;
                    lblerror.Text = "Seleccione un deposito";
                }
            }
            catch
            {
                lblerror.Visible = true;
                lblerror.Text = "Error al recuperar datos";
            }
        }

        protected void CargarDeposito()
        {
            lblerror.Visible = false;
            TheGym k = new TheGym();
            DataTable dt = new DataTable();
            dt = k.GetDeposito();
            if (dt.Rows.Count > 0)
            {
                DropDownList1.DataTextField = "Nombre";
                DropDownList1.DataValueField = "Id_deposito";
                DropDownList1.DataSource = dt;
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, "--Seleccione--");
            }
            else
            {
                lblerror.Visible = true;
                lblerror.Text = "No se encontraron servicios";
            }
        }
    }
}
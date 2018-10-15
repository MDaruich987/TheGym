﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemasIIITHEGYM
{
    public partial class ConsultarDeposito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //la primera vez que se carga la página
                //muestra el panel de  busqueda, no el de edicion
                paneledicion.Visible = true;
                panelconsulta.Focus();
                paneledicion.Visible = false;

                //lblmensajebienvenida.Text = Session["inicio"].ToString();
                //si efectivamente se ha iniciado sesión
                if (Session["inicio"] != null)
                {
                    //declaramos una variale sesion para mantener el dato del usuario
                    string usuario = (string)Session["Usuario"];
                    lblusuario.Text = "Bienvenido/a " + (String)Session["inicio"];

                }
                else
                {
                    //si no se ha iniciado sesion me manda al inicio
                    //Response.Redirect("InicioLogin.aspx");
                }

            }
        }

        protected void gridsucursales_SelectedIndexChanged(object sender, EventArgs e)
        {
            //mostramos el panel de edicion, que es donde se verán los productos en stock en esa sucursal
            //aqui se puede buscar por productos tambien
            panelconsulta.Visible = false;
            paneledicion.Visible = true;

        }

        protected void btnconsultar_Click(object sender, EventArgs e)
        {
            //aqui se debe buscar sobre el gridview de propiedas por productos
        }
    }

}
<%@ Page Title="" Language="C#" MasterPageFile="~/GYMPaginasMaestras/PaginaMaestaGerente.Master" AutoEventWireup="true" CodeBehind="InicioGerente.aspx.cs" Inherits="SistemasIIITHEGYM.InicioGerente" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Label ID="lblusuario" runat="server" Font-Bold="True" Font-Names="Arial Black" Font-Size="Small" ForeColor="White"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <!-- Small boxes (Stat box) -->
      <div class="row">
        <div class="col-lg-3 col-xs-6">
          <!-- small box -->
          <div class="small-box bg-aqua">
            <div class="inner">
              <h3>
                  <asp:Label ID="lblventas" runat="server" Text="150"></asp:Label>
                </h3>

              <p>Ventas de Productos</p>
            </div>
            <div class="icon">
              <i class="fa fa-shopping-cart"></i>
            </div>
              <a href="#" class="small-box-footer">
              <asp:Button ID="btnverestadisticaventasproducto" runat="server" BackColor="#00ACD7" BorderColor="#00ACD7" BorderStyle="None" OnClick="btnverestadisticaventasproducto_Click" Text="Ver estadisticas" />
&nbsp;<i class="fa fa-arrow-circle-right"></i></a></div>
        </div>
        <!-- ./col -->
        <div class="col-lg-3 col-xs-6">
          <!-- small box -->
        </div>
        <!-- ./col -->
        <%--<div class="col-lg-3 col-xs-6">
          <!-- small box -->
          <div class="small-box bg-yellow">
            <div class="inner">
              <h3>
                  <asp:Label ID="lblclientes" runat="server" Text="150"></asp:Label>
                </h3>

              <p>Nuevos clientes</p>
            </div>
            <div class="icon">
              <i class="ion ion-person-add"></i>
            </div>
            <a href="RegistrarClienteEmpleado.aspx" class="small-box-footer">
              Ver estadísticas <i class="fa fa-arrow-circle-right"></i>
            </a>
          </div>
        </div>--%>
        <!-- ./col -->
        <div class="col-lg-3 col-xs-6">
          <!-- small box -->
          <div class="small-box bg-red">
            <div class="inner">
              <h3>
                  <asp:Label ID="lblplanes" runat="server" Text="150"></asp:Label>
                </h3>

              <p>Cobro de planes</p>
            </div>
            <div class="icon">
              <i class="ion ion-pie-graph"></i>
            </div>
              <a href="#" class="small-box-footer">
              <asp:Button ID="btnverestadisticascobro" runat="server" BackColor="#C64333" BorderColor="#C64333" BorderStyle="None" OnClick="btnverestadisticascobro_Click" Text="Ver estadisticas" />
              <i class="fa fa-arrow-circle-right"></i>
            &nbsp;</a></div>
        </div>
        <!-- ./col -->
      </div>
      <!-- /.row -->
    <asp:Panel ID="panelcobrodeplanes" runat="server">
        <div class="box box-default">
        <div class="box-header with-border">
            <h3 class="box-title">Datos de Cobro de Planes </h3>
            <div class="box-tools pull-right">
<%--                boton minimizar y cerrar--%>
<%--                <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>--%>
            </div>
        </div>
            <div class="box-body">
                <br />
                <asp:Label ID="lblerror" runat="server" BackColor="White" BorderColor="White" ForeColor="#CC0000" Visible="False"></asp:Label>
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<br />
                <asp:Chart ID="ChartPlan" runat="server" OnLoad="ChartPlan_Load">
                    <Series>
                        <asp:Series Name="Series1">
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1">
                        </asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
                <br />
                <br />
                <!-- /.row -->
            </div>
        <!-- /.box-header -->
    </div>
    </asp:Panel>
    
    <asp:Panel ID="panelproductos" runat="server">
        <div class="box box-default">
        <div class="box-header with-border">
            <h3 class="box-title">Datos de Cobro de Productos </h3>
            <div class="box-tools pull-right">
<%--                boton minimizar y cerrar--%>
<%--                <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>--%>
            </div>
        </div>
        <!-- /.box-header -->
                <div class="box-body">

          <!-- /.row -->
                    <br />
                    <br />
                    <br />
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Chart ID="ChartProd" runat="server">
                        <Series>
                            <asp:Series Name="Series1">
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1">
                            </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
        </div>
        <!-- /.box-body -->
    </div>
    </asp:Panel>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />

    <br />
</asp:Content>

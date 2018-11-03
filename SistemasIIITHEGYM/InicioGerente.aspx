<%@ Page Title="" Language="C#" MasterPageFile="~/GYMPaginasMaestras/PaginaMaestaGerente.Master" AutoEventWireup="true" CodeBehind="InicioGerente.aspx.cs" Inherits="SistemasIIITHEGYM.InicioGerente" %>
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
          <div class="small-box bg-green">
            <div class="inner">
              <h3>
                  <asp:Label ID="lblasistencias" runat="server" Text="150"></asp:Label>
                  <sup style="font-size: 20px">%</sup></h3>

              <p>Asistencias</p>
            </div>
            <div class="icon">
              <i class="ion ion-stats-bars"></i>
            </div>
            <a href="#" class="small-box-footer">
              Ver estadísticas <i class="fa fa-arrow-circle-right"></i>
            </a>
          </div>
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
        <!-- /.box-header -->
                <div class="box-body">
                    <asp:Label ID="lblerror" runat="server" BackColor="White" BorderColor="White" ForeColor="#CC0000" Visible="False"></asp:Label>
                    <asp:GridView ID="gridcobrocuota" runat="server" AllowSorting="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CaptionAlign="Bottom" CellPadding="4" CellSpacing="1" Font-Size="Medium" ForeColor="Black" GridLines="Horizontal" Height="163px" HorizontalAlign="Justify" PageSize="6" ShowHeaderWhenEmpty="True" style="margin-left: 316px; margin-bottom: 9px;" Width="333px" AutoGenerateColumns="False" Enabled="False" >
                                              <Columns>
                                                  <asp:BoundField DataField="Nombre" HeaderText="Producto" />
                                                  <asp:BoundField DataField="cantidad" HeaderText="Cantidad" />
                                              </Columns>
                                              <EditRowStyle BorderColor="Black" BorderStyle="None" Font-Size="Small" />
                                              <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                              <HeaderStyle BackColor="#364E6F" Font-Bold="True" ForeColor="White" Height="30px" />
                                              <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                                              <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="220px" />
                                              <SelectedRowStyle BackColor="#6A8BB7" Font-Bold="True" ForeColor="White" />
                                              <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                              <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                              <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                              <SortedDescendingHeaderStyle BackColor="#242121" />
                                          </asp:GridView>
          <!-- /.row -->
        </div>
        <!-- /.box-body -->
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
                    <asp:GridView ID="gridplanes" runat="server" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CaptionAlign="Bottom" CellPadding="4" CellSpacing="1" DataKeyNames="Id_sucursal" Enabled="False" Font-Size="Medium" ForeColor="Black" GridLines="Horizontal" Height="163px" HorizontalAlign="Justify" PageSize="6" ShowHeaderWhenEmpty="True" style="margin-left: 316px; margin-bottom: 9px;" Width="333px">
                        <Columns>
                            <asp:BoundField HeaderText="Producto" />
                            <asp:BoundField HeaderText="Cantidad" />
                        </Columns>
                        <EditRowStyle BorderColor="Black" BorderStyle="None" Font-Size="Small" />
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <HeaderStyle BackColor="#364E6F" Font-Bold="True" ForeColor="White" Height="30px" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                        <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="220px" />
                        <SelectedRowStyle BackColor="#6A8BB7" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#242121" />
                    </asp:GridView>
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

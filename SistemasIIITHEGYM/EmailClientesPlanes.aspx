<%@ Page Title="" Language="C#" MasterPageFile="~/GYMPaginasMaestras/PaginaMaestraEmpleado.Master" AutoEventWireup="true" CodeBehind="EmailClientesPlanes.aspx.cs" Inherits="SistemasIIITHEGYM.EmailClientesPlanes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Label ID="lblusuario" runat="server" Font-Bold="True" Font-Names="Arial Black" Font-Size="Small" ForeColor="White"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <%--<section class="content-header">
                    <h1>Operaciones de caja <small>TheGym</small> </h1>
                </section>--%>
    <!-- SELECT2 EXAMPLE -->
    <div class="box box-default">
        <div class="box-header with-border">
            <h3 class="box-title">Envio de Promociones</h3>
            <div class="box-tools pull-right">
<%--                boton minimizar y cerrar--%>
<%--                <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>--%>
            </div>
        </div>
        <!-- /.box-header -->
                <div class="box-body">

   <asp:Label ID="lblseleccione" runat="server" Text="Seleccione el cliente al cual desea enviar el Email:" Font-Names="Arial" Font-Size="Medium"></asp:Label>       
                    <br />       
                    <br /> 
                    <asp:GridView ID="gridclientes" runat="server" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CaptionAlign="Bottom" CellPadding="4" CellSpacing="1" DataKeyNames="Id_cliente" Font-Size="Medium" ForeColor="Black" GridLines="Horizontal" Height="210px" HorizontalAlign="Justify" PageSize="6" ShowHeaderWhenEmpty="True" style="margin-left: 107px; margin-bottom: 9px;" Width="601px">
                                                          <Columns>
                                                              <asp:BoundField DataField="Nombre" HeaderText="Nombre" ItemStyle-Width="100">
                                                              <ItemStyle Width="150px" />
                                                              </asp:BoundField>
                                                              <asp:BoundField DataField="Apellido" HeaderText="Apellido" ItemStyle-Width="100">
                                                              <ItemStyle Width="150px" />
                                                              </asp:BoundField>
                                                              <asp:BoundField DataField="DNI" HeaderText="DNI" ItemStyle-Width="100">
                                                              <ItemStyle Width="190px" />
                                                              </asp:BoundField>
                                                              <asp:BoundField DataField="Fecha_nac" HeaderText="Fecha Nacimiento" ItemStyle-Width="100" Visible="False">
                                                              <ItemStyle Width="180px" />
                                                              </asp:BoundField>
                                                              <asp:BoundField DataField="Email" HeaderText="Emai" ItemStyle-Width="100" Visible="False">
                                                              <ItemStyle Width="160px" />
                                                              </asp:BoundField>
                                                              <asp:BoundField DataField="Telefono" HeaderText="Telefono" ItemStyle-Width="100" Visible="False">
                                                              <ItemStyle Width="160px" />
                                                              </asp:BoundField>
                                                              <asp:BoundField ConvertEmptyStringToNull="true" DataField="Domicilio" HeaderText="Domicilio" ItemStyle-Width="100" Visible="False">
                                                              <ItemStyle Width="190px" />
                                                              </asp:BoundField>
                                                              <asp:ImageField DataImageUrlField="Foto" HeaderText="Foto">
                                                              </asp:ImageField>
                                                              <asp:CommandField ButtonType="Image" SelectImageUrl="~/ImagenesSistema/editargrid.png" ShowSelectButton="True">
                                                              <ControlStyle Height="20px" Width="20px" />
                                                              </asp:CommandField>
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
    <!-- /.box -->

              <!-- quick email widget -->
          <div class="box box-info">
            <div class="box-header">
              <i class="fa fa-envelope"></i>

              <h3 class="box-title">Envío del E-mail</h3>
              <!-- tools box -->
              <div class="pull-right box-tools">
              </div>
              <!-- /. tools -->
            </div>
            <div class="box-body">
                <div class="form-group">
                  <asp:TextBox ID="tbusuario" Cssclass="form-control" runat="server" Height="24px" Width="140px"></asp:TextBox>
                </div>
                <div>
                    <asp:TextBox ID="tbmensaje" Cssclass="textarea" runat="server" Height="51px" TextMode="MultiLine" Width="537px"></asp:TextBox>
                </div>
            </div>
            <div class="box-footer clearfix">
            <asp:Button ID="btnenviar" CssClass="pull-right btn btn-default" runat="server" Text="Enviar" />
            </div>
          </div>
</asp:Content>

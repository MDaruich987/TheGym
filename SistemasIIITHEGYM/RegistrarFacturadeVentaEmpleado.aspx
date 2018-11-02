﻿<%@ Page Title="" Language="C#" MasterPageFile="~/GYMPaginasMaestras/PaginaMaestraEmpleado.Master" AutoEventWireup="true" CodeBehind="RegistrarFacturadeVentaEmpleado.aspx.cs" Inherits="SistemasIIITHEGYM.RegistrarFacturadeVentaEmpleado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Label ID="lblusuario" runat="server" Font-Bold="True" Font-Names="Arial Black" Font-Size="Small" ForeColor="White"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <%--gridmodal--%>
             <div class="modal fade" id="modal-aperturacaja">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header">
                  <%--fingridmodal--%><%--<button type="button" class="btn btn-default pull-left" data-dismiss="modal">Close</button>
                <button type="button" class="btn btn-primary">Save changes</button>--%>
                <h4 class="modal-title">THEGYM</h4>
              </div>
              <div class="modal-body">
                <p>No se registró la apertura de caja diaria&hellip;</p>
              </div>
              <div class="modal-footer">
                  <%--inicio boxs--%>
              </div>
            </div>
            <!-- /.modal-content -->
          </div>
          <!-- /.modal-dialog -->
        </div>
        <!-- /.modal -->
<link rel="stylesheet" href="../../bower_components/select2/dist/css/select2.min.css">
    <script type ="text/javascript">

 function show()
    {
        document.write("<head runat='server'></head>");
    }
    </script>
<section class="content-header">
      <h1>Registrar Factura de Venta<small>TheGym</small> </h1>
       <br />
</section>
     <div class="modal fade" id="modal-compraregistrada">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header">
                  <%--                boton minimizar y cerrar--%>                  <%--                <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>--%>
                <h4 class="modal-title">THEGYM</h4>
              </div>
              <div class="modal-body">
                <p>¡Factura de Venta registrada exitosamente!&hellip;</p>
              </div>
              <div class="modal-footer">
                  <%--<div class="box-footer">
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  <asp:Button ID="btnregistrar" CssClass="btn btn-info" runat="server" Text="Registrar" OnClick="btnregistrar_Click" />
                
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  <asp:Button ID="btncancelar" runat="server" CssClass="btn btn-default" Text="Cancelar" CausesValidation="False" />
                
              </div>--%>
              </div>
            </div>
            <!-- /.modal-content -->
          </div>
          <!-- /.modal-dialog -->
        </div>
        <!-- /.modal -->
     <div class="modal fade" id="modal-cliente">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header">
                  <%--<div class="box-footer">
             
              <!-- /.row -->
            </div>--%>
                  <%--<span aria-hidden="true">&times;</span></button>--%>
                <h4 class="modal-title">Seleccione un cliente:</h4>
              </div>
              <div class="modal-body">
                  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                      <ContentTemplate>
                          <asp:Panel ID="panelconsulta" runat="server">
                             <asp:TextBox ID="tbnombrecliente" runat="server" Height="21px" Width="371px"></asp:TextBox>
                               <table class="nav-justified" style="height: 48px">
                                   <caption>
                                       <br />
                                       <asp:Button ID="btnconsultarclientemodal" runat="server" CssClass="btn btn-info" Text="Consultar" OnClick="btnconsultarproveedorgrid_Click" CausesValidation="False" />
                                       <br />
                                       <asp:Label ID="lblerrorconsultarclientemodal" runat="server" CssClass="error-text"></asp:Label>
                                       <br />
                                       <%--aqui esta el grid del modal para los proveedores--%>
                                       <asp:GridView ID="gvproveedoresmodal" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CaptionAlign="Bottom" CellPadding="4" CellSpacing="1" Font-Size="Medium" ForeColor="Black" GridLines="Horizontal" Height="210px" HorizontalAlign="Justify" PageSize="4" ShowHeaderWhenEmpty="True" style="margin-left: 136px; margin-bottom: 9px;" Width="601px" OnSelectedIndexChanged="gvproveedores_SelectedIndexChanged">
                                           <Columns>
                                               <%--<asp:BoundField DataField="Id_proveedor" HeaderText="ID" />
                                               <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                               <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
                                               <asp:BoundField DataField="NomContacto" HeaderText="Representante" />
                                               <asp:CommandField ButtonType="Image" SelectImageUrl="~/ImagenesSistema/editargrid.png" ShowSelectButton="True">
                                               <ControlStyle Height="20px" Width="20px" />
                                               </asp:CommandField>--%>
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
                                       <%--fingridmodal--%>
                                   </caption>
                                    </table>
                          </asp:Panel>
                     </ContentTemplate>
                  </asp:UpdatePanel>
              </div>
              <div class="modal-footer">
                <%--<button type="button" class="btn btn-default pull-left" data-dismiss="modal">Close</button>
                <button type="button" class="btn btn-primary">Save changes</button>--%>
              </div>
            </div>
            <!-- /.modal-content -->
          </div>
          <!-- /.modal-dialog -->
        </div>
    <%--modal añadir producto--%>
    <div class="modal fade" id="modal-añadirproducto">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header">
                  <%--                boton minimizar y cerrar--%>                  <%--                <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>--%>
                <h4 class="modal-title">Seleccione un producto</h4>
              </div>
              <div class="modal-body">
                  <asp:UpdatePanel ID="upproductos" runat="server">
                      <ContentTemplate>
                          <asp:Panel ID="panelmodalproductos" runat="server">
                             <asp:TextBox ID="tbnombreproductos" runat="server" Height="21px" Width="371px"></asp:TextBox>
                              <br />                                   
                               <table class="nav-justified" style="height: 48px">
                                   <caption>
                                       <br />
                                       <asp:Button ID="botonconsultarproductos" runat="server" CssClass="btn btn-info" Text="Consultar" OnClick="botonconsultarproductos_Click" CausesValidation="False" />
                                       <br />
                                       <asp:Label ID="lblerrorproductosmodal" runat="server" CssClass="error-text"></asp:Label>
                                       <br />
                                       <%--aqui esta el grid del modalpara los productos--%>
                                       <asp:GridView ID="gvproductos" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CaptionAlign="Bottom" CellPadding="4" CellSpacing="1" Font-Size="Medium" ForeColor="Black" GridLines="Horizontal" Height="210px" HorizontalAlign="Justify" PageSize="4" ShowHeaderWhenEmpty="True" style="margin-left: 136px; margin-bottom: 9px;" Width="601px">
                                           <Columns>
                                               <asp:BoundField DataField="Id_producto" HeaderText="ID" />
                                                  <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                                  <asp:BoundField DataField="PrecioCompra" HeaderText="Precio" />
                                                  <asp:CommandField ButtonType="Image" 
                                                   SelectImageUrl="~/ImagenesSistema/selecccionar.png" ShowSelectButton="True">
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
                                       <%--fingridmodal--%>
                                   </caption>
                                    </table>
                              <%--boton añadir--%>
                              <br />
                                <p class="text-center">
                                <strong><asp:TextBox  CssClass="form-control"  ID="tbcantidad"  runat="server" Height="24px" Width="100px" TextMode="number" Enabled="False"></asp:TextBox></strong>
                                </p>
                              <br />
                              <asp:Button ID="btnañadirproductomodal" runat="server"  CssClass="btn btn-success"  Text="Añadir" CausesValidation="False" Enabled="False" OnClick="btnañadirproductomodal_Click" />
                              
                          </asp:Panel>
                    </ContentTemplate>
                  </asp:UpdatePanel>
              </div>
              <div class="modal-footer">
                  <%--<div class="box-footer">
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  <asp:Button ID="btnregistrar" CssClass="btn btn-info" runat="server" Text="Registrar" OnClick="btnregistrar_Click" />
                
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  <asp:Button ID="btncancelar" runat="server" CssClass="btn btn-default" Text="Cancelar" CausesValidation="False" />
                
              </div>--%>
              </div>
            </div>
            <!-- /.modal-content -->
          </div>
          <!-- /.modal-dialog -->
        </div>
        <!-- /.modal -->
<%--inicio boxs--%>
    <div class="box box-default">
        <div class="box-header with-border">
            <h3 class="box-title">Datos de la Factura de Venta </h3>
            <div class="box-tools pull-right">
<%--                boton minimizar y cerrar--%>
<%--                <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>--%>
            </div>
        </div>
        <!-- /.box-header -->
                <div class="box-body">
          <div class="row">
            <div class="col-md-6">
                <div class="form-group">
                  <label for="inputEmail3" class="col-sm-2 control-label" style="left: 0px; top: 0px; width: 114px">Fecha:</label>

                  <div class="col-sm-10" style="left: 0px; top: 0px; width: 253px">
                      <asp:Label ID="lblFecha" CssClass="text-muted" runat="server" Text="HoraActual"></asp:Label>
                  </div>
                </div>
                    <br />
                <div class="form-group">
                  <label for="inputEmail3" class="col-sm-2 control-label" style="left: 0px; top: 0px; width: 114px; height: 20px;">Cliente:</label>

                  <div class="col-sm-10" style="left: 0px; top: 0px; width: 253px">
                        <asp:TextBox ID="tbproveedor" runat="server" Height="22px" Width="158px" Enabled="False" OnTextChanged="tbproveedor_TextChanged">Seleccione un proveedor</asp:TextBox>
                         <asp:Button ID="btnselecproveedor" runat="server" CssClass="btn btn-success" Text="..." CausesValidation="False" OnClick="btnselecproveedor_Click" Width="39px" Height="30px" />
                
                  </div>
                </div>
                <div class="form-group">
                            <br />
                            <br />
                        </div>
              <!-- /.form-group -->
            </div>
            <!-- columna2 inicio/.col -->
            <div class="col-md-6">
                <div class="form-group">
                  <label for="inputEmail3" class="col-sm-2 control-label" style="left: 0px; top: 0px; width: 114px">Hora:</label>

                  <div class="col-sm-10" style="left: 0px; top: 0px; width: 253px">
                      <asp:Label ID="lblhora" CssClass="text-muted" runat="server" Text="HoraActual"></asp:Label>
                  </div>
                </div>
                    <br />
                <div class="form-group">
                  <label for="inputEmail3" class="col-sm-2 control-label" style="left: 0px; top: 0px; width: 114px">Nro Factura:</label>

                  <div class="col-sm-10" style="left: 0px; top: 0px; width: 253px">
                      <asp:Label ID="lblnroOrden" CssClass="text-muted" runat="server" Text="numeroFactura"></asp:Label>
                  </div>
                </div>
                    <br />
                <div class="form-group">
                  <label for="inputEmail3" class="col-sm-2 control-label" style="left: 0px; top: 0px; width: 114px">Empleado:</label>

                  <div class="col-sm-10" style="left: 0px; top: 0px; width: 253px">
                      <asp:Label ID="lblempleado" CssClass="text-muted" runat="server" Text="EMPLEADO"></asp:Label>
                  </div>
                </div>
              <!-- /.form-group -->
                <asp:Label ID="lblerror" CssClass="error-text" runat="server"></asp:Label>
            </div>
            <!-- /.col -->
          </div>
          <!-- /.row -->
        </div>
        <!-- /.box-body -->
<%--<div class="box-footer">
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  <asp:Button ID="btnregistrar" CssClass="btn btn-info" runat="server" Text="Registrar" OnClick="btnregistrar_Click" />
                
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  <asp:Button ID="btncancelar" runat="server" CssClass="btn btn-default" Text="Cancelar" CausesValidation="False" />
                
              </div>--%>
    </div>

                      <%--panel detalle de orden--%>
    <asp:UpdatePanel ID="updetallefactura" runat="server">
        <ContentTemplate>
            <div class="row">
                          <div class="col-md-12">
                              <div class="box">
                                  <div class="box-header with-border" style="left: 0px; top: 0px; width: 898px;">
                                      <h3 class="box-title">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; Detalle de Factura</h3>
                                  </div>
                                  <div class="box-body">
              <!-- Date -->
                                      <div class="form-group">
                                          <asp:Button ID="btnañadirproducto" runat="server" 
                        CssClass="btn btn-success"  Text="Añadir Producto" CausesValidation="False" OnClick="btnañadirproducto_Click" />
               


                                          <br />
                                          &nbsp;
                                          <table class="nav-justified">
                                              <tr>
                                                  <td style="width: 70px">&nbsp;</td>
                                                  <td>
                                                      
                                <asp:GridView ID="griddetallefactura" runat="server" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CaptionAlign="Bottom" CellPadding="4" CellSpacing="1" Font-Size="Medium" ForeColor="Black" GridLines="Horizontal" Height="210px" HorizontalAlign="Justify" PageSize="6" style="margin-left: 107px; margin-bottom: 9px;" Width="425px" OnRowDeleting="griddetallefactura_RowDeleting">
                                    <Columns>
                                        <asp:BoundField DataField="ID" HeaderText="ID" />
                                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                                        <asp:BoundField DataField="Precio" HeaderText="Precio" />
                                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/ImagenesSistema/eliminar.png" ShowDeleteButton="True">
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
                                                      
                                                  </td>
                                              </tr>
                                          </table>

                  <br />

                  <br />
                                      </div>
                  <!-- /.description-block -->
                <br />
                                  </div>
                              </div>
              <!-- /.row -->
                          </div>
                             <div class="box-footer">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnregistrar" runat="server" CssClass="btn btn-info" Text="Registrar" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btncancelar" runat="server" CausesValidation="False" CssClass="btn btn-default" Text="Cancelar" />
                    <br />
                    <asp:Label ID="lblerroregistrar" CssClass="error-text" runat="server"></asp:Label>
                </div>
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>
            <!-- /.box-footer -->


</asp:Content>
<%@ Page Title="" Language="C#" MasterPageFile="~/GYMPaginasMaestras/PaginaMaestaGerente.Master" AutoEventWireup="true" CodeBehind="PagodeFacturaGerente.aspx.cs" Inherits="SistemasIIITHEGYM.PagodeFacturaGerente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Label ID="lblusuario" runat="server" Font-Bold="True" Font-Names="Arial Black" Font-Size="Small" ForeColor="White"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <script type ="text/javascript">
       
 function show()
    {
        document.write("<head runat='server'></head>");
    }
    </script>
    <section class="content-header">
                    <h1>Registrar Pago de Factura<small>TheGym</small> </h1>
       <br />
                </section>
    <div class="modal fade" id="modal-Detalle">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header">
                  <%--<asp:CommandField ButtonType="Image" DeleteImageUrl="~/ImagenesSistema/eliminar.png" ShowDeleteButton="True">
                                                  <ControlStyle Height="20px" Width="20px" />
                                                  </asp:CommandField>--%>                  <%--fingridmodal--%>
                <h4 class="modal-title">Detalle de factura:</h4>
              </div>
              <div class="modal-body">
                  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                      <ContentTemplate>
                          <asp:Panel ID="panel1" runat="server">
                                       <%--<asp:GridView ID="griddetallefactura" runat="server" AllowPaging="True"  AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CaptionAlign="Bottom" CellPadding="4" CellSpacing="1" Font-Size="Medium" ForeColor="Black" GridLines="Horizontal" Height="210px" HorizontalAlign="Justify" PageSize="4" ShowHeaderWhenEmpty="True" style="margin-left: 0px; margin-bottom: 9px;" Width="401px" OnSelectedIndexChanged="griddetallefactura_SelectedIndexChanged" >
                                           <EditRowStyle BorderColor="Black" BorderStyle="None" Font-Size="Small" />
                                           <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                           <HeaderStyle BackColor="#364E6F" Font-Bold="True" ForeColor="White" Height="20px" />
                                           <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                                           <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="220px" />
                                           <SelectedRowStyle BackColor="#6A8BB7" Font-Bold="True" ForeColor="White" />
                                           <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                           <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                           <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                           <SortedDescendingHeaderStyle BackColor="#242121" />
                                       </asp:GridView>--%>
                                        <div>
                                            <asp:Label runat="server" id="lblIdFact" Text="Id Factura:" ></asp:Label>
                                            <asp:TextBox runat="server" ID ="tbIdFact" ReadOnly="true"></asp:TextBox>
                                        </div>
                                        <br />
                                        <div>
                                            <asp:Label runat="server" id="lblTipo" Text="Tipo Comprobante:" ></asp:Label>
                                            <asp:TextBox runat="server" ID ="tbTipo" ReadOnly="true"></asp:TextBox>
                                        </div>
                                        <br />
                                        <div>
                                            <asp:Label runat="server" id="lblConcepto" Text="Concepto:" ></asp:Label>
                                            <asp:TextBox runat="server" ID ="tbConcepto" ReadOnly="true" Width="200px"></asp:TextBox>
                                        </div>
                                        <br />
                                        <div>
                                            <asp:Label runat="server" id="lblFecha" Text="Fecha:" ></asp:Label>
                                            <asp:TextBox runat="server" ID ="tbFecha" ReadOnly="true"></asp:TextBox>
                                        </div>
                                        <br />
                                        
                                <p class="text-center">
                                    <asp:Label ID="Lblerror1" ForeColor="Red" runat="server" Visible="false"></asp:Label>
                                <strong><asp:TextBox  CssClass="form-control"  ID="tbtotalFactura"  runat="server" Height="24px" Width="100px" TextMode="SingleLine" Enabled="False"></asp:TextBox></strong>
                                </p>
                              <br />
                              <asp:Button ID="Pagofactura" runat="server"  CssClass="btn btn-success"  Text="Pago de Factura" CausesValidation="False" OnClick="Pagofactura_Click" />
                                       <%--fingridmodal--%>
                                   </caption>
                                    </table>
                          </asp:Panel>
                     </ContentTemplate>
                  </asp:UpdatePanel>
              </div>
              <div class="modal-footer">
                  <%--inicio boxs--%>
              </div>
            </div>
            <!-- /.modal-content -->
          </div>
          <!-- /.modal-dialog -->
        </div>
      <div class="text-center">
          <asp:UpdatePanel ID="UpdatePanel2" runat="server">
              <ContentTemplate>
                  <asp:Panel ID="panelconsulta" runat="server">
        <%-- inicio contenedor busqueda--%>
                      <div class="box box-default" style="left: 0px; top: 0px; width: 109%">
        <div class="box-header with-border">
            <h3 class="box-title">Datos de Factura: </h3>
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
                  <label for="inputEmail3" class="col-sm-2 control-label" style="left: 0px; top: 0px; width: 114px">Tipo de Comprobante:</label>

                  <div class="col-sm-10" style="left: 0px; top: 0px; width: 253px">
                      <asp:DropDownList ID="ddlTipoComprobante" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTipoComprobante_SelectedIndexChanged" OnTextChanged="ddlTipoComprobante_TextChanged" Width="150px">
                                          </asp:DropDownList>
                                          
                  </div>
                </div>
                    <br />
                <br />
                <div class="form-group">
                  <label for="inputEmail3" class="col-sm-2 control-label" style="left: 0px; top: 0px; width: 114px">
                      <asp:Label ID="LblProveedor" runat="server" Text="Proveedor:" Visible="False"></asp:Label>
                  </label>

                  <div class="col-sm-10" style="left: 0px; top: 0px; width: 253px">
                      <asp:DropDownList ID="ddlProveedor" runat="server" Visible="False" Width="150px">
                                                      </asp:DropDownList>
                      <%--<asp:Label ID="Label1" CssClass="text-muted" runat="server" Text="HoraActual"></asp:Label>--%>
                  </div>
                </div>
              <!-- /.form-group -->
            </div>
            <!-- columna2 inicio/.col -->
            <div class="col-md-6">
                <div class="form-group">
                  <label for="inputEmail3" class="col-sm-2 control-label" style="left: 0px; top: 0px; width: 114px">
                      <asp:Label ID="LblServicio" runat="server" Text="Servicio:" Visible="False"></asp:Label>
                  </label>

                  <div class="col-sm-10" style="left: 0px; top: 0px; width: 253px">
                                                                            
                                                      <asp:DropDownList ID="ddlServicio" runat="server" Visible="False" Width="150px" OnSelectedIndexChanged="ddlServicio_SelectedIndexChanged">
                                                      </asp:DropDownList>
                                                  
                  </div>
                </div>
                    <br />                              
              <!-- /.form-group -->
                <asp:Label ID="lblerror" CssClass="error-text" runat="server"></asp:Label>
                &nbsp;&nbsp;&nbsp;
                <asp:Label ID="LblFiltro" runat="server" CssClass="error-text"></asp:Label>
            </div>
            <!-- /.col -->
          </div>
          <!-- /.row -->
        </div>
        <!-- /.box-body -->
<div class="box-footer">
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  <asp:Button ID="btnconsultar0" CssClass="btn btn-info" runat="server" Text="Consultar" OnClick="btnconsultar_Click" />
                
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                  
              </div>
    </div>




                      <div class="row">
                          <div class="col-md-12">
                          </div>
                      </div>
            <%--fin de contenedor busqueda inicio contenedor gridview--%>

                      <div class="row">
                          <div class="col-md-12">
                              <div class="box">
                                  <div class="box-header with-border" style="left: 0px; top: 0px; width: 1246px;">
                                      <h3 class="box-title">Ficha de Facturas</h3>
                                  </div>
                                  <div class="box-body">
              <!-- Date -->
                                      <div class="form-group">
                                          &nbsp;
                                          <asp:GridView ID="grid" runat="server" AllowSorting="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CaptionAlign="Bottom" CellPadding="4" CellSpacing="1" Font-Size="Medium" ForeColor="Black" GridLines="Horizontal" Height="210px" HorizontalAlign="Justify" OnSelectedIndexChanged="gridfacturas_SelectedIndexChanged" PageSize="5" ShowHeaderWhenEmpty="True" style="margin-left: 107px; margin-bottom: 9px;" Width="601px" AllowPaging="True" OnPageIndexChanging="grid_PageIndexChanging">
                                              <Columns>
                                                  <asp:CommandField ButtonType="Image" SelectImageUrl="~/ImagenesSistema/ver.png" ShowSelectButton="True">
                                                  <ControlStyle Height="20px" Width="20px" />
                                                  </asp:CommandField>
                                                  <%--<asp:CommandField ButtonType="Image" DeleteImageUrl="~/ImagenesSistema/eliminar.png" ShowDeleteButton="True">
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

                  <br />

                  <br />
                                      </div>
                  <!-- /.description-block -->
                <br />
                                  </div>
                              </div>
              <!-- /.row -->
                          </div>
                      </div>
            <!-- /.box-footer -->
                  </asp:Panel>
              </ContentTemplate>
          </asp:UpdatePanel>
      </div>
</asp:Content>

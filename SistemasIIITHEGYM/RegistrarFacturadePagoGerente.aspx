<%@ Page Title="" Language="C#" MasterPageFile="~/GYMPaginasMaestras/PaginaMaestaGerente.Master" AutoEventWireup="true" CodeBehind="RegistrarFacturadePagoGerente.aspx.cs" Inherits="SistemasIIITHEGYM.RegistrarFacturadePagoGerente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
        <asp:Label ID="lblusuario" runat="server" Font-Bold="True" Font-Names="Arial Black" Font-Size="Small" ForeColor="White"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<button type="button" class="btn btn-default pull-left" data-dismiss="modal">Close</button>
                <button type="button" class="btn btn-primary">Save changes</button>--%>
    <div class="modal fade" id="modal-ordencompra">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header">
                  <%--evitar error con el required validator--%><%--    TituloSuperior--%>
                <h4 class="modal-title">Seleccione una orden:</h4>
              </div>
              <div class="modal-body">
                  <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                      <ContentTemplate>
                          <asp:Panel ID="panelconsulta" runat="server">
                             <%--<asp:TextBox ID="tbnombreproveedor" runat="server" Height="21px" Width="371px" AutoPostBack="false"></asp:TextBox>--%>
                              <asp:DropDownList ID="ddlProveedor" runat="server" Height="30px" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="ddlProveedor_SelectedIndexChanged"></asp:DropDownList>
                               <table class="nav-justified" style="height: 48px">
                                   <caption>
                                       <br />
                                       <asp:Button ID="btnconsultarodenmodel" runat="server" CssClass="btn btn-info" Text="Consultar" OnClick="btnconsultarodenmodel_Click"  CausesValidation="False" />
                                       <br />
                                       <asp:Label ID="lblerrorordenmodal" runat="server" CssClass="error-text"></asp:Label>
                                       <br />
                                       <%--aqui esta el grid del modal para los proveedores--%>
                                       <asp:GridView ID="gridordenmodal" runat="server" AllowPaging="True" OnSelectedIndexChanged="gridordenmodal_SelectedIndexChanged"  AllowSorting="True"  AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CaptionAlign="Bottom" CellPadding="4" CellSpacing="1" Font-Size="Medium" ForeColor="Black" GridLines="Horizontal" Height="210px" HorizontalAlign="Justify" PageSize="4" ShowHeaderWhenEmpty="True" style="margin-left: 0px; margin-bottom: 9px;" Width="401px" >
                                           <Columns>
                                               <asp:BoundField DataField="Id_orden" HeaderText="ID" />
                                               <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                                               <asp:BoundField DataField="Total" HeaderText="Total" />
                                               <asp:CommandField ButtonType="Image" SelectImageUrl="~/ImagenesSistema/ver.png" ShowSelectButton="True">
                                               <ControlStyle Height="20px" Width="20px" />
                                               </asp:CommandField>
                                           </Columns>
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
                                       </asp:GridView>
                                       <br />
                                       <br />
                                       <asp:GridView ID="griddetalleordenmodal" runat="server" AllowPaging="True"  AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CaptionAlign="Bottom" CellPadding="4" CellSpacing="1" Font-Size="Medium" ForeColor="Black" GridLines="Horizontal" Height="210px" HorizontalAlign="Justify" PageSize="4" ShowHeaderWhenEmpty="True" style="margin-left: 0px; margin-bottom: 9px;" Width="401px" >
                                           <Columns>
                                               <asp:BoundField DataField="Id_producto" HeaderText="ID" />
                                               <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                               <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                                               <%--<asp:CommandField ButtonType="Image" SelectImageUrl="~/ImagenesSistema/selecccionar.png" ShowSelectButton="True">
                                               <ControlStyle Height="20px" Width="20px" />
                                               </asp:CommandField>--%>
                                           </Columns>
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
                                       </asp:GridView>
                                       <%--fingridmodal--%>
                                   </caption>
                                    </table>
                          </asp:Panel>
                     </ContentTemplate>
                  </asp:UpdatePanel>
              </div>
              <div class="modal-footer">
                  <%--                <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>--%>
              </div>
            </div>
            <!-- /.modal-content -->
          </div>
          <!-- /.modal-dialog -->
        </div>
    <%--input dinero--%>
             <div class="modal fade" id="modal-default">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header">
                  <%--fin input dinero--%>
                  <%--<span aria-hidden="true">&times;</span></button>--%>
                <h4 class="modal-title">THEGYM</h4>
              </div>
              <div class="modal-body">
                <p>¡Factura de Pago registrada exitosamente!&hellip;</p>
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
        <!-- /.modal -->



    <!-- Select2 -->
    <link rel="stylesheet" href="../../bower_components/select2/dist/css/select2.min.css">
        <%--evitar error con el required validator--%>
    <script type ="text/javascript">

 function show()
    {
        document.write("<head runat='server'></head>");
    }



    </script>
    <!-- Main content -->
<%--    TituloSuperior--%>
    <%--<section class="content-header">
                    <h1>Operaciones de caja <small>TheGym</small> </h1>
                </section>--%>
    <!-- SELECT2 EXAMPLE -->
    <div class="box box-default">
        <div class="box-header with-border">
            <h3 class="box-title">Registrar Factura de Pago </h3>
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
                  <label for="inputEmail3" class="col-sm-2 control-label" style="left: 0px; top: 0px; width: 114px">Empleado:</label>

                  <div class="col-sm-10" style="left: 0px; top: 0px; width: 253px">
                      <asp:Label ID="lblnombreusuario" CssClass="text-muted" runat="server" Text="APELLIDO, Nombre"></asp:Label>
                  </div>
                </div>
                    <br />
                                <table class="nav-justified">
                                    <tr>
                                        <td>
                                <div class="form-group">
                  <label for="inputEmail3" class="col-sm-2 control-label" style="left: 1px; top: -5px; width: 147px">Tipo Comprobante:</label></div>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>

                  <div class="col-sm-10" style="left: 0px; top: 0px; width: 253px">
                       <asp:DropDownList  CssClass="form-control"   ID="ddlTipoComprobante"  runat="server" Height="30px" Width="167px" AutoPostBack="True" OnSelectedIndexChanged="ddlTipoComprobante_SelectedIndexChanged"></asp:DropDownList>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlTipoComprobante" Display="None" ErrorMessage="Seleccione el tipo de Documento" SetFocusOnError="True"></asp:RequiredFieldValidator>
                      <ajaxToolkit:ValidatorCalloutExtender ID="RequiredFieldValidator5_ValidatorCalloutExtender" runat="server" BehaviorID="RequiredFieldValidator5_ValidatorCalloutExtender" TargetControlID="RequiredFieldValidator5">
                      </ajaxToolkit:ValidatorCalloutExtender>
                  </div>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                        <label for="inputEmail3" class="col-sm-2 control-label" style="left: 0px; top: 0px; width: 114px; height: 20px;">
                                            <asp:Label ID="LblServicios" runat="server" Text="Servicios:" Visible="False"></asp:Label>
                                            </label>
                                        </td>
                                        <td>
                <div class="form-group">
                                        <label for="inputEmail3" class="col-sm-2 control-label" style="left: 0px; top: 0px; width: 135px; height: 20px;">
                                        <asp:Label ID="LblOrdenCompra" runat="server" Text="Orden de Compra:" Visible="False" Width="159px"></asp:Label>
&nbsp;</label>
                                    </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                                <div class="col-sm-10" style="left: 0px; top: 0px; width: 253px" __designer:mapid="22b">
                                                   <asp:DropDownList  CssClass="form-control"   ID="ddlservicio"  runat="server" Height="30px" Width="128px" Visible="False"></asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator91" runat="server" ControlToValidate="ddlservicio" Display="None" ErrorMessage="Seleccione el tipo la Sucursal" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                    <ajaxToolkit:ValidatorCalloutExtender ID="RequiredFieldValidator91_ValidatorCalloutExtender" runat="server" BehaviorID="RequiredFieldValidator5_ValidatorCalloutExtender" TargetControlID="RequiredFieldValidator91">
                                                    </ajaxToolkit:ValidatorCalloutExtender>
                                                </div>
                                            </td>
                                        <td>
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <div class="col-sm-10" style="left: 0px; top: 0px; width: 253px">
                                                    <asp:TextBox ID="tbordencompra" runat="server" AutoPostBack="True" Enabled="False" Font-Size="Small" Height="22px" ReadOnly="True" Visible="False" Width="128px">Seleccione una orden</asp:TextBox>
                                                    <asp:Button ID="btnordencomprapopup" runat="server" CausesValidation="False" CssClass="btn btn-success" Height="30px" OnClick="btnordencomprapopup_Click" Text="..." Visible="False" Width="39px" />
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        </td>
                                    </tr>
                </table>
                <br />
             <br />
                <br />
                                <br />
                <div class="form-group">
                  <label for="inputEmail3" class="col-sm-2 control-label" style="left: 0px; top: 10px; width: 128px">Total:</label>
                 <%--input dinero--%>
                 <div class="input-group" style="left: 0px; top: 0px; width: 320px">
                <span class="input-group-addon">$</span>
                     <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                         <ContentTemplate>
                             <asp:TextBox ID="tbmonto" runat="server" Cssclass="form-control" ReadOnly="True" style="left: 0px; top: 0px; height: 42px; width: 33%" TextMode="Number"></asp:TextBox>
                         </ContentTemplate>
                     </asp:UpdatePanel>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="tbmonto" Display="None" ErrorMessage="Ingrese un monto" SetFocusOnError="True"></asp:RequiredFieldValidator>
                      <ajaxToolkit:ValidatorCalloutExtender ID="RequiredFieldValidator12_ValidatorCalloutExtender" runat="server" BehaviorID="RequiredFieldValidator12_ValidatorCalloutExtender" TargetControlID="RequiredFieldValidator12">
                      </ajaxToolkit:ValidatorCalloutExtender>
              </div>
                 <%--fin input dinero--%>
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
                  <label for="inputEmail3" class="col-sm-2 control-label" style="left: 0px; top: 0px; width: 114px">Sucursal:</label>

                  <div class="col-sm-10" style="left: 0px; top: 0px; width: 253px">
                      <asp:Label ID="lblsucursal" CssClass="text-muted" runat="server" Text="SUCURSAL"></asp:Label>
                  </div>
                </div>
                    <br />
               <br />
              <!-- /.form-group -->
                <asp:Label ID="lblerror" CssClass="error-text" runat="server"></asp:Label>
            </div>
            <!-- /.col -->
          </div>
          <!-- /.row -->
        </div>
        <!-- /.box-body -->
<div class="box-footer">
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  <asp:Button ID="btnregistrar" CssClass="btn btn-info" runat="server" Text="Registrar" OnClick="btnregistrar_Click" />
                
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  <asp:Button ID="btncancelar" runat="server" CssClass="btn btn-default" Text="Cancelar" CausesValidation="False" OnClick="btncancelar_Click" />
                
              </div>
    </div>
    <!-- /.box -->
</asp:Content>

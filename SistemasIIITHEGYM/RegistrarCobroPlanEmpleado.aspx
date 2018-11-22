<%@ Page Title="" Language="C#" MasterPageFile="~/GYMPaginasMaestras/PaginaMaestraEmpleado.Master" AutoEventWireup="true" CodeBehind="RegistrarCobroPlanEmpleado.aspx.cs" Inherits="SistemasIIITHEGYM.RegistrarCobroPlanEmpleado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Label ID="lblusuario" runat="server" Font-Bold="True" Font-Names="Arial Black" Font-Size="Small" ForeColor="White"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="EstilosCSS.css" rel="stylesheet" />

     <%--modal para el registro exitoso--%>
             <div class="modal fade" id="modal-default">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header">
                <%--<button type="button" class="close" data-dismiss="modal" aria-label="Close">--%>
                  <%--<span aria-hidden="true">&times;</span></button>--%>
                <h4 class="modal-title">THEGYM</h4>
              </div>
              <div class="modal-body">
                <p>¡Cobro registrado exitosamente!&hellip;</p>
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


    <script type ="text/javascript">

 function show()
    {
        document.write("<head runat='server'></head>");
    }
    </script>
        
                    <section class="content-header">
      <h1>
        Cobro de Planes
        <small>TheGym</small>
      </h1>
    </section>
    <div class="modal fade" id="modal-cliente">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header">
                  <%--aqui esta el grid del modalpara los productos--%>                  <%--fingridmodal--%>
                <h4 class="modal-title">Seleccione un Cliente:</h4>
              </div>
              <div class="modal-body">
                  <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                      <ContentTemplate>
                          <asp:Panel ID="panelconsulta" runat="server">
                             <asp:TextBox ID="tbnombrcliente" runat="server" Height="21px" Width="371px"></asp:TextBox>
                               <table class="nav-justified" style="height: 48px">
                                   <caption>
                                       <br />
                                       <asp:Button ID="btnconsultarclientemodal" runat="server" CssClass="btn btn-info" Text="Consultar" OnClick="btnconsultarclientemodal_Click"  CausesValidation="False" />
                                       <br />
                                       <asp:Label ID="lblerrorconsultarclientemodal" runat="server" CssClass="error-text"></asp:Label>
                                       <br />
                                       <%--aqui esta el grid del modal para los proveedores--%>
                                       <asp:GridView ID="gvclientemodal" runat="server" OnPageIndexChanging="gvclientemodal_PageIndexChanging" OnSelectedIndexChanged="gvclientemodal_SelectedIndexChanged" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CaptionAlign="Bottom" CellPadding="4" CellSpacing="1" Font-Size="Medium" ForeColor="Black" GridLines="Horizontal" Height="210px" HorizontalAlign="Justify" PageSize="4" ShowHeaderWhenEmpty="True" style="margin-left: 0px; margin-bottom: 9px;" Width="401px" >
                                           <Columns>
                                               <asp:BoundField DataField="Id_cliente" HeaderText="ID" />
                                               <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                               <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                                               <asp:CommandField ButtonType="Image" SelectImageUrl="~/ImagenesSistema/editargrid.png" ShowSelectButton="True">
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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <%--inicio panel de edicion--%>
            <asp:Panel ID="paneldatosdecobro" runat="server" Height="1859px">
                  <!-- SELECT2 EXAMPLE -->
    <div class="box box-default">
        <div class="box-header with-border">
            <h3 class="box-title">Datos de Cobro</h3>
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
                  <label for="inputEmail3" class="col-sm-2 control-label" style="left: 0px; top: 0px; width: 114px">Cliente:</label>

                  <div class="col-sm-10" style="left: 0px; top: 0px; width: 253px">
                      <asp:TextBox ID="tbcliente" runat="server" AutoPostBack="True" Enabled="False" Height="19px" ReadOnly="True" Width="141px">Seleccione un cliente</asp:TextBox>
                      &nbsp;
                                <asp:Button ID="btnseleccioncliente" runat="server" CausesValidation="False" CssClass="btn btn-success" Height="30px" Text="..." Width="39px" OnClick="btnseleccioncliente_Click" />
                      &nbsp;
                  </div>
                </div>
                    <br />
                <br />
                <div class="form-group">
                  <label for="inputEmail3" class="col-sm-2 control-label" style="left: 0px; top: 0px; width: 127px">Monto total:</label>
                 <%--input dinero--%>
                 <div class="input-group" style="left: 0px; top: 0px; width: 320px">
                <span class="input-group-addon">$</span>
                     <asp:TextBox ID="tbmonto" Cssclass="form-control" runat="server" style="left: 0px; top: 0px; height: 42px; width: 37%" ReadOnly="True"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="tbmonto" Display="None" ErrorMessage="Ingrese un monto" SetFocusOnError="True"></asp:RequiredFieldValidator>
                      <ajaxToolkit:ValidatorCalloutExtender ID="RequiredFieldValidator12_ValidatorCalloutExtender" runat="server" BehaviorID="RequiredFieldValidator12_ValidatorCalloutExtender" TargetControlID="RequiredFieldValidator12">
                      </ajaxToolkit:ValidatorCalloutExtender>
              </div>
                 <%--fin input dinero--%>
                </div>
             <br />
            </div>
            <!-- columna2 inicio/.col -->
            <div class="col-md-6">
                <div class="form-group">
                  <label for="inputEmail3" class="col-sm-2 control-label" style="left: 0px; top: 0px; width: 114px">Hora:</label>

                  <div class="col-sm-10" style="left: 0px; top: 0px; width: 253px">
                      <asp:Label ID="lblhora" CssClass="text-muted" runat="server" Text="HoraActual"></asp:Label>
                  </div>
                </div>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <br />
                        <div class="form-group">
                            <label class="col-sm-2 control-label" for="inputEmail3" style="left: 0px; top: 0px; width: 114px">
                            Plan:</label>
                            <div class="col-sm-10" style="left: 0px; top: 0px; width: 253px">
                                <asp:DropDownList ID="ddlplan" runat="server" AutoPostBack="True" Cssclass="form-control" OnSelectedIndexChanged="ddlplan_SelectedIndexChanged" Width="170px">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlplan" Display="None" ErrorMessage="Seleccione un plan" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" BehaviorID="RequiredFieldValidator3_ValidatorCalloutExtender" TargetControlID="RequiredFieldValidator3">
                                </ajaxToolkit:ValidatorCalloutExtender>
                            </div>
                        </div>
                        <br />
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>
                                <div class="form-group">
                                    <label class="col-sm-2 control-label" for="inputEmail3" style="left: 0px; top: 0px; width: 114px">
                                    Forma de Pago:</label>
                                    <div class="col-sm-10" style="left: 0px; top: 0px; width: 253px">
                                        <asp:DropDownList ID="ddlformadepago" runat="server" AutoPostBack="True" Cssclass="form-control" OnSelectedIndexChanged="ddlformadepago_SelectedIndexChanged" Width="170px">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator45" runat="server" ControlToValidate="ddlformadepago" Display="None" ErrorMessage="Seleccione una forma de pago" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                        <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender45" runat="server" BehaviorID="RequiredFieldValidator45_ValidatorCalloutExtender" TargetControlID="RequiredFieldValidator45">
                                        </ajaxToolkit:ValidatorCalloutExtender>
                                    </div>
                                    <br />
                                    <br />
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div class="form-group">
                            <label class="col-sm-2 control-label" for="inputEmail3" style="left: -4px; top: 18px; width: 131px">
                            <asp:Label ID="lblComprobante" runat="server" Text="Nº Comprobante:" Visible="False"></asp:Label>
                            </label>
                            <br />
                            <br />
                            <br />
                            &nbsp;<div class="col-sm-10" style="left: -16px; top: 0px; width: 253px">
                                <asp:TextBox ID="TbComprobante" runat="server" Visible="False"></asp:TextBox>
                            </div>
                        </div>
                        <asp:Label ID="Label1" runat="server" CssClass="error-text"></asp:Label>
                        <br />
                        <br />
                        <asp:Button ID="btngenerarcomprobante" runat="server" CssClass="btn btn-success" OnClick="btngenerarcomprobante_Click" Text="Generar Comprobante" Width="177px" CausesValidation="False" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnvolver" runat="server" CausesValidation="False" CssClass="btn btn-default" OnClick="btnvolver_Click" Text="Volver" />
                    </ContentTemplate>
                </asp:UpdatePanel>
                    <br />
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
                
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                  
              </div>
    </div>
    <!-- /.box -->
            </asp:Panel>
    <%--inicio panel de consulta--%>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

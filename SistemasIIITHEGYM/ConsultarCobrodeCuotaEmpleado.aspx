<%@ Page Title="" Language="C#" MasterPageFile="~/GYMPaginasMaestras/PaginaMaestraEmpleado.Master" AutoEventWireup="true" CodeBehind="ConsultarCobrodeCuotaEmpleado.aspx.cs" Inherits="SistemasIIITHEGYM.ConsultarCobrodeCuotaEmpleado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Label ID="lblusuario" runat="server" Font-Bold="True" Font-Names="Arial Black" Font-Size="Small" ForeColor="White"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                <script type="text/javascript">

       
 function show()
    {
        document.write("<head runat='server'></head>");
 }
                    </script>

                            <asp:Panel ID="panelconsulta" runat="server">
        <%-- inicio contenedor busqueda--%>
                <div class="row">
                    <div class="col-md-12">
                        <div class="box">
                            <div class="box-header with-border" style="left: 0px; top: 0px; width: 794px;">
                                <h3 class="box-title">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Consultar Cobro de Cuotas&nbsp;</h3>
                            </div>
                            <div class="box-body">
                                <div class="form-group">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;<asp:TextBox ID="tbbusqueda" runat="server" Height="21px" Width="371px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbbusqueda" Display="None" ErrorMessage="Indique un cliente" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    <ajaxToolkit:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender" runat="server" BehaviorID="RequiredFieldValidator1_ValidatorCalloutExtender" TargetControlID="RequiredFieldValidator1">
                                    </ajaxToolkit:ValidatorCalloutExtender>
                  <br />
                                    <table class="nav-justified" style="height: 48px">
                                        <tr>
                                            <td class="modal-sm" style="width: 429px">&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                                            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <br />
                                                &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnconsultar" runat="server" CssClass="btn btn-info" OnClick="btnconsultar_Click" Text="Consultar" />
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:Label ID="lblerror" runat="server" CssClass="error-text"></asp:Label>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            <%--fin de contenedor busqueda inicio contenedor gridview--%>

                      <div class="row">
                          <div class="col-md-12">
                              <div class="box">
                                  <div class="box-header with-border" style="left: 0px; top: 0px; width: 830px;">
                                      <h3 class="box-title" style="width: 827px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; Ficha de Cobro de Cuotas&nbsp;&nbsp;&nbsp; </h3>
                                  </div>
                                  <div class="box-body">
              <!-- Date -->
                                      <div class="form-group">
                                          &nbsp;
                                          <asp:GridView ID="gridcuota" runat="server" AllowSorting="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CaptionAlign="Bottom" CellPadding="4" CellSpacing="1" Font-Size="Medium" ForeColor="Black" GridLines="Horizontal" Height="210px" HorizontalAlign="Justify" PageSize="6" ShowHeaderWhenEmpty="True" style="margin-left: 235px; margin-bottom: 9px;" Width="601px" OnSelectedIndexChanged="gridcuota_SelectedIndexChanged" DataKeyNames="Id_cuota">
                                              <Columns>
                                                   <asp:CommandField ButtonType="Image" SelectImageUrl="~/ImagenesSistema/ver.png" ShowSelectButton="True">
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
                <asp:Panel ID="paneldatosdecobro" runat="server" Height="1859px">
                    <!-- SELECT2 EXAMPLE -->
                    <div class="box box-default">
                        <div class="box-header with-border" style="left: 0px; top: 0px">
                            <h3 class="box-title">Datos de Cobro</h3>
                            <div class="box-tools pull-right">
                                <%--                boton minimizar y cerrar--%><%--                <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>--%>
                            </div>
                        </div>
                        <!-- /.box-header -->
                        <div class="box-body">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="inputEmail3" style="left: 0px; top: 0px; width: 114px">
                                        Fecha:</label>
                                        <div class="col-sm-10" style="left: 0px; top: 0px; width: 253px">
                                            <asp:Label ID="lblFecha" runat="server" CssClass="text-muted" Text="HoraActual"></asp:Label>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="inputEmail3" style="left: 0px; top: 0px; width: 114px">
                                        Cliente:</label>
                                        <div class="col-sm-10" style="left: 0px; top: 0px; width: 253px">
                                            <asp:Label ID="lblnombrecliente" runat="server" CssClass="text-muted" Text="APELLIDO, Nombre"></asp:Label>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="inputEmail3" style="left: 0px; top: 0px; width: 114px">
                                        Monto total:</label> <%--input dinero--%>
                                        <div class="input-group" style="left: 0px; top: 0px; width: 320px">
                                            <span class="input-group-addon">$</span>
                                           <asp:Label ID="lblmonto" runat="server" CssClass="text-muted" Text="MONTO"></asp:Label>
                                        </div>
                                        <%--fin input dinero--%>
                                    </div>
                                    <br />
                                    <!-- /.form-group -->
                                </div>
                                <!-- columna2 inicio/.col -->
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="inputEmail3" style="left: 0px; top: 0px; width: 114px">
                                        Hora:</label>
                                        <div class="col-sm-10" style="left: 0px; top: 0px; width: 253px">
                                            <asp:Label ID="lblhora" runat="server" CssClass="text-muted" Text="HoraActual"></asp:Label>
                                        </div>
                                    </div>
                                            <br />
                                            <div class="form-group">
                                                <label class="col-sm-2 control-label" for="inputEmail3" style="left: 0px; top: 0px; width: 114px">
                                                Plan:</label>
                                                <div class="col-sm-10" style="left: 0px; top: 0px; width: 253px">
                                                    <asp:Label ID="lblplan" runat="server" CssClass="text-muted" Text="PLAN"></asp:Label>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="form-group">
                                                <label class="col-sm-2 control-label" for="inputEmail3" style="left: 0px; top: 0px; width: 114px">
                                                Vencimiento:</label>
                                                <div class="col-sm-10" style="left: 0px; top: 0px; width: 253px">
                                                    <asp:Label ID="lblvencimiento" runat="server" CssClass="text-muted" Text="VENCIMIENTO"></asp:Label>
                                                </div>
                                            </div>
                                            <br />
                                            <br />
                                            <!-- /.form-group -->
                                            <asp:Label ID="lblerrorimpresion" runat="server" CssClass="error-text"></asp:Label>
                                    <br />
                                </div>
                                <!-- /.col -->
                            </div>
                            <!-- /.row -->
                        </div>
                        <!-- /.box-body -->
                
                        <div class="box-footer">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnimprimir" runat="server" CssClass="btn btn-info" Text="Imprimir Comprobante" OnClick="btnimprimir_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnvolver" runat="server" CausesValidation="False" CssClass="btn btn-default" Text="Volver" />
                        </div>
                    </div>
                    <!-- /.box -->
                </asp:Panel>

</asp:Content>

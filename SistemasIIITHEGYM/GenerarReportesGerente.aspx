<%@ Page Title="" Language="C#" MasterPageFile="~/GYMPaginasMaestras/PaginaMaestaGerente.Master" AutoEventWireup="true" CodeBehind="GenerarReportesGerente.aspx.cs" Inherits="SistemasIIITHEGYM.GenerarReportesGerente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="EstilosCSS.css" rel="stylesheet" />
    <script type ="text/javascript">
       
 function show()
    {
        document.write("<head runat='server'></head>");
    }
    </script>



    
                <section class="content-header">
                    <h1>Reporte de Capital <small>TheGym</small> </h1>
                </section>
                <%--panel de datos generales rutina--%>
    <asp:Panel ID="panelreporte" runat="server">
    <div class="box box-default">
                    <div class="box-header with-border">
                        <h3 class="box-title">Datos&nbsp;capital </h3>
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
                                    Fecha Inicio:</label>
                                    <div class="col-sm-10" style="left: 0px; top: 0px; width: 253px">
                                        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" Height="24px" Width="156px" TextMode="Date"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox1" Display="None" ErrorMessage="Ingrese fecha inicio" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                        <ajaxToolkit:ValidatorCalloutExtender ID="validadornombre" runat="server" BehaviorID="validadornombre" TargetControlID="RequiredFieldValidator2">
                                        </ajaxToolkit:ValidatorCalloutExtender>
                                    </div>
                                </div>
                                <br />
                                <br />
                                <label class="col-sm-2 control-label" for="inputEmail3" style="left: 0px; top: 0px; width: 114px">
                                Capital:</label><div class="col-sm-10" style="left: 0px; top: 0px; width: 253px">
                                    <asp:DropDownList ID="ddlcapital" runat="server" CssClass="form-control" Height="32px" OnSelectedIndexChanged="ddlcapital_SelectedIndexChanged" Width="128px" AutoPostBack="True">
                                        <asp:ListItem>Ingreso</asp:ListItem>
                                        <asp:ListItem>Egreso</asp:ListItem>
                                        <asp:ListItem>Todo</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <br />
                                <br />
                                <br />
                                <div class="form-group">
                                    <label class="col-sm-2 control-label" for="inputEmail3" style="left: 0px; top: 0px; width: 114px">
                                    Concepto:</label>
                                    <div class="col-sm-10" style="left: 0px; top: 0px; width: 253px">
                                     <asp:DropDownList ID="ddlconcepto" runat="server" Cssclass="form-control" Width="159px">
                                            <asp:ListItem>Todo</asp:ListItem>
                                            </asp:DropDownList>
                                    </div>
                                </div>
                                <br />
                              
                            
                            </div>
                            <!-- columna2 inicio/.col -->
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="col-sm-2 control-label" for="inputEmail3" style="left: 0px; top: 0px; width: 114px">
                                    Fecha Fin:</label>
                                    <div class="col-sm-10" style="left: 0px; top: 0px; width: 253px">
                                        <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" Height="24px" Width="156px" TextMode="Date"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox2" Display="None" ErrorMessage="Ingrese fin" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                        <ajaxToolkit:ValidatorCalloutExtender ID="RequiredFieldValidator3_ValidatorCalloutExtender" runat="server" BehaviorID="validadornombre" TargetControlID="RequiredFieldValidator3">
                                        </ajaxToolkit:ValidatorCalloutExtender>
                                    </div>
                                </div>
                                <br />
                                <br />
                
              
                                
                            
                                <!-- /.form-group -->
                                <asp:Label ID="Label1" runat="server" CssClass="error-text"></asp:Label>
                            </div>
                            <!-- /.col -->
                        </div>
                        <!-- /.row -->
                    </div>
                    <!-- /.box-body --><%--pie con botones registrar--%>
                    <div class="box-footer">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnaplicar" runat="server" CssClass="btn btn-info"  Text="Aplicar" OnClick="btnaplicar_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </div>
                </div>
        </asp:Panel>
                <!-- Horizontal Form -->
    <asp:Panel ID="paneldetalle" runat="server">
                    <div class="box" style="left: 0px; top: 0px; height: 762px">
                    <div class="box-header with-border">
                        <h3 class="box-title">Reporte</h3>
                        <br />
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <!-- ./box-body -->
                        <asp:GridView ID="gridreportes" runat="server" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CaptionAlign="Bottom" CellPadding="4" CellSpacing="1" Font-Size="Medium" ForeColor="Black" GridLines="Horizontal" Height="210px" HorizontalAlign="Justify" ShowHeaderWhenEmpty="True" style="margin-left: 107px; margin-bottom: 9px;" Width="800px" AllowPaging="True" OnPageIndexChanging="gridreportes_PageIndexChanging">
                            <Columns>
                            <%--<asp:BoundField DataField="ID_MovimientoCaja" HeaderText="Id Movimiento"/>--%>
                            <asp:BoundField DataField="descripcion" HeaderText="Forma Pago"/>
                            <asp:BoundField DataField="Monto" HeaderText="Monto"/>
                            <asp:BoundField DataField="Estado" HeaderText="Capital"/>
                            <asp:BoundField DataField="Concepto" HeaderText="Concepto"/>
                            <asp:BoundField DataField="Comprobante" HeaderText="Comprobante"/>
                            <asp:BoundField DataField="Dia" HeaderText="Dia"/>
                                
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
                        <div class="form-group">
                            <label class="col-sm-2 control-label" for="inputEmail3" style="left: 0px; top: 0px; width: 114px">
                            Ingreso:</label>
                            <div class="col-sm-10" style="left: 0px; top: 1px; width: 253px">
                                <asp:TextBox ID="tbingreso" runat="server" CssClass="form-control" Height="24px" ReadOnly="True" Width="156px" Visible="False"></asp:TextBox>
                            </div>
                        </div>
                        <br />
                        <div class="form-group">
                            <label class="col-sm-2 control-label" for="inputEmail3" style="left: 0px; top: 0px; width: 114px">
                            Egreso:</label>
                            <div class="col-sm-10" style="left: 0px; top: 0px; width: 253px">
                                <asp:TextBox ID="tbegreso" runat="server" CssClass="form-control" Height="24px" ReadOnly="True" Width="156px" Visible="False" ></asp:TextBox>
                            </div>
                        </div>
                        <br />
                        <div class="form-group">
                            <label class="col-sm-2 control-label" for="inputEmail3" style="left: 0px; top: 0px; width: 114px">
                            Total:</label>
                            <div class="col-sm-10" style="left: 0px; top: 0px; width: 253px">
                                <asp:TextBox ID="tbtotal" runat="server" CssClass="form-control" Height="24px" ReadOnly="True" Width="156px" Visible="False"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="box-footer">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button3" runat="server" CssClass="btn btn-info"  Text="Exportar" OnClick="Button1_Click" />
                        <asp:Button ID="Button2" runat="server" CausesValidation="False" CssClass="btn btn-default" Text="Cancelar" OnClick="Button2_Click" />
                </div>
                </div>
     
                <!--/.col (right) -->
                </div>
    </asp:Panel>
                <!-- /.row -->
                </section>

    
                <!-- /.content -->
                <!-- /.content-wrapper -->
    
  
        
    

</asp:Content>

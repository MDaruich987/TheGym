<%@ Page Title="" Language="C#" MasterPageFile="~/GYMPaginasMaestras/PaginaMaestaGerente.Master" AutoEventWireup="true" CodeBehind="RegistrarProductoGerente.aspx.cs" Inherits="SistemasIIITHEGYM.RegistrarProductoGerente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Label ID="lblusuario" runat="server" Font-Bold="True" Font-Names="Arial Black" Font-Size="Small" ForeColor="White"></asp:Label>
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
      <h1>
        Nuevo Producto
        <small>TheGym</small>
      </h1>
    </section>

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
                  <label for="inputEmail3" class="col-sm-2 control-label" style="left: 0px; top: 0px; width: 114px">Nombre:</label>

                  <div class="col-sm-10" style="left: 0px; top: 0px; width: 253px">
                       <asp:TextBox  CssClass="form-control" ID="tbnombre"  runat="server" Height="32px" Width="128px"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbnombre" Display="None" ErrorMessage="Ingrese el nombre" SetFocusOnError="True"></asp:RequiredFieldValidator>
                      <ajaxToolkit:ValidatorCalloutExtender ID="validadornombre" runat="server" BehaviorID="validadornombre" TargetControlID="RequiredFieldValidator1">
                      </ajaxToolkit:ValidatorCalloutExtender>
                  </div>
                </div>
                <br />
                <br />
                <div class="form-group">
                  <label for="inputEmail3" class="col-sm-2 control-label" style="left: 0px; top: 0px; width: 114px">Proveedor:</label>

                  <div class="col-sm-10" style="left: 0px; top: 0px; width: 253px">
                      <asp:DropDownList  CssClass="form-control"   ID="ddlproveedor"  runat="server" Height="32px" Width="135px"></asp:DropDownList>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlproveedor" Display="None" ErrorMessage="Seleccione un proveedor" SetFocusOnError="True"></asp:RequiredFieldValidator>
                      <ajaxToolkit:ValidatorCalloutExtender ID="RequiredFieldValidator5_ValidatorCalloutExtender" runat="server" BehaviorID="RequiredFieldValidator5_ValidatorCalloutExtender" TargetControlID="RequiredFieldValidator5">
                      </ajaxToolkit:ValidatorCalloutExtender>
                  </div>
                </div>
                <br />
                <br />
                <div class="form-group">
                  <label for="inputEmail3" class="col-sm-2 control-label" style="left: 0px; top: 0px; width: 114px">Precio:</label>
                 <%--input dinero--%>
                 <div class="input-group" style="left: 14px; top: 0px; width: 306px">
                <span class="input-group-addon">$</span>
                     <asp:TextBox ID="tbprecio" Cssclass="form-control" runat="server" style="left: -1px; top: 0px; height: 42px; width: 28%"></asp:TextBox>
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" CssClass="error-text" ControlToValidate="tbprecio" ErrorMessage="Ingrese un precio válido" ValidationExpression="^\d+$" Display="Dynamic"></asp:RegularExpressionValidator>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="tbprecio" Display="None" ErrorMessage="Ingrese un precio" SetFocusOnError="True"></asp:RequiredFieldValidator>
                      <ajaxToolkit:ValidatorCalloutExtender ID="RequiredFieldValidator12_ValidatorCalloutExtender" runat="server" BehaviorID="RequiredFieldValidator12_ValidatorCalloutExtender" TargetControlID="RequiredFieldValidator12">
                      </ajaxToolkit:ValidatorCalloutExtender>
              </div>
                 <%--fin input dinero--%>
                </div>
             <br />
                <br />
            </div>
            <!-- columna2 inicio/.col -->
            <div class="col-md-6">
                <div class="form-group">
                  <label for="inputEmail3" class="col-sm-2 control-label" style="left: 0px; top: 0px; width: 114px">Descripción:</label>

                  <div class="col-sm-10" style="left: 0px; top: 0px; width: 253px">
                      <asp:TextBox  CssClass="form-control"  ID="tbdescripcion"  runat="server" Height="42px" Width="220px" TextMode="MultiLine"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="tbdescripcion" Display="None" ErrorMessage="Ingrese una descripcion" SetFocusOnError="True"></asp:RequiredFieldValidator>
                      <ajaxToolkit:ValidatorCalloutExtender ID="RequiredFieldValidator10_ValidatorCalloutExtender" runat="server" BehaviorID="RequiredFieldValidator10_ValidatorCalloutExtender" TargetControlID="RequiredFieldValidator10">
                      </ajaxToolkit:ValidatorCalloutExtender>
                  </div>
                </div>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <br />
                        <br />
                        <div class="form-group">
                            <label class="col-sm-2 control-label" for="inputEmail3" style="left: 0px; top: 0px; width: 114px">
                            Stock:</label>
                            <div class="col-sm-10" style="left: 0px; top: 0px; width: 253px">
                                <asp:TextBox  CssClass="form-control"  ID="tbstock"  runat="server" Height="24px" Width="100px" TextMode="number"></asp:TextBox>

                      <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" CssClass="error-text" ControlToValidate="tbstock" ErrorMessage="Ingrese un stock válido" ValidationExpression="^\d+$" Display="Dynamic"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbstock" Display="None" ErrorMessage="Ingrese un stock" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" BehaviorID="RequiredFieldValidator3_ValidatorCalloutExtender" TargetControlID="RequiredFieldValidator3">
                                </ajaxToolkit:ValidatorCalloutExtender>
                            </div>
                        </div>
                        <br />
                        <div class="form-group">
                            <label class="col-sm-2 control-label" for="inputEmail3" style="left: 0px; top: 0px; width: 114px">
                            Stock Minimo:</label>
                            <div class="col-sm-10" style="left: 0px; top: 0px; width: 253px">
                                <asp:TextBox  CssClass="form-control"  ID="tbstockminimo"  runat="server" Height="24px" Width="100px" TextMode="number"></asp:TextBox>

                      <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" CssClass="error-text" ControlToValidate="tbstockminimo" ErrorMessage="Ingrese un stock minimo válido" ValidationExpression="^\d+$" Display="Dynamic"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator45" runat="server" ControlToValidate="tbstockminimo" Display="None" ErrorMessage="Ingrese un stock minimo" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender45" runat="server" BehaviorID="RequiredFieldValidator45_ValidatorCalloutExtender" TargetControlID="RequiredFieldValidator45">
                                </ajaxToolkit:ValidatorCalloutExtender>
                            </div>
                            <br />
                            <br />
                        </div>
                        <asp:Label ID="Label1" runat="server" CssClass="error-text"></asp:Label>
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
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
                  <asp:Button ID="btnregistrar" CssClass="btn btn-info" runat="server" Text="Registrar" OnClick="btnregistrar_Click1" />
                
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  <asp:Button ID="btncancelar" runat="server" CssClass="btn btn-default" Text="Cancelar" CausesValidation="False" />
                
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                  
              </div>
    </div>
    <!-- /.box -->
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

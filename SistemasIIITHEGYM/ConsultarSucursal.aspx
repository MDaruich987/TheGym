<%@ Page Title="" Language="C#" MasterPageFile="~/GYMPaginasMaestras/PaginaMaestaGerente.Master" AutoEventWireup="true" CodeBehind="ConsultarSucursal.aspx.cs" Inherits="SistemasIIITHEGYM.ConsultarSucursal" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="EstilosCSS.css" rel="stylesheet" />
    <script type ="text/javascript">
       
 function show()
    {
        document.write("<head runat='server'></head>");
    }
    </script>


    <asp:ScriptManager ID="SMAJAX" runat="server"></asp:ScriptManager>



    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="paneledicion" runat="server">
                <section class="content-header" style="left: 0px; top: 0px; height: 26px">
                    <h1>Registrar Sucursal <small>TheGym</small> </h1>
                </section>
     <!-- Main content -->
                <section class="content">
                    <div class="row">
        <!-- left column -->
                        <div class="col-md-6">
          <!-- general form elements -->
                            <div class="box box-primary">
                                <div class="box-header with-border">
                                    <h3 class="box-title" style="width: 390px">Información de Sucursal</h3>
                                </div>
            <!-- /.box-header -->
            <!-- form start -->
                                <div class="box-body">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="inputEmail3" style="left: 0px; top: 0px; width: 114px">
                                        Nombre:</label>
                                        <div class="col-sm-10" style="left: 0px; top: 0px; width: 253px">
                                            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" Height="24px" Width="128px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbnombre" Display="None" ErrorMessage="Ingrese el nombre" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <ajaxToolkit:ValidatorCalloutExtender ID="validadornombre" runat="server" BehaviorID="validadornombre" TargetControlID="RequiredFieldValidator1">
                                            </ajaxToolkit:ValidatorCalloutExtender>
                                        </div>
                                    </div>
                    <br />
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="inputEmail3" style="left: 0px; top: 0px; width: 114px">
                                        Teléfono:</label>
                                        <div class="col-sm-10" style="left: 0px; top: 0px; width: 258px">
                                            <asp:TextBox ID="tbtelefono" runat="server" CssClass="form-control" Height="24px" TextMode="Number" Width="128px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbtelefono" Display="None" ErrorMessage="Ingrese el teléfono" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <ajaxToolkit:ValidatorCalloutExtender ID="validadorapellido" runat="server" BehaviorID="validadorapellido" TargetControlID="RequiredFieldValidator2">
                                            </ajaxToolkit:ValidatorCalloutExtender>
                                        </div>
                                    </div>
                   <br />
                                </div>
              <!-- /.box-body -->

                            </div>
          <!-- /.box -->

          <!-- Form Element sizes -->
<%--          <div class="box box-success">
            <div class="box-header with-border">
              <h3 class="box-title">Información de contacto</h3>
            </div>
            <div class="box-body">           
                <div class="box-body">
                <div class="form-group">
                  <label for="inputEmail3" class="col-sm-2 control-label">Email</label>

                  <div class="col-sm-10">
                    <asp:TextBox  CssClass="form-control"  ID="tbemail"  runat="server" Height="24px" Width="128px" TextMode="email"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="tbemail" Display="None" ErrorMessage="Ingrese el el E-mail" SetFocusOnError="True"></asp:RequiredFieldValidator>
                      <ajaxToolkit:ValidatorCalloutExtender ID="RequiredFieldValidator7_ValidatorCalloutExtender" runat="server" BehaviorID="RequiredFieldValidator7_ValidatorCalloutExtender" TargetControlID="RequiredFieldValidator7">
                      </ajaxToolkit:ValidatorCalloutExtender>
                  </div>
                </div>
                    <br />
                <div class="form-group" style="margin-bottom: 5px">
                  <label for="inputPassword3" class="col-sm-2 control-label">Teléfono:</label>

                  <div class="col-sm-10">
                   <asp:TextBox  CssClass="form-control"  ID="tbtelefono"  runat="server" Height="24px" Width="128px" TextMode="number"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="tbtelefono" Display="None" ErrorMessage="Ingrese el teléfono" SetFocusOnError="True"></asp:RequiredFieldValidator>
                      <ajaxToolkit:ValidatorCalloutExtender ID="RequiredFieldValidator8_ValidatorCalloutExtender" runat="server" BehaviorID="RequiredFieldValidator8_ValidatorCalloutExtender" TargetControlID="RequiredFieldValidator8">
                      </ajaxToolkit:ValidatorCalloutExtender>
                  </div>
                </div>

                <div class="form-group">
                  <div class="col-sm-offset-2 col-sm-10">
                    <%--<div class="checkbox">
                      <label>
                        <input type="checkbox"> Remember me
                      </label>
                    &nbsp;&nbsp;&nbsp;&nbsp;</div>--%>
<%--                  </div>
                </div>
              </div>
              
            </div>--%>
            <!-- /.box-body -->
<%--          </div>--%>
          <!-- /.box -->
          <!-- /.box -->

                        </div>
        <!--/.col (left) -->
        <!-- right column -->
                        <div class="col-md-6">
          <!-- Horizontal Form -->
                            <div class="box box-info">
                                <div class="box-header with-border">
                                    <h3 class="box-title">Dirección:</h3>
                                </div>
            <!-- /.box-header -->
            <!-- form start -->
                                <div class="box-body">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="inputEmail3" style="left: 0px; top: 0px; width: 114px">
                                        Localidad:</label>
                                        <div class="col-sm-10" style="left: 0px; top: 0px; width: 258px">
                                            <asp:DropDownList ID="ddllocalidad" runat="server" CssClass="form-control" Height="24px" Width="128px">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddllocalidad" Display="None" ErrorMessage="Seleccione una localidad" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <ajaxToolkit:ValidatorCalloutExtender ID="RequiredFieldValidator9_ValidatorCalloutExtender" runat="server" BehaviorID="RequiredFieldValidator9_ValidatorCalloutExtender" TargetControlID="RequiredFieldValidator9">
                                            </ajaxToolkit:ValidatorCalloutExtender>
                                        </div>
                                    </div>
                   <br />
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="inputEmail3" style="left: 0px; top: 0px; width: 114px">
                                        Calle:</label>
                                        <div class="col-sm-10" style="left: 0px; top: 0px; width: 257px">
                                            <asp:TextBox ID="tbcalle" runat="server" CssClass="form-control" Height="24px" TextMode="number" Width="128px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="tbcalle" Display="None" ErrorMessage="Ingrese una calle" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <ajaxToolkit:ValidatorCalloutExtender ID="RequiredFieldValidator10_ValidatorCalloutExtender" runat="server" BehaviorID="RequiredFieldValidator10_ValidatorCalloutExtender" TargetControlID="RequiredFieldValidator10">
                                            </ajaxToolkit:ValidatorCalloutExtender>
                                        </div>
                                    </div>
                   <br />
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="inputEmail3" style="left: 0px; top: 0px; width: 114px">
                                        Barrio:</label>
                                        <div class="col-sm-10" style="left: 0px; top: 0px; width: 257px">
                                            <asp:TextBox ID="tbbarrio" runat="server" CssClass="form-control" Height="24px" TextMode="number" Width="128px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="tbbarrio" Display="None" ErrorMessage="Ingrese un barrio" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <ajaxToolkit:ValidatorCalloutExtender ID="RequiredFieldValidator11_ValidatorCalloutExtender" runat="server" BehaviorID="RequiredFieldValidator11_ValidatorCalloutExtender" TargetControlID="RequiredFieldValidator11">
                                            </ajaxToolkit:ValidatorCalloutExtender>
                                        </div>
                                    </div>
                  <br />
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="inputEmail3" style="left: 0px; top: 0px; width: 114px">
                                        Nº de casa:</label>
                                        <div class="col-sm-10" style="left: 0px; top: 0px; width: 257px">
                                            <asp:TextBox ID="tbnumerocasa" runat="server" CssClass="form-control" Height="24px" TextMode="number" Width="128px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="tbnumerocasa" Display="None" ErrorMessage="Ingrese un número" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <ajaxToolkit:ValidatorCalloutExtender ID="RequiredFieldValidator12_ValidatorCalloutExtender" runat="server" BehaviorID="RequiredFieldValidator12_ValidatorCalloutExtender" TargetControlID="RequiredFieldValidator12">
                                            </ajaxToolkit:ValidatorCalloutExtender>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-sm-offset-2 col-sm-10">
                    <%--<div class="checkbox">
                      <label>
                        <input type="checkbox"> Remember me
                      </label>
                    &nbsp;&nbsp;&nbsp;&nbsp;</div>--%>
                                        </div>
                                    </div>
                                </div>
              <!-- /.box-body -->
              <%--<div class="box-footer">
                <button type="submit" class="btn btn-default">Cancel</button>
                <button type="submit" class="btn btn-info pull-right">Sign in</button>
              </div>--%>
              <!-- /.box-footer -->
                            </div>
          <!-- /.box -->
          <!-- general form elements disabled -->
<%--          <div class="box box-warning">
            <div class="box-header with-border">
              <h3 class="box-title">Información de usuario</h3>
            </div>
            <!-- /.box-header -->
            <div class="box-body">
                                    <div class="form-group">
                  <label for="inputEmail3" class="col-sm-2 control-label">Usuario:</label>

                  <div class="col-sm-10" style="left: 0px; top: 0px">
                    <asp:TextBox  CssClass="form-control"  ID="tbusuario"  runat="server" Height="24px" Width="128px" TextMode="email"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="tbusuario" Display="None" ErrorMessage="Ingrese un usuario" SetFocusOnError="True"></asp:RequiredFieldValidator>
                      <ajaxToolkit:ValidatorCalloutExtender ID="RequiredFieldValidator13_ValidatorCalloutExtender" runat="server" BehaviorID="RequiredFieldValidator13_ValidatorCalloutExtender" TargetControlID="RequiredFieldValidator13">
                      </ajaxToolkit:ValidatorCalloutExtender>
                  </div>
                </div>
                    <br />
                <div class="form-group" style="margin-bottom: 5px">
                  <label for="inputPassword3" class="col-sm-2 control-label">Contraseña</label>

                  <div class="col-sm-10">
                   <asp:TextBox  CssClass="form-control"  ID="tbcontraseña"  runat="server" Height="24px" Width="128px" TextMode="password"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="tbcontraseña" Display="None" ErrorMessage="Ingrese una contraseña" SetFocusOnError="True"></asp:RequiredFieldValidator>
                  </div>
                </div>
            </div>
            <!-- /.box-body -->
          </div>--%>
          <!-- /.box -->
                        </div>
        <!--/.col (right) -->
                    </div>
      <!-- /.row -->
                </section>
    <!-- /.content -->
                <div class="box-footer">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btneditar" runat="server" CssClass="btn btn-info" OnClick="btneditar_Click" Text="Editar" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnvolver" runat="server" CausesValidation="False" CssClass="btn btn-default" OnClick="btnvolver_Click" Text="Volver" />
                </div>
            </asp:Panel>
            <asp:Panel ID="panelconsulta" runat="server">
        <%-- inicio contenedor busqueda--%>
                <div class="row">
                    <div class="col-md-12">
                        <div class="box">
                            <div class="box-header with-border" style="left: 0px; top: 0px; width: 607px;">
                                <h3 class="box-title">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Búsqueda de Sucursales&nbsp;</h3>
                            </div>
                            <div class="box-body">
                                <div class="form-group">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="tbnombre" runat="server" Height="21px" Width="371px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbnombre" Display="None" ErrorMessage="Indique una sucursal" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    <ajaxToolkit:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender" runat="server" BehaviorID="RequiredFieldValidator1_ValidatorCalloutExtender" TargetControlID="RequiredFieldValidator1">
                                    </ajaxToolkit:ValidatorCalloutExtender>
                  <br />
                                    <table class="nav-justified" style="height: 48px">
                                        <tr>
                                            <td class="modal-sm" style="width: 408px">&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                                            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnconsultar" runat="server" CssClass="btn btn-info" OnClick="btnconsultar_Click" Text="Consultar" />
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
                                  <div class="box-header with-border" style="left: 0px; top: 0px; width: 607px;">
                                      <h3 class="box-title">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; Ficha de Sucursales</h3>
                                  </div>
                                  <div class="box-body">
              <!-- Date -->
                                      <div class="form-group">
                                          &nbsp;
                                          <asp:GridView ID="gridplanes" runat="server" AllowSorting="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CaptionAlign="Bottom" CellPadding="4" CellSpacing="1" DataKeyNames="Id_actividad" Font-Size="Medium" ForeColor="Black" GridLines="Horizontal" Height="210px" HorizontalAlign="Justify" OnSelectedIndexChanged="gridplanes_SelectedIndexChanged" PageSize="6" ShowHeaderWhenEmpty="True" style="margin-left: 107px; margin-bottom: 9px;" Width="601px">
                                              <Columns>
                                                  <asp:CommandField ButtonType="Image" SelectImageUrl="~/ImagenesSistema/editargrid.png" ShowSelectButton="True">
                                                  <ControlStyle Height="20px" Width="20px" />
                                                  </asp:CommandField>
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



</asp:Content>

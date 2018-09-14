<%@ Page Title="" Language="C#" MasterPageFile="~/GYMPaginasMaestras/PaginaMaestraEmpleado.Master" AutoEventWireup="true" CodeBehind="ConsultarActividadEmpleado.aspx.cs" Inherits="SistemasIIITHEGYM.ConsultarActividadEmpleado" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="EstilosCSS.css" rel="stylesheet" />
    <%--fin de contenedor busqueda inicio contenedor gridview--%>
    <script type ="text/javascript">
        
       
 function show()
 {
     //evita error con los mensajes de jquery
     document.write("<head runat='server'></head>");
     
 }

     </script>


    <asp:ScriptManager ID="SMAJAX" runat="server"></asp:ScriptManager>


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
 <%--   inicio panel edicion--%>
            <asp:Panel ID="panelregistro" runat="server">
                <section class="content-header">
                    <h1>Consultar Actividad <small>TheGym</small> </h1>
                </section>
        <%--inicio main--%>
            <!-- Main content -->
                <section class="content">
                    <div class="row">
        <!-- left column -->
                        <div class="col-md-6">
          <!-- general form elements -->
                            <div class="box box-primary">
                                <div class="box-header with-border">
                                    <h3 class="box-title">Información de actividad</h3>
                                </div>
            <!-- /.cabeza de general  form -->
            <!-- contenido principal general form -->
                                <div class="box-body">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="inputEmail3" style="left: 0px; top: 0px; width: 114px">
                                        Nombre:</label>
                                        <div class="col-sm-10" style="left: 0px; top: 0px; width: 253px">
                                            <asp:TextBox ID="tbnombreedi" runat="server" CssClass="form-control" Enabled="False" Height="30px" Width="128px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="tbnombre" Display="None" ErrorMessage="Ingrese el nombre" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <ajaxToolkit:ValidatorCalloutExtender ID="validadornombre" runat="server" BehaviorID="validadornombre" TargetControlID="RequiredFieldValidator1">
                                            </ajaxToolkit:ValidatorCalloutExtender>
                                        </div>
                                    </div>
                    <br />

                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="inputEmail3" style="left: 0px; top: 0px; width: 114px">
                                        Sucursal:</label>
                                        <div class="col-sm-10" style="left: 0px; top: 0px; width: 258px">
                                            <asp:DropDownList ID="ddlsucursal" runat="server" CssClass="form-control" Enabled="False" Height="30px" Width="128px">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlsucursal" Display="None" ErrorMessage="Seleccione una sucursal" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <ajaxToolkit:ValidatorCalloutExtender ID="RequiredFieldValidator5_ValidatorCalloutExtender" runat="server" BehaviorID="RequiredFieldValidator5_ValidatorCalloutExtender" TargetControlID="RequiredFieldValidator5">
                                            </ajaxToolkit:ValidatorCalloutExtender>
                                        </div>
                                    </div>
                   <br />
                
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="inputEmail3" style="left: 0px; top: 0px; width: 114px">
                                        Descripción:</label>
                                        <div class="col-sm-10" style="left: 0px; top: 0px; width: 253px">
                                            <asp:TextBox ID="tbdescripcion" runat="server" CssClass="form-control" Enabled="False" Height="37px" textmode="MultiLine" Width="225px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbdescripcion" Display="None" ErrorMessage="Ingrese una descripción" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender10" runat="server" BehaviorID="validardescri" TargetControlID="RequiredFieldValidator2">
                                            </ajaxToolkit:ValidatorCalloutExtender>
                                        </div>
                                    </div>
                    <br />


                                </div>
              <!-- /cuerpo de general form -->

                            </div>
          <!-- /.box -->

                        </div>
        <!--/.col (left) -->
        <!-- right column -->
                        <div class="col-md-6">
          <!-- Horizontal Form -->
                            <div class="box box-info">
                                <div class="box-header with-border">
                                    <h3 class="box-title">Detalles de Actividad:</h3>
                                </div>
            <!-- /.box-header -->
            <!-- form start -->
                                <div class="box-body">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="inputEmail3" style="left: 0px; top: 0px; width: 114px">
                                        Profesor:</label>
                                        <div class="col-sm-10" style="left: 0px; top: 0px; width: 258px">
                                            <asp:DropDownList ID="ddlprofesor" runat="server" CssClass="form-control" Enabled="False" Height="30px" Width="128px">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlprofesor" Display="None" ErrorMessage="Seleccione un profesor" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" BehaviorID="RequiredFieldValidator3_ValidatorCalloutExtender" TargetControlID="RequiredFieldValidator3">
                                            </ajaxToolkit:ValidatorCalloutExtender>
                                        </div>
                                    </div>
                   <br />

                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="inputEmail3" style="left: 0px; top: 0px; width: 114px">
                                        Cupos:</label>
                                        <div class="col-sm-10" style="left: 0px; top: 0px; width: 258px">
                                            <asp:DropDownList ID="ddlcupos" runat="server" CssClass="form-control" Enabled="False" Height="30px" Width="128px">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlcupos" Display="None" ErrorMessage="Seleccione un cupo" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" BehaviorID="RequiredFieldValidator4_ValidatorCalloutExtender" TargetControlID="RequiredFieldValidator4">
                                            </ajaxToolkit:ValidatorCalloutExtender>
                                        </div>
                                    </div>
                   <br />
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="inputEmail3" style="left: 0px; top: 0px; width: 114px">
                                        Horario:</label>
                                        <div class="col-sm-10" style="left: 0px; top: 0px; width: 340px">
                                            <div class="form-group">
                                                <label class="col-sm-2 control-label" for="inputEmail3" style="left: 0px; top: 0px; width: 114px">
                                                De:</label>
                                                <div class="col-sm-10" style="left: 0px; top: 0px; width: 309px">
                                                    <asp:DropDownList ID="ddlhorarioinicio" runat="server" CssClass="form-control" Enabled="False" Height="30px" Width="128px">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlhorarioinicio" Display="None" ErrorMessage="Seleccione un cupo" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                    <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender8" runat="server" BehaviorID="RequiredFieldValidator7_ValidatorCalloutExtender" TargetControlID="RequiredFieldValidator7">
                                                    </ajaxToolkit:ValidatorCalloutExtender>
                                                </div>
                                            </div>
                                     <br />
                                            <div class="form-group">
                                                <label class="col-sm-2 control-label" for="inputEmail3" style="left: 0px; top: 0px; width: 114px">
                                                A:</label>
                                                <div class="col-sm-10" style="left: 0px; top: 0px; width: 306px">
                                                    <asp:DropDownList ID="ddlhorariofin" runat="server" CssClass="form-control" Enabled="False" Height="30px" Width="128px">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="ddlhorariofin" Display="None" ErrorMessage="Seleccione un cupo" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                    <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender12" runat="server" BehaviorID="RequiredFieldValidator12_ValidatorCalloutExtender" TargetControlID="RequiredFieldValidator12">
                                                    </ajaxToolkit:ValidatorCalloutExtender>
                                                </div>
                                            </div>
                                     <br />
                       <%-- <label for="inputEmail3" class="col-sm-2 control-label" style="left: 0px; top: 0px; width: 114px">De:</label>
                    <asp:DropDownList  CssClass="form-control"   ID="ddlhorarioinicio"  runat="server" Height="24px" Width="128px"></asp:DropDownList>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlhorarioinicio" Display="None" ErrorMessage="Seleccione un horario" SetFocusOnError="True"></asp:RequiredFieldValidator>
                      <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" BehaviorID="RequiredFieldValidator6_ValidatorCalloutExtender" TargetControlID="RequiredFieldValidator6">
                      </ajaxToolkit:ValidatorCalloutExtender>
                                            <label for="inputEmail3" class="col-sm-2 control-label" style="left: 0px; top: 0px; width: 114px">A:</label>
                    <asp:DropDownList  CssClass="form-control"   ID="ddlhorariofin"  runat="server" Height="24px" Width="128px"></asp:DropDownList>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlhorariofin" Display="None" ErrorMessage="Seleccione un horario" SetFocusOnError="True"></asp:RequiredFieldValidator>
                      <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" BehaviorID="RequiredFieldValidator7_ValidatorCalloutExtender" TargetControlID="RequiredFieldValidator7">
                      </ajaxToolkit:ValidatorCalloutExtender>--%>
                                        </div>
                                    </div>
                   <br />
                  

                                </div>
              <!-- /.box-body -->
                                <div class="box-footer">
                                </div>
              <!-- /.box-footer -->
                            </div>
          <!-- /.box -->
          <!-- general form elements disabled -->
          <!-- /.box -->
                        </div>
        <!--/.col (right) -->
                    </div>
      <!-- /.row -->
                </section>
    <!-- /.content -->
  <!-- /.content-wrapper -->
                <div class="box-footer">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btneditar" runat="server" CausesValidation="False" CssClass="btn btn-info" OnClick="btneditar_Click" Text="Editar" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnvolver" runat="server" CausesValidation="False" CssClass="btn btn-default" OnClick="btnvolver_Click" Text="Volver" Visible="False" />
                </div>
<%-- fin panel edicion--%>
            </asp:Panel>
            <asp:Panel ID="panelgeneral" runat="server">
        <%-- inicio contenedor busqueda--%>             
                
                <div class="row">
                    <div class="col-md-12">
                        <div class="box">
                            <div class="box-header with-border" style="left: 0px; top: 0px; width: 659px;">
                                <h3 class="box-title">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Búsqueda de Actividades&nbsp;</h3>
                            </div>
                            <div class="box-body">
                                <div class="form-group">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="tbnombre" runat="server" Height="21px" Width="371px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbnombre" Display="None" ErrorMessage="Indique una actividad" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    <ajaxToolkit:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender" runat="server" BehaviorID="RequiredFieldValidator1_ValidatorCalloutExtender" TargetControlID="RequiredFieldValidator1">
                                    </ajaxToolkit:ValidatorCalloutExtender>
                  <br />
                                    <table class="nav-justified" style="height: 48px">
                                        <tr>
                                            <td class="modal-sm" style="width: 408px">&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                                            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnconsultar" runat="server" CssClass="btn btn-info" OnClick="btnconsultar_Click" Text="Consultar" UseSubmitBehavior="False" />
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
                                      <h3 class="box-title" style="width: 666px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Ficha de Actividades</h3>
                                  </div>
                                  <div class="box-body">
              <!-- Date -->
                                      <div class="form-group">
                                          &nbsp;<table class="nav-justified">
                                              <tr>
                                                  <td style="width: 125px">&nbsp;</td>
                                                  <td>
                                                      <asp:GridView ID="gridactividades" runat="server" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CaptionAlign="Bottom" CellPadding="4" CellSpacing="1" DataKeyNames="Id_actividad" Font-Size="Medium" ForeColor="Black" GridLines="Horizontal" Height="210px" HorizontalAlign="Justify" OnSelectedIndexChanged="gridactividades_SelectedIndexChanged1" PageSize="6" ShowHeaderWhenEmpty="True" style="margin-left: 107px; margin-bottom: 9px;" Width="601px">
                                                          <Columns>
                                                              <asp:BoundField DataField="Id_actividad" HeaderText="ID" Visible="False" />
                                                              <asp:BoundField DataField="Actividad" HeaderText="Nombre" />
                                                              <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                                                              <asp:BoundField DataField="Profesor" HeaderText="Profesor" />
                                                              <asp:BoundField DataField="Sucursal" HeaderText="Sucursal" Visible="False" />
                                                              <asp:BoundField DataField="HoraInicio" HeaderText="Hora Inicio" Visible="False" />
                                                              <asp:BoundField DataField="HoraFin" HeaderText="Hora Fin" Visible="False" />
                                                              <asp:BoundField DataField="Cupos" HeaderText="Cupos" Visible="False" />
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
                                                  </td>
                                              </tr>
                                          </table>
                                          &nbsp;<br />

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

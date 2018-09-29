<%@ Page Title="" Language="C#" MasterPageFile="~/GYMPaginasMaestras/MasterPageEntrenador.Master" AutoEventWireup="true" CodeBehind="RegistrarRutinaEntrenador.aspx.cs" Inherits="SistemasIIITHEGYM.RegistrarRutinaEntrenador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Label ID="lblusuario" runat="server" Font-Bold="True" Font-Names="Arial Black" Font-Size="Small" ForeColor="White"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                         <section class="content-header" style="left: 0px; top: 0px; height: 26px">
      <h1>
          Registrar Rutina
        <small>TheGym</small>
      </h1>
    </section>
               <script type="text/javascript">

       
        function show()
          {
             document.write("<head runat='server'></head>");
                  }

    </script>
    <br />
    <br />
    <asp:UpdatePanel ID="updatepanelgeneral" runat="server">
        <ContentTemplate>
        <!-- SELECT2 EXAMPLE -->

            <div class="box box-default">
                <div class="box-header with-border">
                    <h3 class="box-title">Datos de Rutina </h3>
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
                                <label class="col-sm-2 control-label" for="inputEmail3" style="left: 0px; top: 0px; width: 114px">
                                Nombre:</label>
                                <div class="col-sm-10" style="left: 0px; top: 0px; width: 253px">
                                    <asp:TextBox ID="tbnombre" runat="server" CssClass="form-control" Height="24px" Width="128px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbnombre" Display="None" ErrorMessage="Ingrese el nombre" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    <ajaxToolkit:ValidatorCalloutExtender ID="validadornombre" runat="server" BehaviorID="validadornombre" TargetControlID="RequiredFieldValidator1">
                                    </ajaxToolkit:ValidatorCalloutExtender>
                                </div>
                            </div>
                            <br />
                        </div>
            <!-- columna2 inicio/.col -->
                        <div class="col-md-6">
                            <div class="form-group">
                                <label class="col-sm-2 control-label" for="inputEmail3" style="left: 0px; top: 0px; width: 114px">
                                 Cliente:</label>
                                <div class="col-sm-10" style="left: 0px; top: 0px; width: 253px">
                                    <asp:TextBox ID="tbdnicliente" runat="server"></asp:TextBox>
                                    <asp:Button ID="Button1" runat="server" Text="Verificar" />
                                    <br />
                                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                                    <br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbdnicliente" Display="None" ErrorMessage="Seleccione un cliente" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" BehaviorID="RequiredFieldValidator3_ValidatorCalloutExtender" TargetControlID="RequiredFieldValidator3">
                                    </ajaxToolkit:ValidatorCalloutExtender>
                                </div>
                            </div>
                            <br />
              <!-- /.form-group -->
                            <asp:Label ID="lblerror" runat="server" CssClass="error-text"></asp:Label>
                        </div>
            <!-- /.col -->
                    </div>
          <!-- /.row -->
                </div>
        <!-- /.box-body -->
                <%--pie con botones registrar--%>
                <%--<div class="box-footer">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnregistrar" runat="server" CssClass="btn btn-info" OnClick="btnregistrar_Click" Text="Registrar" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btncancelar" runat="server" CausesValidation="False" CssClass="btn btn-default" Text="Cancelar" />
                </div>--%>
            </div>
    <!-- /.box -->

            <%--segunda caja inicio--%>
            <div class="box">
            <div class="box-header with-border">
              <h3 class="box-title">Ejercicios de la rutina</h3>

              <%--<div class="box-tools pull-right">
                <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i>
                </button>
                <div class="btn-group">
                  <button type="button" class="btn btn-box-tool dropdown-toggle" data-toggle="dropdown">
                    <i class="fa fa-wrench"></i></button>
                  <ul class="dropdown-menu" role="menu">
                    <li><a href="#">Action</a></li>
                    <li><a href="#">Another action</a></li>
                    <li><a href="#">Something else here</a></li>
                    <li class="divider"></li>
                    <li><a href="#">Separated link</a></li>
                  </ul>
                </div>
                <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
              </div>--%>
            </div>
            <!-- /.box-header -->
            <div class="box-body">
              <div class="row">
                <div class="col-md-8">
                  <p class="text-center">
                    <strong></strong>
                  </p>
                  <asp:GridView ID="gridejerciciosrutina" runat="server" AllowSorting="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CaptionAlign="Bottom" CellPadding="4" CellSpacing="1" DataKeyNames="Id_sucursal" Font-Size="Medium" ForeColor="Black" GridLines="Horizontal" Height="188px" HorizontalAlign="Justify" PageSize="6" ShowHeaderWhenEmpty="True" style="margin-left: 107px; margin-bottom: 9px;" Width="451px" AutoGenerateColumns="False" ViewStateMode="Enabled">
                                              <Columns>
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
                  
                  <!-- /.chart-responsive -->
                </div>
                <!-- /.col -->
                <div class="col-md-4">
                  <p class="text-center">
                    <strong>Agregar ejercicio</strong>
                  </p>
                    <br />
                    <div class="form-group">
                                <label class="col-sm-2 control-label" for="inputEmail3" style="left: 0px; top: 0px; width: 114px">
                                Grupo Muscular:</label>
                                a<div class="col-sm-10" style="left: 0px; top: 0px; width: 151px">
                                    <asp:DropDownList ID="ddlgrupomuscular" runat="server" CssClass="form-control" Height="32px" Width="128px" AutoPostBack="True" OnSelectedIndexChanged="ddlgrupomuscular_SelectedIndexChanged1">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlgrupomuscular" Display="None" ErrorMessage="Seleccione un grupo" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    <ajaxToolkit:ValidatorCalloutExtender ID="RequiredFieldValidator5_ValidatorCalloutExtender" runat="server" BehaviorID="RequiredFieldValidator5_ValidatorCalloutExtender" TargetControlID="RequiredFieldValidator5">
                                    </ajaxToolkit:ValidatorCalloutExtender>
                                </div>
                            </div>
                     <br />
                    <br />
                  <div class="form-group">
                                <label class="col-sm-2 control-label" for="inputEmail3" style="left: 0px; top: 0px; width: 114px">
                                Ejercicio:</label>
                                <div class="col-sm-10" style="left: 0px; top: 0px; width: 165px">
                                    <asp:DropDownList ID="ddlejercicio" runat="server" CssClass="form-control" Height="32px" Width="128px">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlejercicio" Display="None" ErrorMessage="Seleccione un ejercicio" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" BehaviorID="RequiredFieldValidator3_ValidatorCalloutExtender" TargetControlID="RequiredFieldValidator3">
                                    </ajaxToolkit:ValidatorCalloutExtender>
                                </div>
                            </div>
                    <br />
                    <br />
                   <div class="form-group">
                  <label for="inputEmail3" class="col-sm-2 control-label" style="left: 0px; top: 0px; width: 115px">Nº de Series:</label>

                  <div class="col-sm-10" style="left: 0px; top: 0px; width: 162px">
                      <asp:ListBox ID="lbseries" runat="server" Height="24px" Width="37px">
                          <asp:ListItem>0</asp:ListItem>
                          <asp:ListItem>1</asp:ListItem>
                          <asp:ListItem>2</asp:ListItem>
                          <asp:ListItem>3</asp:ListItem>
                          <asp:ListItem>4</asp:ListItem>
                          <asp:ListItem>5</asp:ListItem>
                          <asp:ListItem>6</asp:ListItem>
                          <asp:ListItem>7</asp:ListItem>
                          <asp:ListItem>8</asp:ListItem>
                          <asp:ListItem>9</asp:ListItem>
                          <asp:ListItem>10</asp:ListItem>
                          <asp:ListItem>11</asp:ListItem>
                          <asp:ListItem>12</asp:ListItem>
                      </asp:ListBox>
                  </div>
                </div>
                  <br />
                   <div class="form-group">
                  <label for="inputEmail3" class="col-sm-2 control-label" style="left: 0px; top: 0px; width: 115px">Nº de Repeticiones:</label>

                  <div class="col-sm-10" style="left: 0px; top: 0px; width: 162px">
                      <asp:ListBox ID="lbrrepeticiones" runat="server" Height="24px" Width="37px">
                          <asp:ListItem>0</asp:ListItem>
                          <asp:ListItem>1</asp:ListItem>
                          <asp:ListItem>2</asp:ListItem>
                          <asp:ListItem>3</asp:ListItem>
                          <asp:ListItem>4</asp:ListItem>
                          <asp:ListItem>5</asp:ListItem>
                          <asp:ListItem>6</asp:ListItem>
                          <asp:ListItem>7</asp:ListItem>
                          <asp:ListItem>8</asp:ListItem>
                          <asp:ListItem>9</asp:ListItem>
                          <asp:ListItem>10</asp:ListItem>
                          <asp:ListItem>11</asp:ListItem>
                          <asp:ListItem>12</asp:ListItem>
                      </asp:ListBox>
                  </div>
                       <br />
                       <div class="form-group">
                           <label class="col-sm-2 control-label" for="inputEmail3" style="left: 0px; top: -6px; width: 115px">
                           Día:</label>
                           <div class="col-sm-10" style="left: 0px; top: 0px; width: 162px">
                               <asp:DropDownList ID="DropDownList1" runat="server">
                                   <asp:ListItem>Lunes</asp:ListItem>
                                   <asp:ListItem>Martes</asp:ListItem>
                                   <asp:ListItem>Miercoles</asp:ListItem>
                                   <asp:ListItem>Jueves</asp:ListItem>
                                   <asp:ListItem>Viernes</asp:ListItem>
                                   <asp:ListItem>Sabado</asp:ListItem>
                               </asp:DropDownList>
                           </div>
                       </div>
                       <br />
                       <br />
                       &nbsp;&nbsp;<asp:Button ID="btnañadir" runat="server" CssClass="btn btn-success" OnClick="btnañadir_Click" Text="Añadir" CausesValidation="False" />
                <!-- /.col -->
              </div>





                </div>
              <!-- /.row -->
            </div>
            <!-- ./box-body -->
             <div class="box-footer">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnregistrar" runat="server" CssClass="btn btn-info" OnClick="btnregistrar_Click" Text="Registrar" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btncancelar" runat="server" CausesValidation="False" CssClass="btn btn-default" Text="Cancelar" />
                </div>
            <!-- /.box-footer -->
          </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/GYMPaginasMaestras/MasterPageEntrenador.Master" AutoEventWireup="true" CodeBehind="RegistrarRutinaEntrenador.aspx.cs" Inherits="SistemasIIITHEGYM.RegistrarRutinaxEntrenador" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Label ID="lblusuario" runat="server" Font-Bold="True" Font-Names="Arial Black" Font-Size="Small" ForeColor="White"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="EstilosCSS.css" rel="stylesheet" />
    <%-- inicio contenedor busqueda--%>
        <div class="modal fade" id="modal-cliente">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header">
                  <%--aqui esta el grid del modalpara los productos--%>                  <%--fingridmodal--%>
                <h4 class="modal-title">Seleccione un Cliente:</h4>
              </div>
              <div class="modal-body">
                  <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                      <ContentTemplate>
                          <asp:Panel ID="panelconsulta" runat="server">
                             <asp:TextBox ID="tbnombrclientemodal" runat="server" Height="21px" Width="371px" AutoPostBack="false"></asp:TextBox>
                               <table class="nav-justified" style="height: 48px">
                                   <caption>
                                       <br />
                                       <asp:Button ID="btnconsultarclientemodal" runat="server" CssClass="btn btn-info" Text="Consultar" OnClick="btnconsultarclientemodal_Click"  CausesValidation="False" />
                                       <br />
                                       <asp:Label ID="lblerrorconsultarclientemodal" runat="server" CssClass="error-text"></asp:Label>
                                       <br />
                                       <%--aqui esta el grid del modal para los proveedores--%>
                                       <asp:GridView ID="gvclientemodal" runat="server" AllowPaging="True"  AllowSorting="True" OnSelectedIndexChanged="gvclientemodal_SelectedIndexChanged" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CaptionAlign="Bottom" CellPadding="4" CellSpacing="1" Font-Size="Medium" ForeColor="Black" GridLines="Horizontal" Height="210px" HorizontalAlign="Justify" PageSize="4" ShowHeaderWhenEmpty="True" style="margin-left: 0px; margin-bottom: 9px;" Width="401px" >
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
   <%-- otromodal--%>
             <div class="modal fade" id="modal-default">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header">
                  <%--fin de contenedor busqueda inicio contenedor gridview--%>
                  <%--<span aria-hidden="true">&times;</span></button>--%>
                <h4 class="modal-title">THEGYM</h4>
              </div>
              <div class="modal-body">
                <p>¡Rutina registrada exitosamente!&hellip;</p>
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
<section class="content-header" style="left: 0px; top: 0px; height: 26px">
        <h1>Registrar Rutina a un Cliente <small>TheGym</small> </h1>
</section>
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <%--inicio panel de edicion--%>
<asp:Panel ID="paneledicion" runat="server" Height="1859px">
    <div class="box box-default">
        <div class="box-header with-border">
            <h3 class="box-title">Datos de rutina </h3>
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
                      <asp:TextBox  CssClass="form-control" ID="tbnombrerutina"  runat="server" Height="24px" Width="156px"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbnombrerutina" Display="None" ErrorMessage="Ingrese el nombre" SetFocusOnError="True"></asp:RequiredFieldValidator>
                      <ajaxToolkit:ValidatorCalloutExtender ID="validadornombre" runat="server" BehaviorID="validadornombre" TargetControlID="RequiredFieldValidator2">
                      </ajaxToolkit:ValidatorCalloutExtender>
                  </div>
                </div>
                    <br />
                <div class="form-group">
                  <label for="inputEmail3" class="col-sm-2 control-label" style="left: 0px; top: 0px; width: 114px">Entrenador:</label>

                  <div class="col-sm-10" style="left: 0px; top: 0px; width: 256px; height: 62px;">
                      <asp:Label ID="lblentrenador" CssClass="text-muted" runat="server" Text="ENTRENADOR"></asp:Label>
                      <br />
                      <asp:Label ID="lblentrenadordni" runat="server" CssClass="text-muted" Text="ID" Visible="False"></asp:Label>
                      <br />
                      <asp:Label ID="lblemail" runat="server" CssClass="text-muted" Text="EMAIL" Visible="False"></asp:Label>
                  </div>
                </div>
                    <br />
              <!-- /.form-group -->
            </div>
            <!-- columna2 inicio/.col -->
            <div class="col-md-6">
                <div class="form-group">
                  <label for="inputEmail3" class="col-sm-2 control-label" style="left: 0px; top: 0px; width: 68px">Cliente:</label>

                  <div class="col-sm-10" style="left: 0px; top: 0px; width: 255px; height: 64px;">
                      <asp:TextBox ID="tbcliente" runat="server" AutoPostBack="True" Enabled="False" Height="22px" ReadOnly="True" Width="158px">Seleccione un cliente</asp:TextBox>
                                                    <asp:Button ID="btnseleccioncliente" runat="server" CausesValidation="False" CssClass="btn btn-success" Height="30px" Text="..." Width="39px" OnClick="btnseleccioncliente_Click" />
                      <br />
                      <asp:Label ID="lblid" runat="server" CssClass="text-muted" Text="IDcliente" Visible="False"></asp:Label>
                  </div>
                </div>
                <br />
                <br />
                <br />
                    <label class="col-sm-2 control-label" for="inputEmail3" style="left: -1px; top: 15px; width: 114px">
                Dia:</label><br /><!-- /.form-group --><div class="col-sm-10" style="left: 0px; top: 0px; width: 253px">
                    <asp:Label ID="lbldia" runat="server" CssClass="text-muted" Text="Dia"></asp:Label>
                </div>
                    <br />
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
<%--caja detalle--%>
                <div class="box">
            <div class="box-header with-border">
              <h3 class="box-title">Ejercicios de la rutina</h3>             
            </div>
            <!-- /.box-header -->
            <div class="box-body">
              <div class="row">
                <div class="col-md-8" style="left: 0px; top: 0px; height: 58px">
                  <p class="text-center">
                    <strong></strong>
                      <asp:GridView ID="griddetallerutina" runat="server" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CaptionAlign="Bottom" CellPadding="4" CellSpacing="1" Font-Size="Medium" ForeColor="Black" GridLines="Horizontal" Height="210px" HorizontalAlign="Justify" PageSize="6" ShowHeaderWhenEmpty="True" style="margin-left: 107px; margin-bottom: 9px;" Width="601px" OnSelectedIndexChanged="griddetallerutina_SelectedIndexChanged" Visible="False">
                          <Columns>
                            <asp:BoundField DataField="Grupo_muscular" HeaderText="Grupo Muscular"/>
                            <asp:BoundField DataField="Ejercicio" HeaderText="Ejercicio"/>
                            <asp:BoundField DataField="Id_ejercicio" HeaderText="Id ejercio"/>
                            <asp:BoundField DataField="Serie" HeaderText="Serie"/>
                            <asp:BoundField DataField="Rep" HeaderText="Repeticion"/>
                            <asp:BoundField DataField="Dia" HeaderText="Dia"/>
                             <%-- <asp:CommandField ButtonType="Image" DeleteImageUrl="~/ImagenesSistema/eliminar.png" ShowDeleteButton="True">
                                            <ControlStyle Height="20px" Width="20px" />
                                            </asp:CommandField>--%>
                          </Columns>
                          <EditRowStyle BorderColor="Black" BorderStyle="None" Font-Size="Small" />
                           <EmptyDataRowStyle Height="20px" />
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
                  </p>
                  
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
                                <div class="col-sm-10" style="left: 0px; top: 0px; width: 151px">
                                    <asp:DropDownList ID="ddlgrupomuscular" runat="server" CssClass="form-control" Height="32px" Width="128px" AutoPostBack="True" OnSelectedIndexChanged="ddlgrupomuscular_SelectedIndexChanged">
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
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlejercicio" Display="None" ErrorMessage="Seleccione un ejercicio" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" BehaviorID="RequiredFieldValidator3_ValidatorCalloutExtender" TargetControlID="RequiredFieldValidator3">
                                    </ajaxToolkit:ValidatorCalloutExtender>
                                </div>
                            </div>
                    <br />
                    <br />
                   <div class="form-group">
                  <label for="inputEmail3" class="col-sm-2 control-label" style="left: 0px; top: 0px; width: 115px">Nº de Series:</label>

                  <div class="col-sm-10" style="left: 0px; top: 0px; width: 162px">
                      &nbsp;&nbsp;
                      <asp:ListBox ID="lbseries" runat="server" Height="24px" Width="37px" Rows="1">
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

                  <div class="col-sm-10" style="left: 7px; top: 0px; width: 155px; height: 42px;">
                      <asp:ListBox ID="lbrrepeticiones" runat="server" Height="24px" Width="37px" Rows="1">
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
                                 <br />        
                   <div class="form-group">
                                <label class="col-sm-2 control-label" for="inputEmail3" style="left: 0px; top: 0px; width: 114px">
                                Día:</label>
                                <div class="col-sm-10" style="left: 0px; top: 0px; width: 165px">
                                    <asp:DropDownList ID="lbdias" runat="server">
                               <asp:ListItem>Lunes</asp:ListItem>
                               <asp:ListItem>Martes</asp:ListItem>
                               <asp:ListItem>Miercoles</asp:ListItem>
                               <asp:ListItem>Jueves</asp:ListItem>
                               <asp:ListItem>Viernes</asp:ListItem>
                               <asp:ListItem>Sabado</asp:ListItem>
                           </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator48" runat="server" ControlToValidate="lbdias" Display="None" ErrorMessage="Seleccione un día" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender48" runat="server" BehaviorID="RequiredFieldValidator3_ValidatorCalloutExtender" TargetControlID="RequiredFieldValidator48">
                                    </ajaxToolkit:ValidatorCalloutExtender>
                                </div>
                            </div>
                       <br />
                      <%-- <div class="form-group">
                           <label class="col-sm-2 control-label" for="inputEmail3" style="left: 1px; top: 19px; width: 115px">
                           Día:<asp:DropDownList ID="lbdias" runat="server">
                               <asp:ListItem>Lunes</asp:ListItem>
                               <asp:ListItem>Martes</asp:ListItem>
                               <asp:ListItem>Miercoles</asp:ListItem>
                               <asp:ListItem>Jueves</asp:ListItem>
                               <asp:ListItem>Viernes</asp:ListItem>
                               <asp:ListItem>Sabado</asp:ListItem>
                           </asp:DropDownList>
                           </label>
                           &nbsp;<div class="col-sm-10" style="left: 5px; top: -1px; width: 174px; height: 36px;">
                           </div>
                       </div>--%>
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
                    <asp:Button ID="btncancelar" runat="server" CausesValidation="False" CssClass="btn btn-default" Text="Cancelar" OnClick="btncancelar_Click" />
                    <br />
                    <asp:Label ID="lblerroregistrar" CssClass="error-text" runat="server"></asp:Label>
                </div>
            <!-- /.box-footer -->
          </div>
            </asp:Panel>
    <%--inicio panel de consulta--%>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

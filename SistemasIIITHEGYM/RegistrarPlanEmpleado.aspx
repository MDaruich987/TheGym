<%@ Page Title="" Language="C#" MasterPageFile="~/GYMPaginasMaestras/PaginaMaestraEmpleado.Master" AutoEventWireup="true" CodeBehind="RegistrarPlanEmpleado.aspx.cs" Inherits="SistemasIIITHEGYM.RegistrarPlanEmpleado" %>
<%--agregamos esto si nos salen errores en los asp--%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--para los controles ajax--%>
         <script type ="text/javascript">
       
        function show()
          {
             document.write("<head runat='server'></head>");
                  }

    </script>
        <asp:ScriptManager ID="SMAJAX" runat="server"></asp:ScriptManager>
    <asp:Panel ID="panelgeneral" runat="server">
     <section class="content-header">
      <h1>
        Registrar Plan
        <small>TheGym</small>
      </h1>
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
              <h3 class="box-title">Información del Plan</h3>
            </div>
            <!-- /.cabeza de general  form -->
            <!-- contenido principal general form -->
              <div class="box-body">
             <div class="form-group">
                  <label for="inputEmail3" class="col-sm-2 control-label" style="left: 0px; top: 0px; width: 114px">Nombre:</label>

                  <div class="col-sm-10" style="left: 0px; top: 0px; width: 253px">
                    <asp:TextBox  CssClass="form-control" ID="tbnombre"  runat="server" Height="24px" Width="128px"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbnombre" Display="None" ErrorMessage="Ingrese el nombre" SetFocusOnError="True"></asp:RequiredFieldValidator>
                      <ajaxToolkit:ValidatorCalloutExtender ID="validadornombre" runat="server" BehaviorID="validadornombre" TargetControlID="RequiredFieldValidator1">
                      </ajaxToolkit:ValidatorCalloutExtender>
                  </div>
                </div>
                    <br />

                     <div class="form-group">
                  <label for="inputEmail3" class="col-sm-2 control-label" style="left: 0px; top: 0px; width: 114px">Duración:</label>

                  <div class="col-sm-10" style="left: 0px; top: 0px; width: 258px">
                      <asp:ListBox ID="lbduración" runat="server" Height="24px" Width="37px">
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
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="lbduración" Display="None" ErrorMessage="Seleccione una sucursal" SetFocusOnError="True"></asp:RequiredFieldValidator>
                      <ajaxToolkit:ValidatorCalloutExtender ID="RequiredFieldValidator5_ValidatorCalloutExtender" runat="server" BehaviorID="RequiredFieldValidator5_ValidatorCalloutExtender" TargetControlID="RequiredFieldValidator5">
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
              <h3 class="box-title">Actividades del Plan:</h3>
            </div>
            <!-- /.box-header -->
            <!-- form start -->
              <div class="box-body">
               
                  <div class="form-group" style="margin-bottom: 3px">
                  <label for="inputEmail3" class="col-sm-2 control-label" style="left: 0px; top: 0px; width: 114px">Actividad:</label>

                  <div class="col-sm-10" style="left: 0px; top: 0px; width: 258px">
                    <asp:DropDownList  CssClass="form-control"   ID="ddlactividad"  runat="server" Height="24px" Width="128px"></asp:DropDownList>
                  </div>
                </div>
                   <br />

                  <div class="form-group">
                      <br />
                  <label for="inputEmail3" class="col-sm-2 control-label" style="left: 0px; top: 0px; width: 115px">Clases semanales:</label>

                  <div class="col-sm-10" style="left: 0px; top: 0px; width: 258px">
                      <asp:ListBox ID="lbduración0" runat="server" Height="24px" Width="37px">
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
                   &nbsp;&nbsp;
                  <br />
                  <asp:GridView ID="gridactividades0" runat="server" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CaptionAlign="Bottom" CellPadding="4" CellSpacing="1" DataKeyNames="Id_actividad" Font-Size="Medium" ForeColor="Black" GridLines="Horizontal" Height="204px" HorizontalAlign="Justify" OnSelectedIndexChanged="gridactividades_SelectedIndexChanged1" PageSize="6" ShowHeaderWhenEmpty="True" style="margin-left: 91px; margin-bottom: 9px;" Width="448px">
                      <Columns>
                          <asp:BoundField DataField="Nombre" HeaderText="Actividad" ItemStyle-Width="150px">
                          <ItemStyle Width="150px" />
                          </asp:BoundField>
                          <asp:BoundField DataField="Dias_semanas" HeaderText="Dias a la Semana" ItemStyle-Width="150px">
                          <ItemStyle Width="150px" />
                          </asp:BoundField>
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
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  <asp:Button ID="btnregistrar" CssClass="btn btn-info" runat="server" Text="Registrar" OnClick="btnregistrar_Click" />
                
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  <asp:Button ID="btncancelar" runat="server" CssClass="btn btn-default" Text="Cancelar" CausesValidation="False" OnClick="btncancelar_Click" />
                
              </div>

    </asp:Panel>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/GYMPaginasMaestras/PaginaMaestraEmpleado.Master" AutoEventWireup="true" CodeBehind="RegistrarActividadesEmpleado.aspx.cs" Inherits="SistemasIIITHEGYM.RegistrarActividadesEmpleado" %>
<%--agregamos esto si nos salen errores en los asp--%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Label ID="lblusuario" runat="server" Font-Bold="True" Font-Names="Arial Black" Font-Size="Small" ForeColor="White"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       
     <script type ="text/javascript">
       
        function show()
          {
             document.write("<head runat='server'></head>");
                  }

    </script>


    <asp:panel runat="server">
        <asp:ScriptManager ID="SMparaAJAX" runat="server"></asp:ScriptManager>
                <section class="content-header">
      <h1>
        Registrar Actividad
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
              <h3 class="box-title">Información de actividad</h3>
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
                  <label for="inputEmail3" class="col-sm-2 control-label" style="left: 0px; top: 0px; width: 114px">Sucursal:</label>

                  <div class="col-sm-10" style="left: 0px; top: 0px; width: 258px">
                    <asp:DropDownList  CssClass="form-control"   ID="ddlsucursal"  runat="server" Height="24px" Width="128px"></asp:DropDownList>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlsucursal" Display="None" ErrorMessage="Seleccione una sucursal" SetFocusOnError="True"></asp:RequiredFieldValidator>
                      <ajaxToolkit:ValidatorCalloutExtender ID="RequiredFieldValidator5_ValidatorCalloutExtender" runat="server" BehaviorID="RequiredFieldValidator5_ValidatorCalloutExtender" TargetControlID="RequiredFieldValidator5">
                      </ajaxToolkit:ValidatorCalloutExtender>
                  </div>
                </div>
                   <br />
                
                <div class="form-group">
                  <label for="inputEmail3" class="col-sm-2 control-label" style="left: 0px; top: 0px; width: 114px">Descripción:</label>

                  <div class="col-sm-10" style="left: 0px; top: 0px; width: 253px">
                    <asp:TextBox  CssClass="form-control" ID="tbdescripcion" textmode="MultiLine" runat="server" Height="37px" Width="225px"></asp:TextBox>
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
                  <label for="inputEmail3" class="col-sm-2 control-label" style="left: 0px; top: 0px; width: 114px">Profesor:</label>

                  <div class="col-sm-10" style="left: 0px; top: 0px; width: 258px">
                    <asp:DropDownList  CssClass="form-control"   ID="ddlprofesor"  runat="server" Height="24px" Width="128px"></asp:DropDownList>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlprofesor" Display="None" ErrorMessage="Seleccione un profesor" SetFocusOnError="True"></asp:RequiredFieldValidator>
                      <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" BehaviorID="RequiredFieldValidator3_ValidatorCalloutExtender" TargetControlID="RequiredFieldValidator3">
                      </ajaxToolkit:ValidatorCalloutExtender>
                  </div>
                </div>
                   <br />

                  <div class="form-group">
                  <label for="inputEmail3" class="col-sm-2 control-label" style="left: 0px; top: 0px; width: 114px">Cupos:</label>

                  <div class="col-sm-10" style="left: 0px; top: 0px; width: 258px">
                    <asp:DropDownList  CssClass="form-control"   ID="ddlcupos"  runat="server" Height="24px" Width="128px"></asp:DropDownList>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlcupos" Display="None" ErrorMessage="Seleccione un cupo" SetFocusOnError="True"></asp:RequiredFieldValidator>
                      <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" BehaviorID="RequiredFieldValidator4_ValidatorCalloutExtender" TargetControlID="RequiredFieldValidator4">
                      </ajaxToolkit:ValidatorCalloutExtender>
                  </div>
                </div>
                   <br />
                  <div class="form-group">
                  <label for="inputEmail3" class="col-sm-2 control-label" style="left: 0px; top: 0px; width: 114px">Horario:</label>
                  <div class="col-sm-10" style="left: 0px; top: 0px; width: 340px">
                              <div class="form-group">
                                <label for="inputEmail3" class="col-sm-2 control-label" style="left: 0px; top: 0px; width: 114px">De:</label>

                                <div class="col-sm-10" style="left: 0px; top: 0px; width: 309px">
                                 <asp:DropDownList  CssClass="form-control"   ID="ddlhorarioinicio"  runat="server" Height="24px" Width="128px"></asp:DropDownList>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlhorarioinicio" Display="None" ErrorMessage="Seleccione un cupo" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                   <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender8" runat="server" BehaviorID="RequiredFieldValidator7_ValidatorCalloutExtender" TargetControlID="RequiredFieldValidator7">
                                  </ajaxToolkit:ValidatorCalloutExtender>
                                    </div>
                                    </div>
                                     <br />
                                 <div class="form-group">
                                <label for="inputEmail3" class="col-sm-2 control-label" style="left: 0px; top: 0px; width: 114px">A:</label>

                                <div class="col-sm-10" style="left: 0px; top: 0px; width: 306px">
                                 <asp:DropDownList  CssClass="form-control"   ID="ddlhorariofin"  runat="server" Height="24px" Width="128px"></asp:DropDownList>
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
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  <asp:Button ID="btnregistrar" CssClass="btn btn-info" runat="server" Text="Registrar" OnClick="btnregistrar_Click" />
                
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  <asp:Button ID="btncancelar" runat="server" CssClass="btn btn-default" Text="Cancelar" CausesValidation="False" />
                
              </div>
    </asp:panel>
</asp:Content>

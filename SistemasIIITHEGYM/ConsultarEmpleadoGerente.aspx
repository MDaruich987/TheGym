<%@ Page Title="" Language="C#" MasterPageFile="~/GYMPaginasMaestras/PaginaMaestaGerente.Master" AutoEventWireup="true" CodeBehind="ConsultarEmpleadoGerente.aspx.cs" Inherits="SistemasIIITHEGYM.ConsultarEmpleadoGerente" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <asp:Label ID="lblusuario" runat="server" Font-Bold="True" Font-Names="Arial Black" Font-Size="Small" ForeColor="White"></asp:Label>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="EstilosCSS.css" rel="stylesheet" />
    <script type ="text/javascript">
       
 function show()
    {
        document.write("<head runat='server'></head>");
    }
    </script>



 
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="paneledicion" runat="server">
                <section class="content-header" style="left: 0px; top: 0px; height: 26px">
                    <h1>Actualizar Empleado <small>TheGym</small> </h1>
                </section>
     <!-- Main content -->
                <section class="content">
                    <div class="row">
        <!-- left column -->
                        <div class="col-md-6">
          <!-- general form elements -->
                            <div class="box box-primary">
                                <div class="box-header with-border">
                                    <h3 class="box-title" style="width: 390px">Información personal</h3>
                                </div>
            <!-- /.box-header -->
            <!-- form start -->
                                <div class="box-body">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="inputEmail3" style="left: 0px; top: 0px; width: 114px">
                                        Nombre:</label>
                                        <div class="col-sm-10" style="left: 0px; top: 0px; width: 253px">
                                            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" Height="24px" Width="128px" Enabled="False"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbnombre" Display="None" ErrorMessage="Ingrese el nombre" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <ajaxToolkit:ValidatorCalloutExtender ID="validadornombre" runat="server" BehaviorID="validadornombre" TargetControlID="RequiredFieldValidator1">
                                            </ajaxToolkit:ValidatorCalloutExtender>
                                        </div>
                                    </div>
                    <br />
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="inputEmail3" style="left: 0px; top: 0px; width: 114px">
                                        Apellido:</label>
                                        <div class="col-sm-10" style="left: 0px; top: 0px; width: 258px">
                                            <asp:TextBox ID="tbapellido" runat="server" CssClass="form-control" Height="24px" Width="128px" Enabled="False"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbapellido" Display="None" ErrorMessage="Ingrese el apellido" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <ajaxToolkit:ValidatorCalloutExtender ID="validadorapellido" runat="server" BehaviorID="validadorapellido" TargetControlID="RequiredFieldValidator2">
                                            </ajaxToolkit:ValidatorCalloutExtender>
                                        </div>
                                    </div>
                   <br />
                <%--<div class="form-group">
                  <label for="exampleInputPassword1">Fecha de Nacimiento:</label><asp:TextBox type="date" CssClass="form-control" ID="tbfechanacimiento"  runat="server" Height="24px" Width="128px"></asp:TextBox>
                </div>--%>
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="inputEmail3" style="left: 0px; top: 0px; width: 114px">
                                        Fecha de Nacimiento:</label>
                       <br />

                                        <div class="col-sm-10" style="left: 0px; top: 0px; width: 258px">
                                            <asp:TextBox ID="tbfechadenacimiento" runat="server" CssClass="form-control" Height="24px" TextMode="DateTime" Width="128px" Enabled="False"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tbfechadenacimiento" Display="None" ErrorMessage="Ingrese la fecha de Nacimiento" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <ajaxToolkit:ValidatorCalloutExtender ID="validadorfechanacimiento" runat="server" BehaviorID="validadorfechanacimiento" TargetControlID="RequiredFieldValidator3">
                                            </ajaxToolkit:ValidatorCalloutExtender>
                                        </div>
                                    </div>
                   <br />
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="inputEmail3" style="left: 0px; top: 0px; width: 114px">
                                        Tipo de documento:</label>
                                        <div class="col-sm-10" style="left: 0px; top: 0px; width: 258px">
                                            <asp:DropDownList ID="ddltipodedocumento" runat="server" CssClass="form-control" Height="32px" Width="128px" Enabled="False">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddltipodedocumento" Display="None" ErrorMessage="Seleccione el tipo de Documento" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <ajaxToolkit:ValidatorCalloutExtender ID="RequiredFieldValidator5_ValidatorCalloutExtender" runat="server" BehaviorID="RequiredFieldValidator5_ValidatorCalloutExtender" TargetControlID="RequiredFieldValidator5">
                                            </ajaxToolkit:ValidatorCalloutExtender>
                                        </div>
                                    </div>
                   <br />
                  <br />
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="inputEmail3" style="left: 0px; top: 0px; width: 114px">
                                        Nº de documento:</label>
                                        <div class="col-sm-10" style="left: 0px; top: 0px; width: 257px">
                                            <asp:TextBox ID="tbnumerodocumento" runat="server" CssClass="form-control" Height="24px" TextMode="number" Width="128px" Enabled="False"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="tbnumerodocumento" Display="None" ErrorMessage="Ingrese el documento" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                   <br />

                <%--<div class="form-group">
                  <label for="exampleInputFile">Fotografía</label>
                    <asp:FileUpload ID="fiupfotografiacliente" runat="server" />
                  <p class="help-block">Seleccione la fotografía del cliente.</p>
                </div>--%>
                                </div>
              <!-- /.box-body -->

                            </div>
          <!-- /.box -->

          <!-- Form Element sizes -->
                            <div class="box box-success">
                                <div class="box-header with-border">
                                    <h3 class="box-title">Información de contacto</h3>
                                </div>
                                <div class="box-body">
                                    <div class="box-body">
                                        <div class="form-group">
                                            <label class="col-sm-2 control-label" for="inputEmail3">
                                            Email</label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="tbemail" runat="server" CssClass="form-control" Height="24px" TextMode="email" Width="128px" Enabled="False"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="tbemail" Display="None" ErrorMessage="Ingrese el el E-mail" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                    <br />
                                        <div class="form-group" style="margin-bottom: 5px">
                                            <label class="col-sm-2 control-label" for="inputPassword3">
                                            Teléfono:</label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="tbtelefono" runat="server" CssClass="form-control" Height="24px" TextMode="number" Width="128px" Enabled="False"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="tbtelefono" Display="None" ErrorMessage="Ingrese el teléfono" SetFocusOnError="True"></asp:RequiredFieldValidator>
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
                                            </div>
                                        </div>
                                    </div>
                                </div>
            <!-- /.box-body -->
                            </div>
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
                                            <asp:DropDownList ID="ddllocalidad" runat="server" CssClass="form-control" Height="32px" Width="128px" Enabled="False">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddllocalidad" Display="None" ErrorMessage="Seleccione una localidad" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <ajaxToolkit:ValidatorCalloutExtender ID="RequiredFieldValidator9_ValidatorCalloutExtender" runat="server" BehaviorID="RequiredFieldValidator9_ValidatorCalloutExtender" TargetControlID="RequiredFieldValidator9">
                                            </ajaxToolkit:ValidatorCalloutExtender>
                                        </div>
                                    </div>
                   <br />
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="inputEmail3" style="left: 0px; top: 0px; width: 114px">
                                        Calle:</label>
                                        <div class="col-sm-10" style="left: 0px; top: 0px; width: 257px">
                                            <asp:TextBox ID="tbcalle" runat="server" CssClass="form-control" Height="24px" Width="128px" Enabled="False"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="tbcalle" Display="None" ErrorMessage="Ingrese una calle" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <ajaxToolkit:ValidatorCalloutExtender ID="RequiredFieldValidator10_ValidatorCalloutExtender" runat="server" BehaviorID="RequiredFieldValidator10_ValidatorCalloutExtender" TargetControlID="RequiredFieldValidator10">
                                            </ajaxToolkit:ValidatorCalloutExtender>
                                        </div>
                                    </div>
                   <br />
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="inputEmail3" style="left: 0px; top: 0px; width: 114px">
                                        Barrio:</label>
                                        <div class="col-sm-10" style="left: 0px; top: 0px; width: 257px">
                                            <asp:TextBox ID="tbbarrio" runat="server" CssClass="form-control" Height="24px" Width="128px" Enabled="False"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="tbbarrio" Display="None" ErrorMessage="Ingrese un barrio" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <ajaxToolkit:ValidatorCalloutExtender ID="RequiredFieldValidator11_ValidatorCalloutExtender" runat="server" BehaviorID="RequiredFieldValidator11_ValidatorCalloutExtender" TargetControlID="RequiredFieldValidator11">
                                            </ajaxToolkit:ValidatorCalloutExtender>
                                        </div>
                                    </div>
                  <br />
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="inputEmail3" style="left: 0px; top: 0px; width: 114px">
                                        Nº de casa:</label>
                                        <div class="col-sm-10" style="left: 0px; top: 0px; width: 257px">
                                            <asp:TextBox ID="tbnumerocasa" runat="server" CssClass="form-control" Height="24px" TextMode="number" Width="128px" Enabled="False"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="tbnumerocasa" Display="None" ErrorMessage="Ingrese un número" SetFocusOnError="True"></asp:RequiredFieldValidator>
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
                            <div class="box box-warning">
                                <div class="box-header with-border">
                                    <h3 class="box-title">Información de usuario</h3>
                                </div>
            <!-- /.box-header -->
                                <div class="box-body">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="inputEmail3">
                                        Usuario:</label>
                                        <div class="col-sm-10" style="left: 0px; top: 0px">
                                            <asp:TextBox ID="tbusuario" runat="server" CssClass="form-control" Height="24px" TextMode="email" Width="128px" Enabled="False"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="tbusuario" Display="None" ErrorMessage="Ingrese un usuario" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <ajaxToolkit:ValidatorCalloutExtender ID="RequiredFieldValidator13_ValidatorCalloutExtender" runat="server" BehaviorID="RequiredFieldValidator13_ValidatorCalloutExtender" TargetControlID="RequiredFieldValidator13">
                                            </ajaxToolkit:ValidatorCalloutExtender>
                                        </div>
                                    </div>
                    <br />
                                    <div class="form-group" style="margin-bottom: 5px">
                                        <label class="col-sm-2 control-label" for="inputPassword3">
                                        Contraseña</label>
                                        <div class="col-sm-10">
                                            <asp:TextBox ID="tbcontraseña" runat="server" CssClass="form-control" Height="24px" Width="128px" Enabled="False"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="tbcontraseña" Display="None" ErrorMessage="Ingrese una contraseña" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
            <!-- /.box-body -->
                            </div>
          <!-- /.box -->

            
  <!-- general form elements disabled -->
                            <div class="box box-warning">
                                <div class="box-header with-border">
                                    <h3 class="box-title">Información Laboral</h3>
                                </div>
            <!-- /.box-header -->
                                <div class="box-body">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="inputEmail3" style="left: 0px; top: 0px; width: 114px">
                                        Cargo:</label>
                                        <div class="col-sm-10" style="left: 0px; top: 0px; width: 258px">
                                            <asp:DropDownList ID="ddlcargo" runat="server" CssClass="form-control" Height="32px" Width="181px" Enabled="False">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="ddlcargo" Display="None" ErrorMessage="Seleccione un cargo" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender20" runat="server" BehaviorID="RequiredFieldValidator20_ValidatorCalloutExtender" TargetControlID="RequiredFieldValidator20">
                                            </ajaxToolkit:ValidatorCalloutExtender>
                                        </div>
                                    </div>
                    <br />
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="inputEmail3" style="left: 0px; top: 0px; width: 114px">
                                        Titulo:</label>
                                        <div class="col-sm-10" style="left: 0px; top: 0px; width: 258px">
                                            <asp:TextBox ID="tbtitulo" runat="server" CssClass="form-control" Height="24px" Width="128px" Enabled="False"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator90" runat="server" ControlToValidate="tbtitulo" Display="None" ErrorMessage="Ingrese un titulo" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender90" runat="server" BehaviorID="RequiredFieldValidator90_ValidatorCalloutExtender" TargetControlID="RequiredFieldValidator90">
                                            </ajaxToolkit:ValidatorCalloutExtender>
                                        </div>
                                    </div>
                <br />
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label" for="inputEmail3" style="left: 0px; top: 0px; width: 114px">
                                        Contratación:</label>
                                        <div class="col-sm-10" style="left: 0px; top: 0px; width: 258px">
                                            <asp:TextBox ID="tbfechacontratacion" runat="server" CssClass="form-control" Height="24px" Width="158px" Enabled="False"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="tbfechacontratacion" Display="None" ErrorMessage="Seleccione una fecha" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <br />
                                            <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender30" runat="server" BehaviorID="RequiredFieldValidator30_ValidatorCalloutExtender" TargetControlID="RequiredFieldValidator30">
                                            </ajaxToolkit:ValidatorCalloutExtender>
                                        </div>
                                        <br />
                                    </div>
                                </div>
                                <br />
                                <asp:Button ID="btneditar" runat="server" CssClass="btn btn-info" OnClick="btneditar_Click" Text="Editar" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lblerror" runat="server" CssClass="error-text"></asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnvolver" runat="server" CssClass="btn btn-default" OnClick="btnvolver_Click" Text="Volver" />
                                <br />
            <!-- /.box-body -->
                            </div>
                        </div>
        <!--/.col (right) -->
                    </div>
      <!-- /.row -->
                </section>
    <!-- /.content -->
                <div class="box-footer">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                
                  <br />
                </div>
            </asp:Panel>
            <asp:Panel ID="panelconsulta" runat="server">
               <%-- inicio contenedor busqueda--%>
                <div class="row">
                    <div class="col-md-12">
                        <div class="box">
                            <div class="box-header with-border" style="left: 0px; top: 0px; width: 607px;">
                                <h3 class="box-title">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Búsqueda de Empleado </h3>
                            </div>
                            <div class="box-body">
                                <div class="form-group">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:TextBox ID="tbnombre" runat="server" Height="21px" Width="371px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbnombre" Display="None" ErrorMessage="Indique un nombre o DNI" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    <ajaxToolkit:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender" runat="server" BehaviorID="RequiredFieldValidator1_ValidatorCalloutExtender" TargetControlID="RequiredFieldValidator1">
                                    </ajaxToolkit:ValidatorCalloutExtender>
                  <br />
                                    <table class="nav-justified" style="height: 48px">
                                        <tr>
                                            <td class="modal-sm" style="width: 408px">&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                                            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="btnconsultar" runat="server" CssClass="btn btn-info" OnClick="btnconsultar_Click" Text="Consultar" />
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
                                      <h3 class="box-title">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; Ficha de Empleado</h3>
                                  </div>
                                  <div class="box-body">
              <!-- Date -->
                                      <div class="form-group">
                                          &nbsp;
                  
                  <br />


                                          <asp:GridView ID="gridempleados" runat="server" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CaptionAlign="Bottom" CellPadding="4" CellSpacing="1" Font-Size="Medium" ForeColor="Black" GridLines="Horizontal" Height="210px" HorizontalAlign="Justify" OnSelectedIndexChanged="gridempleados_SelectedIndexChanged" PageSize="6" ShowHeaderWhenEmpty="True" style="margin-left: 85px; margin-bottom: 9px;" Width="601px">
                                              <Columns>
                                                  <asp:BoundField DataField="Id_empleado" HeaderText="ID" ItemStyle-Width="100" />
                                                  <asp:BoundField DataField="Nombre" HeaderText="Nombre" ItemStyle-Width="100">
                                                  <ItemStyle Width="150px" />
                                                  </asp:BoundField>
                                                  <asp:BoundField DataField="Apellido" HeaderText="Apellido" ItemStyle-Width="100">
                                                  <ItemStyle Width="150px" />
                                                  </asp:BoundField>
                                                  <asp:BoundField DataField="Documento" HeaderText="DNI" ItemStyle-Width="100">
                                                  <ItemStyle Width="190px" />
                                                  </asp:BoundField>
                                                  <asp:BoundField DataField="Fecha_nac" HeaderText="Fecha Nacimiento" ItemStyle-Width="100" Visible="False">
                                                  <ItemStyle Width="180px" />
                                                  </asp:BoundField>
                                                  <asp:BoundField DataField="Email" HeaderText="Emai" ItemStyle-Width="100" Visible="False">
                                                  <ItemStyle Width="160px" />
                                                  </asp:BoundField>
                                                  <asp:BoundField DataField="Telefono" HeaderText="Telefono" ItemStyle-Width="100" Visible="False">
                                                  <ItemStyle Width="160px" />
                                                  </asp:BoundField>
                                                  <asp:BoundField ConvertEmptyStringToNull="true" DataField="Domicilio" HeaderText="Domicilio" ItemStyle-Width="100" Visible="False">
                                                  <ItemStyle Width="190px" />
                                                  </asp:BoundField>
                                                  <asp:ImageField DataImageUrlField="Foto" HeaderText="Foto">
                                                  </asp:ImageField>
                                                                 <%--<asp: DataField="Foto" HeaderText="Foto" ItemStyle-Width="150" >
                                                                 <ItemStyle Width="150px" />
                                                                 </asp:>--%>
                                                                 <%--<asp:TemplateField>
                                                                     <ItemTemplate>
                                                                         <asp:Button ID="Button1" runat="server"  Text="Seleccionar" OnClick="GridView1_SelectedIndexChanged" />
                                                                        
                                                                     </ItemTemplate>
                                                                 </asp:TemplateField>--%>
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

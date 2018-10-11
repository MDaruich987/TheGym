<%@ Page Title="" Language="C#" MasterPageFile="~/GYMPaginasMaestras/MasterPageEntrenador.Master" AutoEventWireup="true" CodeBehind="RegistrarEjercicioEntrenador.aspx.cs" Inherits="SistemasIIITHEGYM.RegistrarEjercicioEntrenador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Label ID="lblusuario" runat="server" Font-Bold="True" Font-Names="Arial Black" Font-Size="Small" ForeColor="White"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <%--modal para el registro exitoso--%>
             <div class="modal fade" id="modal-default">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header">
                <%--<button type="button" class="close" data-dismiss="modal" aria-label="Close">--%>
                  <%--<span aria-hidden="true">&times;</span></button>--%>
                <h4 class="modal-title">THEGYM</h4>
              </div>
              <div class="modal-body">
                <p>¡Ejercicio registrado exitosamente!&hellip;</p>
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


            <script type="text/javascript">

       
        function show()
          {
             document.write("<head runat='server'></head>");
                  }

    </script>
    <asp:UpdatePanel ID="updatepanelgeneral" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
        <ContentTemplate>


        <!-- SELECT2 EXAMPLE -->

            <div class="box box-default">
        <!-- /.box-header -->
                <div class="box-body">
                    <div class="row">
            <!-- columna2 inicio/.col -->
            <!-- /.col -->
                    </div>
          <!-- /.row -->
                </div>
        <!-- /.box-body -->
                <div class="box-footer">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </div>
            </div>
    <!-- /.box -->
        </ContentTemplate>
    </asp:UpdatePanel>

            <asp:Panel ID="Panel1" runat="server">
                <div class="box-header with-border">
                    <h3 class="box-title">Registrar Ejercicio </h3>
                    <div class="box-tools pull-right">
                        <%--                boton minimizar y cerrar--%><%--                <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>--%>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <label class="col-sm-2 control-label" for="inputEmail3" style="left: 0px; top: 0px; width: 114px">
                        Nombre:</label>
                        <div class="col-sm-10" style="left: 0px; top: 0px; width: 253px">
                            <asp:TextBox ID="tbnombre" runat="server" CssClass="form-control" Height="24px" Width="128px" OnTextChanged="tbnombre_TextChanged"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbnombre" Display="None" ErrorMessage="Ingrese el nombre" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <ajaxToolkit:ValidatorCalloutExtender ID="validadornombre" runat="server" BehaviorID="validadornombre" TargetControlID="RequiredFieldValidator1">
                            </ajaxToolkit:ValidatorCalloutExtender>
                        </div>
                    </div>
                    <br />
                    <div class="form-group">
                        <label class="col-sm-2 control-label" for="inputEmail3" style="left: -255px; top: -265px; width: 114px">
                        Elemento:</label>
                        <div class="col-sm-10" style="left: 0px; top: 0px; width: 253px">
                            <asp:DropDownList ID="ddlelemento" runat="server" CssClass="form-control" Height="32px" Width="128px">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlelemento" Display="None" ErrorMessage="Seleccione un elemento" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <ajaxToolkit:ValidatorCalloutExtender ID="RequiredFieldValidator5_ValidatorCalloutExtender" runat="server" BehaviorID="RequiredFieldValidator5_ValidatorCalloutExtender" TargetControlID="RequiredFieldValidator5">
                            </ajaxToolkit:ValidatorCalloutExtender>
                        </div>
                    </div>
                    <br />
                    <div class="form-group">
                        <label class="col-sm-2 control-label" for="inputEmail3" style="left: 0px; top: 0px; width: 114px">
                        Fotograría:</label>
                        <div class="col-sm-10" style="left: 0px; top: 0px; width: 253px">
                            <asp:FileUpload ID="fiupfotografiacliente" runat="server" OnLoad="fiupfotografiacliente_Load" />
                            <p class="help-block">
                                Seleccione la fotografía del ejercicio.</p>
                        </div>
                    </div>
                    <br />
                    <!-- /.form-group -->
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <label class="col-sm-2 control-label" for="inputEmail3" style="left: 0px; top: 0px; width: 114px">
                        Grupo Muscular:</label>
                        <div class="col-sm-10" style="left: 0px; top: 0px; width: 253px">
                            <asp:DropDownList ID="ddlgrupomuscular" runat="server" CssClass="form-control" Height="32px" Width="128px">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlgrupomuscular" Display="None" ErrorMessage="Seleccione un grupo muscular" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" BehaviorID="RequiredFieldValidator3_ValidatorCalloutExtender" TargetControlID="RequiredFieldValidator3">
                            </ajaxToolkit:ValidatorCalloutExtender>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div class="form-group">
                        <label class="col-sm-2 control-label" for="inputEmail3" style="left: 0px; top: 0px; width: 114px">
                        Descripción:</label>
                        <div class="col-sm-10" style="left: 0px; top: 0px; width: 253px">
                            <asp:TextBox ID="tbdescripcion" runat="server" CssClass="form-control" Height="37px" textmode="MultiLine" Width="225px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbdescripcion" Display="None" ErrorMessage="Ingrese una descripción" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender10" runat="server" BehaviorID="validardescri" TargetControlID="RequiredFieldValidator2">
                            </ajaxToolkit:ValidatorCalloutExtender>
                        </div>
                    </div>
                    <br />
                    <!-- /.form-group -->
                    <asp:Label ID="lblerror" runat="server" CssClass="error-text"></asp:Label>
                </div>
                <asp:Button ID="btnregistrar" runat="server" CssClass="btn btn-info" OnClick="btnregistrar_Click" Text="Registrar" />
                <asp:Button ID="btncancelar" runat="server" CausesValidation="False" CssClass="btn btn-default" Text="Cancelar" />
            </asp:Panel>
            <br />

</asp:Content>

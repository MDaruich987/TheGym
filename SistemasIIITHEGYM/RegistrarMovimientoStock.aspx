<%@ Page Title="" Language="C#" MasterPageFile="~/GYMPaginasMaestras/PaginaMaestraEmpleado.Master" AutoEventWireup="true" CodeBehind="RegistrarMovimientoStock.aspx.cs" Inherits="SistemasIIITHEGYM.RegistrarRemitoGerente" %>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Label ID="lblusuario" runat="server" Font-Bold="True" Font-Names="Arial Black" Font-Size="Small" ForeColor="White"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="EstilosCSS.css" rel="stylesheet" />
    <div class="modal fade" id="modalexito">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header">
                  <%--                <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>--%><%--input dinero--%>
                <h4 class="modal-title">THEGYM</h4>
              </div>
              <div class="modal-body">
                <p>Se registró el Movimiento de Stock&hellip;</p>
              </div>
              <div class="modal-footer">
                  <%--fin input dinero--%>
              </div>
            </div>
            <!-- /.modal-content -->
          </div>
          <!-- /.modal-dialog -->
        </div>
        <!-- /.modal -->
    <%--input dinero--%>
    <section class="content-header">
        <h1>Registrar Movimiento de Stock<small>TheGym</small> </h1>
    </section>
    <!-- Select2 -->
    <link rel="stylesheet" href="../../bower_components/select2/dist/css/select2.min.css">
    <%--fin input dinero--%>
    <script type ="text/javascript">

 function show()
    {
        document.write("<head runat='server'></head>");
    }



    </script>
    <!-- Main content -->
<%--    TituloSuperior--%>
    <%--<section class="content-header">
                    <h1>Operaciones de caja <small>TheGym</small> </h1>
                </section>--%>
    <!-- SELECT2 EXAMPLE -->
    <div class="box box-default">
        <div class="box-header with-border">
            <h3 class="box-title">Datos del movimiento</h3>
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
                  <label for="inputEmail3" class="col-sm-2 control-label" style="left: 0px; top: 0px; width: 114px">Fecha:</label>

                  <div class="col-sm-10" style="left: 0px; top: 0px; width: 253px">
                      <asp:Label ID="lblFecha" CssClass="text-muted" runat="server" Text="HoraActual"></asp:Label>
                  </div>
                </div>
                    <br />
                <div class="form-group">
                  <label for="inputEmail3" class="col-sm-2 control-label" style="left: 0px; top: 0px; width: 114px">Usuario:</label>

                  <div class="col-sm-10" style="left: 0px; top: 0px; width: 253px">
                      <asp:Label ID="lblnombreusuario" CssClass="text-muted" runat="server" Text="APELLIDO, Nombre"></asp:Label>
                  </div>
                </div>
                    <br />
                <div class="form-group">
                  <label for="inputEmail3" class="col-sm-2 control-label" style="left: 0px; top: 0px; width: 114px">Tipo de Movimiento:</label>

                  <div class="col-sm-10" style="left: 0px; top: 0px; width: 253px">
                      <asp:DropDownList ID="ddltipomovimiento" runat="server" CssClass="form-control" Height="32px" Width="128px">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddltipomovimiento" Display="None" ErrorMessage="Seleccione un Movimiento" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" BehaviorID="RequiredFieldValidator7_ValidatorCalloutExtender" TargetControlID="RequiredFieldValidator7">
                                            </ajaxToolkit:ValidatorCalloutExtender>
                  </div>
                </div>
                    <br />
                <br />
                                  <div class="form-group">
                  <label for="inputEmail3" class="col-sm-2 control-label" style="left: 0px; top: 0px; width: 114px">Nº Factura:</label>

                  <div class="col-sm-10" style="left: 0px; top: 0px; width: 253px">
                    <asp:TextBox  CssClass="form-control" ID="tbnrofactura"  runat="server" Height="24px" Width="128px"></asp:TextBox>
                  <asp:Button ID="btnverificarNfactura" CssClass="btn btn-success" runat="server" Text="Verificar" OnClick="btnregistrar_Click" CausesValidation="False" Height="31px" Width="82px" />
                
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbnrofactura" Display="None" ErrorMessage="Ingrese el Nro de Factura" SetFocusOnError="True"></asp:RequiredFieldValidator>
                      <ajaxToolkit:ValidatorCalloutExtender ID="validadornombre" runat="server" BehaviorID="validadornombre" TargetControlID="RequiredFieldValidator1">
                      </ajaxToolkit:ValidatorCalloutExtender>
                  </div>
                </div>
                <br />
                <br />
                <br />
                <div class="form-group">
                  <label for="inputEmail3" class="col-sm-2 control-label" style="left: 0px; top: 0px; width: 114px">Monto de Apertura:</label>
                 <%--input dinero--%>
                 <div class="input-group" style="left: 0px; top: 0px; width: 320px">
                <span class="input-group-addon">$</span>
                     <asp:TextBox ID="tbmonto" Cssclass="form-control" runat="server" style="left: 0px; top: 0px; height: 42px; width: 44%" TextMode="Number"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="tbmonto" Display="None" ErrorMessage="Ingrese un monto" SetFocusOnError="True"></asp:RequiredFieldValidator>
                      <ajaxToolkit:ValidatorCalloutExtender ID="RequiredFieldValidator12_ValidatorCalloutExtender" runat="server" BehaviorID="RequiredFieldValidator12_ValidatorCalloutExtender" TargetControlID="RequiredFieldValidator12">
                      </ajaxToolkit:ValidatorCalloutExtender>
              </div>
                 <%--fin input dinero--%>
                </div>
             <br />
              <!-- /.form-group -->
            </div>
            <!-- columna2 inicio/.col -->
            <div class="col-md-6">
                <div class="form-group">
                  <label for="inputEmail3" class="col-sm-2 control-label" style="left: 0px; top: 0px; width: 114px">Hora:</label>

                  <div class="col-sm-10" style="left: 0px; top: 0px; width: 253px">
                      <asp:Label ID="lblhora" CssClass="text-muted" runat="server" Text="HoraActual"></asp:Label>
                  </div>
                </div>
                    <br />
                <div class="form-group">
                  <label for="inputEmail3" class="col-sm-2 control-label" style="left: 0px; top: 0px; width: 114px; height: 20px;">Depósito:</label>

                  <div class="col-sm-10" style="left: 0px; top: 0px; width: 253px">
                      <asp:Label ID="lbldeposito" CssClass="text-muted" runat="server" Text="DEPOSITO"></asp:Label>
                  </div>
                </div>
                    <br />
                 <div class="form-group">
                  <label for="inputEmail3" class="col-sm-2 control-label" style="left: 0px; top: 0px; width: 114px">Tipo de Comprobante:</label>

                  <div class="col-sm-10" style="left: 0px; top: 0px; width: 253px">
                      <asp:DropDownList ID="ddlcomprobante" runat="server" CssClass="form-control" Height="32px" Width="128px">
                      </asp:DropDownList>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator68" runat="server" ControlToValidate="ddlcomprobante" Display="None" ErrorMessage="Seleccione un comprobante" SetFocusOnError="True"></asp:RequiredFieldValidator>
                      <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender68" runat="server" BehaviorID="RequiredFieldValidator68_ValidatorCalloutExtender" TargetControlID="RequiredFieldValidator68">
                      </ajaxToolkit:ValidatorCalloutExtender>
                  </div>
                </div>
               <br />
                <br />
                <div class="form-group">
                  <label for="inputEmail3" class="col-sm-2 control-label" style="left: 0px; top: 0px; width: 114px">Nº Orden:</label>

                  <div class="col-sm-10" style="left: 0px; top: 0px; width: 253px">
                    <asp:TextBox  CssClass="form-control" ID="tbnumerodeorden"  runat="server" Height="24px" Width="128px"></asp:TextBox>
                  <asp:Button ID="btnverificarNorden" CssClass="btn btn-success" runat="server" Text="Verificar" OnClick="btnregistrar_Click" Height="31px" Width="82px" />
                
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator79" runat="server" ControlToValidate="tbnumerodeorden" Display="None" ErrorMessage="Ingrese el Nro de Orden" SetFocusOnError="True"></asp:RequiredFieldValidator>
                      <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender79" runat="server" BehaviorID="validadornombre" TargetControlID="RequiredFieldValidator79">
                      </ajaxToolkit:ValidatorCalloutExtender>
                  </div>
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
<div class="box-footer">
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  <asp:Button ID="btnregistrar" CssClass="btn btn-info" runat="server" Text="Registrar" OnClick="btnregistrar_Click" />
                
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  <asp:Button ID="btncancelar" runat="server" CssClass="btn btn-default" Text="Cancelar" CausesValidation="False" />
                
              </div>
    </div>
    <!-- /.box -->

</asp:Content>

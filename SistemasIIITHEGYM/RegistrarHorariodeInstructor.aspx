<%@ Page Title="" Language="C#" MasterPageFile="~/GYMPaginasMaestras/PaginaMaestraEmpleado.Master" AutoEventWireup="true" CodeBehind="RegistrarHorariodeInstructor.aspx.cs" Inherits="SistemasIIITHEGYM.RegistrarHorariodeInstructor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="EstilosCSS.css" rel="stylesheet" />
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
                <p>¡Horario registrado exitosamente!&hellip;</p>
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



    <div class="box box-primary" style="left: 0px; top: 0px; width: 97%">
            <div class="box-header with-border">
              <h3 class="box-title" style="width: 390px">Horario de Instructor</h3>
            </div>
            <!-- /.box-header -->
            <!-- form start -->
                      <div class="box-body">
                      <asp:Panel ID="Panel1" runat="server" Font-Size="Medium" Height="478px" Width="524px" style="margin-left: 34px">
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblProfesor" runat="server" Text="Profesor:"></asp:Label>
        <asp:DropDownList ID="ddlProfesor" runat="server">
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <table class="nav-justified">
            <tr>
                <td>
                    <asp:Label ID="lbldias" runat="server" Text="Dias"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblDesde" runat="server" Text="Desde"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblHasta" runat="server" Text="Hasta"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="CbLunes" runat="server" Text="Lunes" OnCheckedChanged="CbLunes_CheckedChanged" AutoPostBack="True" />
                </td>
                <td>
                    <asp:DropDownList ID="DdldeLunes" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DdldeLunes_SelectedIndexChanged">
                        <asp:ListItem>--</asp:ListItem>
                        <asp:ListItem Value="8">8:00</asp:ListItem>
                        <asp:ListItem Value="9">9:00</asp:ListItem>
                        <asp:ListItem Value="10">10:00</asp:ListItem>
                        <asp:ListItem Value="11">11:00</asp:ListItem>
                        <asp:ListItem Value="12">12:00</asp:ListItem>
                        <asp:ListItem Value="13">13:00</asp:ListItem>
                        <asp:ListItem Value="14">14:00</asp:ListItem>
                        <asp:ListItem Value="15">15:00</asp:ListItem>
                        <asp:ListItem Value="16">16:00</asp:ListItem>
                        <asp:ListItem Value="17">17:00</asp:ListItem>
                        <asp:ListItem Value="18">18:00</asp:ListItem>
                        <asp:ListItem Value="19">19:00</asp:ListItem>
                        <asp:ListItem Value="20">20:00</asp:ListItem>
                        <asp:ListItem Value="21">21:00</asp:ListItem>
                        <asp:ListItem Value="22">22:00</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="DdlhastaLunes" runat="server" OnSelectedIndexChanged="DropDownList7_SelectedIndexChanged" Width="54px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="CbMartes" runat="server" Text="Martes" AutoPostBack="True" OnCheckedChanged="CbMartes_CheckedChanged" />
                </td>
                <td>
                    <asp:DropDownList ID="DdldeMartes" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DdldeMartes_SelectedIndexChanged1">
                        <asp:ListItem>--</asp:ListItem>
                        <asp:ListItem Value="8">8:00</asp:ListItem>
                        <asp:ListItem Value="9">9:00</asp:ListItem>
                        <asp:ListItem Value="10">10:00</asp:ListItem>
                        <asp:ListItem Value="11">11:00</asp:ListItem>
                        <asp:ListItem Value="12">12:00</asp:ListItem>
                        <asp:ListItem Value="13">13:00</asp:ListItem>
                        <asp:ListItem Value="14">14:00</asp:ListItem>
                        <asp:ListItem Value="15">15:00</asp:ListItem>
                        <asp:ListItem Value="16">16:00</asp:ListItem>
                        <asp:ListItem Value="17">17:00</asp:ListItem>
                        <asp:ListItem Value="18">18:00</asp:ListItem>
                        <asp:ListItem Value="19">19:00</asp:ListItem>
                        <asp:ListItem Value="20">20:00</asp:ListItem>
                        <asp:ListItem Value="21">21:00</asp:ListItem>
                        <asp:ListItem Value="22">22:00</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="DdlhastaMartes" runat="server" OnSelectedIndexChanged="DropDownList7_SelectedIndexChanged" Width="54px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="height: 25px">
                    <asp:CheckBox ID="CbMiercoles" runat="server" Text="Miercoles" AutoPostBack="True" OnCheckedChanged="CbMiercoles_CheckedChanged" />
                </td>
                <td style="height: 25px">
                    <asp:DropDownList ID="DdldeMiercoles" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DdldeMiercoles_SelectedIndexChanged">
                        <asp:ListItem>--</asp:ListItem>
                        <asp:ListItem Value="8">8:00</asp:ListItem>
                        <asp:ListItem Value="9">9:00</asp:ListItem>
                        <asp:ListItem Value="10">10:00</asp:ListItem>
                        <asp:ListItem Value="11">11:00</asp:ListItem>
                        <asp:ListItem Value="12">12:00</asp:ListItem>
                        <asp:ListItem Value="13">13:00</asp:ListItem>
                        <asp:ListItem Value="14">14:00</asp:ListItem>
                        <asp:ListItem Value="15">15:00</asp:ListItem>
                        <asp:ListItem Value="16">16:00</asp:ListItem>
                        <asp:ListItem Value="17">17:00</asp:ListItem>
                        <asp:ListItem Value="18">18:00</asp:ListItem>
                        <asp:ListItem Value="19">19:00</asp:ListItem>
                        <asp:ListItem Value="20">20:00</asp:ListItem>
                        <asp:ListItem Value="21">21:00</asp:ListItem>
                        <asp:ListItem Value="22">22:00</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="height: 25px">
                    <asp:DropDownList ID="DdlhastaMiercoles" runat="server" OnSelectedIndexChanged="DropDownList7_SelectedIndexChanged" Width="54px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="CbJueves" runat="server" Text="Jueves" AutoPostBack="True" OnCheckedChanged="CbJueves_CheckedChanged" />
                </td>
                <td>
                    <asp:DropDownList ID="DdldeJueves" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DdldeJueves_SelectedIndexChanged">
                        <asp:ListItem>--</asp:ListItem>
                        <asp:ListItem Value="8">8:00</asp:ListItem>
                        <asp:ListItem Value="9">9:00</asp:ListItem>
                        <asp:ListItem Value="10">10:00</asp:ListItem>
                        <asp:ListItem Value="11">11:00</asp:ListItem>
                        <asp:ListItem Value="12">12:00</asp:ListItem>
                        <asp:ListItem Value="13">13:00</asp:ListItem>
                        <asp:ListItem Value="14">14:00</asp:ListItem>
                        <asp:ListItem Value="15">15:00</asp:ListItem>
                        <asp:ListItem Value="16">16:00</asp:ListItem>
                        <asp:ListItem Value="17">17:00</asp:ListItem>
                        <asp:ListItem Value="18">18:00</asp:ListItem>
                        <asp:ListItem Value="19">19:00</asp:ListItem>
                        <asp:ListItem Value="20">20:00</asp:ListItem>
                        <asp:ListItem Value="21">21:00</asp:ListItem>
                        <asp:ListItem Value="22">22:00</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="DdlhastaJueves" runat="server" OnSelectedIndexChanged="DropDownList7_SelectedIndexChanged" Width="54px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="CbViernes" runat="server" Text="Viernes" AutoPostBack="True" OnCheckedChanged="CbViernes_CheckedChanged" />
                </td>
                <td>
                    <asp:DropDownList ID="DdldeViernes" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DdldeViernes_SelectedIndexChanged">
                        <asp:ListItem>--</asp:ListItem>
                        <asp:ListItem Value="8">8:00</asp:ListItem>
                        <asp:ListItem Value="9">9:00</asp:ListItem>
                        <asp:ListItem Value="10">10:00</asp:ListItem>
                        <asp:ListItem Value="11">11:00</asp:ListItem>
                        <asp:ListItem Value="12">12:00</asp:ListItem>
                        <asp:ListItem Value="13">13:00</asp:ListItem>
                        <asp:ListItem Value="14">14:00</asp:ListItem>
                        <asp:ListItem Value="15">15:00</asp:ListItem>
                        <asp:ListItem Value="16">16:00</asp:ListItem>
                        <asp:ListItem Value="17">17:00</asp:ListItem>
                        <asp:ListItem Value="18">18:00</asp:ListItem>
                        <asp:ListItem Value="19">19:00</asp:ListItem>
                        <asp:ListItem Value="20">20:00</asp:ListItem>
                        <asp:ListItem Value="21">21:00</asp:ListItem>
                        <asp:ListItem Value="22">22:00</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="DdlhastaViernes" runat="server" OnSelectedIndexChanged="DropDownList7_SelectedIndexChanged" Width="54px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="CbSabado" runat="server" Text="Sabado" AutoPostBack="True" OnCheckedChanged="CbSabado_CheckedChanged" />
                </td>
                <td>
                    <asp:DropDownList ID="DdldeSabado" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DdldeSabado_SelectedIndexChanged">
                        <asp:ListItem>--</asp:ListItem>
                        <asp:ListItem Value="8">8:00</asp:ListItem>
                        <asp:ListItem Value="9">9:00</asp:ListItem>
                        <asp:ListItem Value="10">10:00</asp:ListItem>
                        <asp:ListItem Value="11">11:00</asp:ListItem>
                        <asp:ListItem Value="12">12:00</asp:ListItem>
                        <asp:ListItem Value="13">13:00</asp:ListItem>
                        <asp:ListItem Value="14">14:00</asp:ListItem>
                        <asp:ListItem Value="15">15:00</asp:ListItem>
                        <asp:ListItem Value="16">16:00</asp:ListItem>
                        <asp:ListItem Value="17">17:00</asp:ListItem>
                        <asp:ListItem Value="18">18:00</asp:ListItem>
                        <asp:ListItem Value="19">19:00</asp:ListItem>
                        <asp:ListItem Value="20">20:00</asp:ListItem>
                        <asp:ListItem Value="21">21:00</asp:ListItem>
                        <asp:ListItem Value="22">22:00</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="DdlhastaSabado" runat="server" OnSelectedIndexChanged="DropDownList7_SelectedIndexChanged" Width="54px">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <br />
        <br />
                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="BtnGuardar" CssClass="btn btn-info" runat="server" Text="Guardar" Width="123px" OnClick="BtnGuardar_Click" />
                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="BtnCancelar" runat="server" CssClass="btn btn-default" Text="Cancelar" Width="123px" OnClick="BtnCancelar_Click" />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                          <asp:Label ID="lblerror" CssClass="error-text" runat="server"></asp:Label>
        <br />
                          <br />
                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
    </asp:Panel>
              </div>
              <!-- /.box-body -->

          </div>
              
</asp:Content>

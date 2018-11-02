<%@ Page Title="" Language="C#" MasterPageFile="~/GYMPaginasMaestras/PaginaMaestraEmpleado.Master" AutoEventWireup="true" CodeBehind="RegistrarCronogramaSemanalEmpleado.aspx.cs" Inherits="SistemasIIITHEGYM.RegistrarCronogramaSemanalEmpleado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <asp:Label ID="lblusuario" runat="server" Font-Bold="True" Font-Names="Arial Black" Font-Size="Small" ForeColor="White"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <link href="EstilosCSS.css" rel="stylesheet" />
    <script type ="text/javascript">
       
 function show()
    {
        document.write("<head runat='server'></head>");
    }
    </script>

                    <section class="content-header">
                    <h1>Registrar Horario Semanal <small>TheGym</small> </h1>
                </section>


    <asp:Panel ID="panelconsulta" runat="server">
                <%-- inicio contenedor busqueda--%>
                <div class="row">
                    <div class="col-md-12">
                        <div class="box">
                            <div class="box-header with-border" style="left: 0px; top: 0px; width: 607px;">
                                <h3 class="box-title">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </h3>
                            </div>
                            <div class="box-body">
                                <div class="form-group">
                                    <table class="nav-justified" style="height: 294px">
                                        <tr>
                                            <td style="height: 21px; width: 266px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblProfesor" runat="server" Text="Profesor:"></asp:Label>
                                                <asp:DropDownList ID="ddlProfesor" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="height: 21px; width: 198px;">
                                                <asp:Label ID="LblActividad" runat="server" Text="Actividad:"></asp:Label>
                                                <asp:DropDownList ID="ddlActividad" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 266px">
                                                <asp:Label ID="lbldias" runat="server" Text="Dias"></asp:Label>
                                            </td>
                                            <td style="width: 198px">
                                                <asp:Label ID="lblDesde" runat="server" Text="Desde"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblHasta" runat="server" Text="Hasta"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 266px">
                                                <asp:CheckBox ID="CbLunes" runat="server" AutoPostBack="True" OnCheckedChanged="CbLunes_CheckedChanged" Text="Lunes" />
                                            </td>
                                            <td style="width: 198px">
                                                <asp:DropDownList ID="DdlLunes" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DdlLunes_SelectedIndexChanged">
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
                                            <td style="width: 266px; height: 21px;">
                                                <asp:CheckBox ID="CbMartes" runat="server" AutoPostBack="True" OnCheckedChanged="CbMartes_CheckedChanged" Text="Martes" />
                                            </td>
                                            <td style="width: 198px; height: 21px">
                                                <asp:DropDownList ID="DdlMartes" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DdlMartes_SelectedIndexChanged">
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
                                            <td style="height: 21px">
                                                <asp:DropDownList ID="DdlhastaMartes" runat="server" OnSelectedIndexChanged="DropDownList7_SelectedIndexChanged" Width="54px">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 266px">
                                                <asp:CheckBox ID="CbMiercoles" runat="server" AutoPostBack="True" OnCheckedChanged="CbMiercoles_CheckedChanged" Text="Miercoles" />
                                            </td>
                                            <td style="width: 198px">
                                                <asp:DropDownList ID="DdlMiercoles" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DdlMiercoles_SelectedIndexChanged">
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
                                                <asp:DropDownList ID="DdlhastaMiercoles" runat="server" OnSelectedIndexChanged="DropDownList7_SelectedIndexChanged" Width="54px">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 266px">
                                                <asp:CheckBox ID="CbJueves" runat="server" AutoPostBack="True" OnCheckedChanged="CbJueves_CheckedChanged" Text="Jueves" />
                                            </td>
                                            <td style="width: 198px">
                                                <asp:DropDownList ID="DdlJueves" runat="server" AutoPostBack="True" Height="16px" OnSelectedIndexChanged="DdlJueves_SelectedIndexChanged">
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
                                            <td style="width: 266px">
                                                <asp:CheckBox ID="CbViernes" runat="server" AutoPostBack="True" OnCheckedChanged="CbViernes_CheckedChanged" Text="Viernes" />
                                            </td>
                                            <td style="width: 198px">
                                                <asp:DropDownList ID="DdlViernes" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DdlViernes_SelectedIndexChanged">
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
                                            <td style="width: 266px; height: 20px;">
                                                <asp:CheckBox ID="CbSabado" runat="server" AutoPostBack="True" OnCheckedChanged="CbSabado_CheckedChanged" Text="Sabado" />
                                            </td>
                                            <td style="height: 20px; width: 198px;">
                                                <asp:DropDownList ID="DdlSabado" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DdlSabado_SelectedIndexChanged">
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
                                            <td style="height: 20px">
                                                <asp:DropDownList ID="DdlhastaSabado" runat="server" OnSelectedIndexChanged="DropDownList7_SelectedIndexChanged" Width="54px">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 266px">
                                                <asp:Button ID="BtnGuardar" runat="server" CssClass="btn btn-info" OnClick="BtnGuardar_Click" Text="Guardar" Width="123px" />
                                            </td>
                                            <td style="width: 198px">
                                                <asp:Button ID="BtnCancelar" runat="server" CssClass="btn btn-default" OnClick="BtnCancelar_Click" Text="Cancelar" Width="123px" />
                                            </td>
                                            <td>
                                                <asp:Label ID="lblerror" runat="server" CssClass="error-text"></asp:Label>
                                            </td>
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
                                      <h3 class="box-title">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; Cronograma</h3>
                                  </div>
                                  <div class="box-body">
              <!-- Date -->
                                      <div class="form-group">
                                          &nbsp;
                                          <asp:GridView ID="gvcronograma" runat="server" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CaptionAlign="Bottom" CellPadding="4" CellSpacing="1" Font-Size="Medium" ForeColor="Black" GridLines="Horizontal" Height="175px" HorizontalAlign="Justify" PageSize="6" ShowHeaderWhenEmpty="True" style="margin-left: 136px; margin-bottom: 9px;" Width="520px">
                                              <Columns>
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
                                      <div class="box-footer">
                                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnRegistrar" runat="server" CssClass="btn btn-info" Text="Registrar" />
                                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnvolver" runat="server" CausesValidation="False" CssClass="btn btn-default" Text="Volver" />
                                      </div>
                <br />
                                  </div>
                              </div>
              <!-- /.row -->
                          </div>
                </div>
            <!-- /.box-footer -->
            </asp:Panel>
</asp:Content>

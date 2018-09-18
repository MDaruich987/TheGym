<%@ Page Title="" Language="C#" MasterPageFile="~/GYMPaginasMaestras/PaginaMaestraEmpleado.Master" AutoEventWireup="true" CodeBehind="RegistrarHorariodeInstructor.aspx.cs" Inherits="SistemasIIITHEGYM.RegistrarHorariodeInstructor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" Font-Size="Medium" Height="478px" Width="524px">
        <asp:Label ID="lblRegistrar" runat="server" Text="Registrar Horario de Instructor" Font-Size="X-Large"></asp:Label>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblProfesor" runat="server" Text="Profesor:"></asp:Label>
        <asp:DropDownList ID="ddlProfesor" runat="server">
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="LblActividad" runat="server" Text="Actividad:"></asp:Label>
        <asp:DropDownList ID="ddlActividad" runat="server">
        </asp:DropDownList>
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
                    <asp:CheckBox ID="CbLunes" runat="server" Text="Lunes" />
                </td>
                <td>
                    <asp:DropDownList ID="DdldeLunes" runat="server">
                        <asp:ListItem>--</asp:ListItem>
                        <asp:ListItem>08:00</asp:ListItem>
                        <asp:ListItem>09:00</asp:ListItem>
                        <asp:ListItem>10:00</asp:ListItem>
                        <asp:ListItem>11:00</asp:ListItem>
                        <asp:ListItem>12:00</asp:ListItem>
                        <asp:ListItem>13:00</asp:ListItem>
                        <asp:ListItem>14:00</asp:ListItem>
                        <asp:ListItem>15:00</asp:ListItem>
                        <asp:ListItem>16:00</asp:ListItem>
                        <asp:ListItem>17:00</asp:ListItem>
                        <asp:ListItem>18:00</asp:ListItem>
                        <asp:ListItem>19:00</asp:ListItem>
                        <asp:ListItem>20:00</asp:ListItem>
                        <asp:ListItem>21:00</asp:ListItem>
                        <asp:ListItem>22:00</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="DdlhastaLunes" runat="server" OnSelectedIndexChanged="DropDownList7_SelectedIndexChanged">
                        <asp:ListItem>--</asp:ListItem>
                        <asp:ListItem>09:00</asp:ListItem>
                        <asp:ListItem>10:00</asp:ListItem>
                        <asp:ListItem>11:00</asp:ListItem>
                        <asp:ListItem>12:00</asp:ListItem>
                        <asp:ListItem>13:00</asp:ListItem>
                        <asp:ListItem>14:00</asp:ListItem>
                        <asp:ListItem>15:00</asp:ListItem>
                        <asp:ListItem>16:00</asp:ListItem>
                        <asp:ListItem>17:00</asp:ListItem>
                        <asp:ListItem>18:00</asp:ListItem>
                        <asp:ListItem>19:00</asp:ListItem>
                        <asp:ListItem>20:00</asp:ListItem>
                        <asp:ListItem>21:00</asp:ListItem>
                        <asp:ListItem>22:00</asp:ListItem>
                        <asp:ListItem>23:00</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="CbMartes" runat="server" Text="Martes" />
                </td>
                <td>
                    <asp:DropDownList ID="DdldeMartes" runat="server" OnSelectedIndexChanged="DdldeMartes_SelectedIndexChanged">
                        <asp:ListItem>--</asp:ListItem>
                        <asp:ListItem>08:00</asp:ListItem>
                        <asp:ListItem>09:00</asp:ListItem>
                        <asp:ListItem>10:00</asp:ListItem>
                        <asp:ListItem>11:00</asp:ListItem>
                        <asp:ListItem>12:00</asp:ListItem>
                        <asp:ListItem>13:00</asp:ListItem>
                        <asp:ListItem>14:00</asp:ListItem>
                        <asp:ListItem>15:00</asp:ListItem>
                        <asp:ListItem>16:00</asp:ListItem>
                        <asp:ListItem>17:00</asp:ListItem>
                        <asp:ListItem>18:00</asp:ListItem>
                        <asp:ListItem>19:00</asp:ListItem>
                        <asp:ListItem>20:00</asp:ListItem>
                        <asp:ListItem>21:00</asp:ListItem>
                        <asp:ListItem>22:00</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="DdlhastaMartes" runat="server" OnSelectedIndexChanged="DropDownList7_SelectedIndexChanged">
                        <asp:ListItem>--</asp:ListItem>
                        <asp:ListItem>09:00</asp:ListItem>
                        <asp:ListItem>10:00</asp:ListItem>
                        <asp:ListItem>11:00</asp:ListItem>
                        <asp:ListItem>12:00</asp:ListItem>
                        <asp:ListItem>13:00</asp:ListItem>
                        <asp:ListItem>14:00</asp:ListItem>
                        <asp:ListItem>15:00</asp:ListItem>
                        <asp:ListItem>16:00</asp:ListItem>
                        <asp:ListItem>17:00</asp:ListItem>
                        <asp:ListItem>18:00</asp:ListItem>
                        <asp:ListItem>19:00</asp:ListItem>
                        <asp:ListItem>20:00</asp:ListItem>
                        <asp:ListItem>21:00</asp:ListItem>
                        <asp:ListItem>22:00</asp:ListItem>
                        <asp:ListItem>23:00</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="height: 25px">
                    <asp:CheckBox ID="CbMiercoles" runat="server" Text="Miercoles" />
                </td>
                <td style="height: 25px">
                    <asp:DropDownList ID="DdldeMiercoles" runat="server">
                        <asp:ListItem>--</asp:ListItem>
                        <asp:ListItem>08:00</asp:ListItem>
                        <asp:ListItem>09:00</asp:ListItem>
                        <asp:ListItem>10:00</asp:ListItem>
                        <asp:ListItem>11:00</asp:ListItem>
                        <asp:ListItem>12:00</asp:ListItem>
                        <asp:ListItem>13:00</asp:ListItem>
                        <asp:ListItem>14:00</asp:ListItem>
                        <asp:ListItem>15:00</asp:ListItem>
                        <asp:ListItem>16:00</asp:ListItem>
                        <asp:ListItem>17:00</asp:ListItem>
                        <asp:ListItem>18:00</asp:ListItem>
                        <asp:ListItem>19:00</asp:ListItem>
                        <asp:ListItem>20:00</asp:ListItem>
                        <asp:ListItem>21:00</asp:ListItem>
                        <asp:ListItem>22:00</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="height: 25px">
                    <asp:DropDownList ID="DdlhastaMiercoles" runat="server" OnSelectedIndexChanged="DropDownList7_SelectedIndexChanged">
                        <asp:ListItem>--</asp:ListItem>
                        <asp:ListItem>09:00</asp:ListItem>
                        <asp:ListItem>10:00</asp:ListItem>
                        <asp:ListItem>11:00</asp:ListItem>
                        <asp:ListItem>12:00</asp:ListItem>
                        <asp:ListItem>13:00</asp:ListItem>
                        <asp:ListItem>14:00</asp:ListItem>
                        <asp:ListItem>15:00</asp:ListItem>
                        <asp:ListItem>16:00</asp:ListItem>
                        <asp:ListItem>17:00</asp:ListItem>
                        <asp:ListItem>18:00</asp:ListItem>
                        <asp:ListItem>19:00</asp:ListItem>
                        <asp:ListItem>20:00</asp:ListItem>
                        <asp:ListItem>21:00</asp:ListItem>
                        <asp:ListItem>22:00</asp:ListItem>
                        <asp:ListItem>23:00</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="CbJueves" runat="server" Text="Jueves" />
                </td>
                <td>
                    <asp:DropDownList ID="DdldeJueves" runat="server">
                        <asp:ListItem>--</asp:ListItem>
                        <asp:ListItem>08:00</asp:ListItem>
                        <asp:ListItem>09:00</asp:ListItem>
                        <asp:ListItem>10:00</asp:ListItem>
                        <asp:ListItem>11:00</asp:ListItem>
                        <asp:ListItem>12:00</asp:ListItem>
                        <asp:ListItem>13:00</asp:ListItem>
                        <asp:ListItem>14:00</asp:ListItem>
                        <asp:ListItem>15:00</asp:ListItem>
                        <asp:ListItem>16:00</asp:ListItem>
                        <asp:ListItem>17:00</asp:ListItem>
                        <asp:ListItem>18:00</asp:ListItem>
                        <asp:ListItem>19:00</asp:ListItem>
                        <asp:ListItem>20:00</asp:ListItem>
                        <asp:ListItem>21:00</asp:ListItem>
                        <asp:ListItem>22:00</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="DdlhastaJueves" runat="server" OnSelectedIndexChanged="DropDownList7_SelectedIndexChanged">
                        <asp:ListItem>--</asp:ListItem>
                        <asp:ListItem>09:00</asp:ListItem>
                        <asp:ListItem>10:00</asp:ListItem>
                        <asp:ListItem>11:00</asp:ListItem>
                        <asp:ListItem>12:00</asp:ListItem>
                        <asp:ListItem>13:00</asp:ListItem>
                        <asp:ListItem>14:00</asp:ListItem>
                        <asp:ListItem>15:00</asp:ListItem>
                        <asp:ListItem>16:00</asp:ListItem>
                        <asp:ListItem>17:00</asp:ListItem>
                        <asp:ListItem>18:00</asp:ListItem>
                        <asp:ListItem>19:00</asp:ListItem>
                        <asp:ListItem>20:00</asp:ListItem>
                        <asp:ListItem>21:00</asp:ListItem>
                        <asp:ListItem>22:00</asp:ListItem>
                        <asp:ListItem>23:00</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="CbViernes" runat="server" Text="Viernes" />
                </td>
                <td>
                    <asp:DropDownList ID="DdldeViernes" runat="server">
                        <asp:ListItem>--</asp:ListItem>
                        <asp:ListItem>08:00</asp:ListItem>
                        <asp:ListItem>09:00</asp:ListItem>
                        <asp:ListItem>10:00</asp:ListItem>
                        <asp:ListItem>11:00</asp:ListItem>
                        <asp:ListItem>12:00</asp:ListItem>
                        <asp:ListItem>13:00</asp:ListItem>
                        <asp:ListItem>14:00</asp:ListItem>
                        <asp:ListItem>15:00</asp:ListItem>
                        <asp:ListItem>16:00</asp:ListItem>
                        <asp:ListItem>17:00</asp:ListItem>
                        <asp:ListItem>18:00</asp:ListItem>
                        <asp:ListItem>19:00</asp:ListItem>
                        <asp:ListItem>20:00</asp:ListItem>
                        <asp:ListItem>21:00</asp:ListItem>
                        <asp:ListItem>22:00</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="DdlhastaViernes" runat="server" OnSelectedIndexChanged="DropDownList7_SelectedIndexChanged">
                        <asp:ListItem>--</asp:ListItem>
                        <asp:ListItem>09:00</asp:ListItem>
                        <asp:ListItem>10:00</asp:ListItem>
                        <asp:ListItem>11:00</asp:ListItem>
                        <asp:ListItem>12:00</asp:ListItem>
                        <asp:ListItem>13:00</asp:ListItem>
                        <asp:ListItem>14:00</asp:ListItem>
                        <asp:ListItem>15:00</asp:ListItem>
                        <asp:ListItem>16:00</asp:ListItem>
                        <asp:ListItem>17:00</asp:ListItem>
                        <asp:ListItem>18:00</asp:ListItem>
                        <asp:ListItem>19:00</asp:ListItem>
                        <asp:ListItem>20:00</asp:ListItem>
                        <asp:ListItem>21:00</asp:ListItem>
                        <asp:ListItem>22:00</asp:ListItem>
                        <asp:ListItem>23:00</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="CbSabado" runat="server" Text="Sabado" />
                </td>
                <td>
                    <asp:DropDownList ID="DdldeSabado" runat="server">
                        <asp:ListItem>--</asp:ListItem>
                        <asp:ListItem>08:00</asp:ListItem>
                        <asp:ListItem>09:00</asp:ListItem>
                        <asp:ListItem>10:00</asp:ListItem>
                        <asp:ListItem>11:00</asp:ListItem>
                        <asp:ListItem>12:00</asp:ListItem>
                        <asp:ListItem>13:00</asp:ListItem>
                        <asp:ListItem>14:00</asp:ListItem>
                        <asp:ListItem>15:00</asp:ListItem>
                        <asp:ListItem>16:00</asp:ListItem>
                        <asp:ListItem>17:00</asp:ListItem>
                        <asp:ListItem>18:00</asp:ListItem>
                        <asp:ListItem>19:00</asp:ListItem>
                        <asp:ListItem>20:00</asp:ListItem>
                        <asp:ListItem>21:00</asp:ListItem>
                        <asp:ListItem>22:00</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="DdlhastaSabado" runat="server" OnSelectedIndexChanged="DropDownList7_SelectedIndexChanged">
                        <asp:ListItem>--</asp:ListItem>
                        <asp:ListItem>09:00</asp:ListItem>
                        <asp:ListItem>10:00</asp:ListItem>
                        <asp:ListItem>11:00</asp:ListItem>
                        <asp:ListItem>12:00</asp:ListItem>
                        <asp:ListItem>13:00</asp:ListItem>
                        <asp:ListItem>14:00</asp:ListItem>
                        <asp:ListItem>15:00</asp:ListItem>
                        <asp:ListItem>16:00</asp:ListItem>
                        <asp:ListItem>17:00</asp:ListItem>
                        <asp:ListItem>18:00</asp:ListItem>
                        <asp:ListItem>19:00</asp:ListItem>
                        <asp:ListItem>20:00</asp:ListItem>
                        <asp:ListItem>21:00</asp:ListItem>
                        <asp:ListItem>22:00</asp:ListItem>
                        <asp:ListItem>23:00</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" Width="123px" OnClick="BtnGuardar_Click" />
        <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" Width="123px" OnClick="BtnCancelar_Click" />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
    </asp:Panel>
</asp:Content>

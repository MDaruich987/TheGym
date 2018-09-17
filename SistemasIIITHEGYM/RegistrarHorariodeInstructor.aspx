<%@ Page Title="" Language="C#" MasterPageFile="~/GYMPaginasMaestras/PaginaMaestraEmpleado.Master" AutoEventWireup="true" CodeBehind="RegistrarHorariodeInstructor.aspx.cs" Inherits="SistemasIIITHEGYM.RegistrarHorariodeInstructor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" Font-Size="Medium" Height="425px" Width="523px">
        <asp:Label ID="lblRegistrar" runat="server" Text="Registrar Horario de Instructor" Font-Size="X-Large"></asp:Label>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblProfesor" runat="server" Text="Profesor:"></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server">
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="LblActividad" runat="server" Text="Actividad:"></asp:Label>
        <asp:DropDownList ID="DropDownList2" runat="server">
        </asp:DropDownList>
        <br />
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblHorario" runat="server" Text="Horario"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblDe" runat="server" Text="De:"></asp:Label>
        <asp:DropDownList ID="DropDownList3" runat="server" Height="16px" Width="57px">
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblHasta" runat="server" Text="Hasta:"></asp:Label>
        <asp:DropDownList ID="DropDownList5" runat="server" Height="16px" Width="57px">
        </asp:DropDownList>
        <br />
        <br />
        <br />
        <asp:Label ID="lblSemana" runat="server" Text="Dias de la semana:"></asp:Label>
        &nbsp;<asp:RadioButton ID="RbLunes" runat="server" Text="Lunes" />
        &nbsp;<asp:RadioButton ID="RbMartes" runat="server" Text="Martes" />
        &nbsp;<asp:RadioButton ID="RbMiercoles" runat="server" Text="Miercoles" />
        &nbsp;<asp:RadioButton ID="RBJueves" runat="server" Text="Jueves" />
        &nbsp;<asp:RadioButton ID="RBViernes" runat="server" Text="Viernes" />
        &nbsp;<asp:RadioButton ID="RBSabado" runat="server" Text="Sabado" />
        <br />
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" Width="123px" />
        <asp:Button ID="BtnCancelar" runat="server" Text="Cancelar" Width="123px" />
        <br />
    </asp:Panel>
</asp:Content>

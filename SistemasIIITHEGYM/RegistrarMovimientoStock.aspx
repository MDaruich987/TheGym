<%@ Page Title="" Language="C#" MasterPageFile="~/GYMPaginasMaestras/PaginaMaestaGerente.Master" AutoEventWireup="true" CodeBehind="RegistrarMovimientoStock.aspx.cs" Inherits="SistemasIIITHEGYM.RegistrarRemitoGerente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Label ID="lblusuario" runat="server" Font-Bold="True" Font-Names="Arial Black" Font-Size="Small" ForeColor="White"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="modal fade" id="modalexito">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header">
                  <%--<span aria-hidden="true">&times;</span></button>--%>                  <%--<button type="button" class="btn btn-default pull-left" data-dismiss="modal">Close</button>
                <button type="button" class="btn btn-primary">Save changes</button>--%>
                <h4 class="modal-title">THEGYM</h4>
              </div>
              <div class="modal-body">
                <p>Se registró el Movimiento de Stock&hellip;</p>
              </div>
              <div class="modal-footer">
                  <%--                boton minimizar y cerrar--%>
              </div>
            </div>
            <!-- /.modal-content -->
          </div>
          <!-- /.modal-dialog -->
        </div>
        <!-- /.modal -->
<%--    TituloSuperior--%>
    <section class="content-header">
        <h1>Registrar Movimiento de Stock<small>TheGym</small> </h1>
        <p>
            &nbsp;</p>
        <br />
    </section>


</asp:Content>

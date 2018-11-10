<%@ Page Title="" Language="C#" MasterPageFile="~/GYMPaginasMaestras/PaginaMaestraEmpleado.Master" AutoEventWireup="true" CodeBehind="EmailClientesPlanes.aspx.cs" Inherits="SistemasIIITHEGYM.EmailClientesPlanes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Label ID="lblusuario" runat="server" Font-Bold="True" Font-Names="Arial Black" Font-Size="Small" ForeColor="White"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                 <div class="modal fade" id="modal-envio">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header">
                  <%--<span aria-hidden="true">&times;</span></button>--%>                  <%--<button type="button" class="btn btn-default pull-left" data-dismiss="modal">Close</button>
                <button type="button" class="btn btn-primary">Save changes</button>--%>
                <h4 class="modal-title">THEGYM</h4>
              </div>
              <div class="modal-body">
                <p>¡Promoción enviada exitosamene!</p>
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
    <%--<section class="content-header">
                    <h1>Operaciones de caja <small>TheGym</small> </h1>
                </section>--%>
    <!-- SELECT2 EXAMPLE -->
    <div class="box box-default">
        <div class="box-header with-border">
            <h3 class="box-title">Envio de Promociones</h3>
            <div class="box-tools pull-right">
<%--                boton minimizar y cerrar--%>
<%--                <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>--%>
            </div>
        </div>
        <!-- /.box-header -->
                <div class="box-body">

   <asp:Label ID="lblseleccione" runat="server" Text="Seleccione el cliente al cual desea enviar el Email:" Font-Names="Arial" Font-Size="Medium"></asp:Label>       
                    <br />       
                    <asp:GridView ID="GridView1" runat="server" CellPadding="4" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" AllowPaging="True" PageSize="5">
                        <Columns>
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre"/>
                            <asp:BoundField DataField="Apellido" HeaderText="Apellido"/>
                            <asp:BoundField DataField="DNI" HeaderText="DNI"/>
                            <asp:ImageField DataImageUrlField="Foto" HeaderText="Foto"/>
                            <asp:BoundField DataField="Email" HeaderText="Email"/>
                            <asp:BoundField DataField="Vencimiento" HeaderText="Vencimiento"/>
                            <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
                        </Columns>
                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                        <RowStyle BackColor="White" ForeColor="#003399" />
                        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                        <SortedAscendingCellStyle BackColor="#EDF6F6" />
                        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                        <SortedDescendingCellStyle BackColor="#D6DFDF" />
                        <SortedDescendingHeaderStyle BackColor="#002876" />
                    </asp:GridView>
                    <br /> 
                    <asp:Label ID="Label1" runat="server" Font-Size="Large" ForeColor="Red"></asp:Label>

          <!-- /.row -->
        </div>
        <!-- /.box-body -->
    </div>
    <!-- /.box -->

              <!-- quick email widget -->
          <div class="box box-info">
            <div class="box-header">
              <i class="fa fa-envelope"></i>

              <h3 class="box-title">Envío del E-mail</h3>
              <!-- tools box -->
              <div class="pull-right box-tools">
              </div>
              <!-- /. tools -->
            </div>
            <div class="box-body">
                <div class="form-group">
                  <asp:TextBox ID="tbusuario" Cssclass="form-control" runat="server" Height="24px" Width="140px" ReadOnly="True"></asp:TextBox>
                  <asp:TextBox ID="tbusuario0" Cssclass="form-control" runat="server" Height="24px" Width="140px" ReadOnly="True"></asp:TextBox>
                    <asp:Label ID="lberror" runat="server"></asp:Label>
                </div>
                <div>
                    <asp:TextBox ID="tbmensaje" Cssclass="textarea" runat="server" Height="51px" TextMode="MultiLine" Width="537px" ReadOnly="True">Te estamos esperando. Presentando este mail obtene un 20% de descuento.</asp:TextBox>
                </div>
            </div>
            <div class="box-footer clearfix">
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Enviar Email" />
            </div>
          </div>
</asp:Content>

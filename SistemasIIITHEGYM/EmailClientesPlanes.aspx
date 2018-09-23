<%@ Page Title="" Language="C#" MasterPageFile="~/GYMPaginasMaestras/PaginaMaestraEmpleado.Master" AutoEventWireup="true" CodeBehind="EmailClientesPlanes.aspx.cs" Inherits="SistemasIIITHEGYM.EmailClientesPlanes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Label ID="lblusuario" runat="server" Font-Bold="True" Font-Names="Arial Black" Font-Size="Small" ForeColor="White"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                    <br /> 
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" EmptyDataText="No hay registros de datos para mostrar." OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                    <asp:BoundField DataField="Apellido" HeaderText="Apellido" SortExpression="Apellido" />
                    <asp:BoundField DataField="DNI" HeaderText="DNI" SortExpression="DNI" />
                    <asp:ImageField DataImageUrlField="Foto" HeaderText="Foto" SortExpression="Foto" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                    <asp:BoundField DataField="Vencimiento" HeaderText="Vencimiento" SortExpression="Vencimiento" />
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=DESKTOP-TN40SE1\SQLEXPRESS;Initial Catalog=TheGym;Integrated Security=True" DeleteCommand="DELETE FROM [Cliente] WHERE [Id_cliente] = @Id_cliente" InsertCommand="INSERT INTO [Cliente] ([Nombre], [Apellido], [Fecha_nac], [Email], [Telefono], [Foto], [Estado], [FK_TipoDocumento], [Numero], [Calle], [Barrio], [DNI], [FK_localidad]) VALUES (@Nombre, @Apellido, @Fecha_nac, @Email, @Telefono, @Foto, @Estado, @FK_TipoDocumento, @Numero, @Calle, @Barrio, @DNI, @FK_localidad)" ProviderName="System.Data.SqlClient" SelectCommand="select Nombre,Apellido,DNI,Foto,Email,Vencimiento
from Cliente as cli inner join Cuota as cuo on cli.Id_cliente=cuo.FK_Cliente where Vencimiento  &lt; =  GETDATE()
" UpdateCommand="UPDATE [Cliente] SET [Nombre] = @Nombre, [Apellido] = @Apellido, [Fecha_nac] = @Fecha_nac, [Email] = @Email, [Telefono] = @Telefono, [Foto] = @Foto, [Estado] = @Estado, [FK_TipoDocumento] = @FK_TipoDocumento, [Numero] = @Numero, [Calle] = @Calle, [Barrio] = @Barrio, [DNI] = @DNI, [FK_localidad] = @FK_localidad WHERE [Id_cliente] = @Id_cliente">
                <DeleteParameters>
                    <asp:Parameter Name="Id_cliente" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="Nombre" Type="String" />
                    <asp:Parameter Name="Apellido" Type="String" />
                    <asp:Parameter DbType="Date" Name="Fecha_nac" />
                    <asp:Parameter Name="Email" Type="String" />
                    <asp:Parameter Name="Telefono" Type="Int64" />
                    <asp:Parameter Name="Foto" Type="String" />
                    <asp:Parameter Name="Estado" Type="String" />
                    <asp:Parameter Name="FK_TipoDocumento" Type="Int32" />
                    <asp:Parameter Name="Numero" Type="Int32" />
                    <asp:Parameter Name="Calle" Type="String" />
                    <asp:Parameter Name="Barrio" Type="String" />
                    <asp:Parameter Name="DNI" Type="String" />
                    <asp:Parameter Name="FK_localidad" Type="Int32" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Nombre" Type="String" />
                    <asp:Parameter Name="Apellido" Type="String" />
                    <asp:Parameter DbType="Date" Name="Fecha_nac" />
                    <asp:Parameter Name="Email" Type="String" />
                    <asp:Parameter Name="Telefono" Type="Int64" />
                    <asp:Parameter Name="Foto" Type="String" />
                    <asp:Parameter Name="Estado" Type="String" />
                    <asp:Parameter Name="FK_TipoDocumento" Type="Int32" />
                    <asp:Parameter Name="Numero" Type="Int32" />
                    <asp:Parameter Name="Calle" Type="String" />
                    <asp:Parameter Name="Barrio" Type="String" />
                    <asp:Parameter Name="DNI" Type="String" />
                    <asp:Parameter Name="FK_localidad" Type="Int32" />
                    <asp:Parameter Name="Id_cliente" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>

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

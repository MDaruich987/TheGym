<%@ Page Title="" Language="C#" MasterPageFile="~/GYMPaginasMaestras/PaginaMaestaGerente.Master" AutoEventWireup="true" CodeBehind="GenerarReportesGerente.aspx.cs" Inherits="SistemasIIITHEGYM.GenerarReportesGerente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="EstilosCSS.css" rel="stylesheet" />
    <script type ="text/javascript">
       
 function show()
    {
        document.write("<head runat='server'></head>");
    }
    </script>



    <asp:UpdatePanel ID="upgeneral" runat="server">
        <ContentTemplate>
            <asp:Panel ID="paneledicion" runat="server" Height="1109px">
                <section class="content-header">
                    <h1>Reporte de Capital <small>TheGym</small> </h1>
                </section>
                <%--panel de datos generales rutina--%>
                <div class="box box-default">
                    <div class="box-header with-border">
                        <h3 class="box-title">Datos de Rutina </h3>
                        <div class="box-tools pull-right">
                            <%--                boton minimizar y cerrar--%><%--                <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>--%>
                        </div>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="col-sm-2 control-label" for="inputEmail3" style="left: 0px; top: 0px; width: 114px">
                                    Fecha Inicio:</label>
                                    <div class="col-sm-10" style="left: 0px; top: 0px; width: 253px">
                                        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" Height="24px" Width="128px" TextMode="DateTime"></asp:TextBox>
                                    </div>
                                </div>
                                <br />
                            </div>
                            <!-- columna2 inicio/.col -->
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="col-sm-2 control-label" for="inputEmail3" style="left: 0px; top: 0px; width: 114px">
                                    Fecha Fin:</label>
                                    <div class="col-sm-10" style="left: 0px; top: 0px; width: 253px">
                                        <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" Height="24px" Width="128px" TextMode="DateTime"></asp:TextBox>
                                    </div>
                                </div>
                                <br />
                                <!-- /.form-group -->
                                <asp:Label ID="Label1" runat="server" CssClass="error-text"></asp:Label>
                                <asp:Button ID="btnconsultar0" runat="server" CssClass="btn btn-info" OnClick="btnconsultar_Click" Text="Consultar" />
                            </div>
                            <!-- /.col -->
                        </div>
                        <!-- /.row -->
                    </div>
                    <!-- /.box-body --><%--pie con botones registrar--%>
                    <%--<div class="box-footer">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnregistrar" runat="server" CssClass="btn btn-info" OnClick="btnregistrar_Click" Text="Registrar" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btncancelar" runat="server" CausesValidation="False" CssClass="btn btn-default" Text="Cancelar" />
                </div>--%>
                </div>
                <!-- Horizontal Form -->
                <div class="box" style="left: 0px; top: 0px; height: 755px">
                    <div class="box-header with-border">
                        <h3 class="box-title">Reporte</h3>
                        <br />
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="row" style="height: 642px">
                            <!-- /.col -->
                            <!-- /.row -->&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <br />
                            <br />
                            <div class="col-lg-3 col-xs-6">
                                <div class="small-box bg-aqua">
                                    <div class="inner">
                                        <h3>
                                            <asp:Label ID="lblventas" runat="server" Text="150"></asp:Label>
                                        </h3>
                                        <p>
                                            Ingreso</p>
                                    </div>
                                    <div class="icon">
                                        <i class="fa fa-shopping-cart"></i>
                                    </div>
                                </div>
                            </div>
                            <!-- ./col -->
                            <div class="col-lg-3 col-xs-6">
                                <!-- small box -->
                                <div class="small-box bg-yellow">
                                    <div class="inner">
                                        <h3>
                                            <asp:Label ID="lblclientes" runat="server" Text="150"></asp:Label>
                                        </h3>
                                        <p>
                                            Egreso</p>
                                    </div>
                                    <div class="icon">
                                        <i class="ion ion-person-add"></i>
                                    </div>
                                </div>
                            </div>
                            <!-- ./col -->
                            <div class="col-lg-3 col-xs-6">
                                <!-- small box -->
                                <div class="small-box bg-red">
                                    <div class="inner">
                                        <h3>
                                            <asp:Label ID="lblplanes" runat="server" Text="150"></asp:Label>
                                        </h3>
                                        <p>
                                            Total</p>
                                    </div>
                                    <div class="icon">
                                        <i class="ion ion-pie-graph"></i>
                                    </div>
                                </div>
                                <br />
                                <br />
                                <br />
                                <asp:Button ID="btncancelar" runat="server" CausesValidation="False" CssClass="btn btn-default" OnClick="btncancelar_Click" Text="Cancelar" />
                                <br />
                            </div>
                            <!-- ./col -->
                        </div>
                        <!-- ./box-body -->
                    </div>
                    <!-- /.box -->
                    <!-- general form elements disabled -->
                    <!-- /.box -->
                </div>
                <!--/.col (right) -->
                </div>
                <!-- /.row -->
                </section>
                <!-- /.content -->
                <!-- /.content-wrapper -->
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

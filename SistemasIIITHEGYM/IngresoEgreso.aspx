<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IngresoEgreso.aspx.cs" Inherits="SistemasIIITHEGYM.IngresoEgreso" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="EstilosCSS.css" rel="stylesheet" />
    <meta charset="utf-8"/>
  <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
  <title>Asistencia</title>

        <%--librerias modal--%>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" />
<script src="//code.jquery.com/jquery-1.12.0.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
   <%-- fin librerias modal--%>

        <%--script modal--%>
    <script>
   $(document).ready(function()
   {
      $("#mostrarmodal").modal("show");
   });
        //redireccionar con los botones href con jquery
   function redirectEmpleado() {
       location.href = '<%= Page.ResolveUrl("~/IngresoEgresoEmpleado.aspx") %>';
   }
          function redirectIngresoEgreso() {
       location.href = '<%= Page.ResolveUrl("~/IngresoEgreso.aspx") %>';
          }

          function redirectLogin() {
       location.href = '<%= Page.ResolveUrl("~/InicioLogueo.aspx") %>';
   }

</script>

  <!-- Tell the browser to be responsive to screen width -->
  <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport"/>
  <!-- Bootstrap 3.3.7 -->
  <link rel="stylesheet" href="../../bower_components/bootstrap/dist/css/bootstrap.min.css"/>
  <!-- Font Awesome -->
  <link rel="stylesheet" href="../../bower_components/font-awesome/css/font-awesome.min.css"/>
  <!-- Ionicons -->
  <link rel="stylesheet" href="../../bower_components/Ionicons/css/ionicons.min.css"/>
  <!-- Theme style -->
  <link rel="stylesheet" href="../../dist/css/AdminLTE.min.css"/>
  <!-- iCheck -->
  <link rel="stylesheet" href="../../plugins/iCheck/square/blue.css"/>

  <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
  <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
  <!--[if lt IE 9]>
  <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
  <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
  <![endif]-->

  <!-- Google Font -->
  <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700,300italic,400italic,600italic"/>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
</head>
<body>


    <%--modal--%>
    <div class="modal fade" id="mostrarmodal" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
   <div class="modal-dialog">
      <div class="modal-content">
         <div class="modal-header">
            <h3>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Bienvenido a TheGym</h3>
     </div>
         <div class="modal-body">
            <h4>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Usted es...</h4>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="IngresoEgresoEmpleado.aspx" onclick="redirectEmpleado(); return false;" data-dismiss="modal" class="btn btn-success btn bottom-left">Empleado</a> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="IngresoEgreso.aspx"  data-dismiss="modal" class="btn btn-warning btn bottom-right">Cliente</a>                                                                                                                                         
     </div>
         <div class="modal-footer">
                <%--footer--%>
     </div>
      </div>
   </div>
</div>
    <%--fin modal--%>

    <form id="form1" runat="server">
            <asp:ScriptManager ID="SMAJAX" runat="server"></asp:ScriptManager>
<%--inicio cabecera--%>
    <section class="content-header">
      <h1>
       <a href="IngresoEgreso.aspx" onclick="redirectIngresoEgreso(); return false;"  data-dismiss="modal" class="btn btn-adn btn bottom-right">Volver</a>
          <a href="InicioLogueo.aspx" onclick="redirectLogin(); return false;"  data-dismiss="modal" class="btn btn-info btn bottom-right">Log In</a>
      </h1>
    </section>
  <%--      fin cabecera--%>
<asp:PlaceHolder ID="contenidoprincipal" runat="server">

        <div class="login-box">
  <div class="login-logo">
      <a href="../../index2.html"><b>The</b>GYM</a>
  </div>
    <br />
  <!-- /.login-logo -->
  <div class="login-box-body">

      <div class="form-group has-feedback">
        <asp:TextBox ID="tbid"  Cssclass="form-control"  runat="server" Text="ID"></asp:TextBox>
        <span class="glyphicon glyphicon-envelope form-control-feedback"></span>
            <asp:Button ID="btnverificar" runat="server" Text="Verificar Cliente" Cssclass=" btn btn-default btn-block btn-flat"/>
          <br />
            <asp:Panel ID="panelNOT" runat="server">
                <div class="clean-gray">
                    <asp:Label ID="Label1" runat="server" Text="APELLIDO, nombre"></asp:Label>
                </div>
            </asp:Panel>
            <br />
          <asp:Button ID="btnregistrar" runat="server" Text="Registrar" Cssclass="btn btn-success btn-block btn-flat"/>
      </div>
      <div class="row">
        <div class="col-xs-8">
          <div class="checkbox icheck">
            <label>
            </label>
          </div>
        </div>
        <!-- /.col -->
        <div class="col-xs-4">
          <asp:Label ID="lblerror" CssClass="error-text center-block text-center" runat="server" Text=""></asp:Label>
        </div>
        <!-- /.col -->
      </div>

  </div>
  <!-- /.login-box-body -->
</div>
<!-- /.login-box -->

<!-- jQuery 3 -->
<script src="../../bower_components/jquery/dist/jquery.min.js"></script>
<!-- Bootstrap 3.3.7 -->
<script src="../../bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
<!-- iCheck -->
<script src="../../plugins/iCheck/icheck.min.js"></script>
<script>
  $(function () {
    $('input').iCheck({
      checkboxClass: 'icheckbox_square-blue',
      radioClass: 'iradio_square-blue',
      increaseArea: '20%' /* optional */
    });
  });
</script>

</asp:PlaceHolder>
   </form>
    

</body>
</html>

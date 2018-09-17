<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IngresoEgresoEmpleado.aspx.cs" Inherits="SistemasIIITHEGYM.IngresoEgresoEmpleado" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="EstilosCSS.css" rel="stylesheet" />
    <meta charset="utf-8"/>
  <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
  <title>Asistencia</title>

        <%--script modal--%>
    <script>
        //redireccionar con los botones href con jquery
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

    <form id="form1" runat="server">
<%--inicio cabecera--%>
    <section class="content-header">
      <h1>
       <a href="IngresoEgreso.aspx" onclick="redirectIngresoEgreso(); return false;"  data-dismiss="modal" class="btn btn-adn btn bottom-right">Volver</a>
          <a href="InicioLogueo.aspx" onclick="redirectLogin(); return false;"  data-dismiss="modal" class="btn btn-info btn bottom-right">Log In</a>
      </h1>
    </section>
  <%--      fin cabecera--%>

        <div class="login-box">
  <div class="login-logo">
      <a href="../../index2.html"><b>The</b>GYM</a>
  </div>
    <br />
  <!-- /.login-logo -->
  <div class="login-box-body">

      <div class="form-group has-feedback">
        <asp:TextBox ID="tbid"  Cssclass="form-control"  runat="server"></asp:TextBox>
        <span class="glyphicon glyphicon-envelope form-control-feedback"></span>
            <asp:Button ID="btnverificar" runat="server" Text="Verificar Empleado" Cssclass=" btn btn-default btn-flat" OnClick="btnverificar_Click"/>
          <br />
            <asp:Panel ID="panelNOT" runat="server">
                <div class="clean-gray">
                    <asp:Label ID="Label1" runat="server" Text="APELLIDO, nombre"></asp:Label>
                </div>
            </asp:Panel>
            <br />
          <asp:Button ID="Button1" runat="server" Text="Registrar" Cssclass="btn btn-success btn-block btn-flat" OnClick="Button1_Click"/>
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

   </form>
    

</body>
</html>

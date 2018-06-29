<%@ Page Language="C#" AutoEventWireup="true" CodeFile="bienvenida.aspx.cs" Inherits="bienvenida" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
        <link href="Flat-UI-master/dist/css/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">
    <link href="Flat-UI-master/dist/css/flat-ui.css" rel="stylesheet">
    <link href="Flat-UI-master/docs/assets/css/demo.css" rel="stylesheet">
    <link rel="shortcut icon" href="Flat-UI-master/img/favicon.ico">
      <script src="Flat-UI-master/dist/js/vendor/html5shiv.js"></script>
      <script src="Flat-UI-master/dist/js/vendor/respond.min.js"></script>
</head>

<body bgcolor="#81BEF7">
    <form id="form1" runat="server">
    <div>
               <center><h1>Bienvenido!</h1><br />
        <h2>Programa de becas y subsidios alimenticios</h2>
        <br />
        <h3>Asociación de estudiantes foráneos</h3>
                   Eres...
        <br />
        <br />
        <asp:Button ID="btEst" runat="server" OnClick="btEst_Click" Text="Estudiante" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btRest" runat="server" OnClick="btRest_Click" Text="Restaurante" /></center> 
    </div>
    </form>
    <br/>
    <br/>
    <br/>
    <br/>
        <footer>
      <div class="container">
        <div class="row">
          <div class="col-xs-7">
            <h3 class="footer-title">Rutas AEF</h3>
            <p>¿Te gusta lo que ves?<br/>
              Quieres registrarte como restaurante o inscribirte como estudiante.<br/>
              Entra a: <a href="http://aef.itam.mx/integration_fin_mail.php" target="_blank">Foráneos oficial</a>
            </p>

            <p class="pvl">
              <a href="https://twitter.com/share" class="twitter-share-button" data-url="http://designmodo.com/flat-free/" data-text="Flat UI Free - PSD&amp;amp;HTML User Interface Kit" data-via="designmodo">Tweet</a>
							<script>!function(d,s,id){var js,fjs=d.getElementsByTagName(s)[0],p=/^http:/.test(d.location)?'http':'https';if(!d.getElementById(id)){js=d.createElement(s);js.id=id;js.src=p+'://platform.twitter.com/widgets.js';fjs.parentNode.insertBefore(js,fjs);}}(document, 'script', 'twitter-wjs');</script>
            </p>

            </a>
          </div>

          <div class="col-xs-5">
            <div class="footer-banner">
              <h3 class="footer-title">Get Flat UI Pro</h3>
              <ul>
                <li>Apoyos alimenticios</li>
                <li>Orientación Estudiantil</li>
                <li>Dudas</li>

              </ul>
              Llama: <a href="http://designmodo.com/flat" target="_blank">01 800 000 ITAM Ext. 1364</a>
            </div>
          </div>
        </div>
      </div>
    </footer>
</body>
</html>

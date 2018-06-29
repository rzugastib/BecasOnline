<%@ Page Language="C#" AutoEventWireup="true" CodeFile="estudiante.aspx.cs" Inherits="estudiante" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Becas y Subsidios Alimenticios</title>
        <link href="Flat-UI-master/dist/css/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">
    <link href="Flat-UI-master/dist/css/flat-ui.css" rel="stylesheet">
    <link href="Flat-UI-master/docs/assets/css/demo.css" rel="stylesheet">
    <link rel="shortcut icon" href="Flat-UI-master/img/favicon.ico">
      <script src="Flat-UI-master/dist/js/vendor/html5shiv.js"></script>
      <script src="Flat-UI-master/dist/js/vendor/respond.min.js"></script>
</head>

<body bgcolor="#CEECF5">
    <form id="form1" runat="server">
<div class="bar">
    <a href="bienvenida.aspx">Inicio</a>
    <a href="restaurant.aspx"><i class="fa fa-user"></i> Ir a restaurante</a>
    </a>
  </div>
    <div style="float: left; width: 50%">
            <br />
            <Center style="height: 536px">
            <h4>Clave única: (sin ceros)</h4>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="tbClave" runat="server"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            <h4>Semana</h4>
                <h3>
            <asp:DropDownList ID="ddSemana" runat="server">
            </asp:DropDownList>
                </h3>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Selecciona el lugar donde quieres comer esta semana:<br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="ddRest" runat="server"  Height="35px">
            </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btAgregar" runat="server" OnClick="Button1_Click" style="margin-bottom: 3px" Text="Agregar comida" Height="44px" Width="137px" />
                &nbsp;</div>
        <div style="float: right; width: 50%; height: 570px;">
        &nbsp;<asp:Button ID="btConsulta" runat="server" OnClick="btConsulta_Click" Text="Consultar al estudiante" Height="52px" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
        <asp:GridView ID="gvEst" HeaderStyle-BackColor="#666666" HeaderStyle-ForeColor="White"
    RowStyle-BackColor="#E4E4E4" runat="server">
        </asp:GridView>
     
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                <br />
            <asp:ListBox ID="listComidas" runat="server"></asp:ListBox>
     
    
            <br /></div></center>
<div>
    <br />
    <br />
Consulta el calendario.<br/>
<iframe src="http://escolar.itam.mx/servicios_escolares/calendarios/calesc2018.gif"  
marginwidth="0" marginheight="0" name="ventana_iframe" scrolling="auto" border="0"  
frameborder="0" width="1000" height="600"> 
</iframe></div>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
    
    </form>
</body>
</html>

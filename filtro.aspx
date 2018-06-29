<%@ Page Language="C#" AutoEventWireup="true" CodeFile="filtro.aspx.cs" Inherits="filtro" %>

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
    <style>
body,h1,h2,h3,h4,h5,h6 {font-family: "Lato", sans-serif;}
body, html {
    height: 100%;
    color: #777;
    line-height: 1.8;
}
</style>
<body bgcolor="#CEECF5">
    <form id="form1" runat="server">
        <asp:HyperLink ID="hlVolver" runat="server" NavigateUrl="restaurant.aspx">Volver</asp:HyperLink>
        <br />
        Inserta tu contraseña:<br />
        <br />
        <asp:TextBox ID="tbPwd" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btSiguiente" runat="server" OnClick="Button1_Click" Text="Siguiente" />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </form>
</body>
</html>

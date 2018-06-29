<%@ Page Language="C#" AutoEventWireup="true" CodeFile="restaurant.aspx.cs" Inherits="restaurant" %>

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
    <div>        
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="bienvenida.aspx">Inicio</asp:HyperLink>
        <br />  
        ¿Qué restaurante buscas?&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Semana<br />
        <asp:DropDownList ID="ddRest" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddSemana" runat="server" AutoPostBack="True" >
        </asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="btConsultar" runat="server" OnClick="btConsultar_Click" Text="Consultar información" />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <br />
        <br />
        <br />
        <asp:Button ID="btReporte" runat="server" OnClick="btReporte_Click" Text="Generar lista" />
    </div>
    </form>
</body>
</html>

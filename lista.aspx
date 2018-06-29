<%@ Page Language="C#" AutoEventWireup="true" CodeFile="lista.aspx.cs" Inherits="lista" %>

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

<body bgcolor="#CEECF5">
    <form id="form1" runat="server">
    <div>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="restaurant.aspx">Volver</asp:HyperLink>
        <br />
        <asp:Label ID="Label1" runat="server" Text="[Restaurante]"></asp:Label>
&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Text="[Programa]"></asp:Label>
        <asp:GridView ID="GridView1" HeaderStyle-BackColor="#666666" HeaderStyle-ForeColor="White"
    RowStyle-BackColor="#E4E4E4" runat="server">
        </asp:GridView>
    
        <br />
        <br />
        <asp:Button ID="btCrear" runat="server" OnClick="btCrear_Click" Text="Crear PDF" />
    
    </div>
    </form>
</body>
</html>

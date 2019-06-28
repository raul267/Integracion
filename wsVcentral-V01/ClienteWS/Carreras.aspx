<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Carreras.aspx.cs" Inherits="index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">    
        <h2>Malla Carrera</h2>
        
        <p>
            <asp:Label runat="server">Carreras</asp:Label>
            <asp:DropDownList ID="cboCarrera" runat="server" AutoPostBack="true"
                OnSelectedIndexChanged="cboCarrera_SelectedIndexChanged">
            </asp:DropDownList>
        </p>
        <p>
            <asp:Label runat="server">Ramos</asp:Label>
            <asp:DropDownList ID="cboRamos" runat="server"></asp:DropDownList>
        </p>
        <p>
            <asp:Button ID="Asignar" runat="server" Text="Registrar Equivalencia" />
        </p>
    </form>
</body>
</html>

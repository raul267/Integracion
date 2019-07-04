<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Carreras.aspx.cs" Inherits="index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="miCss.css" rel="stylesheet" />
</head>
<body>
    <div class="divMedio">
    <form id="form1" runat="server">    
        <h1>Asignar Equivalencia</h1>
        <h2>Carrera U+</h2>
        <p>
            <asp:Label runat="server">Carreras</asp:Label>
            <asp:DropDownList ID="cboCarrera" runat="server" CssClass="ddl" AutoPostBack="true"
                OnSelectedIndexChanged="cboCarrera_SelectedIndexChanged">
            </asp:DropDownList>
        </p>
        <p>
            <asp:Label runat="server">Ramos</asp:Label>
            <asp:DropDownList ID="cboRamos" CssClass="ddl" runat="server"></asp:DropDownList>
        </p>
        <h2>Carrera Moodle</h2>
        <p>
            <asp:Label runat="server">Cursos</asp:Label>
            <asp:DropDownList ID="cboCursoo" CssClass="ddl" runat="server"></asp:DropDownList>
        </p>
        <p>
            <asp:Button ID="Asignar" runat="server" CssClass="btnRedondo" Text="Registrar Equivalencia" OnClick="Asignar_Click" />
        <asp:Button ID="Button1" runat="server" CssClass="btnRedondo"  Text="Volver" OnClick="Button1_Click" />
        </p>
    </form>
        </div>
 <script>
     
 </script>
</body>
</html>

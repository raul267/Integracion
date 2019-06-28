<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Carreras.aspx.cs" Inherits="index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<<body>
    <form id="form1" runat="server">    
        <h1>Asignar Equivalencia</h1>
        <h2>Carrera U+</h2>
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
        <h2>Carrera Moodle</h2>
        <p>
            <asp:Label runat="server">Cursos</asp:Label>
            <asp:DropDownList ID="cboCurso" runat="server"></asp:DropDownList>
        </p>
        <p>
            <asp:Button ID="Asignar" runat="server" Text="Registrar Equivalencia" OnClick="Asignar_Click" />
        </p>

        <p>
            <label id="lblResultado" runat="server"></label>
        </p>
    </form>
</body>
</html>

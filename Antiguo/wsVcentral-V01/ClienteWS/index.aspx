<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="Notas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
            <div style="float:left;">
                <asp:Button ID="btnAdmCursos" runat="server"  CssClass="btn" Text="Administrar cursos" OnClick="btnAdmCursos_Click" />
                <asp:Button ID="btnCargarNotas" runat="server" CssClass="btn" Text="Cargar notas" OnClick="btnCargarNotas_Click"/>
            </div>
    </form>
</body>
</html>

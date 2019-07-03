<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="nota3.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <link href="MiCss.css" rel="stylesheet" type="text/css" />

<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <div style="margin:100px;">
        <form id="form1" runat="server"> 
            <div>
                <h1>Bienvenido a nuestra aplicacion intermedia</h1>
            </div>
            <div style="float:left;">
                <asp:Button ID="btnAdmCursos" runat="server"  CssClass="btn" Text="Administrar cursos" OnClick="btnAdmCursos_Click" />
                <asp:Button ID="btnCargarNotas" runat="server" CssClass="btn" Text="Cargar notas" OnClick="btnCargarNotas_Click"/>
            </div>
        </form>
    </div>
</body>
</html>

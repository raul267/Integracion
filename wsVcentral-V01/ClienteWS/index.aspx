<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="Notas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="miCss.css" rel="stylesheet" />
    <title></title>
</head>
<body style="">
    <div class="divMedio">
        
        <form id="form1" runat="server">
                <div style="float:left;">
                    <h3>Bienvenido a la aplicacion intermedia de Moodle y Umas</h3> <br />
                    <asp:Button ID="btnAdmCursos" runat="server"  CssClass="btnRedondoI" Text="Administrar cursos" OnClick="btnAdmCursos_Click" />
                    <asp:Button ID="btnCargarNotas" runat="server" CssClass="btnRedondoI" Text="Cargar notas" OnClick="btnCargarNotas_Click"/>
                </div>
        </form>
    </div>
</body>
</html>

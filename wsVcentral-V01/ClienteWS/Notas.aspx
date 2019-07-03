<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Notas.aspx.cs" Inherits="Notas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="miCss.css" rel="stylesheet" />
</head>
<body>
    <div id="divNotas">
        <label id="lblNotas" runat="server"></label>
    </div>
    <div class="divMedio2">
    <form id="form1" runat="server">
        <div>
            <h1>Registrar notas</h1>
        <asp:Label ID="lblAno" runat="server" Text="Año"></asp:Label>
        <asp:DropDownList ID="cboAno" class="ddl2" runat="server"></asp:DropDownList><br/><br/>
        <asp:Label ID="lblPeriodo" runat="server" Text="Periodo"></asp:Label>
        <asp:DropDownList ID="cboPeriodo" class="ddl" runat="server"></asp:DropDownList>    
        <asp:Button ID="btnTraspasar" runat="server" CssClass="btnRedondo2" Text="Traspasar" OnClick="btnTraspasar_Click" />
        </div>
    </form>
        </div>
    
    
    <script>
        document.getElementById("btnMostrar").onclick = function () {
            document.getElementById("divNotas").style.display = "block";
            
        };

      
    </script>
        </body>
</html>

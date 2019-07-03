<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AsignarRamos.aspx.cs" Inherits="nota3.AsignarRamos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Asignar ramos</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <h1>Asignacion de equivalencias de ramos</h1>
            </div>
            <div>
               <label runat="server" id="lblRamo"></label>
                 
            </div>
             <div>
                <asp:DropDownList ID="ddlCarreras" CssClass="btn" runat="server"  AutoPostBack="true" OnSelectedIndexChanged="ddlCarreras_SelectedIndexChanged"></asp:DropDownList>
                <asp:DropDownList ID="ddlRamos" CssClass="btn" runat="server"></asp:DropDownList>
                  
            </div>
        </div>
    </form>
</body>
</html>

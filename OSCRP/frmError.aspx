<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmError.aspx.cs" Inherits="OSCRP.frmError" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td align="center">
                        <asp:Label ID="lblError" runat="server" Width="400" Font-Size="X-Large" ForeColor="Red" Text="Label"></asp:Label>
                                      </td>
                </tr>
                <tr>
                    <td align="center">
                        
                    <asp:ImageButton ID="btnClose" runat="server" ImageUrl ="~/Images/btnClose.jpg"   Width="85px" Height="30px" ToolTip="CLICK HERE TO Close!" OnClick="btnClose_Click"    />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

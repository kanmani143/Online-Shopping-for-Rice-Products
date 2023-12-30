<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmAddDDLValue.aspx.cs" Inherits="OSCRP.frmAddDDLValue" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table id="Invoice" style="width:1165px;border: none;height:200px;" runat="server" >
                <tr>
                    <td>
                        <asp:Label ID="lblId" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtValue" runat="server" Width="300px"></asp:TextBox>
                    </td>
                    
                </tr>
                <tr>
                                  <td>

                        <br />
                        <asp:ImageButton ID="btnSave" runat="server" ImageUrl ="~/Images/imgSave.jpg"   Width="85px" Height="30px" ToolTip="CLICK HERE TO SAVE!" OnClick="btnSave_Click" OnClientClick="javascript:window.close();" />
                    
                </td>
                <td>
                     <asp:Label ID="lblError" runat="server" Text="                       "   Font-Size="Medium" ForeColor="Red" Font-Names="viladimir script" Visible="false"></asp:Label>

                </td>
                </tr>
                </table>
        </div>
    </form>
</body>
</html>

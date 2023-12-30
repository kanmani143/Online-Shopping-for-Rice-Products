<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="frmLogin.aspx.cs" Inherits="OSCRP.frmLogin" %>
<%@ MasterType VirtualPath="~/MainMaster.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<%--    <script language="javascript" type="text/javascript">
        var prntData = document.getElementById('<%=Login.ClientID%>');
        </script>--%>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div style="clear: both;">
          
            <div style="position: relative; float: left; width: auto;top: 0px; right: -50px; ">
<br />
<br />
<br />
  
<asp:Panel ID="pnlMain" runat="server"  Height="1200px" Width="1200px">
    <div align="center">
        <table style="width: 40%; ">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="User ID :" Font-Size="Medium" ForeColor="Black"></asp:Label>
                   
                </td>
                <td>
                    <asp:TextBox ID="txtUserID" runat="server" Font-Size="Medium" ForeColor="Black"></asp:TextBox>
                  <%--<asp:RequiredFieldValidator ID="rfvUserID" runat="server" ErrorMessage="Please Enter User Name" ControlToValidate="txtUserID" Font-Size="Small" SkinID=""></asp:RequiredFieldValidator>--%>
                    
                </td>
                <td>
                    <asp:Label ID="lblUserError" runat="server" Text="" Font-Size="Smaller" ForeColor="Red" Visible="false"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Password :" Font-Size="Medium" ForeColor="Black"></asp:Label>
                    
                </td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode ="Password" Font-Size="Medium" ForeColor="Black"></asp:TextBox>
                  <%--<asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="Please Enter password" ControlToValidate="txtPassword" Font-Size="Small"></asp:RequiredFieldValidator>--%>
                </td>
                   <td>
                    <asp:Label ID="lblPasswordError" runat="server" Text="" Font-Size="Smaller" ForeColor="Red" Visible="false"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <%--<asp:Button ID="btnLogin" runat="server" Text="Login" 
                        onclick="btnLogin_Click" Font-Size="XX-Large" ForeColor="Black" />--%>
                        <br />
                        <asp:ImageButton ID="ImgLogin" runat="server" ImageUrl ="~/Images/ImgLogin2.jpg" onclick="btnLogin_Click"  Width="85px" Height="30px" ToolTip="CLICK HERE TO LOGIN NOW!"/>
                    
                </td>
                <td>
                    <asp:Label ID="lblError" runat="server" Text="                       "   Font-Size="X-Large" ForeColor="Red" Font-Names="viladimir script" Visible="false"></asp:Label>
                </td>
                <td>

                </td>
            </tr>
        </table>
    </div>
                </asp:Panel>
            </div>
        </div>
    </asp:Content>
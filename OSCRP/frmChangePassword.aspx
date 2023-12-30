<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="frmChangePassword.aspx.cs" Inherits="OSCRP.frmChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="clear: both;">
          
            <div style="position: relative; float: left; width: auto;top: 0px; right: -50px; ">

  
<asp:Panel ID="pnlMain" runat="server"  Height="1200px" Width="1200px">
    <div align="center">
        <table style="width: 36%; ">
            <tr>
                <td colspan="2" align="center">
                    <asp:Label ID="lblRegistrationForm" runat="server" Text="Change Password :" Font-Size="Large" ForeColor="#cc6699" Font-Names="viladimir script" Font-Bold="true" Font-Italic="" ></asp:Label>
                   
                </td>
                
            </tr>
            <tr>
                <td>

                </td>
                 <td>

                </td>
            </tr>
            <tr>

                <td>
                    <asp:Label ID="lblOldPassword" runat="server" Text="Old Password :" Font-Size="Medium" ForeColor="Black" Font-Names="viladimir script"></asp:Label>
                   
                </td>
                <td>
                    <asp:TextBox ID="txtOldPassword"  text= "" runat="server" Font-Size="Medium" ForeColor="Black" TextMode="Password"></asp:TextBox>
                  
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblNewPassword" runat="server" Text="New Password :" Font-Size="Medium" ForeColor="Black" Font-Names="viladimir script"></asp:Label>
                   
                </td>
                <td>
                    <asp:TextBox ID="txtNewPassword"  text= ""  runat="server" TextMode ="Password" Font-Size="Medium" ForeColor="Black"></asp:TextBox>
                  
                </td>
            </tr>
                        <tr>
                <td>
                    <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password :" Font-Size="Medium" ForeColor="Black" Font-Names="viladimir script"></asp:Label>
                   
                </td>
                <td>
                    <asp:TextBox ID="txtConfirmPassword"  text= ""  runat="server"  Font-Size="Medium" ForeColor="Black"></asp:TextBox>
                  
                </td>
            </tr>


            <tr>
                <td>

                        
                    
                </td>
                <td>
                    <br />
                        <asp:ImageButton ID="btnSubmit" runat="server" ImageUrl ="~/Images/imgSubmit.jpg"   Width="85px" Height="30px" ToolTip="CLICK HERE TO SUBMIT!" OnClick="btnSubmit_Click"/>
                <asp:ImageButton ID="btnClose" runat="server" ImageUrl ="~/Images/btnClose.jpg"   Width="85px" Height="30px" ToolTip="CLICK HERE TO Close!" OnClick="btnClose_Click"    />
                </td>
            </tr>
            <tr>
                <td>
                                         <asp:Label ID="lblError" runat="server" Text="                       "   Font-Size="Medium" ForeColor="Red" Font-Names="viladimir script" Visible="false"></asp:Label>

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

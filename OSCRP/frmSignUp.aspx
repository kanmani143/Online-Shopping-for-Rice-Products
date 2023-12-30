<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="frmSignUp.aspx.cs" Inherits="OSCRP.frmSignUp" %>
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
                    <asp:Label ID="lblRegistrationForm" runat="server" Text="Registration Form :" Font-Size="Large" ForeColor="#cc6699" Font-Names="viladimir script" Font-Bold="true" Font-Italic="" ></asp:Label>
                   
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
                    <asp:Label ID="lblLoginID" runat="server" Text="User Name :" Font-Size="Medium" ForeColor="Black" Font-Names="viladimir script"></asp:Label>
                   
                </td>
                <td>
                    <asp:TextBox ID="txtlLoginID" runat="server" Font-Size="Medium" ForeColor="Black"></asp:TextBox>
                  
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblFirstName" runat="server" Text="First Name :" Font-Size="Medium" ForeColor="Black" Font-Names="viladimir script"></asp:Label>
                   
                </td>
                <td>
                    <asp:TextBox ID="txtFirstName" runat="server" Font-Size="Medium" ForeColor="Black"></asp:TextBox>
                  
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblLastName" runat="server" Text="Last Name :" Font-Size="Medium" ForeColor="Black" Font-Names="viladimir script"></asp:Label>
                   
                </td>
                <td>
                    <asp:TextBox ID="txtLastName" runat="server" TextMode ="SingleLine" Font-Size="Medium" ForeColor="Black"></asp:TextBox>
                  
                </td>
            </tr>
                        <tr>
                <td>
                    <asp:Label ID="lblEmail" runat="server" Text="Email :" Font-Size="Medium" ForeColor="Black" Font-Names="viladimir script"></asp:Label>
                   
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server"  Font-Size="Medium" ForeColor="Black"></asp:TextBox>
                  
                </td>
            </tr>
                                    <tr>
                <td>
                    <asp:Label ID="lblAddress" runat="server" Text="Address :" Font-Size="Medium" ForeColor="Black" Font-Names="viladimir script"></asp:Label>
                   
                </td>
                <td>
                    <asp:TextBox ID="txtAddress" runat="server"  Font-Size="Medium" ForeColor="Black" TextMode ="SingleLine"></asp:TextBox>
                  
                </td>
            </tr>
                                                <tr>
                <td>
                    <asp:Label ID="lblPinCode" runat="server" Text="Pin Code :" Font-Size="Medium" ForeColor="Black" Font-Names="viladimir script"></asp:Label>
                   
                </td>
                <td>
                    <asp:TextBox ID="txtPinCode" runat="server"  Font-Size="Medium" ForeColor="Black"></asp:TextBox>
                  
                </td>
            </tr>
                                                <tr>
                <td>
                    <asp:Label ID="lblPhoneNo" runat="server" Text="Phone No :" Font-Size="Medium" ForeColor="Black" Font-Names="viladimir script"></asp:Label>
                   
                </td>
                <td>
                    <asp:TextBox ID="txtPhoneNo" runat="server"  Font-Size="Medium" ForeColor="Black"></asp:TextBox>
                  
                </td>
            </tr>
                                                            <tr>
                <td>
                    <asp:Label ID="lblWhatsApp" runat="server" Text="WhatsApp :" Font-Size="Medium" ForeColor="Black" Font-Names="viladimir script"></asp:Label>
                   
                </td>
                <td>
                    <asp:TextBox ID="txtWhatsApp" runat="server"  Font-Size="Medium" ForeColor="Black"></asp:TextBox>
                  
                </td>
            </tr>
                                                                        <tr>
                <td>
                    <asp:Label ID="lblPassword" runat="server" Text="Password :"   Font-Size="Medium" ForeColor="Black" Font-Names="viladimir script"></asp:Label>
                   
                </td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server"  Font-Size="Medium" TextMode="Password" ForeColor="Black"></asp:TextBox>
                  
                </td>
            </tr>
                                                                                    <tr>
                <td>
                    <asp:Label ID="lblConfirmPassWord" runat="server" Text="Confirm Password :"   Font-Size="Medium" ForeColor="Black" Font-Names="viladimir script"></asp:Label>
                   
                </td>
                <td>
                    <asp:TextBox ID="txtConfirmPassWord" runat="server"  Font-Size="Medium"  ForeColor="Black"></asp:TextBox>
                  
                </td>
            </tr>
            <tr>
                <td>
                    <%--<asp:Button ID="btnLogin" runat="server" Text="Login" 
                        onclick="btnLogin_Click" Font-Size="XX-Large" ForeColor="Black" />--%>
                       
                </td>
                <td>
                     <br />
                        <asp:ImageButton ID="btnSignUp" runat="server" ImageUrl ="~/Images/imgSubmit.jpg"   Width="85px" Height="30px" ToolTip="CLICK HERE TO LOGIN NOW!" OnClick="btnSignUp_Click"/>
                    
                    <asp:ImageButton ID="btnClose" runat="server" ImageUrl ="~/Images/btnClose.jpg"   Width="85px" Height="30px" ToolTip="CLICK HERE TO Close!" OnClick="btnClose_Click"    />
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                                         
                                <asp:CompareValidator runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassWord"
                ErrorMessage="Passwords do not match." ForeColor="Red" Display="Dynamic">
            </asp:CompareValidator>
                </td>
                <td>
                    <asp:Label ID="lblError" runat="server" Text="                       "   Font-Size="Medium" ForeColor="Red" Font-Names="viladimir script" Visible="false"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
                </asp:Panel>
            </div>
        </div>
</asp:Content>

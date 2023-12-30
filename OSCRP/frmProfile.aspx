<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="frmProfile.aspx.cs" Inherits="OSCRP.frmProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Successfully submitted. Are you sure want to display home page?")) {
                lblError
                document.getElementById('<%=lblError.ClientID%>').value = "Yes";
                confirm_value.value = "Yes";
            }
            else {
                document.getElementById('<%=lblError.ClientID%>').value = "No";
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
    <style type="text/css">
        .auto-style4 {
            width: 36%;
            margin-right: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="clear: both;">
          
            <div style="position: relative; float: left; width: auto;top: 0px; right: -50px; ">

  
<asp:Panel ID="pnlMain" runat="server"  Height="1200px" Width="1200px">
    <div align="center">
        <table class="auto-style4">
            <tr>
                <td colspan="2" align="center">
                    <asp:Label ID="lblRegistrationForm" runat="server" Text="Edit Profile :" Font-Size="Large" ForeColor="#cc6699" Font-Names="viladimir script" Font-Bold="true" Font-Italic="false" ></asp:Label>
                   
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
                    <asp:Label ID="lblFirstName" runat="server" Text="First Name :" Font-Size="Medium" ForeColor="Black" Font-Names="viladimir script"></asp:Label>
                   
                </td>
                <td>
                    <asp:TextBox ID="txtFirstName"  text= "Nagarajan" runat="server" Font-Size="Medium" ForeColor="Black"></asp:TextBox>
                  
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblLastName" runat="server" Text="Last Name :" Font-Size="Medium" ForeColor="Black" Font-Names="viladimir script"></asp:Label>
                   
                </td>
                <td>
                    <asp:TextBox ID="txtLastName"  text= "Alagappan"  runat="server" TextMode ="SingleLine" Font-Size="Medium" ForeColor="Black"></asp:TextBox>
                  
                </td>
            </tr>
                        <tr>
                <td>
                    <asp:Label ID="lblEmail" runat="server" Text="Email :" Font-Size="Medium" ForeColor="Black" Font-Names="viladimir script"></asp:Label>
                   
                </td>
                <td>
                    <asp:TextBox ID="txtEmail"  text= "al_nagarajan@hotmail.com"  runat="server"  Font-Size="Medium" ForeColor="Black" Enabled="false"></asp:TextBox>
                  
                </td>
            </tr>
                                    <tr>
                <td>
                    <asp:Label ID="lblAddress" runat="server" Text="Address :" Font-Size="Medium" ForeColor="Black" Font-Names="viladimir script"></asp:Label>
                   
                </td>
                <td>
                    <asp:TextBox ID="txtAddress"  text= "Telphone Colony First Street"  runat="server"  Font-Size="Medium" ForeColor="Black" TextMode ="SingleLine"></asp:TextBox>
                  
                </td>
            </tr>
                                                <tr>
                <td>
                    <asp:Label ID="lblPinCode"    runat="server" Text="Pin Code :" Font-Size="Medium" ForeColor="Black" Font-Names="viladimir script"></asp:Label>
                   
                </td>
                <td>
                    <asp:TextBox ID="txtPinCode"   text= "630106" runat="server"  Font-Size="Medium" ForeColor="Black"></asp:TextBox>
                  
                </td>
            </tr>
                                                <tr>
                <td>
                    <asp:Label ID="lblPhoneNo" runat="server" Text="Phone No :" Font-Size="Medium" ForeColor="Black" Font-Names="viladimir script"></asp:Label>
                   
                </td>
                <td>
                    <asp:TextBox ID="txtPhoneNo"   text= "+917538821533" runat="server"  Font-Size="Medium" ForeColor="Black"></asp:TextBox>
                  
                </td>
            </tr>
                                                            <tr>
                <td>
                    <asp:Label ID="lblWhatsApp" runat="server" Text="WhatsApp :" Font-Size="Medium" ForeColor="Black" Font-Names="viladimir script"></asp:Label>
                   
                </td>
                <td>
                    <asp:TextBox ID="txtWhatsApp"   text= "+65 93255275" runat="server"  Font-Size="Medium" ForeColor="Black"></asp:TextBox>
                  
                </td>
            </tr>

            <tr>
                <td>

                        
                    
                </td>
                <td >
                    <br />
                        <asp:ImageButton ID="btnSubmit" runat="server" ImageUrl ="~/Images/imgSubmit.jpg"   Width="85px" Height="30px" ToolTip="CLICK HERE TO SUBMIT!" OnClick="btnSubmit_Click"/>
                <asp:ImageButton ID="btnClose" runat="server" ImageUrl ="~/Images/btnClose.jpg"   Width="85px" Height="30px" ToolTip="CLICK HERE TO Close!" OnClick="btnClose_Click"    />
                </td>
            </tr>
            <tr>
                <td>

                        
                    
                </td>
                <td >
                   
                        <%--<asp:LinkButton ID="lnkChangePassword" runat="server" Text="Change Password"  Height="20px"  Width ="200px"  ForeColor="#cc6699" style="text-decoration: none; text-align:left" Font-Size="Small" Font-Bold="true"  OnClientClick="return true;" Visible="false" OnClick="lnkChangePassword_Click" ></asp:LinkButton>--%>
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

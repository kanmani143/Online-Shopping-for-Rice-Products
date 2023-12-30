<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmLogin.aspx.cs" Inherits="HaiSia.frmLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script src="js/jquery-1.7.min.js" type="text/javascript"></script>


   
    <link href="css/style.css" rel="stylesheet" type="text/css" />

    <link rel="stylesheet" href="css/jquery-ui.css" />

    <script type="text/javascript" src="js/jquery-1.10.2.js"></script>

    <script type="text/javascript" src="js/jquery-ui.js"></script>


    <script type="text/javascript" >
        function Popup(url) {
            url = "frmImageWindow.aspx?ImageUrl=" + url;
            window.open(url, "Image Window", "status = 1, height = 390, width = 457, resizable = 0")
        }
        </script>
        
    <style type="text/css">
            .FixedHeader {
            position: fixed;
            font-weight: bold;
        }     
       

    /* This will only target checkboxes within your report grid */
    .reportgrid input[type=checkbox] { height: 40px; width: 40px;}
    
    /* This will only target checkboxes within your report grid (with class sillygrid) */
    .sillygrid input[type=checkbox] { height: 40px; width: 40px; }
</style>  
</head>
<body style="font-family: Sans-Serif;">
    <form id="form1" runat="server">
              <div style="clear: both;">

            <div style="position: relative; float: left; width: auto ;">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>

        <div style="clear: both;">

            <%--<div style="position: relative; float: left; width: 300px;">--%>
                <div style="position: relative; float: left; width: 550px; top: 0px; right: -50px; text-align:left;" >
                <table style="width: 100%;" >
                    <tr>
              
                        <td >
                          <asp:Image ID="imgLogo" runat="server" ImageUrl="~/Images/HaiSiabanner3.jpg" 
                                Height="150px"  Width ="1200px"/> 
                                
                        </td>
                       
                    </tr>
                    
                </table>
            </div>
        </div>

        <div style="clear: both;">
            
            <div style="position: relative; float: left; width: 550px; top: 0px; right: -50px; text-align:left;">
                 <asp:Label ID="lblCustomer" runat="server" Text="User" 
                     Width="800px" ForeColor ="Black" Font-Size="X-Large" Font-Bold="true"  ></asp:Label>
                <br />
                <br />
              </div></div>
              <div style="clear: both;">
              <div style="position: relative; float: left; width: 1000px; top: 0px; right: -50px; text-align:left;">
              
              <asp:LinkButton ID="lnkHome" runat="server" onclick="lnkHome_Click"  Font-Size="XX-Large" Width ="100px" >Home</asp:LinkButton>
               <asp:LinkButton ID="lnkMyCart" runat="server" onclick="lnkMyCart_Click"  Font-Size="XX-Large" Width ="135px" >My Cart</asp:LinkButton>
                  
                <asp:LinkButton ID="lnkMyOrder" runat="server" onclick="lnkMyOrder_Click" Font-Size="XX-Large" Width ="150px" >My Order</asp:LinkButton>
                <asp:LinkButton ID="lnkOurProducts" runat="server"  Font-Size="XX-Large" 
                      Width ="216px" onclick="lnkOurProducts_Click" >Our Products</asp:LinkButton>
          <asp:LinkButton ID="lnkContactUs" runat="server" onclick="lnkContactUs_Click" Font-Size="XX-Large" Width ="180px" >Contact Us</asp:LinkButton>
             
                    <asp:LinkButton ID="lnkLogout" runat="server" onclick="lnkLogout_Click" Font-Size="XX-Large" Width ="120px" >Login</asp:LinkButton>
                 
                 
          
            </div>
                 
          
           
                     
        </div>
          <div style="clear: both;">
        <div style="position: relative; float: left; width: auto;top: 0px; right: -50px; ">
        <br />
          <table  frame="void" >
        	<tr align="center" >
		<%--<td width="1235" height="1" colspan="3" align ="left"  >--%>
			<%--<img src="images/08.jpg" height="174" alt="" align="left"  
                style="width: 1235px">--%><%--</td>--%>
                
                     <td width="1200" height="1" colspan="3" align ="center" 
                    style="background-color:#3FA902; color:White;font-family: Arial; font-size: small;">
                      </td>                
	</tr>
	</table>
        </div>
        </div>
            
        <div style="clear: both;">
          
            <div style="position: relative; float: left; width: auto;top: 0px; right: -50px; ">
<br />
<br />
<br />
  
                <asp:Panel ID="pnlMain" runat="server" ScrollBars="Vertical" Height="1200px" Width="1200px">
                       <div align="center">
        <table style="width: 36%; ">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="User ID :" Font-Size="XX-Large" ForeColor="Black"></asp:Label>
                   
                </td>
                <td>
                    <asp:TextBox ID="txtUserID" runat="server" Font-Size="XX-Large" ForeColor="Black"></asp:TextBox>
                  
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Password :" Font-Size="XX-Large" ForeColor="Black"></asp:Label>
                   
                </td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode ="Password" Font-Size="XX-Large" ForeColor="Black"></asp:TextBox>
                  
                </td>
            </tr>
            <tr>
                <td>
                    <%--<asp:Button ID="btnLogin" runat="server" Text="Login" 
                        onclick="btnLogin_Click" Font-Size="XX-Large" ForeColor="Black" />--%>
                        <br />
                        <asp:ImageButton ID="ImgLogin" runat="server" ImageUrl ="~/Images/ImgLogin2.jpg" onclick="btnLogin_Click"  Width="170px" Height="50px" ToolTip="CLICK HERE TO ORDER NOW!"/>
                    
                </td>
                <td>
                    
                </td>
            </tr>
        </table>
    </div>
                </asp:Panel>
            </div>
        </div>
        <%--</div>--%>
        </div></div>
    </form>
</body>
</html>


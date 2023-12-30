<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmContactUs.aspx.cs" Inherits="HaiSia.frmContactUs" %>

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
                                Height="150px"  Width ="1150px"/> 
                                
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
               <asp:LinkButton ID="lnkMyCart" runat="server"  Font-Size="XX-Large" Width ="135px" 
                      onclick="lnkMyCart_Click" >My Cart</asp:LinkButton>
                  
                <asp:LinkButton ID="lnkMyOrder" runat="server" onclick="lnkMyOrder_Click" Font-Size="XX-Large" Width ="150px" >My Order</asp:LinkButton>
                <asp:LinkButton ID="lnkOurProducts" runat="server"  Font-Size="XX-Large" 
                      Width ="216px" onclick="lnkOurProducts_Click" >Our Products</asp:LinkButton>
          <asp:LinkButton ID="lnkContactUs" runat="server" onclick="lnkContactUs_Click" Font-Size="XX-Large" Width ="180px" >Contact Us</asp:LinkButton>
             
                    <asp:LinkButton ID="lnkLogout" runat="server" onclick="lnkLogout_Click" Font-Size="XX-Large" Width ="120px" >Logout</asp:LinkButton>
                 
                 
          
            </div>
                 
          
           
                     
        </div>
      
            
        <div style="clear: both;">
          
            <div style="position: relative; float: left; width: auto;">

  
                <asp:Panel ID="pnlMain" runat="server" ScrollBars="Vertical" Height="1200px" Width="1200px">
                     <div class="contact">
        <img class="logo" src="Images/body-logo-graphic.jpg" alt="" />
        <div class="info">
            <p>若有垂询，欢迎联络。<br />
            All enquiries are welcome. We look forward to hearing from you.</p>
            Email: <img src="Images/email-address.jpg" alt=""  height="40px" width="400px"/>
            <p>Address: 35A Fishery Port Road, Singapore 619743</p>
            <p>Tel: (+65) 6264 3159<br />
            Fax: (+65) 6265 8166</p>
        </div>
        <div class="clear"></div>
    </div>
                </asp:Panel>
            </div>
        </div>
        <%--</div>--%>
        </div></div>
    </form>
</body>
</html>


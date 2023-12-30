<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmHome.aspx.cs" Inherits="HaiSia.frmHome" %>

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
             
                    <asp:LinkButton ID="lnkLogout" runat="server" onclick="lnkLogout_Click" Font-Size="XX-Large" Width ="120px" >Logout</asp:LinkButton>
                 
                 
          
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

  
                <asp:Panel ID="pnlMain" runat="server" ScrollBars="Vertical" Height="1200px" Width="1200px">
                    <div class="about eng" >
        <p><span class="bold">Hai Sia</span>&mdash;literally the 'sound of the sea'&mdash;evokes the rich bounty of the oceans. From humble beginnings in 1977, Hai Sia has grown into a modern, HACCP-certified company engaged in many areas of the fresh and frozen seafood trade. Based in Singapore, we provide local and overseas business partners with integrated services. These include import and export, processing, packaging, deep-freezing and cold storage. We count among our clients supermarkets, airline caterees, seafood wholesalers, hotels, food and beverage outlets, foodstuff manufacturers and hospitals.</p>
        <p>Hai Sia's auction lot at the Jurong Central Fish Market carries out the import and wholesale of fresh seafood. Our processing plant is sited directly opposite this wholesale market. Thus, we are in an excellent position to take advantage of the flow of goods and people through Singapore's largest and busiest seafood wholesale market. Our plant is well equipped with deep-freezing (-40&deg;C) and cold storage (-18&deg;C) facilities. It is also outfitted with a comprehensive range of processing and packaging equipment.</p>
        <p>Hai Sia is committed to supplying top quality seafood products at competitive prices. We strive to build upon the excellent reputation that we have established over the years.</p>
    </div>
                </asp:Panel>
            </div>
        </div>
        <%--</div>--%>
        </div></div>
    </form>
</body>
</html>

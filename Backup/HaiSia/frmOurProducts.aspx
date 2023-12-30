<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmOurProducts.aspx.cs" Inherits="HaiSia.frmOurProducts" %>

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
        function ShowImage(url) {

            document.getElementById('Image2').setAttribute('src', url);
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
                <asp:LinkButton ID="lnkOurProducts" runat="server" onclick="lnkContactUs_Click" Font-Size="XX-Large" Width ="216px" >Our Products</asp:LinkButton>
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
          
            <div style="position: relative; float: left; width: auto;top: 0px; right: -50px;  ">

  
                <asp:Panel ID="pnlMain" runat="server" ScrollBars="Vertical" Height="1200px" Width="1200px">
                   
                   
                      <div class="about eng" style="font-size: x-large   ;">
       
        <p><span class="bold">Hai Sia</span> carries a complete range of fresh and frozen seafood to meet all the needs of our clients. This list of items is non-exhaustive. Please contact us for more information.</p>
        <p class="products_chn">海声为海内外的客户供应世界各地的新鲜与鲜冻海产。除下列海产以外，我们也供应其他海鲜。
若有垂询，欢迎联络。</p>
    </div>
     
                         <br />
                    <div style="clear: both;">
                    <div style="position: relative; float: left; width: 400;top: 0px; overflow:scroll; height:900px ">
                        
                        <asp:GridView ID="gvLeft" runat="server" ShowHeader ="false" AutoGenerateColumns="False" BorderStyle="None" GridLines="None" 
                        OnRowDataBound ="gvLeft_OnRowDataBound"   >
                         <Columns>

                                        <asp:BoundField DataField="varProductName" HeaderText="Product" ItemStyle-Width="380px" HeaderStyle-HorizontalAlign ="Center" ItemStyle-Wrap ="false" ItemStyle-ForeColor ="Blue" ItemStyle-Font-Underline ="true" ItemStyle-Font-Size ="XX-Large" />
                                        
                                        
                         </Columns>                
                        </asp:GridView>
                    </div>
                     <div style=" position: relative; float: left; width: 670;top: 0px; left:10px; height:500; "  >
                         
                         <img id ="Image2" alt="" src="Images/OurProduct/assorted_shellfish.jpg" width ="670px" height ="500px"/>
                    </div>
                     <%-- <div style="position: relative; float: left; width: 320;top: 0px; overflow:scroll;height:480px  ">
                        <asp:GridView ID="gvRight" runat="server" ShowHeader ="false" AutoGenerateColumns="False"  OnRowDataBound ="gvRight_OnRowDataBound" BorderStyle="None" GridLines="None"   >
                         <Columns>

                                        <asp:BoundField DataField="varProductName" HeaderText="Product" ItemStyle-Width="300px" HeaderStyle-HorizontalAlign ="Center" ItemStyle-Wrap ="false" ItemStyle-ForeColor ="Blue" ItemStyle-Font-Underline ="true" ItemStyle-Font-Size ="X-Large" />
                                        
                                        
                         </Columns>                
                        </asp:GridView>
                    </div>--%>
                    </div>
                </asp:Panel>
            </div>
        </div>
        <%--</div>--%>
        </div></div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmMyCartNew.aspx.cs" Inherits="HaiSia.frmMyCartNew" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script src="js/jquery-1.7.min.js" type="text/javascript"></script>


   
    <link href="css/style.css" rel="stylesheet" type="text/css" />

    <link rel="stylesheet" href="css/jquery-ui.css" />
<link rel="stylesheet" href="css/jquery-ui-1.8.9-custom.css" />
    <script type="text/javascript" src="js/jquery-1.10.2.js"></script>

    <script type="text/javascript" src="js/jquery-ui.js"></script>


    <script type="text/javascript" >
        function Popup(url) {
            url = "frmImageWindow.aspx?ImageUrl=" + url;
            window.open(url, "Image Window", "status = 1, height = 390, width = 457, resizable = 0")
        }

        function isNumber(evt, obj) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            var val = obj.value;
            if (charCode == 46 && val.length > 0 && val.indexOf(".") == -1) {
                return true;
            }
            else {
                if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                    return false;
                }
                return true;
            }
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
 <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
 <asp:Timer ID="Timer1" OnTick="Timer1_Tick" runat="server" Interval="60000">
            </asp:Timer></ContentTemplate> 
                </asp:UpdatePanel> 

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
                     Width="800px" Font-Size="X-Large" Font-Bold="True" ForeColor="Black" ></asp:Label>
                <br />
               
              </div>
              
        </div>
       
              <div style="clear: both;">
              <div style="position: relative; float: left; width: 1150px; top: 0px; right: -50px; text-align:left;">
              
              <asp:LinkButton ID="lnkHome" runat="server" onclick="lnkHome_Click"  Font-Size="XX-Large" Width ="100px" >Home</asp:LinkButton>
               <%--<asp:LinkButton ID="lnkCheckOut" runat="server"   Font-Size="XX-Large" 
                      Width ="165px" onclick="lnkCheckOut_Click" >Check Out</asp:LinkButton>--%>
                  
                <asp:LinkButton ID="lnkMyOrder" runat="server" onclick="lnkMyOrder_Click" Font-Size="XX-Large" Width ="150px" >My Order</asp:LinkButton>
                <asp:LinkButton ID="lnkOurProducts" runat="server"  Font-Size="XX-Large" 
                      Width ="216px" onclick="lnkOurProducts_Click" >Our Products</asp:LinkButton>
          <asp:LinkButton ID="lnkContactUs" runat="server" onclick="lnkContactUs_Click" Font-Size="XX-Large" Width ="180px" >Contact Us</asp:LinkButton>
             
                    <asp:LinkButton ID="lnkLogout" runat="server" onclick="lnkLogout_Click" Font-Size="XX-Large" Width ="120px" >Logout</asp:LinkButton>
                 
                 <asp:ImageButton ID="imgCheckOut"  ImageAlign ="AbsBottom" runat="server" ImageUrl ="~/Images/ImgCheckOut.jpg" onclick="lnkCheckOut_Click"  Width="240px" Height="50px" ToolTip="CLICK HERE TO CHECK OUT NOW!"/> 
          
            </div>
                 
          
           
                     
        </div>
        
         <div style="clear: both;">
            <br />
            <div style="position: relative; float: left; width: 440px; top: 0px; right: -50px; text-align:left;">
              
              <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                <ContentTemplate>
                <asp:Label ID="lblItem" runat="server" Text="Time Left : 2 Days 10 Hours 42 Min 30 Sec" BorderStyle="Solid" BorderColor="Green"  BorderWidth="1px" Width="420px" Font-Size="X-Large" ForeColor="Black"  ></asp:Label>
                <br />
                <asp:Label ID="lblCollection" runat="server" Text="Collection Date : 23 March 2015" BorderStyle="Solid" BorderColor="Green"  BorderWidth="1px" Width="420px" Font-Size="X-Large" ForeColor="Black"></asp:Label>
                 </ContentTemplate> 
                </asp:UpdatePanel> 
              </div>
              
               <div style="position: relative; float: left; width: 360px; top: 0px; right: -50px; text-align:left;">
              
              <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                <ContentTemplate>
                <asp:Label ID="lblCartRefNo" runat="server" Text="Time Left : 2 Days 10 Hours 42 Min 30 Sec" BorderStyle="Solid" BorderColor="Green"  BorderWidth="1px" Width="340px" Font-Size="X-Large" ForeColor="Black" ></asp:Label>
                <br />
                <asp:Label ID="lblOderDate" runat="server" Text="Collection Date : 23 March 2015" BorderStyle="Solid" BorderColor="Green"  BorderWidth="1px" Width="340px" Font-Size="X-Large" ForeColor="Black"></asp:Label>
                 </ContentTemplate> 
                </asp:UpdatePanel> 
              </div>
              
               <div style="position: relative; float: left; width: 390px; top: 0px; right: -50px; text-align:left;">
              
              <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                <asp:Label ID="lblTotItem" runat="server" Text="" BorderStyle="Solid" BorderColor="Green"  BorderWidth="1px" Width="370px" Font-Size="X-Large" ForeColor="Black"></asp:Label>
                <br />
                <asp:Label ID="lblTotQty" runat="server" Text="" BorderStyle="Solid" BorderColor="Green"  BorderWidth="1px" Width="370px" Font-Size="X-Large" ForeColor="Black"></asp:Label>
                 <br />
                <asp:Label ID="lblTotPrice" runat="server" Text="" BorderStyle="Solid" BorderColor="Green"  BorderWidth="1px" Width="370px" Font-Size="X-Large" ForeColor="Black"></asp:Label>
                 </ContentTemplate> 
                </asp:UpdatePanel> 
              </div>
              
        </div>
        
         <%--  <div style="clear: both;">
            
            <div style="position: relative; float: left; width: 1000px; top: 0px; right: 0px; text-align:left;">
               <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                        <asp:Label ID="lblCartRefNo" runat="server" Text=""  Width="445px" Font-Size="XX-Large" Visible="false"  ></asp:Label>
                        <asp:Label ID="lblOderDate" runat="server" Text=""  Width="445px" Font-Size="XX-Large" Visible="false"></asp:Label>
                </ContentTemplate> 
                </asp:UpdatePanel> 
              </div>
              
        </div>--%>
       <%--<div style="clear: both;">
            
            <div style="position: relative; float: left; width: 1200px; top: 0px; right: 0px; text-align:left;">
                       <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                            
                             
                <asp:Label ID="lblTotItem" runat="server" Text=" "  Width="370px" Font-Size="XX-Large"  ></asp:Label>
                
                <asp:Label ID="lblTotQty" runat="server" Text=" "  Width="370px" Font-Size="XX-Large" ></asp:Label>
                
                <asp:Label ID="lblTotPrice" runat="server" Text=" "  Width="370px" Font-Size="XX-Large" ></asp:Label>
                </ContentTemplate> </asp:UpdatePanel> 
              </div>
              
        </div>--%>
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
  
                <asp:Panel ID="pnlMain" runat="server" ScrollBars="Vertical" Height="1200px" Width="1200px">
                      <asp:ListView ID="lstItemView" runat="server" GroupItemCount="3" GroupPlaceholderID="grpPh_1"
                        ItemPlaceholderID="Iph1" onitemdatabound="lstItemView_ItemDataBound">
                        <LayoutTemplate>
                            <table>
                                <asp:PlaceHolder runat="server" ID="grpPh_1"></asp:PlaceHolder>
                            </table>
                        </LayoutTemplate>
                        <GroupTemplate>
                            <tr>
                                <asp:PlaceHolder runat="server" ID="Iph1"></asp:PlaceHolder>
                            </tr>
                        </GroupTemplate>

                        <ItemTemplate>
                            <td valign ="top" >
                           
                                <table cellpadding="5"  >
                                    <tr>
                                                
                                        <td  id="tdItems" align="center" style="width: 376px; height : auto;  border-color:#3FA902;  border-style: solid;border-width: thin ;" valign ="top" runat ="server"    >
                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                            <asp:ImageButton ID="imgBtnList" runat="server" 
                                                ImageUrl="~/Images/NoImage.jpg" Enabled="true" Width="100px" Height="90px" ToolTip ="Click on this to view the image in large size" />
                                            <br />
                                                            
                                              <asp:Label ID="lblItemCode" runat="server" Text='<%#Eval("DMITNO") %>' Font-Size="XX-Large" ForeColor="Black" ></asp:Label>
                                            <br />
                                            <asp:Label ID="lblItemName" runat="server" Text='<%#Eval("DMITDS") %>' Font-Size="XX-Large" ForeColor="DarkGoldenrod" Height ="100px" ></asp:Label>
                                            <br />
                                            <asp:Label ID="lblCurr" runat="server" Text='<%#Eval("AMCURR") %>' Font-Size="XX-Large" ForeColor ="Red"></asp:Label>
                                            <asp:Label ID="lblPrice" runat="server" Text='<%#Eval("AMLIST","{0:0.00}") %>' Font-Size="XX-Large" ForeColor ="Red" DataFormatString="{0:0.00}"></asp:Label>
                                            <asp:Label ID="lblSlash" runat="server" Text="/" Font-Size="XX-Large" ForeColor ="Red"></asp:Label>
                                            <asp:Label ID="lblUom" runat="server" Text='<%#Eval("DMPUOM") %>' Font-Size="XX-Large" ForeColor ="Red"></asp:Label>
                                                         </ContentTemplate>
                                </asp:UpdatePanel>
                                            <br />
                                            <br />
                                            <div style="text-align: center ;" >
                                          <%--           <asp:Label ID="lblSize" runat="server" Text="Size:" Font-Size="Small" ></asp:Label>
                                               <asp:TextBox ID="txtSize" runat="server" Width="80px" Font-Size="Small"></asp:TextBox>
                                               
                                                <br />--%>
                                                
                                        
                                         <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
                            <ContentTemplate>
                                        <asp:Label ID="lblQty" runat="server" Text="Qty :" Font-Size="XX-Large" ForeColor ="Black"></asp:Label>
                                        <%--<asp:ImageButton ID="imgBtnMinus" runat="server" ImageUrl ="~/Images/btnMinusImage1.jpeg"  ImageAlign ="Middle" CommandArgument='<%# Container.DataItemIndex %>' OnCommand="ClickButton" CommandName="ReduceToCart_Me"   OnClientClick="return true;" />--%>
                                                <asp:ImageButton ID="imgBtnMinus" runat="server" ImageUrl ="~/Images/btnMinusImage_New_1.jpeg"  ImageAlign ="Middle"   CommandArgument='<%# DataBinder.Eval(((IDataItemContainer)Container).DataItem, "DMITNO") %>' OnCommand="ClickButton" CommandName="ReduceToCart_Me"   OnClientClick="return true;" />
                                                <asp:TextBox ID="txtQty" runat="server" Width="85px" Font-Size="XX-Large" Text="0" onkeypress="return isNumber(event,this)" ></asp:TextBox>
                                                <asp:ImageButton ID="imgBtnAdd" runat="server" ImageUrl ="~/Images/btnAddImage_New_1.jpeg" ImageAlign ="Middle" CommandArgument='<%# DataBinder.Eval(((IDataItemContainer)Container).DataItem, "DMITNO") %>' OnCommand="ClickButton" CommandName="AddToCart_Me"   OnClientClick="return true;"/>
                                                <%--<asp:Button ID="btnAddToCart" runat="server" Text="Add to Cart" CommandArgument='<%# Container.DataItemIndex %>' OnCommand="ClickButton" CommandName="AddToCart_Me"   OnClientClick="return confirm('Are you sure you want to add?');" />--%>
                                            </ContentTemplate>
                                </asp:UpdatePanel>
                                            </div>
                                        </td>
                              
                                    </tr>
                                </table>
                                

                            </td>
                        </ItemTemplate>
                    </asp:ListView>
                </asp:Panel>
            </div>
        </div>
        <%--</div>--%>
        </div></div>
    </form>
</body>
</html>


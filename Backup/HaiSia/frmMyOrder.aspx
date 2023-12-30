<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmMyOrder.aspx.cs" Inherits="HaiSia.frmMyOrder" %>

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
                     Width="800px" Font-Size="X-Large" Font-Bold="True" ForeColor="Black" ></asp:Label>
                <br />
               
              </div>
              
        </div>
       
              <div style="clear: both;">
              <div style="position: relative; float: left; width: 1150px; top: 0px; right: -50px; text-align:left;">
              <br />
              <asp:LinkButton ID="lnkHome" runat="server" onclick="lnkHome_Click"  Font-Size="XX-Large" Width ="100px" >Home</asp:LinkButton>
            <asp:LinkButton ID="lnkMyCart" runat="server" onclick="lnkMyCart_Click"  Font-Size="XX-Large" Width ="135px" >My Cart</asp:LinkButton>
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
	
                
                     <td width="1200" height="1" colspan="3" align ="center" 
                    style="background-color:#3FA902; color:White;font-family: Arial; font-size: small;">
                      </td>                
	</tr>
	</table>
        </div>
        </div>
               <div style="clear: both;">
        
              
                        <div style="position: relative; text-align:center; width: auto;right:-50px;">
            <br />
                <asp:Label ID="Label1" runat="server" Text="List of my Orders"  Width="345px" Font-Size="XX-Large" ForeColor="White"  BackColor ="DarkGoldenrod"   ></asp:Label>
                </div>
                <br />
                   <br />  
                    <div style="position: relative; text-align: left ; width: auto;right:-50px;  ">
            
                <asp:Label ID="lblNote" runat="server" Text="Note: To view or confirm Orders, click on Order ID or Cart Ref No"  Width="970px" Font-Size="XX-Large" ForeColor="Blue"     ></asp:Label>
                </div>
                <br />
                 
                   </div>
        <div style="clear: both;">
          
            <div style="position: relative; float: left; width: auto;top: 0px; right: -50px; ">
<br />
  
               <%-- <asp:Panel ID="pnlMain" runat="server" ScrollBars="Vertical" Height="1200px" Width="1200px">--%>
       <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical" Height="1200px">
                <div style="position: relative; float: left; width: auto;">
                                         <asp:GridView ID="grdvwMyOrder" runat="server" 
                                    AutoGenerateColumns="False" BorderColor="#CCCCCC" BorderStyle="Solid" 
                                    BorderWidth="1px"   OnPageIndexChanging="grdvwMyOrder_PageIndexChanging"
                                     OnRowDataBound ="grdvwMyOrder_OnRowDataBound"  CellPadding="5" CssClass ="GridViweAuto" >
                                    <AlternatingRowStyle BackColor="White" ForeColor="Black" Font-Size="X-Large" />
                            
                                
                                    <HeaderStyle BackColor="LightBlue" 
                                        Font-Size="X-Large" ForeColor="Black"  Font-Bold="true"  Height ="14px" />
                                    <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" />
                                    <RowStyle BackColor="White" Font-Size="X-Large" ForeColor="Black" 
                                        Height="24px" />
                                    <Columns>
                                   
                                        <asp:TemplateField HeaderText="SNo" >
                                            <ItemTemplate>
                                                <span>
                                                    <%#Container.DataItemIndex + 1%>
                                                </span>
                                            </ItemTemplate>

                                            <ItemStyle Width="40px"></ItemStyle>
                                        </asp:TemplateField>
                                    
                                
                                        <%--<asp:BoundField DataField="nvarPpcRefno" HeaderText="PPC Reference No" ItemStyle-Width="160px" ItemStyle-Font-Underline="true" ItemStyle-ForeColor ="Blue" />--%>
                                        <%--<asp:BoundField DataField="Sno" HeaderText="Sno" ItemStyle-Width="30px"  />--%>
                                        <asp:BoundField DataField="varOrderID" HeaderText="Order ID" ItemStyle-Width="180px" HeaderStyle-HorizontalAlign ="Center" ItemStyle-Wrap ="false" ItemStyle-ForeColor ="Blue" ItemStyle-Font-Underline ="true" />
                                        <asp:BoundField DataField="varTempCartID" HeaderText="Cart Ref No" HeaderStyle-HorizontalAlign ="Center" ItemStyle-ForeColor ="Blue" ItemStyle-Font-Underline ="true" >
                                         <ItemStyle Width="120px" HorizontalAlign="Left" />
                                                                </asp:BoundField>
                                        <asp:BoundField DataField="dtCreated" HeaderText="Date & Time" ItemStyle-Width="160px" DataFormatString="{0:dd/MMM/yyyy HH:mm:ss}" HeaderStyle-HorizontalAlign ="Center"  />
                                       <%-- <asp:BoundField DataField="dtSubmittedDate"  
                                            HeaderText="Date of Action" ItemStyle-Width="110px" DataFormatString="{0:dd/MMM/yyyy HH:mm:ss}" />--%>
                                       <asp:BoundField DataField="TotItems" HeaderText="Total Items" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right"   HeaderStyle-HorizontalAlign ="Center" DataFormatString="{0:0}"/>
                                        <asp:BoundField DataField="TotQty" HeaderText="Total Qty" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Right"   HeaderStyle-HorizontalAlign ="Center" DataFormatString="{0:0}"/>
                                        <asp:BoundField DataField="TotPrice" HeaderText="Total Price"  ItemStyle-Width="130px" DataFormatString="{0:0.00}" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign ="Center" />
                                        <asp:BoundField DataField="varStatus" HeaderText="StatusCode" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Right"   HeaderStyle-HorizontalAlign ="Center" Visible="false" />
                                        <asp:BoundField DataField="varCartHeaderRemarks" HeaderText="Status" ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Right"   HeaderStyle-HorizontalAlign ="Center" ItemStyle-Wrap ="false"  />
                                              <asp:TemplateField>
                                            <ItemTemplate>
                                            
                                                <asp:ImageButton ID="btndelete"  ImageUrl="~/Images/delete.jpg"  runat="server"   CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" OnCommand="ClickButton" CommandName="Delete_Me_Order"   OnClientClick="return confirm('Are you sure you want to delete?');" Width ="15px" /> 
                    
                                            </ItemTemplate>
                                            <ItemStyle Width="20px" HorizontalAlign ="Center" />
                                        </asp:TemplateField>                  
                                        
                                        
                                                                               
                                    </Columns>
                                </asp:GridView></div> 
                </asp:Panel>
                <%--</asp:Panel>--%>
            </div>
        </div>
        <%--</div>--%>
        </div></div>
    </form>
</body>
</html>

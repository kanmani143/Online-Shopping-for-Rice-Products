<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmCheckOut.aspx.cs" Inherits="HaiSia.frmCheckOut" %>

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
            <script type="text/javascript" >
                function Popup(url) {
                    url = "frmImageWindow.aspx?ImageUrl=" + url;
                    window.open(url, "Image Window", "status = 1, height = 390, width = 457, resizable = 0")
                }
                function CheckBoxAll(Checkbox, ClientID1) {
                    var GridVwHeaderChckbox = document.getElementById(ClientID1);
                    for (i = 1; i < GridVwHeaderChckbox.rows.length - 1; i++) {
                        GridVwHeaderChckbox.rows[i].cells[7].getElementsByTagName("INPUT")[0].checked = Checkbox.checked;
                    }
                }

                function CheckHead(Checkbox, ClientID1) {
                    var GridVwHeaderChckbox = document.getElementById(ClientID1);

                    if (Checkbox.checked == false) {
                        GridVwHeaderChckbox.rows[0].cells[7].getElementsByTagName("INPUT")[1].checked = false;
                    }
                    else {
                        GridVwHeaderChckbox.rows[0].cells[7].getElementsByTagName("INPUT")[1].checked = true;
                        for (i = 1; i < GridVwHeaderChckbox.rows.length - 1; i++) {
                            if (GridVwHeaderChckbox.rows[i].cells[7].getElementsByTagName("INPUT")[0].checked == false) {
                                GridVwHeaderChckbox.rows[0].cells[7].getElementsByTagName("INPUT")[1].checked = false;
                            }

                        }
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
                     Width="800px" ForeColor ="Black" Font-Size="X-Large" Font-Bold="true"  ></asp:Label>
                <br />
                <br />
              </div>
              
        </div>
       
              <div style="clear: both;">
              <div style="position: relative; float: left; width: 1000px; top: 0px; right: -50px; text-align:left;">
              
              <asp:LinkButton ID="lnkHome" runat="server" onclick="lnkHome_Click"  Font-Size="XX-Large" Width ="100px" >Home</asp:LinkButton>
 <%--              <asp:LinkButton ID="lnkCheckOut" runat="server"   Font-Size="XX-Large" 
                      Width ="165px" onclick="lnkCheckOut_Click" >Check Out</asp:LinkButton>--%>
                 <asp:LinkButton ID="lnkMyCart" runat="server" onclick="lnkMyCart_Click"  Font-Size="XX-Large" Width ="135px" >My Cart</asp:LinkButton>  
                <asp:LinkButton ID="lnkMyOrder" runat="server" onclick="lnkMyOrder_Click" Font-Size="XX-Large" Width ="150px" >My Order</asp:LinkButton>
                <asp:LinkButton ID="lnkOurProducts" runat="server"  Font-Size="XX-Large" 
                      Width ="216px" onclick="lnkOurProducts_Click" >Our Products</asp:LinkButton>
          <asp:LinkButton ID="lnkContactUs" runat="server" onclick="lnkContactUs_Click" Font-Size="XX-Large" Width ="180px" >Contact Us</asp:LinkButton>
             
                    <asp:LinkButton ID="lnkLogout" runat="server" onclick="lnkLogout_Click" Font-Size="XX-Large" Width ="120px" >Logout</asp:LinkButton>
                 
                 
          
            </div>
                 
          
           
                     
        </div>
        
         <div style="clear: both;">
            <br />
            <div style="position: relative; float: left; width: 440px; top: 0px; right: -50px; text-align:left;">
              
              <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                <ContentTemplate>
                <asp:Label ID="lblItem" runat="server" Text="Time Left : 2 Days 10 Hours 42 Min 30 Sec" BorderStyle="Solid" BorderColor="Green"  BorderWidth="1px" Width="420px" Font-Size="X-Large" Forecolor="Black"></asp:Label>
                <br />
                <asp:Label ID="lblCollection" runat="server" Text="Collection Date : 23 March 2015" BorderStyle="Solid" BorderColor="Green"  BorderWidth="1px" Width="420px" Font-Size="X-Large" Forecolor="Black"></asp:Label>
                 </ContentTemplate> 
                </asp:UpdatePanel> 
              </div>
              
               <div style="position: relative; float: left; width: 360px; top: 0px; right: -50px; text-align:left;">
              
              <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                <ContentTemplate>
                <asp:Label ID="lblCartRefNo" runat="server" Text="Time Left : 2 Days 10 Hours 42 Min 30 Sec" BorderStyle="Solid" BorderColor="Green"  BorderWidth="1px" Width="340px" Font-Size="X-Large" Forecolor="Black"></asp:Label>
                <br />
                <asp:Label ID="lblOderDate" runat="server" Text="Collection Date : 23 March 2015" BorderStyle="Solid" BorderColor="Green"  BorderWidth="1px" Width="340px" Font-Size="X-Large" Forecolor="Black"></asp:Label>
                 <br />
                <asp:Label ID="lblOrderID" runat="server" Text="Collection Date : 23 March 2015" BorderStyle="Solid" BorderColor="Green"  BorderWidth="1px" Width="340px" Font-Size="X-Large" Forecolor="Black"></asp:Label>
                 </ContentTemplate> 
                </asp:UpdatePanel> 
              </div>
              
               <div style="position: relative; float: left; width: 390px; top: 0px; right: -50px; text-align:left;">
              
              <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                <asp:Label ID="lblTotItem" runat="server" Text="" BorderStyle="Solid" BorderColor="Green"  BorderWidth="1px" Width="370px" Font-Size="X-Large" Forecolor="Black" ></asp:Label>
                <br />
                <asp:Label ID="lblTotQty" runat="server" Text="" BorderStyle="Solid" BorderColor="Green"  BorderWidth="1px" Width="370px" Font-Size="X-Large" Forecolor="Black"></asp:Label>
                 <br />
                <asp:Label ID="lblTotPrice" runat="server" Text="" BorderStyle="Solid" BorderColor="Green"  BorderWidth="1px" Width="370px" Font-Size="X-Large" Forecolor="Black"></asp:Label>
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
         <br />
               
             <div style="position: relative; text-align:center; width: auto; right:-50px">
            
                <asp:Label ID="Label1" runat="server" Text="List of ordered items"  Width="345px" Font-Size="XX-Large" ForeColor="White"  BackColor ="DarkGoldenrod"   ></asp:Label>
                </div>
                <br />
                    
                   <div style="position: relative; float: left; width: 450px; top: 0px;  text-align:left ; right: -50px">
               <%--ForeColor="#409E03"--%>
                         <asp:Label ID="Label7" runat="server" Text="Select Font Size: " 
                             Font-Size="XX-Large" Font-Bold="True" ForeColor="Blue"   ></asp:Label>
                <asp:DropDownList ID="dpdItemList" runat="server" AutoPostBack ="true" 
                    onselectedindexchanged="dpdItemList_SelectedIndexChanged" Font-Size="XX-Large" 
                             ForeColor="Black" >
                    <asp:ListItem Value ="XX-Large">XX-Large</asp:ListItem>
                    <asp:ListItem Value ="X-Large">X-Large</asp:ListItem>
                    <asp:ListItem Value ="Large">Large</asp:ListItem>
                    <asp:ListItem Value ="Larger">Larger</asp:ListItem>
                    <asp:ListItem Value ="Medium">Medium</asp:ListItem>
                    <asp:ListItem Value ="Small">Small</asp:ListItem>
                    <asp:ListItem Value ="Smaller">Smaller</asp:ListItem>
                    <asp:ListItem Value ="X-Small">X-Small</asp:ListItem>
                    <asp:ListItem Value ="XX-Small">XX-Small</asp:ListItem>
                </asp:DropDownList>
                         
            </div>
                      <div style="position: relative; float: right; width: 300px; top: 0px; left: 0px; text-align:right ;">
                <%--<asp:Button ID="BtnLogout" runat="server" Text="Logout" Width="124px" 
                      Height="50px" onclick="BtnLogout_Click" />--%>
                    <%--<asp:ImageButton ID="BtnLogout" runat="server" onclick="BtnLogout_Click" ImageUrl ="~/Images/LogoutImage5.jpeg"  ImageAlign ="Middle" />--%>
                          <asp:ImageButton ID="imgConfirmOrder" runat="server" ImageUrl ="~/Images/imgConfirmOrder7.jpg" onclick="imgConfirmOrder_Click"  Width="240px" Height="50px" ToolTip="CLICK HERE TO ORDER NOW!"/> 
                          <%--<asp:LinkButton ID="lnkConfirmOrder" runat="server" onclick="lnkConfirmOrder_Click" Font-Size="XX-Large" >Confirm Order</asp:LinkButton>--%>
            </div>
                
        </div>
        <div style="clear: both;">
          
            <div style="position: relative; float: left; width: auto;top: 0px; right: -50px; ">
<br />
  
                <asp:Panel ID="pnlMain" runat="server" ScrollBars="Vertical" Height="1200px" Width="1200px">
                                      <asp:GridView ID="grdvwMyCart" runat="server"  CssClass ="reportgrid"
                                    AutoGenerateColumns="False" BorderColor="#CCCCCC" BorderStyle="Solid" 
                                    BorderWidth="1px"   OnPageIndexChanging="grdvwMyCart_PageIndexChanging" 
                                     OnRowDataBound ="grdvwMyCart_OnRowDataBound"  CellPadding="5" style="table-layout: auto ;" Width="1160px">
                                    <AlternatingRowStyle BackColor="White" ForeColor="Black" Font-Size="XX-Large" />
                            
                                
                                    <HeaderStyle BackColor="LightBlue" 
                                        Font-Size="XX-Large" ForeColor="Black"  Font-Bold="true"  Height ="14px" />
                                    <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" />
                                    <RowStyle BackColor="White" Font-Size="XX-Large" ForeColor="Black" 
                                        Height="24px" />
                                    <Columns>
                                   
                                        <asp:TemplateField HeaderText="SNo" >
                                            <ItemTemplate>
                                                <span>
                                                    <%#Container.DataItemIndex + 1%>
                                                </span>
                                            </ItemTemplate>

                                            <ItemStyle Width="30px"></ItemStyle>
                                        </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Item Code"  ItemStyle-Width="220px" HeaderStyle-HorizontalAlign ="Center"    >

                                            <ItemTemplate>
                                                <asp:Image ID="Image1" runat="server" Width ="20px" Height="20px"  ImageAlign="AbsMiddle" ToolTip ="Click on this to view the image"  />
                                                <asp:Label ID="lblitemcode" runat="server" Text='<%#Eval("DMITNO") %>' Width ="120px" Font-Underline ="true"  ForeColor ="Blue" ToolTip ="Click on this to view the image" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                
                                        <%--<asp:BoundField DataField="nvarPpcRefno" HeaderText="PPC Reference No" ItemStyle-Width="160px" ItemStyle-Font-Underline="true" ItemStyle-ForeColor ="Blue" />--%>
                                        <%--<asp:BoundField DataField="Sno" HeaderText="Sno" ItemStyle-Width="30px"  />--%>
                                        <%--<asp:BoundField DataField="DMITNO" HeaderText="Item Code" ItemStyle-Width="70px" HeaderStyle-HorizontalAlign ="Center"  />--%>
                                        <asp:BoundField DataField="DMITDS" HeaderText="Description" ItemStyle-Width="400px" HeaderStyle-HorizontalAlign ="Center"  />
                                        <asp:BoundField DataField="DMPUOM" HeaderText="UOM" ItemStyle-Width="30px" HeaderStyle-HorizontalAlign ="Center" />
                                       <%-- <asp:BoundField DataField="dtSubmittedDate"  
                                            HeaderText="Date of Action" ItemStyle-Width="110px" DataFormatString="{0:dd/MMM/yyyy HH:mm:ss}" />--%>
                                       
                                        <asp:BoundField DataField="intQty" HeaderText="Qty" ItemStyle-Width="90px" ItemStyle-HorizontalAlign="Right"   HeaderStyle-HorizontalAlign ="Center" />
                                        <asp:BoundField DataField="AMLIST" HeaderText="Unit Price" ItemStyle-Width="120px" DataFormatString="{0:0.00}" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign ="Center" />
                                        <asp:BoundField DataField="dblTotPrice" HeaderText="Total Price"  ItemStyle-Width="160px" DataFormatString="{0:0.00}" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign ="Center"
                                            >
                                        
                                        </asp:BoundField>
                                                 <asp:TemplateField ItemStyle-Width="27px" ShowHeader="False">
                                        <HeaderTemplate>
                                         
                    
                                            <asp:ImageButton ID="imgbDelete" runat="server" ImageUrl="~/Images/imgDelete6.jpg" OnCommand="ClickButton" CommandName="Delete_Me_Items"   OnClientClick="return confirm('Are you sure you want to delete?');" Width="100px" Height="50px"/>
                                            <%--<asp:Button ID="btnDelete" runat="server" Text="Delete" Font-Size="XX-Large" />--%>
                                            <asp:CheckBox ID="chbHead" runat="server" 
                                                onclick="CheckBoxAll(this,'grdvwMyCart');" Font-Size="XX-Large" ForeColor ="Red"/>
                                        </HeaderTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemTemplate>
                         <%--                   <asp:CheckBox ID="chb1" runat="server" Checked ='<%# Bind("chb1") %>' 
                                                Enabled="true" onclick="CheckHead(this,'grdvwMyCart');" />--%>
                                                
                                                    <asp:CheckBox ID="chb1" runat="server" 
                                                Enabled="true" onclick="CheckHead(this,'grdvwMyCart');" Font-Size="XX-Large" ForeColor ="Red" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"/>
                                        <EditItemTemplate>
                                            <asp:CheckBox ID="chb1" runat="server" Checked='<%# Bind("chb1") %>' Font-Size="XX-Large" />
                                        </EditItemTemplate>
                                        <ItemStyle Width="27px" />
                                    </asp:TemplateField>                                
                                    </Columns>
                                </asp:GridView>
                </asp:Panel>
            </div>
        </div>
        <%--</div>--%>
        </div></div>
    </form>
</body>
</html>
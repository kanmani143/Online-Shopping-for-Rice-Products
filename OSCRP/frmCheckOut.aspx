<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="frmCheckOut.aspx.cs" Inherits="OSCRP.frmCheckOut" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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

    <div style="position: relative; float: left; width: 1165px; top: 0px; right: -50px; text-align:left;">
              <br />
              <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <table style="width:1165px;border: none;">
                        <tr>
                            
                                                   <td style="border:solid;text-align:center;background-color:ghostwhite;">
                                <p><span style="font-size:medium;color:#cc6699;font-weight:bold" >Cart No</span>&mdash;<span style="font-size: medium;color:black;font-weight:bold" >
              <asp:Label ID="lblcartNo" runat="server" Text=""  style="text-align: right" Visible="true"></asp:Label></span></p>
                            </td>
                            <td style="border:solid;text-align:center;background-color:ghostwhite;">
                                <p><span style="font-size:medium;color:#cc6699;font-weight:bold" >Check-Out Items</span>&mdash;<span style="font-size: medium;color:black;font-weight:bold" >
              <asp:Label ID="lblCartItems" runat="server" Text=""  style="text-align: right" Visible="true"></asp:Label></span></p>
                            </td>
                                                        <td style="border:solid;text-align:center;background-color:ghostwhite;">
                                <p><span style="font-size:medium;color:#cc6699;font-weight:bold" >Check-Out Quanties</span>&mdash;<span style="font-size: medium;color:black;font-weight:bold" >
              <asp:Label ID="lblCartQty" runat="server" Text=""  style="text-align: right" Visible="true"></asp:Label></span></p>
                            </td>
                                                                                    <td style="border:solid;text-align:center;background-color:ghostwhite;">
                                <p><span style="font-size:medium;color:#cc6699;font-weight:bold" >Check-Out Price</span>&mdash;<span style="font-size: medium;color:black;font-weight:bold" >
              <asp:Label ID="lblCartPrice" runat="server" Text=""  style="text-align: right" Visible="true"></asp:Label></span></p>
                            </td>
                            <td style="border:solid;text-align:center;background-color:ghostwhite;">
                                <asp:ImageButton ID="imgOrder"  ImageAlign ="AbsBottom" runat="server" ImageUrl ="~/Images/imgConfirmOrder7.jpg"  Width="85px" Height="30px" ToolTip="CLICK HERE TO ORDER NOW!"  OnClientClick="return true;" OnClick="imgOrder_Click" /> 
                            </td>
                        </tr>

                    </table>                 

                </ContentTemplate> 
                </asp:UpdatePanel> 
              </div>
    <div style="clear: both;">
          
            <div style="position: relative; float: left; width: auto;top: 0px; right: -50px; ">

<br />
  
                <asp:Panel ID="pnlMain" runat="server" ScrollBars="Vertical" Height="600px" Width="1170px">
                      <asp:ListView ID="lstItemView" runat="server" GroupItemCount="1" GroupPlaceholderID="grpPh_1"
                        ItemPlaceholderID="Iph1" onitemdatabound="lstItemView_ItemDataBound" OnSelectedIndexChanged="lstItemView_SelectedIndexChanged">
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
                                                
                                        <td  id="tdItems" align="center" style="width: 376px; height :376px;  border-color:#CC6699;  border-style: none;border-width: thin ;" valign ="top" runat ="server"    >
                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                            <asp:ImageButton ID="imgBtnList" runat="server" 
                                                ImageUrl="~/Images/NoImage.jpg" Enabled="true" Width="200px" Height="240px" ToolTip ="Click on this to view the image in large size" 
                                                CommandArgument='<%# DataBinder.Eval(((IDataItemContainer)Container).DataItem, "nvrPrdNo") %>' OnCommand="ClickButton" CommandName="Add_to_cart" OnClientClick="return true;" />
                                    <%--        <asp:ImageButton ID="imgBtnList" runat="server" ImageUrl="~/Images/NoImage.jpg" Enabled="true" Width="200px" Height="180px" 
                                               CommandArgument='<%# DataBinder.Eval(((IDataItemContainer)Container).DataItem, "DMITNO") %>' OnCommand="ClickButton" CommandName="Add_to_cart"   OnClientClick="return true;"   ToolTip ="Click here add to cart" />--%>
                                            <br />
                                                            
                                              <asp:Label ID="lblItemCode" runat="server" Text='<%#Eval("nvrPrdNo") %>' Font-Size="Medium" ForeColor="Black" visible="false"></asp:Label>
                                            <br />
                                            <asp:Label ID="lblItemName" runat="server" Text='<%#Eval("nvrPrdName") %>' Font-Size="Medium" ForeColor="black" Height ="30px" ></asp:Label>
                                            <br />
                                            <asp:Label ID="lblCurr" runat="server" Text='<%#Eval("nvrCurr") %>' Font-Size="Medium" ForeColor ="black" Visible="true"></asp:Label>
                                            <asp:Label ID="lblPrice" runat="server" Text='<%#Eval("decPrice","{0:0.00}") %>' Font-Size="Medium" ForeColor ="black" DataFormatString="{0:0.00}"></asp:Label>
                                            <asp:Label ID="lblSlash" runat="server" Text="/" Font-Size="Medium" ForeColor ="black"></asp:Label>
                                            <asp:Label ID="lblUom" runat="server" Text='<%#Eval("nvrUOM") %>' Font-Size="Medium" ForeColor ="black"></asp:Label>
                                <asp:Label ID="lblOpenBracket" runat="server" Text=" (" Font-Size="Medium" ForeColor ="black"></asp:Label>
                                <asp:Label ID="lblUnit" runat="server" Text='<%#Eval("intUnit") %>' Font-Size="Medium" ForeColor ="black"></asp:Label>
                                <asp:Label ID="lblClosingBracket" runat="server" Text=" KG)" Font-Size="Medium" ForeColor ="black"></asp:Label>
                                                         </ContentTemplate>
                                </asp:UpdatePanel>
                                 
                                        </td>

                                    </tr>
                                </table>
                                

                            </td>
                            <td valign ="top" >
                                                     <table cellpadding="5"  >
                                    <tr>
                                                
                                        <td  id="td1" align="center" style="width: 376px; height : 376px;  border-color:#CC6699;  border-style: none;border-width: thin ;" valign ="top" runat ="server"    >
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div style="text-align: justify" >
<p><span class="bold"><asp:Label ID="lblTitle" runat="server" Text='<%#Eval("TITLE") %>' Font-Size="small" ForeColor ="Black" style="text-align:justify" Visible="true"></asp:Label></span>&mdash;</p>
        <p style="font-size:medium;"><asp:Label ID="lblDesc" runat="server" Text='<%#Eval("Description") %>' Font-Size="small" ForeColor ="Black" style="text-align:justify" Visible="true"></asp:Label></p>
          <p><span style="font-size:Smaller;color:#cc6699;font-weight:bold" >Total Qty</span>&mdash;<span style="font-size: smaller;color:black;font-weight:bold" >
              <asp:Label ID="lblTotalQty" runat="server" Text='<%#Eval("intPrdQty") %>'  style="text-align: right" Visible="true"></asp:Label></span></p>
               <p><span style="font-size:Smaller;color:#cc6699;font-weight:bold" >Price</span>&mdash;<span style="font-size: smaller;color:black;font-weight:bold" >
              <asp:Label ID="lblItemPrice" runat="server" Text='<%#Eval("decPrice","{0:0.00}") %>'    Visible="true"></asp:Label></span></p>                                                                                                                 
                                          <p><span style="font-size:Smaller;color:#cc6699;font-weight:bold" >Total Price</span>&mdash;<span style="font-size: smaller;color:black;font-weight:bold" >
              <asp:Label ID="lblTotalPrice" runat="server" Text='<%#Eval("monPrdTotPrice","{0:0.00}") %>'    Visible="true"></asp:Label>
                   
                                                                                                    </span></p>  
                                                                              <%--<p><span style="font-size:Smaller;color:#cc6699;font-weight:bold; text-align:center;" >Checkout</span>&mdash;<span style="font-size: smaller;color:black;font-weight:bold; vertical-align:bottom;" >
                                                                                  <asp:CheckBox ID="chbCheckOut" runat="server" />
                   
                                                                                                    </span></p>  --%>
                                <%--<p><asp:ImageButton ID="ImgbtnAddtoCart" runat="server" ImageUrl ="~/Images/ImgAddtoCart.jpg" ImageAlign ="TextTop" CommandArgument="" OnCommand="ClickButton" CommandName="Add_to_cart" Height="30px" Width="120px" OnClientClick="return true;"/></p>
                                <p><asp:Label ID="lblcartNo" runat="server" Text=""   Visible="false"></asp:Label></p>
                                <p><asp:Label ID="lblLineNo" runat="server" Text=""   Visible="false"></asp:Label></p>
                                <p><asp:Label ID="lblLastLineNo" runat="server" Text=""   Visible="false"></asp:Label></p>
                                <p><asp:Label ID="lblError" runat="server" Text=""   Visible="false" ForeColor="Red"></asp:Label></p>--%>
                            </div>
                                   
            
                                </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                                         </table>
                                </td>
                        </ItemTemplate>
                    </asp:ListView>
                </asp:Panel>
            </div>
        </div>
</asp:Content>

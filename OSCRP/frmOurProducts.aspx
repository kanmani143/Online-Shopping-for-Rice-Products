<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="frmOurProducts.aspx.cs" Inherits="OSCRP.frmOurProducts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style4 {
            width: 1157px;
        }
    </style>
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
    <div style="clear: both;">
          
            <div style="position: relative; float: left; width: auto;top: 0px; right: -50px; ">
                <table>
                                                                       <tr>
                <td  align="center" class="auto-style4">
                    <asp:Label ID="lblRegistrationForm" runat="server" Text="Our Products" Font-Size="Large" ForeColor="#cc6699" Font-Names="viladimir script" Font-Bold="true" Font-Italic="" ></asp:Label>
                   
                </td>
                
            </tr>
                </table>
<br />
  
                <asp:Panel ID="pnlMain" runat="server" ScrollBars="Vertical" Height="600px" Width="1170px">
                      <asp:ListView ID="lstItemView" runat="server" GroupItemCount="3" GroupPlaceholderID="grpPh_1"
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
                                                
                                        <td  id="tdItems" align="center" style="width: 376px; height : auto;  border-color:#CC6699;  border-style: solid;border-width: thin ;" valign ="top" runat ="server"    >
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
                                  <%--          <br />
                                            <br />
                                            <div style="text-align: center ;" >
         
                                                
                                        
                                         <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
                            <ContentTemplate>
                                        <asp:Label ID="lblQty" runat="server" Text="Qty :" Font-Size="XX-Large" ForeColor ="Black"></asp:Label>
                                        
                                                <asp:ImageButton ID="imgBtnMinus" runat="server" ImageUrl ="~/Images/btnMinusImage_New_1.jpeg"  ImageAlign ="Middle"   CommandArgument='<%# DataBinder.Eval(((IDataItemContainer)Container).DataItem, "DMITNO") %>' OnCommand="ClickButton" CommandName="ReduceToCart_Me"   OnClientClick="return true;" />
                                                <asp:TextBox ID="txtQty" runat="server" Width="85px" Font-Size="XX-Large" Text="0" onkeypress="return isNumber(event,this)" ></asp:TextBox>
                                                <asp:ImageButton ID="imgBtnAdd" runat="server" ImageUrl ="~/Images/btnAddImage_New_1.jpeg" ImageAlign ="Middle" CommandArgument='<%# DataBinder.Eval(((IDataItemContainer)Container).DataItem, "DMITNO") %>' OnCommand="ClickButton" CommandName="AddToCart_Me"   OnClientClick="return true;"/>
                                                
                                            </ContentTemplate>
                                </asp:UpdatePanel>
                                            </div>--%>
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

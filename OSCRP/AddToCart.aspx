<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="AddToCart.aspx.cs" Inherits="OSCRP.AddToCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 288px;
        }
        .auto-style4 {
        position: relative;
        float: left;
        width: auto;
        top: -40px;
        right: -51px;
    }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <script type="text/javascript" >
        function Popup(url) {
            url = "frmImageWindow.aspx?ImageUrl=" + url;
            window.open(url, "Image Window", "status = 1, height = 390, width = 457, resizable = 0")
        }
            function PopupError(url, errormg) {
                url = "frmError.aspx?Url=" + url+ "&msg="+errormg;
                window.open(url, "Error Window", "status = 1, height = 390, width = 457, resizable = 0")

            }

            function isNumber(evt, obj) {
                document.getElementById('ctl00_ContentPlaceHolder1_lblTotalQty')
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            var val = obj.value;
            if (val.indexOf(".") > 0) {
                if (val.substring(val.indexOf(".") + 1).length > 1) return false;
                
            }
            
                if (charCode == 8 || charCode == 127) {
                    document.getElementById('ctl00_ContentPlaceHolder1_lblTotalQty').value = val.val;
                    return true;
                }
                else if (charCode == 37 || charCode == 39) {
                    document.getElementById('ctl00_ContentPlaceHolder1_lblTotalQty').value = val.val;
                    return true;
                }
                else if (charCode == 46 && val.length > 0 && val.indexOf(".") == -1) {
                    document.getElementById('ctl00_ContentPlaceHolder1_lblTotalQty').value = val.val;
                    return true;
                }
                else if (charCode > 31 && (charCode < 48 || charCode > 57)) return false;
                else {
                    document.getElementById('ctl00_ContentPlaceHolder1_lblTotalQty').value = val.val;
                    return true;
                }
          
            
        }
        
        
        
        </script>
    <br />
    <div style="clear: both;">
<div style="position: relative; float: left; width: 1003px; top: 0px; right: -53px; text-align:left; height: 20px;">
              
    
 <table Width="100%" >
  <tr>
              
                        <td style="border-color:#CC6699; border:thin; border-style:solid;" class="auto-style2" align="center">
                                    <asp:Image ID="ItemImage" runat="server" Height="240px" 
            ImageUrl="~/Images/blueSeaCrab1.jpeg" Width="200px" />
     
                                                      
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
                                                <br />   
                            <br />
                            
                                        <asp:Label ID="lblQty" runat="server" Text="Qty :" Font-Size="small" ForeColor ="Black" style="text-align:justify" Visible="false"></asp:Label>
                                        
                                                <asp:ImageButton ID="imgBtnMinus" runat="server" ImageUrl ="~/Images/btnMinusImage_New_1.jpeg"  ImageAlign ="TextTop"   CommandArgument="" OnCommand="ClickButton" CommandName="ReduceQty" Height="20px" Width="20px"  OnClientClick="return true;" />
                                                <asp:TextBox ID="txtQty" runat="server" Width="50px" Font-Size="small" Text="0" onkeypress="return isNumber(event,this)" OnTextChanged="txtQty_TextChanged"   ></asp:TextBox>
                                                <asp:ImageButton ID="imgBtnAdd" runat="server" ImageUrl ="~/Images/btnAddImage_New_1.jpeg" ImageAlign ="TextTop" CommandArgument="" OnCommand="ClickButton" CommandName="AddQty" Height="20px" Width="20px" OnClientClick="return true;"/>
                                                
                                          <br />
  
                        </td>
                        <td >
                             <div class="auto-style4">

  
                <asp:Panel ID="pnlMain" runat="server"  Height="240px" Width="400px" >
                            <div style="text-align: justify" >
<p><span class="bold"><asp:Label ID="lblTitle" runat="server" Text="" Font-Size="small" ForeColor ="Black" style="text-align:justify" Visible="true"></asp:Label></span>&mdash;</p>
        <p style="font-size:medium;"><asp:Label ID="lblDesc" runat="server" Text="" Font-Size="medium" ForeColor ="Black" style="text-align:justify" Visible="true"></asp:Label></p>
          <p><span style="font-size:Smaller;color:#cc6699;font-weight:bold" >Total Qty</span>&mdash;<span style="font-size: smaller;color:black;font-weight:bold" >
              <asp:Label ID="lblTotalQty" runat="server" Text="0"  style="text-align: right" Visible="true"></asp:Label></span></p>
               <p><span style="font-size:Smaller;color:#cc6699;font-weight:bold" >Price</span>&mdash;<span style="font-size: smaller;color:black;font-weight:bold" >
              <asp:Label ID="lblItemPrice" runat="server" Text="0"   Visible="true"></asp:Label></span></p>                                                                                                                 
                                          <p><span style="font-size:Smaller;color:#cc6699;font-weight:bold" >Total Price</span>&mdash;<span style="font-size: smaller;color:black;font-weight:bold" >
              <asp:Label ID="lblTotalPrice" runat="server" Text="0"   Visible="true"></asp:Label>
                   
                                                                                                    </span></p>  
                                <p><asp:ImageButton ID="ImgbtnAddtoCart" runat="server" ImageUrl ="~/Images/ImgAddtoCart.jpg" ImageAlign ="TextTop" CommandArgument="" OnCommand="ClickButton" CommandName="Add_to_cart" Height="30px" Width="120px" OnClientClick="return true;" /></p>
                                <p><asp:Label ID="lblcartNo" runat="server" Text=""   Visible="false"></asp:Label></p>
                                <p><asp:Label ID="lblLineNo" runat="server" Text=""   Visible="false"></asp:Label></p>
                                <p><asp:Label ID="lblLastLineNo" runat="server" Text=""   Visible="false"></asp:Label></p>
                                <p><asp:Label ID="lblError" runat="server" Text=""   Visible="false" ForeColor="Red"></asp:Label></p>
                            </div>
                                   </asp:Panel>
            </div>
                        </td>
                    </tr>
                    
                </table>
          
            </div>
                 
         
           
                     
        </div>
</asp:Content>

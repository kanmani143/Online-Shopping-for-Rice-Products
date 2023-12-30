<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="frmPlaceOrder.aspx.cs" Inherits="OSCRP.frmPlaceOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript" type="text/javascript">
        
            function CheckBoxAll(Checkbox,ClientID1) {
            var GridVwHeaderChckbox = document.getElementById(GetClientId(ClientID1));
            for (i = 1; i < GridVwHeaderChckbox.rows.length; i++) {
                GridVwHeaderChckbox.rows[i].cells[1].getElementsByTagName("INPUT")[0].checked = Checkbox.checked;
            }
        }
        function Print() {
            alert('1');
            //alert(Invoice);
            //alert(document.getElementById(GetClientId(Invoice)));
            //var prntData = document.getElementById(GetClientId("Invoice"));
            var prntData = document.getElementById('<%=Invoice.ClientID%>');
            //var prntData-=document.getElementById(GetClientId(Invoice));
            //alert(prntData);
            //alert(prntData.outerHTML);
            var mywindow = window.open('', 'Microsoft Print to PDF', 'height=400,width=600');
            /*mywindow.document.write('<html><head><title></title>');*/
            /*mywindow.document.write('</head><body style="direction:ltr;"><pre>');*/
            mywindow.document.write(prntData.innerHTML);
            /*mywindow.document.write('</body></html>');*/
            mywindow.document.close();
            mywindow.print();
        }
    </script>
    <style type="text/css">
        .auto-style5 {
            width: 417px;
        }
        .auto-style6 {
            width: 317px;
            height: 207px;
        }
        .auto-style7 {
            width: 501px;
            height: 207px;
        }
        .auto-style8 {
            width: 1165px;
        }
        .auto-style9 {
            width: 487px;
        }
        .auto-style16 {
            height: 294px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="position: relative; float: left; width: 1165px; top: 0px; right: -50px; text-align:left;">
              <br />
              <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:ImageButton ID="imgBtnPrint1"  ImageAlign ="AbsBottom" runat="server" ImageUrl ="~/Images/ImgPrint.jpg"  Width="85px" Height="30px" ToolTip="CLICK HERE TO PRINT INVOICE!"  OnClientClick="return Print();"  /> 
                    <br />
                    <table  id="Invoice" style="border-style: none; border-color: inherit; border-width: medium;" runat="server" class="auto-style8">
                        <tr>
                            <td>
                                <table Width="1175px" class="auto-style16">
                                    <tr>
                            <td style="vertical-align:top" ">
                                
                                <p><span style="font-size: smaller;color:black;font-weight:bold;" class="auto-style9" >KESAVAMOORTHI M.</span><p><span style="font-size: smaller;color:black;font-weight:normal;" >Idaikattur,</span></p>
                                <p><span style="font-size: smaller;color:black;font-weight:normal;" >Manamadurai Taluk,</span></p>
                                <p><span style="font-size: smaller;color:black;font-weight:normal;" >Sivaganga District,</span></p>
                                <p><span style="font-size: smaller;color:black;font-weight:normal;" >TamilNadu,</span></p>
                                <p><span style="font-size: smaller;color:black;font-weight:normal;" >India -  630602</span></p>
                                <p>
                                    <span style="font-size: smaller;color:black;font-weight:normal;" >INVOICE NO :</span>
                                    <span style="font-size: smaller;color:black;font-weight:normal;" >
                                    <asp:Label ID="lblInvoiceNo" runat="server" Text=""   Visible="true"></asp:Label></span>
                                </p>
                               
                            </td>

                        <td style="vertical-align:top" class="auto-style7" >
                                <p><span style="font-size:smaller;color:#cc6699;font-weight:normal;text-align:center;" >RAJESHWARI MODERN RICEMILL</span></p>
                                <p class="auto-style5"><span style="font-size: smaller;color:black;font-weight:normal" >ORDER ID :</span>
                                                                    <span style="font-size: smaller;color:black;" >
              <asp:Label ID="lblOrderID" runat="server" Text=""  style="text-align: right" Visible="true"></asp:Label></span></p>
                                <p><span style="font-size: smaller;color:black;font-weight:normal" >ORDER DATE :</span>
                                                                    <span style="font-size: smaller;color:black;" >
              <asp:Label ID="lblOrderDate" runat="server" Text=""  style="text-align: right" Visible="true"></asp:Label></span></p>
                                <p><span style="font-size: smaller;color:black;font-weight:normal" >STATUS :</span>
                                                                    <span style="font-size: smaller;color:black;" >
              <asp:Label ID="lblStatus" runat="server" Text=""  style="text-align: right" Visible="true"></asp:Label></span></p>
                            <p><span style="font-size: smaller;color:black;font-weight:normal" >DEPARTURE DATE :</span>
                                                                    <span style="font-size: smaller;color:black;" >
              <asp:Label ID="lblDepartureDate" runat="server" Text=""  style="text-align: right" Visible="true"></asp:Label></span></p>
                            <p><span style="font-size: smaller;color:black;font-weight:normal" >DELIVERED DATE :</span>
                                                                    <span style="font-size: smaller;color:black;" >
              <asp:Label ID="lblDeliveredDate" runat="server" Text=""  style="text-align: right" Visible="true"></asp:Label></span></p>
                            <p><span style="font-size: smaller;color:black;font-weight:normal" >INVOICE DATE :</span>
                                                                    <span style="font-size: smaller;color:black;" >
              <asp:Label ID="lblInvoiceDate" runat="server" Text=""  style="text-align: right" Visible="true"></asp:Label></span></p>
                            </td>
                            <td style="vertical-align:top" class="auto-style6">

                                <p><span style="font-size:small;color:#cc6699;font-weight:bold" >Address:</span></p>
                                                                    <p><span style="font-size: small;color:black;" >
              <asp:Label ID="lblName" runat="server" Text=""  style="text-align: right" Visible="true"></asp:Label></span></p>
                                    <p><span style="font-size: small;color:black;" >
              <asp:Label ID="lblAddress" runat="server" Text=""  style="text-align: right" Visible="true"></asp:Label></span></p>
                                <p><span style="font-size:small;color:#cc6699;font-weight:bold" >Pin Code : </span>
                                                                    <span style="font-size: small;color:black;" >
              <asp:Label ID="lblPinCode" runat="server" Text=""  style="text-align: right" Visible="true"></asp:Label></span></p>
                                                                <p><span style="font-size:small;color:#cc6699;font-weight:bold" >Phone No : </span>
                                                                    <span style="font-size: small;color:black;" >
              <asp:Label ID="lblPhone" runat="server" Text=""  style="text-align: right" Visible="true"></asp:Label></span></p>
                                                                                                <p><span style="font-size:small;color:#cc6699;font-weight:bold" >WhatsApp : </span>
                                                                    <span style="font-size: small;color:black;" >
              <asp:Label ID="lblWhatsApp" runat="server" Text=""  style="text-align: right" Visible="true"></asp:Label></span></p>
<p><span style="font-size: smaller;color:black;font-weight:normal" >INVOICE AMOUNT :</span>
                                                                    <span style="font-size: small;color:black;" >
              <asp:Label ID="lblInvoiceAmount" runat="server" Text=""  style="text-align: right" Visible="true"></asp:Label></span></p>
                            </td>
                                        </tr>
                                    </table>
                            </td>
                            
                        </tr>
                        <%--<tr>
                            <td >
                                <table Width="1175px">
                                    <tr>
                            <td style="vertical-align:top" align="left" >
                                
                                <p class="auto-style13"><span style="font-size: smaller;color:black;font-weight:normal" >INVOICE NO :</span>
                                                                    <span style="font-size: small;color:black;" >
              <asp:Label ID="lblInvoiceNo" runat="server" Text=""   Visible="true"></asp:Label></span></p>
                                
                                
                            </td>
                                                                    <td style="vertical-align:top" align="center"  >
                                
                                <p><span style="font-size: smaller;color:black;font-weight:normal" >INVOICE DATE :</span>
                                                                    <span style="font-size: small;color:black;" >
              <asp:Label ID="lblInvoiceDate" runat="server" Text=""   Visible="true"></asp:Label></span></p>
                            </td>
                                                                    <td style="vertical-align:top;" align="right"  >
                                
                                <p class="auto-style15"><span style="font-size: smaller;color:black;font-weight:normal" >INVOICE AMOUNT :</span>
                                                                    <span style="font-size: small;color:black;" >
              <asp:Label ID="lblInvoiceAmount" runat="server" Text=""   Visible="true"></asp:Label></span></p>
                            </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>--%>
                        <tr>
                            <td >
                                <br />
                                <asp:GridView ID="grdOrder" runat="server" showfooter="True" autogeneratecolumns="False" EnableModelValidation="True" Width="1152px" BorderStyle="None" HeaderStyle-ForeColor="#cc6699">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sno">
                                                                                        <itemtemplate>
                                                <%#(Container.DataItemIndex+1)%>
                                            </itemtemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="nvrPrdNo" HeaderText="Product No" Visible="False" ItemStyle-ForeColor="Black" />
                                        <asp:BoundField DataField="nvrPrdName" HeaderText="Product Name" ItemStyle-ForeColor="Black" />
                                        <asp:BoundField DataField="Price" FooterText="Grand Total:" HeaderText="Price" FooterStyle-Font-Bold="true" FooterStyle-ForeColor="#cc6699" ItemStyle-ForeColor="Black"/>
                                        <asp:BoundField DataField="intPrdQty" HeaderText="Quantity" DataFormatString="{0:0.00}" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right" ItemStyle-ForeColor="Black" />
                                        <asp:BoundField DataField="monPrdTotPrice" HeaderText="Total Amount" DataFormatString="{0:0.00}" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right" ItemStyle-ForeColor="Black" />
                                    </Columns>
                                </asp:GridView>
               <%--                 <asp:gridview runat="server" id="grdOrder" showfooter="true" autogeneratecolumns="false">
                                    <columns>
                                        <asp:templatefield>
                                            <headertemplate>
                                                Sno
                                            </headertemplate>
                                            <itemtemplate>
                                                <%#(Container.DataItemIndex+1)%>
                                            </itemtemplate>
                                        </asp:templatefield>
                                        <asp:boundfield datafield="nvrPrdNo" headertext="Product No" Visible="false">
                                            
                                        <asp:boundfield datafield="nvrPrdName" headertext="Product Name">
                                        <asp:boundfield datafield="Price" headertext="Price" footertext="Grand Total:" footerstyle-font-bold="true">
                                        <asp:boundfield datafield="intPrdQty" headertext="Quantity">
                                        <asp:boundfield datafield="monPrdTotPrice" headertext="Total Amount">
                                        </asp:boundfield></asp:boundfield></asp:boundfield></columns>
    </asp:gridview>--%>
                            </td>
                        </tr>
    
                    </table>                 
                    <br />
                                <asp:ImageButton ID="imgBtnPrint"  ImageAlign ="AbsBottom" runat="server" ImageUrl ="~/Images/ImgPrint.jpg"  Width="85px" Height="30px" ToolTip="CLICK HERE TO PLACE THE ORDER!"  OnClientClick="return Print();"  /> 
                </ContentTemplate> 
                </asp:UpdatePanel> 
              </div>
</asp:Content>

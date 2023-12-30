<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="frmOrder.aspx.cs" Inherits="OSCRP.frmOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript" type="text/javascript">
            function CheckBoxAll(Checkbox,ClientID1) {
            var GridVwHeaderChckbox = document.getElementById(GetClientId(ClientID1));
            for (i = 1; i < GridVwHeaderChckbox.rows.length; i++) {
                GridVwHeaderChckbox.rows[i].cells[1].getElementsByTagName("INPUT")[0].checked = Checkbox.checked;
            }
        }
        function Print() {
            var prntData = document.getElementById('Table1');
            var mywindow = window.open('', 'printer', 'height=400,width=600');
            mywindow.document.write('<html><head><title></title>');
            mywindow.document.write('</head><body style="direction:rtl;"><pre>');
            mywindow.document.write(prntData.innerHTML);
            mywindow.document.write('</body></html>');
            mywindow.document.close();
            mywindow.print();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
        <div style="position: relative; float: left; width: 1165px; top: 0px; right: -50px; text-align:left;">
              <br />
              <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:Label ID="lblcartNo" runat="server" Text=""  style="text-align: right" Visible="false"></asp:Label></span></p>
                    <asp:Label ID="lblTotalItems" runat="server" Text=""  style="text-align: right" Visible="false"></asp:Label></span></p>
                    <asp:Label ID="lblTotalQty" runat="server" Text=""  style="text-align: right" Visible="false"></asp:Label></span></p>
                    <asp:Label ID="lblTotalPrice" runat="server" Text=""  style="text-align: right" Visible="false"></asp:Label></span></p>
                    <table id="Invoice" style="width:1165px;border: none;" runat="server">
                        <tr>
                            <td style="vertical-align:top">
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
                            </td>
                            <td>

                            </td>
                            <td style="vertical-align:top;" align="right">
                                <br />
                                <asp:ImageButton ID="imgPlaceOrder"  ImageAlign ="AbsBottom" runat="server" ImageUrl ="~/Images/imgPlaceOrder.jpg"  Width="170px" Height="60px" ToolTip="CLICK HERE TO PLACE THE ORDER!"  OnClientClick="return confirm('Are you sure you want to place the order?');" OnClick="imgPlaceOrder_Click"  /> 
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
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

                            </td>
                        </tr>
    
                    </table>                 

                </ContentTemplate> 
                </asp:UpdatePanel> 
              </div>
</asp:Content>

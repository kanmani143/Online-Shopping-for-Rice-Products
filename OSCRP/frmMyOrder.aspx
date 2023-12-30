<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="frmMyOrder.aspx.cs" Inherits="OSCRP.frmMyOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="position: relative; float: left; width: 1165px; top: 0px; right: -50px; text-align:left;">
              <br />
              <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
              
                <ContentTemplate>
                    
   
                    <table id="Invoice" style="width:1165px;border: none;height:200px;" runat="server" >
                           <tr>
                <td colspan="2" align="center">
                    <asp:Label ID="lblRegistrationForm" runat="server" Text="My Orders" Font-Size="Large" ForeColor="#cc6699" Font-Names="viladimir script" Font-Bold="true" Font-Italic="" ></asp:Label>
                   
                </td>
                
            </tr>
                        <tr>

<%--                            <td style="vertical-align:top;" align="right">
                                
                                <asp:ImageButton ID="imgAdd"  ImageAlign ="AbsBottom" runat="server" ImageUrl ="~/Images/ImgAddNew.jpg"  Width="85px" Height="30px" ToolTip="CLICK HERE TO add new product!"  OnClientClick="return confirm('Are you sure you want to Add new product?');" OnClick="imgAdd_Click"   /> 
                            </td>--%>
                        </tr>
                        <tr>
                            <td colspan="3">
                                
                                <asp:GridView ID="grdOrders" runat="server" showfooter="True" autogeneratecolumns="False" EnableModelValidation="True" AllowPaging="True" AutoGenerateSelectButton="false"
                                    Width="1152px"  BorderColor="#CCCCCC" BorderStyle="Solid" PagerStyle-BackColor="#D5D5BF" PageSize="8"
                                BorderWidth="1px" CellPadding="0" CellSpacing="0" 
                                    OnRowDataBound="grdOrders_RowDataBound" OnPageIndexChanging="grdOrders_PageIndexChanging" OnRowDeleting="grdOrders_RowDeleting" OnSelectedIndexChanged="grdOrders_SelectedIndexChanged"  >
                                          <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" />
                                <AlternatingRowStyle BackColor="#BFE4FF"  />
                                <PagerStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" />
                                <HeaderStyle BackColor="CadetBlue" BorderColor="#CCCCCC" BorderStyle="Solid" 
                                    BorderWidth="1px" Font-Names="Arial" ForeColor="White" Height="14px" />
                                <RowStyle BackColor="MintCream" BorderColor="#CCCCCC" BorderStyle="Solid" 
                                    BorderWidth="1px" Font-Names="Arial" Font-Size="Small"  
                                    Height="25px"  />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sno">
                                                                                        <itemtemplate>
                                                <%#(Container.DataItemIndex+1)%>
                                            </itemtemplate>
                                        </asp:TemplateField>
                                         <asp:BoundField DataField="nvrOrderID" HeaderText="Order Number" ItemStyle-ForeColor="Black" />
                                        <asp:BoundField DataField="dtOrderDate" HeaderText="Order Date" ItemStyle-ForeColor="Black" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="nvrCatrNo" FooterText="" HeaderText="Cart Number" FooterStyle-Font-Bold="true" FooterStyle-ForeColor="#cc6699" ItemStyle-ForeColor="Black"/>
                                        <asp:BoundField DataField="intTotalItems" HeaderText="Total Items"  ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right" ItemStyle-ForeColor="Black" />
                                        <asp:BoundField DataField="intTotalQty" HeaderText="Total Qty"  ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right" ItemStyle-ForeColor="Black" />
                                        <asp:BoundField DataField="monTotalPrice" FooterText="" HeaderText="Total Price" DataFormatString="{0:0.00}" ItemStyle-HorizontalAlign="Right" FooterStyle-Font-Bold="true" FooterStyle-ForeColor="#cc6699" ItemStyle-ForeColor="Black"/>
                                        <asp:BoundField DataField="dtDepartDate" HeaderText="Departure Date"  DataFormatString="{0:dd/MM/yyyy}" ItemStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Right" ItemStyle-ForeColor="Black" />
                                        <asp:BoundField DataField="dtDeliveredDate" HeaderText="Delivered Date"  DataFormatString="{0:dd/MM/yyyy}" ItemStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Right" ItemStyle-ForeColor="Black" />
                                        <%--<asp:BoundField DataField="dtCancelledDate" HeaderText="Cancelled Date"  DataFormatString="{0:dd/MM/yyyy}" ItemStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Right" ItemStyle-ForeColor="Black" />--%>
                                        <asp:BoundField DataField="varStatus" HeaderText="Status"  ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Right" ItemStyle-ForeColor="Black" />


                                            <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdnOrderID" runat="server" Value='<%# Bind("nvrOrderID") %>' />

                                           </ItemTemplate>
                                            </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="70px" Visible="true">
                                            <ItemTemplate>
                                            <%--<asp:LinkButton ID="lnkViewDetails" Width="70px" Text="ViewDetails" CommandArgument='<%# Bind("nvrOrderID") %>' OnCommand="ClickButton" CommandName="ViewDetails"   OnClientClick="return confirm('Are you sure you want to view details?');" runat="server" Visible="false"></asp:LinkButton>--%>
                                                <%--<asp:LinkButton ID="LinkButton1" Width="60px" Text="Delete" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" OnCommand="ClickButton" CommandName="Delete_Me_Product"   OnClientClick="return confirm('Are you sure you want to delete?');" runat="server"></asp:LinkButton>--%>
                                                <%--<asp:ImageButton ID="btndelete"  ImageUrl="~/Images/ImgDelete.jpg"  runat="server"   CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" OnCommand="ClickButton" CommandName="Delete_Me_Order"   OnClientClick="return confirm('Are you sure you want to delete?');" Width ="55px" Height="35px" />--%> 
                                                <%--<asp:ImageButton ID="btndelete"  ImageUrl="~/Images/ImgDelete.jpg"  runat="server"   CommandArgument='<%# Bind("nvrOrderID") %>' OnCommand="ClickButton" CommandName="Delete_Me_Order"   OnClientClick="return confirm('Are you sure you want to delete?');" Width ="55px" Height="35px" />--%> 
                                                <asp:LinkButton ID="lnkDelete" Width="70px" Text="Cancel" CommandArgument='<%# Bind("nvrOrderID") %>' OnCommand="ClickButton" CommandName="Delete_Me_Order"   OnClientClick="return confirm('Are you sure you want to cancel?');" runat="server" Visible="true"></asp:LinkButton>
                    
                                            </ItemTemplate>
                                            <ItemStyle Width="20px" HorizontalAlign ="Center" />
                                        </asp:TemplateField> 
                                             
                                    </Columns>
                                </asp:GridView>
   
                            </td>
                        </tr>
                        
                    </table>                 
                                                          <table>
                        <tr>
                            <td align="center">
                                <asp:Label ID="Label1" align="center" runat="server" Text="Label" Visible="false" Font-Size="Large" Width="1160"  ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    
                </ContentTemplate> 


                </asp:UpdatePanel> 

              </div>
</asp:Content>

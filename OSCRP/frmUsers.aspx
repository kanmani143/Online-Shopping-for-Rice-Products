<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="frmUsers.aspx.cs" Inherits="OSCRP.frmUsers" %>
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
                    <asp:Label ID="lblRegistrationForm" runat="server" Text="User Maintenance" Font-Size="Large" ForeColor="#cc6699" Font-Names="viladimir script" Font-Bold="true" Font-Italic="" ></asp:Label>
                   
                </td>
                
            </tr>
                        <tr>

<%--                            <td style="vertical-align:top;" align="right">
                                
                                <asp:ImageButton ID="imgAdd"  ImageAlign ="AbsBottom" runat="server" ImageUrl ="~/Images/ImgAddNew.jpg"  Width="85px" Height="30px" ToolTip="CLICK HERE TO add new product!"  OnClientClick="return confirm('Are you sure you want to Add new product?');" OnClick="imgAdd_Click"   /> 
                            </td>--%>
                        </tr>
                                                <tr>

                            <td style="vertical-align:top;" align="right">
                                
                                <asp:ImageButton ID="imgUpdate"  ImageAlign ="AbsBottom" runat="server" ImageUrl ="~/Images/ImgSave.jpg"  Width="85px" Height="30px" ToolTip="CLICK HERE TO update!"  OnClientClick="return confirm('Are you sure you want to update?');" OnClick="imgUpdate_Click"   /> 
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                
                                <asp:GridView ID="grdUsers" runat="server" showfooter="True" autogeneratecolumns="False" EnableModelValidation="True" AllowPaging="True"
                                    Width="1152px"  BorderColor="#CCCCCC" BorderStyle="Solid" PagerStyle-BackColor="#D5D5BF" PageSize="8"
                                BorderWidth="1px" CellPadding="0" CellSpacing="0" 
                                    OnRowDataBound="grdUsers_RowDataBound" OnPageIndexChanging="grdUsers_PageIndexChanging" OnRowDeleting="grdUsers_RowDeleting" OnSelectedIndexChanged="grdUsers_SelectedIndexChanged" >
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
                                      
      
                                        <asp:BoundField DataField="UserId" HeaderText="User ID" ItemStyle-ForeColor="Black" />
                                        <asp:BoundField DataField="varFirstName" HeaderText="FirstName" ItemStyle-ForeColor="Black"   />
                                        <asp:BoundField DataField="nvrLastName" FooterText="" HeaderText="LastName" FooterStyle-Font-Bold="true" FooterStyle-ForeColor="#cc6699" ItemStyle-ForeColor="Black"/>
                                        <asp:BoundField DataField="nvrEmail" HeaderText="Email"  ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Right" ItemStyle-ForeColor="Black" />
                                        <asp:BoundField DataField="txtAddress" HeaderText="Address"  ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right" ItemStyle-ForeColor="Black" />
                                        <asp:BoundField DataField="nvrPinCode" FooterText="" HeaderText="Pin Code"  ItemStyle-HorizontalAlign="Left" FooterStyle-Font-Bold="true" FooterStyle-ForeColor="#cc6699" ItemStyle-ForeColor="Black"/>
                                        <asp:BoundField DataField="nvrPhone" HeaderText="Phone"  ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Right" ItemStyle-ForeColor="Black" />
                                        <asp:BoundField DataField="nvrWhatsAPP" HeaderText="WhatsApp"   ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Right" ItemStyle-ForeColor="Black" />
                                        <asp:BoundField DataField="Role" HeaderText="Role"   ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Right" ItemStyle-ForeColor="Black" />
                

                                            <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdnUserId" runat="server" Value='<%# Bind("UserId") %>' />

                                           </ItemTemplate>
                                            </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="50px" HeaderText="Active">
                                            <ItemTemplate>
                                            <%--<asp:LinkButton ID="lnkDelete" Width="60px" Text="Delete" CommandArgument='<%# Bind("nvrOrderID") %>' OnCommand="ClickButton" CommandName="Delete_Me_Order"   OnClientClick="return confirm('Are you sure you want to delete?');" runat="server"></asp:LinkButton>--%>
                                                <%--<asp:LinkButton ID="LinkButton1" Width="60px" Text="Delete" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" OnCommand="ClickButton" CommandName="Delete_Me_Product"   OnClientClick="return confirm('Are you sure you want to delete?');" runat="server"></asp:LinkButton>--%>
                                                <%--<asp:ImageButton ID="btndelete"  ImageUrl="~/Images/ImgDelete.jpg"  runat="server"   CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" OnCommand="ClickButton" CommandName="Delete_Me_Product"   OnClientClick="return confirm('Are you sure you want to delete?');" Width ="55px" Height="35px" />--%> 
                                                <asp:CheckBox ID="cbxActive" runat="server" Checked='<%# Bind("intActive") %>'/>
                                            </ItemTemplate>
                                            <ItemStyle Width="20px" HorizontalAlign ="Center" />
                                        </asp:TemplateField> 
                                             <asp:TemplateField ItemStyle-Width="50px" HeaderText="Deleted">
                                            <ItemTemplate>
                                                <%--<asp:LinkButton ID="lnkEdit" Width="60px" Text="Edit"  CommandArgument='<%# Bind("nvrOrderID") %>' OnCommand="ClickButton" CommandName="Edit_Me_Product"   OnClientClick="return true;" runat="server">Edit</asp:LinkButton>--%>
                                                <%--<asp:ImageButton ID="btnEdit"  ImageUrl="~/Images/ImgEdit.jpg"  runat="server"   CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" OnCommand="ClickButton" CommandName="Edit_Me_Product"   OnClientClick="return confirm('Are you sure you want to edit?');" Width ="55px" Height="35px" />--%> 
                                                <asp:CheckBox ID="cbxDelete" runat="server" Checked='<%# Bind("intIsDeleted") %>' />
                                            </ItemTemplate>
                                            <ItemStyle Width="50px" HorizontalAlign ="Center" />
                                        </asp:TemplateField> 
                                    </Columns>
                                </asp:GridView>
   
                            </td>
                        </tr>

                    </table>                 

                    
                </ContentTemplate> 


                </asp:UpdatePanel> 

              </div>
</asp:Content>

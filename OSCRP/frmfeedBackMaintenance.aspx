<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="frmfeedBackMaintenance.aspx.cs" Inherits="OSCRP.frmfeedBackMaintenance" %>
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
                    <asp:Label ID="lblRegistrationForm" runat="server" Text="Feedback Maintenance" Font-Size="Large" ForeColor="#cc6699" Font-Names="viladimir script" Font-Bold="true" Font-Italic="" ></asp:Label>
                   
                </td>
                
            </tr>
                        
                        <tr>
                            <td colspan="3">
                                
                                <asp:GridView ID="grdFeedbacks" runat="server" showfooter="True" autogeneratecolumns="False" EnableModelValidation="True" AllowPaging="True"
                                    Width="1152px"  BorderColor="#CCCCCC" BorderStyle="Solid" PagerStyle-BackColor="#D5D5BF" PageSize="8"
                                BorderWidth="1px" CellPadding="0" CellSpacing="0" 
                                    OnRowDataBound="grdFeedbacks_RowDataBound" OnPageIndexChanging="grdFeedbacks_PageIndexChanging"  OnSelectedIndexChanged="grdFeedbacks_SelectedIndexChanged" >
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
                                         <asp:BoundField DataField="UserName" HeaderText="Customer Name" ItemStyle-ForeColor="Black" />
                                        <asp:BoundField DataField="nvrSubject" FooterText="" HeaderText="Subject" FooterStyle-Font-Bold="true" FooterStyle-ForeColor="#cc6699" ItemStyle-ForeColor="Black"/>
                                        <asp:BoundField DataField="txtDescription" HeaderText="Feedback"  ItemStyle-HorizontalAlign="left" FooterStyle-HorizontalAlign="Right" ItemStyle-ForeColor="Black" />
                                        <asp:BoundField DataField="dtFeedBackDate" HeaderText="Feedback Date"  ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Right" ItemStyle-ForeColor="Black" />
                                        <asp:BoundField DataField="nvrActionTaken" HeaderText="Action Taken"  ItemStyle-HorizontalAlign="left" FooterStyle-HorizontalAlign="Right" ItemStyle-ForeColor="Black" />
                                        <asp:BoundField DataField="dtActionDate" HeaderText="Action Date"  ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Right" ItemStyle-ForeColor="Black" />
                                        <asp:BoundField DataField="nvrStatus" FooterText="" HeaderText="Status" FooterStyle-Font-Bold="true" FooterStyle-ForeColor="#cc6699" ItemStyle-ForeColor="Black"/>
                                             <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="FeedBackID" runat="server" Value='<%# Bind("FeedBackID") %>' />

                                           </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="UserID" runat="server" Value='<%# Bind("UserID") %>' />

                                           </ItemTemplate>
                                            </asp:TemplateField>
<%--                                        <asp:TemplateField ItemStyle-Width="50px">
                                            <ItemTemplate>
                                            <asp:LinkButton ID="lnkDelete" Width="60px" Text="Delete" CommandArgument='<%# Bind("FeedBackID") %>' OnCommand="ClickButton" CommandName="Delete_Me_Product"   OnClientClick="return confirm('Are you sure you want to delete?');" runat="server" Visible="false"></asp:LinkButton>
                   
                                            </ItemTemplate>
                                            <ItemStyle Width="20px" HorizontalAlign ="Center" />
                                        </asp:TemplateField> --%>
                                             <asp:TemplateField >
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkEdit" Width="60px" Text="Edit"  CommandArgument='<%# Bind("FeedBackID") %>' OnCommand="ClickButton" CommandName="Edit_Me_Feedback"   OnClientClick="return true;" runat="server">Edit</asp:LinkButton>
                                                <%--<asp:ImageButton ID="btnEdit"  ImageUrl="~/Images/ImgEdit.jpg"  runat="server"   CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" OnCommand="ClickButton" CommandName="Edit_Me_Product"   OnClientClick="return confirm('Are you sure you want to edit?');" Width ="55px" Height="35px" />--%> 
                    
                                            </ItemTemplate>
                                            <ItemStyle Width="20px" HorizontalAlign ="Center" />
                                        </asp:TemplateField> 
                                    </Columns>
                                </asp:GridView>
   
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="clear: both;" runat="server" id="dvDataEntry"  visible="false">
          
            <div style="position: relative; float: left; width: auto;top: 0px; right: -50px; ">

  
<asp:Panel ID="pnlMain" runat="server"  Height="1165px" Width="1100px">
    <div align="center">
        <table style="width: 43%; ">
            <tr>
                <td colspan="2" align="center">
                    <asp:Label ID="lblDataEntry" runat="server" Text="Data Entry" Font-Size="Large" ForeColor="#cc6699" Font-Names="viladimir script" Font-Bold="true" Font-Italic="" ></asp:Label>
                   
                </td>
                
            </tr>
            <tr>
                <td>

                </td>
                 <td>

                </td>
            </tr>
            <tr>
                <td>

                    <asp:Label ID="lblAction" runat="server" Text="Action :" Font-Size="Medium" ForeColor="Black" Font-Names="viladimir script"></asp:Label>
                   
                </td>
                <td>

                    <asp:TextBox ID="txtActionTaken" runat="server" Font-Size="Medium" ForeColor="Black" Width="500px" Height="300px"  TextMode="MultiLine"></asp:TextBox>

                  
                </td>
            </tr>

            <tr>
                <td>
                    
                        <br />
                    
                </td>
                <td>
                    <br />
                        <asp:ImageButton ID="btnSave" runat="server" Height="30px" ImageUrl="~/Images/imgSave.jpg" OnClick="btnSave_Click" ToolTip="CLICK HERE TO SAVE!" Width="85px" />
                        <asp:ImageButton ID="btnCancel" runat="server" ImageUrl ="~/Images/btnCancel.jpg"   Width="85px" Height="30px" ToolTip="CLICK HERE TO CANCEL!" OnClick="btnCancel_Click"  />
                     

                </td>
            </tr>
            <tr>
                <td>
                    
                        <br />
   <asp:Label ID="lblError" runat="server" Text="                       "   Font-Size="Medium" ForeColor="Red" Font-Names="viladimir script" Visible="false"></asp:Label>
                    
                </td>
                <td>
    
                     

                </td>
            </tr>
        </table>
    </div>

                </asp:Panel>
            </div>
        </div>

                            </td>
                        </tr>
                    </table>                 

                    
                </ContentTemplate> 

                </asp:UpdatePanel> 

              </div>
</asp:Content>

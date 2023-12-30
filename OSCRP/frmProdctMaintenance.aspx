<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="frmProdctMaintenance.aspx.cs" Inherits="OSCRP.frmProdctMaintenance" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" >
        //var prntData = document.getElementById('<%=Invoice.ClientID%>');
        document.getElementById('<%=imgflUpload.ClientID%>').onchange = uploadOnChange;

        function uploadOnChange() {

            var filename = document.getElementById('<%=imgflUpload.ClientID%>').value;
            
            var lastIndex = filename.lastIndexOf("\\");
            if (lastIndex >= 0) {
                filename = filename.substring(lastIndex + 1);
            }
            document.getElementById('<%=txtFile.ClientID%>').value = filename;
        }
        function Popup(url) {
            url = "frmImageWindow.aspx?ImageUrl=" + url;
            window.open(url, "Image Window", "status = 1, height = 390, width = 457, resizable = 0")
        }
        
            function PopupDDLValue(lblname) {
                url = "frmAddDDLValue.aspx?lblname=" + lblname;
            window.open(url, "Image Window", "status = 1, height = 390, width = 457, resizable = 0")
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

        function isInteger(evt, obj) {
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
                return false;
            }
            else if (charCode > 31 && (charCode < 48 || charCode > 57)) return false;
            else {
                document.getElementById('ctl00_ContentPlaceHolder1_lblTotalQty').value = val.val;
                return true;
            }


        }
    </script>
    <style type="text/css">
        .auto-style4 {
            margin-left: 0px;
        }
          .FluCntrl1
      {
       background-color:White;
       color: Blue;
       border: 1px solid Gray;
       font: Arial 10px;
       padding: 1px 4px;
       font-family: Arial, Palatino Linotype,  Helvetica, sans-serif;
       
      }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <div style="position: relative; float: left; width: 1165px; top: 0px; right: -50px; text-align:left;">
              <br />
              <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
              
                <ContentTemplate>
   
                    <table id="Invoice" style="width:1165px;border: none;height:200px;" runat="server" >
                           <tr>
                <td colspan="2" align="center">
                    <asp:Label ID="lblRegistrationForm" runat="server" Text="Product Maintenance" Font-Size="Large" ForeColor="#cc6699" Font-Names="viladimir script" Font-Bold="true" Font-Italic="" ></asp:Label>
                   
                </td>
                
            </tr>
                        <tr>

                            <td style="vertical-align:top;" align="right">
                                
                                <asp:ImageButton ID="imgAdd"  ImageAlign ="AbsBottom" runat="server" ImageUrl ="~/Images/ImgAddNew.jpg"  Width="85px" Height="30px" ToolTip="CLICK HERE TO add new product!"  OnClientClick="return confirm('Are you sure you want to Add new product?');" OnClick="imgAdd_Click"   /> 
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                
                                <asp:GridView ID="grdProducts" runat="server" showfooter="True" autogeneratecolumns="False" EnableModelValidation="True" AllowPaging="True"
                                    Width="1152px"  BorderColor="#CCCCCC" BorderStyle="Solid" PagerStyle-BackColor="#D5D5BF" PageSize="8"
                                BorderWidth="1px" CellPadding="0" CellSpacing="0" 
                                    OnRowDataBound="grdProducts_RowDataBound" OnPageIndexChanging="grdProducts_PageIndexChanging" OnRowDeleting="grdProducts_RowDeleting" OnSelectedIndexChanged="grdProducts_SelectedIndexChanged" >
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
                                         <asp:BoundField DataField="nvrPrdName" HeaderText="Product Name" ItemStyle-ForeColor="Black" />
                                        <asp:BoundField DataField="decPrice" FooterText="" HeaderText="Price" FooterStyle-Font-Bold="true" FooterStyle-ForeColor="#cc6699" ItemStyle-ForeColor="Black"/>
                                        <asp:BoundField DataField="nvrUOM" HeaderText="UOM"  ItemStyle-HorizontalAlign="left" FooterStyle-HorizontalAlign="Right" ItemStyle-ForeColor="Black" />
                                        <asp:BoundField DataField="intUnit" HeaderText="Unit"  ItemStyle-HorizontalAlign="left" FooterStyle-HorizontalAlign="Right" ItemStyle-ForeColor="Black" />
                                        <asp:BoundField DataField="decWSprice" FooterText="" HeaderText="WS Price" FooterStyle-Font-Bold="true" FooterStyle-ForeColor="#cc6699" ItemStyle-ForeColor="Black"/>
                                        <asp:BoundField DataField="Title" HeaderText="Title"  ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Right" ItemStyle-ForeColor="Black" />
                                             <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdnProdLocation" runat="server" Value='<%# Bind("nvrPrdLocation") %>' />

                                           </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdnPrdNo" runat="server" Value='<%# Bind("nvrPrdNo") %>' />

                                           </ItemTemplate>
                                            </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="50px">
                                            <ItemTemplate>
                                            <asp:LinkButton ID="lnkDelete" Width="60px" Text="Delete" CommandArgument='<%# Bind("nvrPrdNo") %>' OnCommand="ClickButton" CommandName="Delete_Me_Product"   OnClientClick="return confirm('Are you sure you want to delete?');" runat="server"></asp:LinkButton>
                                                <%--<asp:LinkButton ID="LinkButton1" Width="60px" Text="Delete" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" OnCommand="ClickButton" CommandName="Delete_Me_Product"   OnClientClick="return confirm('Are you sure you want to delete?');" runat="server"></asp:LinkButton>--%>
                                                <%--<asp:ImageButton ID="btndelete"  ImageUrl="~/Images/ImgDelete.jpg"  runat="server"   CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" OnCommand="ClickButton" CommandName="Delete_Me_Product"   OnClientClick="return confirm('Are you sure you want to delete?');" Width ="55px" Height="35px" />--%> 
                    
                                            </ItemTemplate>
                                            <ItemStyle Width="20px" HorizontalAlign ="Center" />
                                        </asp:TemplateField> 
                                             <asp:TemplateField >
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkEdit" Width="60px" Text="Edit"  CommandArgument='<%# Bind("nvrPrdNo") %>' OnCommand="ClickButton" CommandName="Edit_Me_Product"   OnClientClick="return true;" runat="server">Edit</asp:LinkButton>
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

                    <asp:Label ID="lblProdName" runat="server" Text="Product Name :" Font-Size="Medium" ForeColor="Black" Font-Names="viladimir script"></asp:Label>
                   
                </td>
                <td>
                    <asp:DropDownList ID="ddlProdName" runat="server" Width="300px" ></asp:DropDownList>
                    <asp:ImageButton ID="ImgProdNameAdd" runat="server" ImageUrl ="~/Images/imgAdd.jpg"   Width="20px" Height="20px" ToolTip="CLICK HERE TO ADD!" ImageAlign="AbsBottom" OnClick="ImgProdNameAdd_Click" />
                    <asp:TextBox ID="txtProdName" runat="server" Font-Size="Medium" ForeColor="Black" Width="300px" Visible="false"></asp:TextBox>
                    <asp:ImageButton ID="ImgProdNameSave" runat="server" ImageUrl ="~/Images/ImgDDLSave.jpg"   Width="20px" Height="20px" ToolTip="CLICK HERE TO SAVE!" ImageAlign="AbsBottom" Visible="false" OnClick="ImgProdNameSave_Click" />
                  
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblImage" runat="server" Text="Image :" Font-Size="Medium" ForeColor="Black" Font-Names="viladimir script"></asp:Label>
                   
                </td>
                <td>
                    <span><asp:TextBox ID="txtFile" runat="server" Font-Size="Medium" ForeColor="Black"></asp:TextBox>
                    <asp:FileUpload ID="imgflUpload" runat="server" ForeColor="White"  CssClass="auto-style4" Width="84px" onchange = "uploadOnChange();" /></span>
<%--                    <asp:FileUpload ID="fluplReviewer" runat="server" Font-Names="Arial" 
                            Font-Size="Small" ForeColor="#000099" Width="526px" Height="22px" CssClass="FluCntrl1" />--%>
                  
                </td>
            </tr>
                        <tr>
                <td>
                    <asp:Label ID="lblPrice" runat="server" Text="Price :" Font-Size="Medium" ForeColor="Black" Font-Names="viladimir script"></asp:Label>
                   
                </td>
                <td>
                    <asp:TextBox ID="txtPrice" runat="server"  Font-Size="Medium" ForeColor="Black" onkeypress="return isNumber(event,this)"></asp:TextBox>
                  
                </td>
            </tr>
                                    <tr>
                <td>
                    <asp:Label ID="lblUOM" runat="server" Text="UOM :" Font-Size="Medium" ForeColor="Black" Font-Names="viladimir script"></asp:Label>
                   
                </td>
                <td>
                    <asp:TextBox ID="txtUOM" runat="server"  Font-Size="Medium" ForeColor="Black" TextMode ="SingleLine"></asp:TextBox>
                  
                </td>
            </tr>
                                                <tr>
                <td>
                    <asp:Label ID="lblUnit" runat="server" Text="Unit :" Font-Size="Medium" ForeColor="Black" Font-Names="viladimir script"></asp:Label>
                   
                </td>
                <td>
                    <asp:TextBox ID="txtUnit" runat="server"  Font-Size="Medium" ForeColor="Black" onkeypress="return isInteger(event,this)"></asp:TextBox>
                  
                </td>
            </tr>
                                                <tr>
                <td>
                    <asp:Label ID="lblWSPrice" runat="server" Text="WS Price :" Font-Size="Medium" ForeColor="Black" Font-Names="viladimir script"></asp:Label>
                   
                </td>
                <td>
                    <asp:TextBox ID="txtWSPrice" runat="server"  Font-Size="Medium" ForeColor="Black" onkeypress="return isNumber(event,this)"></asp:TextBox>
                  
                </td>
            </tr>
                                                            <tr>
                <td>
                    
                    <asp:Label ID="lblProdType" runat="server" Text="Product Type :" Font-Size="Medium" ForeColor="Black" Font-Names="viladimir script"></asp:Label>
                   
                </td>
                <td>
                    <asp:DropDownList ID="ddlProdType" runat="server" Width="300px"></asp:DropDownList>
                    <asp:ImageButton ID="ImgProdTypeAdd" runat="server" ImageUrl ="~/Images/imgAdd.jpg"   Width="20px" Height="20px" ToolTip="CLICK HERE TO ADD!" ImageAlign="AbsBottom" OnClick="ImgProdTypeAdd_Click" />
                    <asp:TextBox ID="txtProdType" runat="server" Font-Size="Medium" ForeColor="Black" Width="300px" Visible="false"></asp:TextBox>
                    <asp:ImageButton ID="ImgProdTypeSave" runat="server" ImageUrl ="~/Images/ImgDDLSave.jpg"   Width="20px" Height="20px" ToolTip="CLICK HERE TO SAVE!" ImageAlign="AbsBottom" Visible="false" OnClick="ImgProdTypeSave_Click"  />
                  
                    <%--<asp:TextBox ID="txtWhatsApp" runat="server"  Font-Size="Medium" ForeColor="Black"></asp:TextBox>--%>
                  
                </td>
            </tr>
                                                                        <tr>
                <td>
                    <asp:Label ID="lblTitle" runat="server" Text="Title :"   Font-Size="Medium" ForeColor="Black" Font-Names="viladimir script"></asp:Label>
                   
                </td>
                <td>
                    <asp:DropDownList ID="ddlTitle" runat="server" Width="300px"></asp:DropDownList>
                    <asp:ImageButton ID="ImgTitleAdd" runat="server" ImageUrl ="~/Images/imgAdd.jpg"   Width="20px" Height="20px" ToolTip="CLICK HERE TO ADD!" ImageAlign="AbsBottom" OnClick="ImgTitleAdd_Click" />
                    <%--<asp:TextBox ID="txtPassword" runat="server"  Font-Size="Medium" TextMode="Password" ForeColor="Black"></asp:TextBox>--%>
                    <asp:TextBox ID="txtTitle" runat="server" Font-Size="Medium" ForeColor="Black" Width="300px" Visible="false"></asp:TextBox>
                    <asp:ImageButton ID="ImgTitleSave" runat="server" ImageUrl ="~/Images/ImgDDLSave.jpg"   Width="20px" Height="20px" ToolTip="CLICK HERE TO SAVE!" ImageAlign="AbsBottom" Visible="false" OnClick="ImgTitleSave_Click"  />
                  
                </td>
            </tr>
                                                                                    <tr>
                <td>
                    <asp:Label ID="lblDescription" runat="server" Text="Description :"   Font-Size="Medium" ForeColor="Black" Font-Names="viladimir script"></asp:Label>
                   
                </td>
                <td>
                    <asp:TextBox ID="txtDescription" runat="server" Width="300px" Height="100px" Font-Size="Medium"  ForeColor="Black" TextMode="MultiLine"></asp:TextBox>
                  
                </td>
            </tr>
            <tr>
                <td>

                        
                    
                </td>
                <td>
                     <br />
                        <asp:ImageButton ID="btnSave" runat="server" ImageUrl ="~/Images/imgSave.jpg"   Width="85px" Height="30px" ToolTip="CLICK HERE TO SAVE!" OnClick="btnSave_Click" />
                    <asp:ImageButton ID="btnCancel" runat="server" ImageUrl ="~/Images/btnCancelNew.jpg"   Width="85px" Height="30px" ToolTip="CLICK HERE TO CANCEL!" OnClick="btnCancel_Click"    />
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

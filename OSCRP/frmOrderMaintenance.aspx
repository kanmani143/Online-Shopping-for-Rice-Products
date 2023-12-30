<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="frmOrderMaintenance.aspx.cs" Inherits="OSCRP.frmOrderMaintenance" %>

<%@ Register Src="~/ucCalendar.ascx" TagPrefix="uc1" TagName="ucCalendar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <%--<script src="js/jquery-1.4.1.min.js" type="text/javascript"></script>--%>
<%--<script src="js/jquery.dynDateTime.min.js" type="text/javascript"></script>--%>
<%--<script src="js/calendar-en.min.js" type="text/javascript"></script>--%>
<%--<link href="css/calendar-blue.css" rel="stylesheet" type="text/css" />--%>
    <link href="style/jquery-ui.css" rel="stylesheet" />  
<script src="script/jquery-1.11.3.min.js"></script>  
<script src="script/jquery-ui.js"></script> 

    <script>  
        $(function () {
               $("#<%=txtDepartureDate.ClientID %>").datepicker(
                {
                    dateFormat: 'dd/mm/yy',
                    changeMonth: true,
                    changeYear: true,
                    yearRange: '1950:2100'
                });
        })
    </script>  
<script type="text/javascript">
<%--    $(document).ready(function () {
        $("#<%=txtDepartureDate.ClientID %>").dynDateTime({
            showsTime: true,
            ifFormat: "%Y/%m/%d %H:%M",
            daFormat: "%l;%M %p, %e %m, %Y",
            align: "BR",
            electric: false,
            singleClick: false,
            displayArea: ".siblings('.dtcDisplayArea')",
            button: ".next()"
        });

    });--%>
</script>
        <script type="text/javascript" >
           
        function Popup(url) {
            url = "frmImageWindow.aspx?ImageUrl=" + url;
            window.open(url, "Image Window", "status = 1, height = 390, width = 457, resizable = 0")
            }
            function CalendarPopup()
            {
                //alert("Calendar Clicked");
                url = "frmCalendar.aspx?";
                window.open(url, "Image Window", "status = 1, height = 200, width = 270, resizable = 0,screenX=150,left=550,screenY=150,top=550,status=yes,menubar=no")
                var prntData = document.getElementById('<%=txtDepartureDate.ClientID%>');
                
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
<%--        <script language="javascript" src=Calendar.js type="text/javascript"></script>
    <link href=Calendar.css rel="stylesheet" type="text/css"> --%>
    <script language="javascript" type="text/javascript">
        function showCalendarControl1(PostedOn)
        {
            alert("test");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div style="position: relative; float: left; width: 1165px; top: 0px; right: -50px; text-align:left;">
              <br />
              <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
              
                <ContentTemplate>
                    
   
                    <table id="Invoice" style="width:1165px;border: none;height:200px;" runat="server" >
                           <tr>
                <td colspan="2" align="center">
                    <asp:Label ID="lblRegistrationForm" runat="server" Text="Order Maintenance" Font-Size="Large" ForeColor="#cc6699" Font-Names="viladimir script" Font-Bold="true" Font-Italic="" ></asp:Label>
                   
                </td>
                
            </tr>
                        <tr>

<%--                            <td style="vertical-align:top;" align="right">
                                
                                <asp:ImageButton ID="imgAdd"  ImageAlign ="AbsBottom" runat="server" ImageUrl ="~/Images/ImgAddNew.jpg"  Width="85px" Height="30px" ToolTip="CLICK HERE TO add new product!"  OnClientClick="return confirm('Are you sure you want to Add new product?');" OnClick="imgAdd_Click"   /> 
                            </td>--%>
                        </tr>
                        <tr>
                            <td colspan="3">
                                
                                <asp:GridView ID="grdOrders" runat="server" showfooter="True" autogeneratecolumns="False" EnableModelValidation="True" AllowPaging="True"
                                    Width="1152px"  BorderColor="#CCCCCC" BorderStyle="Solid" PagerStyle-BackColor="#D5D5BF" PageSize="8"
                                BorderWidth="1px" CellPadding="0" CellSpacing="0" 
                                    OnRowDataBound="grdOrders_RowDataBound" OnPageIndexChanging="grdOrders_PageIndexChanging" OnRowDeleting="grdOrders_RowDeleting" OnSelectedIndexChanged="grdOrders_SelectedIndexChanged" >
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
                                        <asp:BoundField DataField="dtCancelledDate" HeaderText="Cancelled Date"  DataFormatString="{0:dd/MM/yyyy}" ItemStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Right" ItemStyle-ForeColor="Black" />
                                        <asp:BoundField DataField="varStatus" HeaderText="Status"  ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Right" ItemStyle-ForeColor="Black" />


                                            <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdnOrderID" runat="server" Value='<%# Bind("nvrOrderID") %>' />

                                           </ItemTemplate>
                                            </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="50px">
                                            <ItemTemplate>
                                            <asp:LinkButton ID="lnkDelete" Width="60px" Text="Delete" CommandArgument='<%# Bind("nvrOrderID") %>' OnCommand="ClickButton" CommandName="Delete_Me_Order"   OnClientClick="return confirm('Are you sure you want to delete?');" runat="server"></asp:LinkButton>
                                                <%--<asp:LinkButton ID="LinkButton1" Width="60px" Text="Delete" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" OnCommand="ClickButton" CommandName="Delete_Me_Product"   OnClientClick="return confirm('Are you sure you want to delete?');" runat="server"></asp:LinkButton>--%>
                                                <%--<asp:ImageButton ID="btndelete"  ImageUrl="~/Images/ImgDelete.jpg"  runat="server"   CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" OnCommand="ClickButton" CommandName="Delete_Me_Product"   OnClientClick="return confirm('Are you sure you want to delete?');" Width ="55px" Height="35px" />--%> 
                    
                                            </ItemTemplate>
                                            <ItemStyle Width="20px" HorizontalAlign ="Center" />
                                        </asp:TemplateField> 
                                             <asp:TemplateField >
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkEdit" Width="60px" Text="Edit"  CommandArgument='<%# Bind("nvrOrderID") %>' OnCommand="ClickButton" CommandName="Edit_Me_Product"   OnClientClick="return true;" runat="server">Edit</asp:LinkButton>
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
                <td colspan="3" align="center">
                    <asp:Label ID="lblDataEntry" runat="server" Text="Data Entry" Font-Size="Large" ForeColor="#cc6699" Font-Names="viladimir script" Font-Bold="true" Font-Italic="" ></asp:Label>
                   
                </td>

            </tr>
            <tr>
                <td>
                    <%--<asp:Label ID="lblDateSent" runat="server" Text="Posted on:" CssClass="graytextbold"></asp:Label>--%>
        
                </td>
                 <td>
                     <%--<input ID="PostedOn" runat="server" class="NormalTextBox" readonly="readOnly" type="text" />&nbsp;<a onclick="showCalendarControl1(PostedOn);" href="#"><img src=calendar.gif style="width: 20px; height: 20px" border=0 /></a>--%>
                </td>
                                 <td>

                </td>
            </tr>
            <tr>
              <td align="left" bgcolor="White" class="style191">
                        <asp:Label ID="lblDepartureDate" runat="server" CssClass="lblcaption" 
                            Font-Bold="False" Text="Departure Date:"></asp:Label>
                  <%--<asp:Label ID="lblDateSent" runat="server" Text="Posted on:" CssClass="graytextbold"></asp:Label>
        <input ID="PostedOn" runat="server" class="NormalTextBox" readonly="readOnly" type="text" />&nbsp;<a onclick="showCalendarControl(ctl00_ContentPlaceHolder1_PostedOn)" href="#"><img src="calendar.gif" style="width: 20px; height: 20px" border=0 /></a>--%>

                    </td>
                    <td align="left" bgcolor="White" class="style234">
                        <asp:TextBox ID="txtDepartureDate" runat="server" BorderStyle="Inset" 
                            Height="15px" Width="102px " Visible="true"></asp:TextBox>
                        &nbsp;<a onclick="showCalendarControl(ctl00_ContentPlaceHolder1_txtDepartureDate)" href="#"><img src="calendar.gif" align="center" style="width: 20px; height: 20px;" border=0 /></a>
                        
  
                        <%--<asp:ImageButton ID="ImgCalender" ImageAlign="AbsMiddle" runat="server" ImageUrl="~/Images/calendar_icon.png" style="height: 18px; " Width="18px" Visible="true" OnClick="ImgCalender_Click"   />--%>
                        
                        
                        

                    </td>
                <td>
                    <%--<asp:Calendar ID="calDeparture" Visible="false" runat="server" style="align-items:inherit;" OnSelectionChanged="calDeparture_SelectionChanged"  ></asp:Calendar>--%> 
                </td>
            </tr>
                        <tr>
              <td align="left" bgcolor="White" class="style191">
                        <asp:Label ID="lblDeliveredDate" runat="server" CssClass="lblcaption" 
                            Font-Bold="False" Text="Delivered Date:"></asp:Label>
                                 <%--<asp:Label ID="Label1" runat="server" Text="Posted on:" CssClass="graytextbold"></asp:Label>
        <input ID="PostedOn1" runat="server" class="NormalTextBox" readonly="readOnly" type="text" />&nbsp;<a onclick="showCalendarControl(ctl00_ContentPlaceHolder1_PostedOn1)" href="#"><img src="calendar.gif" style="width: 20px; height: 20px" border=0 /></a>--%>


                    </td>
                    <td align="left" bgcolor="White" class="style234">
                        <asp:TextBox ID="txtDeliveredDate" runat="server" BorderStyle="Inset" 
                            Height="15px" Width="102px " Visible="true"></asp:TextBox>
                        &nbsp;<a onclick="showCalendarControl(ctl00_ContentPlaceHolder1_txtDeliveredDate)" href="#"><img src="calendar.gif" align="center" style="width: 20px; height: 20px; "  border=0 /></a>

                        <%--<asp:ImageButton ID="ImageCalendarDel" ImageAlign="AbsMiddle" runat="server" ImageUrl="~/Images/calendar_icon.png" style="height: 18px; " Width="18px" Visible="true" OnClick="ImageCalendarDel_Click"   />--%>
                        
                        
                        

                    </td>
                <td>
                    <%--<asp:Calendar ID="DeliveredCalendar" Visible="false" runat="server" style="align-items:inherit;" OnSelectionChanged="DeliveredCalendar_SelectionChanged"  ></asp:Calendar>--%> 
                </td>
            </tr>
            <tr>
                <td>
                    
 
                    
                </td>
                <td>
                                            <br />
                        <asp:ImageButton ID="btnSave" runat="server" ImageUrl ="~/Images/imgSave.jpg"   Width="85px" Height="30px" ToolTip="CLICK HERE TO SAVE!" OnClick="btnSave_Click"  />
  <asp:ImageButton ID="btnClose" runat="server" ImageUrl ="~/Images/btnClose.jpg"   Width="85px" Height="30px" ToolTip="CLICK HERE TO Close!" OnClick="btnClose_Click"    />
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

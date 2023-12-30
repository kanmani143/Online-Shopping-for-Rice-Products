<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmImageUpload.aspx.cs" Inherits="HaiSia.frmImageUpload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script src="js/jquery-1.7.min.js" type="text/javascript"></script>


   
    <link href="css/style.css" rel="stylesheet" type="text/css" />

    <link rel="stylesheet" href="css/jquery-ui.css" />

    <script type="text/javascript" src="js/jquery-1.10.2.js"></script>

    <script type="text/javascript" src="js/jquery-ui.js"></script>
    <script type="text/javascript">  
    function Popup1(url) {           
                window.open(url, "Image Window", "status = 1, height = 250, width = 300, resizable = 0")
            }

            function Popup(url) {
                url = "frmImageWindow.aspx?ImageUrl=" + url;
                window.open(url, "Image Window", "status = 1, height = 390, width = 457, resizable = 0")
            }

            function browse(Id) {

                Id.click();
                
            }
          
</script>
<style type="text/css">
	.fileStyle { position:absolute; top:-200px;}
	
	.buttonClass {}
	.test {}
</style>

<script type="text/javascript">
    function OpenDialogueBox(elm) {
        
        var myHdnVar = document.getElementById(elm);

        myHdnVar.click();
        
    }

    $(document).ready(function() {
        $(".buttonClass").click(function() {
            $(".fileStyle").click();
        });
    });
            
</script>

</head>
<body style="font-family: Sans-Serif;">
    <form id="form1" runat="server">
    <div style="clear: both;">
    <div style="position: relative; float: left; width: auto ;">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
            <div style="clear: both;">

            <%--<div style="position: relative; float: left; width: 300px;">--%>
                <div style="position: relative; float: left; width: 550px; top: 0px; right: -50px; text-align:left;" >
                <table style="width: 100%;" >
                    <tr>
              
                        <td >
                          <asp:Image ID="imgLogo" runat="server" ImageUrl="~/Images/HaiSiabanner3.jpg" 
                                Height="150px"  Width ="1200px"/> 
                                
                        </td>
                       
                    </tr>
                    
                </table>
            </div>
        </div>

        <div style="clear: both;">
            
            <div style="position: relative; float: left; width: 550px; top: 0px; right: -50px; text-align:left;">
                 <asp:Label ID="lblCustomer" runat="server" Text="User" 
                     Width="800px" ForeColor ="Black" Font-Size="X-Large" Font-Bold="true"  ></asp:Label>
                <br />
                <br />
              </div></div>
              <div style="clear: both;">
              <div style="position: relative; float: left; width: 1100px; top: 0px; right: -50px; text-align:left;">
              
              <asp:LinkButton ID="lnkHome" runat="server" onclick="lnkHome_Click"  Font-Size="XX-Large" Width ="100px" >Home</asp:LinkButton>
                               
                <asp:LinkButton ID="CCDT" runat="server"  Font-Size="XX-Large" Width ="210px" 
                      onclick="CCDT_Click" >CC DateTime</asp:LinkButton>
                          
                    <asp:LinkButton ID="lnkLogout" runat="server" onclick="lnkLogout_Click" Font-Size="XX-Large" Width ="120px" >Logout</asp:LinkButton>
                 
                 
          
            </div>
                 
          
           
                     
        </div>
          <div style="clear: both;">
        <div style="position: relative; float: left; width: auto;top: 0px; right: -50px; ">
        <br />
          <table  frame="void" >
        	<tr align="center" >
		<%--<td width="1235" height="1" colspan="3" align ="left"  >--%>
			<%--<img src="images/08.jpg" height="174" alt="" align="left"  
                style="width: 1235px">--%><%--</td>--%>
                
                     <td width="1200" height="1" colspan="3" align ="center" 
                    style="background-color:#3FA902; color:White;font-family: Arial; font-size: small;">
                      </td>                
	</tr>
	</table>
        </div>
        </div>
                   <br />
                   <br />
                  <%-- <div style="position: relative; float: right; width: 340px; top: 0px; left: -86px; background-color:LightGoldenrodYellow; border-color:Black; border-style:solid ">
                <asp:Label ID="lblTotItem" runat="server" Text="Total Item"  Width="100px" Font-Size="Small"></asp:Label>
                <asp:Label ID="lblTotQty" runat="server" Text="Collection Date : 23 March 2015"  Width="100px" Font-Size="Small"></asp:Label>
                <asp:Label ID="lblTotPrice" runat="server" Text="Collection Date : 23 March 2015"  Width="120px" Font-Size="Small"></asp:Label> </div>--%>
                      
           <br />
        <div style="clear: both;">
                <div style="position: relative; text-align:center; width: auto; right: -50px;">
            
                <asp:Label ID="Label1" runat="server" Text="Image Maintenance"  Width="445px" Font-Size="XX-Large" ForeColor="White"  BackColor ="DarkGoldenrod"   ></asp:Label>
                </div>
                 
                  <br />
                  <br />   
                   <div style="position: relative; text-align:left; width: auto; right: -50px;">
            
                <asp:Label ID="Label2" runat="server" Text="Image Index  : "   Font-Size="XX-Large" ForeColor="Blue" ></asp:Label>
                <asp:DropDownList ID="dpdImgIndex" runat="server" Font-Size="XX-Large" 
                           ForeColor="Blue" onselectedindexchanged="dpdImgIndex_SelectedIndexChanged" AutoPostBack ="true" >
                            <asp:ListItem>ALL</asp:ListItem>
                    <asp:ListItem>A</asp:ListItem>
                    <asp:ListItem>B</asp:ListItem>
                    <asp:ListItem>C</asp:ListItem>
                    <asp:ListItem>D</asp:ListItem>
                    <asp:ListItem>E</asp:ListItem>
                    <asp:ListItem>F</asp:ListItem>
                    <asp:ListItem>G</asp:ListItem>
                    <asp:ListItem>H</asp:ListItem>
                    <asp:ListItem>I</asp:ListItem>
                    <asp:ListItem>J</asp:ListItem>
                    <asp:ListItem>K</asp:ListItem>
                    <asp:ListItem>L</asp:ListItem>
                    <asp:ListItem>M</asp:ListItem>
                    <asp:ListItem>N</asp:ListItem>
                    <asp:ListItem>O</asp:ListItem>
                    <asp:ListItem>P</asp:ListItem>
                    <asp:ListItem>Q</asp:ListItem>
                    <asp:ListItem>R</asp:ListItem>
                    <asp:ListItem>S</asp:ListItem>
                    <asp:ListItem>T</asp:ListItem>
                    <asp:ListItem>U</asp:ListItem>
                    <asp:ListItem>V</asp:ListItem>
                    <asp:ListItem>W</asp:ListItem>
                    <asp:ListItem>X</asp:ListItem>
                    <asp:ListItem>Y</asp:ListItem>
                    <asp:ListItem>Z</asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="Label4" runat="server" Text="/"   Font-Size="XX-Large" ForeColor="Red"  Width ="50px" CssClass="textalignright"  ></asp:Label>
                <asp:Label ID="Label3" runat="server" Text="Like : "   Font-Size="XX-Large" ForeColor="Blue"  Width ="120px" CssClass="textalignright"  ></asp:Label>
                      &nbsp;
                       <asp:TextBox ID="txtLike" runat="server" Font-Size="XX-Large" ForeColor="Blue" Width ="400px" ></asp:TextBox>
                        
                       <asp:ImageButton ID="imgbLike" runat="server" 
                           ImageUrl="~/Images/ImgSearch1.jpg" Height="60px" ImageAlign="Middle"  
                           onclick="imgbLike_Click"     />
                </div> 
        </div>
            
        <div style="clear: both;">
          
            <div style="position: relative; float: left; width: auto; right: -50px;">
            <br />
  
                <asp:Panel ID="pnlMain" runat="server" ScrollBars="Vertical" Height="1200px">
                   <asp:UpdatePanel  runat="server" ID="upMain" UpdateMode="Always"     >
                                    <ContentTemplate>
                                    <asp:GridView ID="grdvwImage" runat="server"  
                                    AutoGenerateColumns="False" BorderColor="#CCCCCC" BorderStyle="Solid" 
                                    BorderWidth="1px"   OnPageIndexChanging="grdvwImage_PageIndexChanging"
                                     OnRowDataBound ="grdvwImage_OnRowDataBound"  
                                      onrowcancelingedit="grdvwImage_RowCancelingEdit"
                                      onrowdeleting="grdvwImage_RowDeleting" onrowediting="grdvwImage_RowEditing"
                                    onrowupdating="grdvwImage_RowUpdating" maintainscrollpositiononpostback="true"
                                         ShowHeaderWhenEmpty="true"
                                     CellPadding="5" Width="1180px">
                                    <AlternatingRowStyle BackColor="White" ForeColor="Black" Font-Size="X-Large" />
                            
                                
                                    <HeaderStyle BackColor="LightBlue" 
                                        Font-Size="X-Large" ForeColor="Black"  Font-Bold="true"  Height ="14px" />
                                    
                                    <RowStyle BackColor="White" Font-Size="X-Large" ForeColor="Black" 
                                        Height="24px" />
                                    <Columns>
                                 
                                        <asp:TemplateField HeaderText="SNo" >
                                            <ItemTemplate>
                                                <span>
                                                    <%#Container.DataItemIndex + 1%>
                                                </span>
                                            </ItemTemplate>

                                            <ItemStyle Width="30px"></ItemStyle>
                                        </asp:TemplateField>
                                    
                                
                                        <%--<asp:BoundField DataField="nvarPpcRefno" HeaderText="PPC Reference No" ItemStyle-Width="160px" ItemStyle-Font-Underline="true" ItemStyle-ForeColor ="Blue" />--%>
                                        <%--<asp:BoundField DataField="Sno" HeaderText="Sno" ItemStyle-Width="30px"  />--%>
                                         <asp:TemplateField HeaderText="Item Code"  ItemStyle-Width="80px" >

                                            <ItemTemplate>
                                                <asp:Image ID="Image1" runat="server" Width ="20px" Height="20px"  ImageAlign="AbsMiddle"   />
                                                <asp:Label ID="lblitemcode" runat="server" Text='<%#Eval("DMITNO") %>'  />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--<asp:BoundField DataField="DMITNO" HeaderText="Item Code" ItemStyle-Width="70px" HeaderStyle-HorizontalAlign ="Center"  />--%>
                                        <asp:BoundField DataField="DMITDS" HeaderText="Description" ItemStyle-Width="250px" HeaderStyle-HorizontalAlign ="Center" ReadOnly ="true"   />
                                        <asp:TemplateField HeaderText="Image Location"  ItemStyle-Width="300px" >

                                            <ItemTemplate>
                                               
                                                <asp:Label ID="lblimgLoc" runat="server" Text='<%#Eval("DMITNOImageLocation") %>' ItemStyle-Width="300px"  />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                            
                                            <%--<asp:TextBox ID="txtimgLoc" runat="server" Text='<%#Eval("DMITNOImageLocation") %>' ItemStyle-Width="300px"  />--%>
                                                
                                             <%--<asp:UpdatePanel  runat="server" ID="upFlu" >
                                    <ContentTemplate>--%>
                                                        <asp:FileUpload ID="FileUpload1" runat="server"  ItemStyle-Width="300px"   Height ="40px" Font-Size ="XX-Large"  />
                                                   <%-- </ContentTemplate> 
                                                    <Triggers>
                                                    <asp:PostBackTrigger ControlID="fUpload" />
                                                    </Triggers>
                                                </asp:UpdatePanel> --%>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <%--<asp:BoundField DataField="STATUS" HeaderText="Status" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign ="Center" />--%>
                                       
                                        <asp:TemplateField HeaderStyle-Width="55px">
                                       
                                                 <ItemTemplate>
                                                   <%--<asp:UpdatePanel  runat="server" ID="upeBtn" UpdateMode="Conditional"  >
                                    <ContentTemplate>--%>
                                                <asp:Button ID="imgbtnEdit" CommandName="Edit" runat="server" ToolTip="Edit" Height="30px" Width="75px" Text="Edit"  ForeColor ="Blue" Font-Size ="X-Large"  />
                                             <%--  </ContentTemplate> 
                                           </asp:UpdatePanel> --%>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                            <%--<asp:UpdatePanel  runat="server" ID="upuBtn" UpdateMode="Conditional"  >
                                    <ContentTemplate>--%>
                                                <asp:Button ID="imgbtnUpdate" CommandName="Update" runat="server" Text="Update" ToolTip="Update" Height="30px" Width="95px" ForeColor ="Blue" Font-Size ="X-Large" />
                                                <asp:Button ID="imgbtnCancel" runat="server" CommandName="Cancel"  Text="Cancel" ToolTip="Cancel" Height="30px" Width="95px" ForeColor ="Blue" Font-Size ="X-Large" />
                                          <%--  </ContentTemplate> 
                                           </asp:UpdatePanel> --%>
                                            </EditItemTemplate>
                                     
                                        </asp:TemplateField>
                                                                         
                                    </Columns>
                                </asp:GridView>
                                   </ContentTemplate> 
                                       <Triggers>
                                                    <asp:PostBackTrigger ControlID="grdvwImage" />
                                                    </Triggers>
                </asp:UpdatePanel> 
                </asp:Panel>
            </div>
        </div>
        </div>
        </div> 
    </form>
</body>
</html>

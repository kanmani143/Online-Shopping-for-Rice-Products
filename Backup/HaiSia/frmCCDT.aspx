<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmCCDT.aspx.cs" Inherits="HaiSia.frmCCDT" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script src="js/jquery-1.7.min.js" type="text/javascript"></script>
<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.5.0/jquery.min.js"></script>
<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.9/jquery-ui.min.js"></script>

   <link rel="stylesheet" href="css/jquery-ui-1.8.9-custom.css" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />

    <link rel="stylesheet" href="css/jquery-ui.css" />
    <link rel="stylesheet" href="css/jquery.ui.datepicker.css" />

    <script type="text/javascript" src="js/jquery-1.10.2.js"></script>

    <script type="text/javascript" src="js/jquery-ui.js"></script>
    


    <script type="text/javascript">
        
        function isNumberRange(evt, obj, min, max) 
        {
            
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
//            alert(charCode);
            var val = obj.value;
            if (charCode == 8 || charCode == 127) return true;
            else if (charCode == 37 || charCode == 39) return true;
            else if (charCode > 31 && (charCode < 48 || charCode > 57)) return false;
            else if (val == '') return true;
            else if (parseInt(val, 10) == NaN) return true;
            else
            {
                var ret = (parseInt(val, 10) * 10) + charCode - 48;
                if (ret >= min && ret <= max) return true;
                else return false;
             }
         }


       


        function fixedlength(textboxID, keyEvent, maxlength) {
            //validation for digits upto 'maxlength' defined by caller function
            if (textboxID.value.length > maxlength) {
                textboxID.value = textboxID.value.substr(0, maxlength);
            }
            else  
            {
                if (textboxID.value.length < maxlength || textboxID.value.length == maxlength) 
                {
                  
                        textboxID.value = textboxID.value.replace(/[^\d]+/g, '');
                        return true;
                 
                }
                else
                    return false;
            }
           
        }
        
        function show(a) { document.getElementById(a).style.visibility = "visible"; }
        function hide(a) { document.getElementById(a).style.visibility = "hidden"; }

        window.history.forward();
        function noBack() { window.history.forward(); }


        $(function() {

            $("#<%= txtClosingDay.ClientID %>").datepicker({ dateFormat: 'dd/M/yy' });
            $("#<%= txtNextColDate.ClientID %>").datepicker({ dateFormat: 'dd/M/yy' });

        });

        

        
    </script>
    <script language="JavaScript" type="text/javascript">

        // This opens the movie details pop-up after an
        // half second interval.
        function windowDelay(thatImg, ItemName) {
            winOpenTimer = window.setTimeout(function() { openDetails(thatImg, ItemName); }, 2000);
        }


        // This is the function that will open the
        // new window when the mouse is moved over the image
        function openDetails(thatImg, ItemName) {
            // This creates a new window and uses the hovered image name as the window 
            // name so that it can be used in the that window's javascript
            newWindow = open(ItemName, thatImg.name, "width=400,height=500,left=410,top=210");

            // open new document 
            newWindow.document.open();



        }



        // This is the function that will call the
        // closeWindow() after 2 seconds
        // when the mouse is moved off the image.
        function closeDetails() {
            winCloseTimer = window.setTimeout("closeWindow();", 2000);
        }

        // This function closes the pop-up window
        // and turns off the Window Timers
        function closeWindow() {
            // If popUpHover == true then I do not want
            // the window to close
            if (popUpHover == false) {
                clearInterval(winOpenTimer);
                clearInterval(winCloseTimer);
                newWindow.close();
            }
        }

        function popUpDetails() {
            // This will be used to prevent the Details Window from closing
            popUpHover = true;

            // Below is some other javascript code...
        }
</script> 

    <style type="text/css">
        .rbSize input[type=radio] { border: 0px; height: 40px; width: 40px;}
        .style1
        {
            width: 470px;
        }
    </style>
    
    
    
    
    
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
                               
              <asp:LinkButton ID="ImageUpload" runat="server"   Font-Size="XX-Large" 
                      Width ="210px" onclick="ImageUpload_Click" >Image Upload</asp:LinkButton>
                          
                    <asp:LinkButton ID="lnkLogout" runat="server" onclick="lnkLogout_Click" Font-Size="XX-Large" Width ="120px" >Logout</asp:LinkButton>
                 
                 
          
            </div>
                 
          
           
                     
        </div>
          <div style="clear: both;">
        <div style="position: relative; float: left; width: auto;top: 0px; right: -50px; ">
        <br />
          <table  frame="void" >
        	<tr align="center" >
	
                
                     <td width="1200" height="1" colspan="3" align ="center" 
                    style="background-color:#3FA902; color:White;font-family: Arial; font-size: small;">
                      </td>                
	</tr>
	</table>
        </div>
        </div>
                   <br />
                   <br />
                 
                      
           <br />
        <div style="clear: both;">
                <div style="position: relative; text-align:center; width: auto; right: -50px;">
            
                <asp:Label ID="Label1" runat="server" Text="Closing and Collection Date & Time"  Width="600px" Font-Size="XX-Large" ForeColor="White"  BackColor ="DarkGoldenrod"   ></asp:Label>
                </div>
                 
                  <br />
                  <br />   
                   
        </div>
            
             <div style="clear: both;">
                <div style="position: relative; text-align:left; width: auto; right: -50px;">

                                                           <table style="width: 99%;">
                                            <tr>
                                                <td class="style1">
                                                    <asp:Label ID="Label2" runat="server" Text="Closing Day :" Font-Size="XX-Large" ForeColor="Black"></asp:Label>
                                                </td>
                                                <td class="style2">
                                                    <asp:TextBox ID="txtClosingDay" runat="server" Font-Size="XX-Large" ></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style1">
                                                    &nbsp;</td>
                                                <td class="style2">
                                                    <asp:Label ID="Label5" runat="server" Font-Size="XX-Large" Text="Hr" 
                                                        Width="60px" ForeColor="Magenta" ></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Label ID="Label6" runat="server" Font-Size="XX-Large" Text="Mi" 
                                                        Width="60px" ForeColor="Magenta"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Label ID="Label7" runat="server" Font-Size="XX-Large" Text="SS" 
                                                        Width="60px" ForeColor="Magenta"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style1">
                                                    <asp:Label ID="Label3" runat="server" Text="Closing Time :" 
                                                        Font-Size="XX-Large" ForeColor="Black"></asp:Label>
                                                </td>
                                                <td class="style2">
                                                    <table  >
                                                        <tr>
                                                            <td rowspan="2">
                                                              <%--onkeypress="return isHourMaxInt(event,this)"--%>
                                                              
                                                                <%--<asp:TextBox ID="txtHour" runat="server" Font-Size="XX-Large" Width="60px"  Text="0" onblur="return fixedlength(this, event, 2);" onkeypress="return fixedlength(this, event, 2);" onkeyup="return fixedlength(this, event, 2);" ></asp:TextBox>--%>
                                                                <asp:TextBox ID="txtHour" runat="server" Font-Size="XX-Large" Width="60px"  Text="0" onkeypress="return isNumberRange(event,this,0,12)"  ></asp:TextBox>
                                                              <cc1:NumericUpDownExtender ID="NumericUpDownExtender1" runat="server" TargetControlID="txtHour" Width ="60"  Minimum ="00" Maximum ="12" TargetButtonDownID ="imgbD" TargetButtonUpID ="imgbU">
                                                                </cc1:NumericUpDownExtender>
                                                                
                                                            </td>
                                                            <td class="style3">
                                                                <asp:ImageButton ID="imgbU" runat="server" ImageUrl="~/Images/imgUp.jpg" Width="40" Height ="20px"  />
                                                            </td>
                                                            <td rowspan="2">
                                                                <asp:TextBox ID="txtMin" runat="server" Font-Size="XX-Large" Width="60px" Text="0" onkeypress="return isNumberRange(event,this,0,59)"></asp:TextBox>
                                                                <cc1:NumericUpDownExtender ID="NumericUpDownExtender2" runat="server" 
                                                                    Maximum="59" Minimum="00" TargetButtonDownID="imgbMD" TargetButtonUpID="imgbMU" 
                                                                    TargetControlID="txtMin" Width="60">
                                                                </cc1:NumericUpDownExtender>
                                                                </td>
                                                          
                                                            <td>
                                                                <asp:ImageButton ID="imgbMU" runat="server" Height="20px" 
                                                                    ImageUrl="~/Images/imgUp.jpg" Width="40" />
                                                            </td>
                                                            <td rowspan="2">
                                                                <asp:TextBox ID="txtSec" runat="server" Font-Size="XX-Large" Width="60px" Text="0" onkeypress="return isNumberRange(event,this,0,59)"></asp:TextBox>
                                                                <cc1:NumericUpDownExtender ID="NumericUpDownExtender3" runat="server" 
                                                                    Maximum="59" Minimum="00" TargetButtonDownID="imgbSD" TargetButtonUpID="imgbSU" 
                                                                    TargetControlID="txtSec" Width="60">
                                                                </cc1:NumericUpDownExtender>
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="imgbSU" runat="server" Height="20px" 
                                                                    ImageUrl="~/Images/imgUp.jpg" Width="40" />
                                                            </td>
                                                            <td rowspan="2">
                                                                <asp:RadioButtonList ID="rblst" runat="server" Font-Size="XX-Large" 
                                                                    RepeatDirection="Horizontal" class ="rbSize" Width="228px"  ForeColor="Magenta">
                                                                    <asp:ListItem Selected="True">AM</asp:ListItem>
                                                                    <asp:ListItem>PM</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                          
                                                        </tr>
                                                     
                                                        <tr>
                                                            <td class="style3">
                                                                <asp:ImageButton ID="imgbD" runat="server" ImageUrl="~/Images/imgdown.jpg" Width="40" Height ="20px" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="imgbMD" runat="server" Height="20px" 
                                                                    ImageUrl="~/Images/imgdown.jpg" Width="40" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="imgbSD" runat="server" Height="20px" 
                                                                    ImageUrl="~/Images/imgdown.jpg" Width="40" />
                                                            </td>
                                                        </tr>
                                                     
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style1">
                                                    <asp:Label ID="Label4" runat="server" Text="Next Collection Date :" 
                                                        Font-Size="XX-Large" ForeColor="Black"></asp:Label>
                                                </td>
                                                <td class="style2">
                                                    <asp:TextBox ID="txtNextColDate" runat="server" Font-Size="XX-Large"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
            </div>
        </div> 
   <div style="clear: both;">
         <br />
               <br /> 
        <div style="position: relative; float: right; width: 250px; top: 0px; left: -50px; text-align:right ;">
                <%--<asp:Button ID="BtnLogout" runat="server" Text="Logout" Width="124px" 
                      Height="50px" onclick="BtnLogout_Click" />--%>
                    <%--<asp:ImageButton ID="BtnLogout" runat="server" onclick="BtnLogout_Click" ImageUrl ="~/Images/LogoutImage5.jpeg"  ImageAlign ="Middle" />--%>
                          <asp:ImageButton ID="imgSubmit" runat="server" ImageUrl ="~/Images/imgSubmit.jpg" onclick="imgSubmit_Click"  Width="240px" Height="50px" ToolTip="CLICK HERE TO ORDER NOW!"/> 
                          <%--<asp:LinkButton ID="lnkConfirmOrder" runat="server" onclick="lnkConfirmOrder_Click" Font-Size="XX-Large" >Confirm Order</asp:LinkButton>--%>
            </div></div> 
       </div>
        </div>
    </form>
</body>
</html>

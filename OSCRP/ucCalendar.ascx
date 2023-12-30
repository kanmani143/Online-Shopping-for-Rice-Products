<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucCalendar.ascx.cs" Inherits="OSCRP.ucCalendar" %>
<head>
    <link href="css/Style.css" type="text/css" rel="stylesheet">
    <script language="javascript" src="js/calendar.js"></script>
    <script language="javascript">
        var DateStringFormat = "dd-mon-yyyy hh:nn"
        var PickerPath = "../Javascript/";
        var CurrentDate = '<%=System.DateTime.Now.ToString("MM/dd/yyyy")%>';
        function ShowDate(pDateTimeField, withDate, withTime, DateStringFormat, ServerDate) {
            CurrentDate = CurrentDate.replace(/-/g, '/');
            getDateTime(pDateTimeField, true, false, DateStringFormat, CurrentDate)
        }
    </script>
</head>
<body class="body" MS_POSITIONING="GridLayout">
	<table border="0" cellspacing="0" cellpadding="0">
		<tr>
			<td>
				<asp:TextBox ID="txtDate" runat="server" CssClass="textbox" Width="50px" ReadOnly="true" Visible="False" />
				<INPUT TYPE="text" id="<%=_ObjectName%>" NAME="<%=_ObjectName%>" value="<%=dateSelected%>" class="textbox" readOnly style="WIDTH: 60px">
				
			</td>
			<td align="left">
				<div id="ImgPane" runat="server">
					<IMG BORDER="0" CLASS="QueryButton" SRC="~/Images/calender.png" ALIGN="absMiddle" onclick="ShowDate(<%=_ObjectName%>,true,false,DateStringFormat,CurrentDate);"
					ID="Img_PC_ETA">    
				</div>
			</td>
		</tr>
	</table>
</body>
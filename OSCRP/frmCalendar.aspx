<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmCalendar.aspx.cs" Inherits="OSCRP.frmCalendar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>


</head>
    
<body>
    <script type="text/javascript" >
        function uploadOnChange() {

            var filename = document.getElementById('calDeparture').value;
            
            //var lastIndex = filename.lastIndexOf("\\");
            //if (lastIndex >= 0) {
            //    filename = filename.substring(lastIndex + 1);
            //}
            document.getElementById('hdnCal').value = filename;
            alert(filename);
            }
    </script>
    <form id="form1" runat="server">
        <div>
            <asp:Calendar ID="calDeparture" Visible="true" runat="server" style="align-items:inherit;" ></asp:Calendar> 
            <asp:HiddenField ID="hdnCal" runat="server" />
        </div>
    </form>
</body>
</html>

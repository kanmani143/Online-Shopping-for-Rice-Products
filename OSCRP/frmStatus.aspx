<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="frmStatus.aspx.cs" Inherits="OSCRP.frmStatus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link rel="stylesheet" href="css/pikaday.css" type="text/css"/>
    <link rel="stylesheet" href="css/site.css" type="text/css" />
    <link rel="stylesheet" href="css/theme.css" type="text/css" />
    <script src="pikaday.js" type="text/javascript"></script>
                                           <%-- <script>

                                                var picker = new Pikaday(
                                                    {
                                                        field: document.getElementById('<%=txtDate.ClientID%>');,
                                                    firstDay: 1,
                                                    format: 'mm/dd/yyyy',
                                                    minDate: new Date(2000, 01, 01),
                                                    maxDate: new Date(2040, 12, 31),
                                                    yearRange: [2000, 2040],
                                                    numberOfMonths: 1,
                                                    toString: function (date) {
                                                        var parts = [('0' + date.getDate()).slice(-2), ('0' + (date.getMonth() + 1)).slice(-2), date.getFullYear()];
                                                        return parts.join("/");
                                                    }


                                                });

    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <%-- <script src="js/jquery-ui.js"></script>
    <script src="js/jquery-1.7.js"></script>
    <script src="js/jquery.js"></script>
    <link href="css/jquery-ui.css" rel="stylesheet" />
    <script type="text/javascript">
        $(document).ready(function () {
            $('<%= txtDate.ClientID %>').datepicker({
                showon: 'both',
                dateFormat: 'dd/mm/yyyy'
            });
        });
    </script>--%>

        <div style="clear: both;">
          
            <div style="position: relative; float: left; width: auto;top: 0px; right: -50px; ">

  
                <%--<asp:Panel ID="pnlMain" runat="server"  Height="1200px" Width="1200px">--%>
                    <div class="about eng" >
                        <asp:TextBox ID="txtDate" runat="server" ></asp:TextBox>

        </div>
                <%--</asp:Panel>--%>
            </div>
        </div>
</asp:Content>

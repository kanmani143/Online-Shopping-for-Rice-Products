<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="Calendar.aspx.cs" Inherits="OSCRP.Calendar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
<tr>
<td>
<asp:Label ID="lblDateSent" runat="server" Text="Posted on:" CssClass="graytextbold"></asp:Label>
        <input ID="PostedOn" runat="server" class="NormalTextBox" readonly="readOnly" type="text" />&nbsp;<a onclick="showCalendarControl(ctl00_ContentPlaceHolder1_PostedOn)" href="#"><img src="calendar.gif" style="width: 20px; height: 20px" border=0 /></a>
</td>
</tr>
</table>
</asp:Content>

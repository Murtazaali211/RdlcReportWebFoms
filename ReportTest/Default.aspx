<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ReportTest._Default" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<html xmlns="http://www.w3.org/2000/xhtml">
    <head>
        <title>Report</title>
    </head>
    <body>
        <form id="form" runat="server">
            <div style="margin-bottom:10px; margin-left:10px; margin-top:10px;">
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                <asp:Button ID="btnShow" runat="server" Text="Show Report" OnClick="btnShow_Click"></asp:Button>
                <asp:GridView ID="dgvData" runat="server"></asp:GridView>
            </div>
            <div style="height:1000px;margin-bottom:10px; margin-left:10px; margin-top:10px;">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" SizeToReportContent="True"></rsweb:ReportViewer>
            </div>
        </form>
    </body>
</html>


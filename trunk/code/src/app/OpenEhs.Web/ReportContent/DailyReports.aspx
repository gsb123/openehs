<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DailyReports.aspx.cs" Inherits="OpenEhs.Web.ReportContent.DailyReports" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
            font-weight: 700;
        }
        .style2
        {
            width: 267px;
        }
        .style3
        {
            font-size: x-large;
        }
        .style4
        {
            width: 100%;
            font-weight: 700;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
&nbsp;<table class="style1">
            <tr>
                <td class="style2" valign="top">
                    Report Date:<asp:TextBox ID="txtDate" runat="server" BorderStyle="None" 
                        ReadOnly="True"></asp:TextBox>
                    <asp:Calendar ID="calendarDate" runat="server" 
                        onselectionchanged="calendarDate_SelectionChanged"></asp:Calendar>
                </td>
                <td valign="top">
                    <asp:Button ID="btnGenerate" runat="server" onclick="btnGenerate_Click" 
            Text="Generate Report" />
                </td>
            </tr>
        </table>
        <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
        <br />
        <table class="style4">
            <tr>
                <td>
                    <strong><span class="style3">Daily Admissions Report</span></strong><asp:GridView 
                        ID="gvAdmissions" runat="server" BackColor="White" BorderColor="#CCCCCC" 
                        BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" 
                        GridLines="Horizontal">
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#242121" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    Remained Previous Day: 
                    <asp:Label ID="lblPrevDay" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Total Admission:
                    <asp:Label ID="lblTotalAdmission" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Total Discharges:
                    <asp:Label ID="lblTotalDischarges" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Total Deaths:
                    <asp:Label ID="lblTotalDeaths" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                   Remained at Midnight:
                    <asp:Label ID="lblTotalAtMidnight" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <span class="style3">
                    <br />
                    Daily Discharges Report</span><asp:GridView ID="gvDischarge" runat="server" 
                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                        CellPadding="4" ForeColor="Black" GridLines="Horizontal">
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#242121" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    <span class="style3">
                    <br />
                    Deaths</span><asp:GridView ID="gvDeaths" runat="server" BackColor="White" 
                        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                        ForeColor="Black" GridLines="Horizontal">
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#242121" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
        <br />
        <br />
    </div>
    </form>
</body>
</html>

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
        <br />
        <asp:GridView ID="gvAdmissions" runat="server" CellPadding="4" 
            ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
    </div>
    </form>
</body>
</html>

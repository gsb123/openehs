<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MonthlyReports.aspx.cs" Inherits="OpenEhs.Web.Reports" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        Start Date:

        <asp:TextBox ID="txtStartDate" runat="server"></asp:TextBox>
        &nbsp;
        End Date:&nbsp;
        <asp:TextBox ID="txtEndState" runat="server"></asp:TextBox>
    
        &nbsp;<asp:Button ID="btnGenerate" runat="server" onclick="btnGenerate_Click" 
            Text="Generate Reports" />
        <br />
        <br />
    
        <table class="style1" border="1px">
            <tr>
                <td colspan="7" style="text-align: center" bgcolor="#FFFFCC">
                    B. IN-PATIENTSS</td>
            </tr>
            <tr>
                <td class="style2" rowspan="2">
                    AGE GROUPS</td>
                <td class="style2" colspan="2">
                    ADMISSIONS</td>
                <td class="style2" colspan="2">
                    DISCHARGES</td>
                <td class="style2" colspan="2">
                    DEATHS</td>
            </tr>
            <tr>
                <td class="style2">
                    Male</td>
                <td class="style2">
                    Female</td>
                <td class="style2">
                    Male</td>
                <td class="style2">
                    Female</td>
                <td class="style2">
                    Male</td>
                <td class="style2">
                    Female</td>
            </tr>
            <tr>
                <td>
                    Under 1 Year</td>
                <td class="style2">
                    <asp:Label ID="inpatientLbl1" runat="server"></asp:Label>
                </td>
                <td class="style2">
                    <asp:Label ID="inpatientLbl8" runat="server"></asp:Label>
                </td>
                <td class="style2">
                    <asp:Label ID="inpatientLbl15" runat="server"></asp:Label>
                </td>
                <td class="style2">
                    <asp:Label ID="inpatientLbl22" runat="server"></asp:Label>
                </td>
                <td class="style2">
                    <asp:Label ID="inpatientLbl29" runat="server"></asp:Label>
                </td>
                <td class="style2">
                    <asp:Label ID="inpatientLbl36" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    1 - 4 Years</td>
                <td class="style2">
                    <asp:Label ID="inpatientLbl2" runat="server"></asp:Label>
                </td>
                <td class="style2">
                    <asp:Label ID="inpatientLbl9" runat="server"></asp:Label>
                </td>
                <td class="style2">
                    <asp:Label ID="inpatientLbl16" runat="server"></asp:Label>
                </td>
                <td class="style2">
                    <asp:Label ID="inpatientLbl23" runat="server"></asp:Label>
                </td>
                <td class="style2">
                    <asp:Label ID="inpatientLbl30" runat="server"></asp:Label>
                </td>
                <td class="style2">
                    <asp:Label ID="inpatientLbl37" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    5 - 14 Years</td>
                <td class="style2">
                    <asp:Label ID="inpatientLbl3" runat="server"></asp:Label>
                </td>
                <td class="style2">
                    <asp:Label ID="inpatientLbl10" runat="server"></asp:Label>
                </td>
                <td class="style2">
                    <asp:Label ID="inpatientLbl17" runat="server"></asp:Label>
                </td>
                <td class="style2">
                    <asp:Label ID="inpatientLbl24" runat="server"></asp:Label>
                </td>
                <td class="style2">
                    <asp:Label ID="inpatientLbl31" runat="server"></asp:Label>
                </td>
                <td class="style2">
                    <asp:Label ID="inpatientLbl38" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    15 - 44 Years</td>
                <td class="style2">
                    <asp:Label ID="inpatientLbl4" runat="server"></asp:Label>
                </td>
                <td class="style2">
                    <asp:Label ID="inpatientLbl11" runat="server"></asp:Label>
                </td>
                <td class="style2">
                    <asp:Label ID="inpatientLbl18" runat="server"></asp:Label>
                </td>
                <td class="style2">
                    <asp:Label ID="inpatientLbl25" runat="server"></asp:Label>
                </td>
                <td class="style2">
                    <asp:Label ID="inpatientLbl32" runat="server"></asp:Label>
                </td>
                <td class="style2">
                    <asp:Label ID="inpatientLbl39" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    45 - 59 Years</td>
                <td class="style2">
                    <asp:Label ID="inpatientLbl5" runat="server"></asp:Label>
                </td>
                <td class="style2">
                    <asp:Label ID="inpatientLbl12" runat="server"></asp:Label>
                </td>
                <td class="style2">
                    <asp:Label ID="inpatientLbl19" runat="server"></asp:Label>
                </td>
                <td class="style2">
                    <asp:Label ID="inpatientLbl26" runat="server"></asp:Label>
                </td>
                <td class="style2">
                    <asp:Label ID="inpatientLbl33" runat="server"></asp:Label>
                </td>
                <td class="style2">
                    <asp:Label ID="inpatientLbl40" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    60 Years and Above</td>
                <td class="style2">
                    <asp:Label ID="inpatientLbl6" runat="server"></asp:Label>
                </td>
                <td class="style2">
                    <asp:Label ID="inpatientLbl13" runat="server"></asp:Label>
                </td>
                <td class="style2">
                    <asp:Label ID="inpatientLbl20" runat="server"></asp:Label>
                </td>
                <td class="style2">
                    <asp:Label ID="inpatientLbl27" runat="server"></asp:Label>
                </td>
                <td class="style2">
                    <asp:Label ID="inpatientLbl34" runat="server"></asp:Label>
                </td>
                <td class="style2">
                    <asp:Label ID="inpatientLbl41" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    All Ages</td>
                <td class="style2">
                    <asp:Label ID="inpatientLbl7" runat="server"></asp:Label>
                </td>
                <td class="style2">
                    <asp:Label ID="inpatientLbl14" runat="server"></asp:Label>
                </td>
                <td class="style2">
                    <asp:Label ID="inpatientLbl21" runat="server"></asp:Label>
                </td>
                <td class="style2">
                    <asp:Label ID="inpatientLbl28" runat="server"></asp:Label>
                </td>
                <td class="style2">
                    <asp:Label ID="inpatientLbl35" runat="server"></asp:Label>
                </td>
                <td class="style2">
                    <asp:Label ID="inpatientLbl42" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    
    </div>
    <br />
    <table class="style1" border="1px">
        <tr>
            <td colspan="7" style="text-align: center" bgcolor="#FFFFCC">
                A. OUT-PATIENTS</td>
        </tr>
        <tr>
            <td class="style2" rowspan="2">
                AGE GROUPS</td>
            <td class="style2" colspan="2">
                NEW</td>
            <td class="style2" colspan="2">
                OLD</td>
            <td class="style2" colspan="2">
                TOTAL</td>
        </tr>
        <tr>
            <td class="style2">
                Male</td>
            <td class="style2">
                Female</td>
            <td class="style2">
                Male</td>
            <td class="style2">
                Female</td>
            <td class="style2">
                Male</td>
            <td class="style2">
                Female</td>
        </tr>
        <tr>
            <td>
                Under 1 Year</td>
            <td class="style2">
                <asp:Label ID="outpatientLbl1" runat="server"></asp:Label>
            </td>
            <td class="style2">
                <asp:Label ID="outpatientLbl8" runat="server"></asp:Label>
            </td>
            <td class="style2">
                <asp:Label ID="outpatientLbl15" runat="server"></asp:Label>
            </td>
            <td class="style2">
                <asp:Label ID="outpatientLbl22" runat="server"></asp:Label>
            </td>
            <td class="style2">
                <asp:Label ID="outpatientLbl29" runat="server"></asp:Label>
            </td>
            <td class="style2">
                <asp:Label ID="outpatientLbl36" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                1 - 4 Years</td>
            <td class="style2">
                <asp:Label ID="outpatientLbl2" runat="server"></asp:Label>
            </td>
            <td class="style2">
                <asp:Label ID="outpatientLbl9" runat="server"></asp:Label>
            </td>
            <td class="style2">
                <asp:Label ID="outpatientLbl16" runat="server"></asp:Label>
            </td>
            <td class="style2">
                <asp:Label ID="outpatientLbl23" runat="server"></asp:Label>
            </td>
            <td class="style2">
                <asp:Label ID="outpatientLbl30" runat="server"></asp:Label>
            </td>
            <td class="style2">
                <asp:Label ID="outpatientLbl37" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                5 - 14 Years</td>
            <td class="style2">
                <asp:Label ID="outpatientLbl3" runat="server"></asp:Label>
            </td>
            <td class="style2">
                <asp:Label ID="outpatientLbl10" runat="server"></asp:Label>
            </td>
            <td class="style2">
                <asp:Label ID="outpatientLbl17" runat="server"></asp:Label>
            </td>
            <td class="style2">
                <asp:Label ID="outpatientLbl24" runat="server"></asp:Label>
            </td>
            <td class="style2">
                <asp:Label ID="outpatientLbl31" runat="server"></asp:Label>
            </td>
            <td class="style2">
                <asp:Label ID="outpatientLbl38" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                15 - 44 Years</td>
            <td class="style2">
                <asp:Label ID="outpatientLbl4" runat="server"></asp:Label>
            </td>
            <td class="style2">
                <asp:Label ID="outpatientLbl11" runat="server"></asp:Label>
            </td>
            <td class="style2">
                <asp:Label ID="outpatientLbl18" runat="server"></asp:Label>
            </td>
            <td class="style2">
                <asp:Label ID="outpatientLbl25" runat="server"></asp:Label>
            </td>
            <td class="style2">
                <asp:Label ID="outpatientLbl32" runat="server"></asp:Label>
            </td>
            <td class="style2">
                <asp:Label ID="outpatientLbl39" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                45 - 59 Years</td>
            <td class="style2">
                <asp:Label ID="outpatientLbl5" runat="server"></asp:Label>
            </td>
            <td class="style2">
                <asp:Label ID="outpatientLbl12" runat="server"></asp:Label>
            </td>
            <td class="style2">
                <asp:Label ID="outpatientLbl19" runat="server"></asp:Label>
            </td>
            <td class="style2">
                <asp:Label ID="outpatientLbl26" runat="server"></asp:Label>
            </td>
            <td class="style2">
                <asp:Label ID="outpatientLbl33" runat="server"></asp:Label>
            </td>
            <td class="style2">
                <asp:Label ID="outpatientLbl40" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                60 Years and Above</td>
            <td class="style2">
                <asp:Label ID="outpatientLbl6" runat="server"></asp:Label>
            </td>
            <td class="style2">
                <asp:Label ID="outpatientLbl13" runat="server"></asp:Label>
            </td>
            <td class="style2">
                <asp:Label ID="outpatientLbl20" runat="server"></asp:Label>
            </td>
            <td class="style2">
                <asp:Label ID="outpatientLbl27" runat="server"></asp:Label>
            </td>
            <td class="style2">
                <asp:Label ID="outpatientLbl34" runat="server"></asp:Label>
            </td>
            <td class="style2">
                <asp:Label ID="outpatientLbl41" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                All Ages</td>
            <td class="style2">
                <asp:Label ID="outpatientLbl7" runat="server"></asp:Label>
            </td>
            <td class="style2">
                <asp:Label ID="outpatientLbl14" runat="server"></asp:Label>
            </td>
            <td class="style2">
                <asp:Label ID="outpatientLbl21" runat="server"></asp:Label>
            </td>
            <td class="style2">
                <asp:Label ID="outpatientLbl28" runat="server"></asp:Label>
            </td>
            <td class="style2">
                <asp:Label ID="outpatientLbl35" runat="server"></asp:Label>
            </td>
            <td class="style2">
                <asp:Label ID="outpatientLbl42" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>

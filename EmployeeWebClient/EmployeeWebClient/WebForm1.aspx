<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="EmployeeWebClient.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table style="font-family: Arial; border: 1px solid black;">
            <tr>
                <td>
                    <b>ID</b>
                </td>
                <td>
                    <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <b>Name</b>
                </td>
                <td>
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <b>Gender</b>
                </td>
                <td>
                    <asp:TextBox ID="txtGender" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <b>Date Of Birth</b>
                </td>
                <td>
                    <asp:TextBox ID="txtDateOfBirth" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <b>Employee Type</b>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" 
                          OnSelectedIndexChanged ="DropDownList1_SelectedIndexChanged"
                            AutoPostBack="true">
                        <asp:ListItem Text="Select Employee Type" Value="-1"></asp:ListItem>
                        <asp:ListItem Text="Full Time Employee" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Part Time Employee" Value="2"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr id="trMonthlySalary" runat="server" visible="false">
                <td>
                    <b>Monthly Salary</b>
                </td>
                <td>
                    <asp:TextBox ID="txtMonthlySalary" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr id="trHourlyPay" runat="server" visible="false">
                <td>
                    <b>Hourly Pay</b>
                </td>
                <td>
                    <asp:TextBox ID="txtHourlyPay" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr id="trHoursWorked" runat="server" visible="false">
                <td>
                    <b>Hours Worked</b>
                </td>
                <td>
                    <asp:TextBox ID="txtHoursWorked" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Button ID="btnGetEmployee" runat="server" Text="Get Employee" OnClick="btnGetEmployee_Click" />
                </td>
                <td>
                    <asp:Button ID="btnSaveEmployee" runat="server" Text="Save Employee" OnClick="btnSaveEmployee_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Bold="true"></asp:Label>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>

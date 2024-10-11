<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApplyForm.aspx.cs" Inherits="ProjectBatch1.ApplyForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
        <tr>
            <td>From :</td>
            <td><asp:TextBox ID="txtfromemail" runat="server" Width="250px"></asp:TextBox></td>
        </tr>
          <tr>
            <td>Password :</td>
            <td><asp:TextBox ID="txtpassword" runat="server" Width="250px" TextMode="Password"></asp:TextBox></td>
        </tr>
        <tr>
            <td>To :</td>
            <td><asp:TextBox ID="txttoemail" runat="server" Width="250px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Subject :</td>
            <td><asp:TextBox ID="txtsubject" runat="server" Width="250px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="vertical-align:top">Body :</td>
            <td><asp:TextBox ID="txtbody" runat="server" TextMode="MultiLine" Rows="8" Columns="50"></asp:TextBox> </td>
        </tr>
       
        <tr>
            <td></td>
            <td><asp:Button ID="btn_SendMail" Text="Mail Send" runat="server" OnClick="btn_SendMail_Click" /></td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>

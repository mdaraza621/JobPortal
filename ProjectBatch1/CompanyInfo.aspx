<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyInfo.aspx.cs" Inherits="ProjectBatch1.CompanyInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <center>
    <table style="width:100%;">
        <tr>
            <td><b>Company Name :</b></td>
            <td><asp:Label ID="lblcname" runat="server"></asp:Label></td>
        </tr>


        <tr>
            <td><b>Company URL :</b></td>
            <td><asp:Label ID="lblcurl" runat="server"></asp:Label></td>
        </tr>

        <tr>
            <td><b>Company Address :</b></td>
            <td><asp:Label ID="lblcaddress" runat="server"></asp:Label></td>
        </tr>

       
        <tr>
            <td><b>Company HR :</b></td>
            <td><asp:Label ID="lblchr" runat="server"></asp:Label></td>
        </tr>

        <tr>
            <td><b>Contact Number :</b></td>
            <td><asp:Label ID="lblcn" runat="server"></asp:Label></td>
        </tr>

        <tr>
            <td><b>Email :</b></td>
            <td><asp:Label ID="lblemail" runat="server"></asp:Label></td>
        </tr>

        
    </table></center>
    </div>
    </form>
</body>
</html>

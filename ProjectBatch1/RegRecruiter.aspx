<%@ Page Title="" Language="C#" MasterPageFile="~/default.Master" AutoEventWireup="true" CodeBehind="RegRecruiter.aspx.cs" Inherits="ProjectBatch1.RegRecruiter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>Company Name</td>
            <td><asp:TextBox ID="txtcname" runat="server"></asp:TextBox></td>
        </tr>


        <tr>
            <td>Company URL :</td>
            <td><asp:TextBox ID="txtcurl" runat="server"></asp:TextBox></td>
        </tr>

         <tr>
            <td>Country :</td>
            <td>
                <asp:DropDownList ID="ddlcountry" runat="server" OnSelectedIndexChanged="ddlcountry_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td>
        </tr>

        <tr>
            <td>State :</td>
            <td>
                <asp:DropDownList ID="ddlstate" runat="server" OnSelectedIndexChanged="ddlstate_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td>
        </tr>

         <tr>
            <td>City :</td>
            <td>
                <asp:DropDownList ID="ddlcity" runat="server"></asp:DropDownList></td>
        </tr>

        <tr>
            <td>Company Address :</td>
            <td><asp:TextBox ID="txtcaddress" runat="server"></asp:TextBox></td>
        </tr>

        <tr>
            <td>Company HR :</td>
            <td><asp:TextBox ID="txtchr" runat="server"></asp:TextBox></td>
        </tr>

        <tr>
            <td>Contact Number :</td>
            <td><asp:TextBox ID="txtcn" runat="server"></asp:TextBox></td>
        </tr>

        <tr>
            <td>Email :</td>
            <td><asp:TextBox ID="txtemail" runat="server"></asp:TextBox></td>
        </tr>

        <tr>
            <td>Password :</td>
            <td><asp:TextBox ID="txtpassword" runat="server"></asp:TextBox></td>
        </tr>

        <tr>
            <td></td>
            <td><asp:Button ID="btnsave" runat="server" Text="Submit" OnClick="btnsave_Click" />
                 <a href="Login.aspx">Sign In</a>
            </td>
        </tr>

        <tr>
            <td></td>
            <td><asp:Label ID="lblmsg" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label></td>
        </tr>

        
    </table>
</asp:Content>

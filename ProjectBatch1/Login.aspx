﻿<%@ Page Title="" Language="C#" MasterPageFile="~/default.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProjectBatch1.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
         <tr>
            <td>User Type :</td>
            <td><asp:DropDownList ID="ddlusertype" runat="server">
                <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                <asp:ListItem Text="Admin" Value="1"></asp:ListItem>
                <asp:ListItem Text="User" Value="2"></asp:ListItem>
                <asp:ListItem Text="Recruiter" Value="3"></asp:ListItem>
                </asp:DropDownList></td>
        </tr>

        <tr>
            <td>User Email :</td>
            <td><asp:TextBox ID="txtemail" runat="server"></asp:TextBox></td>
        </tr>

         <tr>
            <td>User Password :</td>
            <td><asp:TextBox ID="txtpassword" runat="server"></asp:TextBox></td>
        </tr>

         <tr>
            <td></td>
            <td><asp:Button ID="btnlogin" runat="server" Text="Login" OnClick="btnlogin_Click" />
                <a href="RegistrationForm.aspx">Sign Up for Users</a>
                <a href="RegRecruiter.aspx">Sign Up for Recruiters</a>
            </td>
        </tr>

        <tr>
            <td></td>
            <td><asp:Label ID="lblmsg" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label></td>
        </tr>
    </table>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Recruiter.Master" AutoEventWireup="true" CodeBehind="Recruiter_jobPost.aspx.cs" Inherits="ProjectBatch1.Recruiter_jobPost" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>Job Title :</td>
            <td><asp:DropDownList ID="ddljobtitle" runat="server"></asp:DropDownList></td>
        </tr>

        <tr>
            <td>Min Exp (Year) :</td>
            <td><asp:TextBox ID="txtminexp" runat="server"></asp:TextBox> Year</td>
        </tr>

         <tr>
            <td>Max Exp  (Year) :</td>
            <td><asp:TextBox ID="txtmaxexp" runat="server"></asp:TextBox> Year</td>
        </tr>

         <tr>
            <td>Min Salary (Rs.) :</td>
            <td><asp:TextBox ID="txtminsalary" runat="server"></asp:TextBox></td>
        </tr>

         <tr>
            <td>Max Salary (Rs.) :</td>
            <td><asp:TextBox ID="txtmaxsalary" runat="server"></asp:TextBox></td>
        </tr>

         <tr>
            <td>No of vacancies :</td>
            <td><asp:TextBox ID="txtvacancies" runat="server"></asp:TextBox></td>
        </tr>

        <tr>
            <td style="vertical-align:top">Comment :</td>
            <td><asp:TextBox ID="txtcomment" runat="server" TextMode="MultiLine" Rows="5" Columns="30"></asp:TextBox></td>
        </tr>

        
         <tr>
            <td></td>
            <td><asp:Button ID="btnsave" runat="server" Text="Submit" OnClick="btnsave_Click" /></td>
        </tr>
         <tr>
            <td></td>
            <td><asp:Label ID="lblmsg" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label></td>
        </tr>
    </table>
</asp:Content>

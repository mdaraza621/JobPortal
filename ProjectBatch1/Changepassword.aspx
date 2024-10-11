<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Changepassword.aspx.cs" Inherits="ProjectBatch1.Changepassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript">
         function Validation() {
             var msgs = "";
             msgs = checkoldpassword();
             msgs += checknewpassword();
             msgs += checkcnewpassword();

             if (msgs != "") {
                 alert(msgs);
                 return false;
             }
         }

         function checkoldpassword() {
             var TB = document.getElementById('<%=txtoldpassword.ClientID%>');
            if (TB.value == "") {
                return 'please enter your old password !!\n';
            }
            else {
                return "";
            }
        }

        function checknewpassword() {
            var TB = document.getElementById('<%=txtnewpassword.ClientID%>');
            if (TB.value == "") {
                return 'please enter your new password !!\n';
            }
            else {
                return "";
            }
        }

        function checkcnewpassword() {
            var TB1 = document.getElementById('<%=txtnewpassword.ClientID%>');
            var TB2 = document.getElementById('<%=txtcnewpassword.ClientID%>');
            if (TB2.value == "") {
                return 'please enter your confirm new password !!\n';
            }
            else if (TB1.value == TB2.value) {
                return "";
            }
            else {
                return 'password do not match !!\n';
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>Old Password :</td>
            <td><asp:TextBox ID="txtoldpassword" runat="server"></asp:TextBox></td>
        </tr>

         <tr>
            <td>New Password :</td>
            <td><asp:TextBox ID="txtnewpassword" runat="server"></asp:TextBox></td>
        </tr>

         <tr>
            <td>Confirm New Password :</td>
            <td><asp:TextBox ID="txtcnewpassword" runat="server"></asp:TextBox></td>
        </tr>

         <tr>
            <td></td>
            <td><asp:Button ID="btnchangepassword" runat="server" Text="Change Password" OnClientClick="return Validation()" OnClick="btnchangepassword_Click" /></td>
        </tr>

        <tr>
            <td></td>
            <td><asp:Label ID="lblmsg" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label></td>
        </tr>
    </table>
</asp:Content>

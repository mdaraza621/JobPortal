  <%@ Page Title="" Language="C#" MasterPageFile="~/default.Master" AutoEventWireup="true" CodeBehind="RegistrationForm.aspx.cs" Inherits="ProjectBatch1.RegistrationForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function alok() {
            var msgs = "";
            msgs = checkname();
            msgs += checkemail();
            msgs += checkpassword();
            msgs += checkjp();
            msgs += checkgender();
            msgs += checkqual();
            msgs += checkCountry();
            msgs += checkState();
            msgs += checkCity();
            msgs += checkphoto();
            msgs += checkresume();

            if (msgs == "") {
                return true;
            }
            else {
                alert(msgs);
                return false;
            }
        }

        function checkname() {
            var TB = document.getElementById('<%=txtname.ClientID%>');
            var RegExp = /^[a-zA-Z ]{3,50}$/
            if (TB.value == "") {
                return 'please enter your name !!\n';
            }
            else if (RegExp.test(TB.value)) {
                return "";
            }
            else {
                return 'please enter only alphabets !!\n';
            }
        }

        function checkemail() {
            var TB = document.getElementById('<%=txtemail.ClientID%>');
            if (TB.value == "") {
                return 'please enter your email !!\n';
            }
            else {
                return "";
            }
        }

        function checkpassword() {
            var TB = document.getElementById('<%=txtpassword.ClientID%>');
            if (TB.value == "") {
                return 'please enter your password !!\n';
            }
            else {
                return "";
            }
        }

        function checkjp() {
            var DDLJP = document.getElementById('<%=ddljp.ClientID%>');
            if (DDLJP.value == "0") {
                return 'please select your job profile !!\n';
            }
            else {
                return "";
            }
        }

        function checkqual() {
            var DDLQ = document.getElementById('<%=ddlqualification.ClientID%>');
            if (DDLQ.value == "0") {
                return 'please select your qualification !!\n';
            }
            else {
                return "";
            }
        }

        function checkCountry() {
            var DDLC = document.getElementById('<%=ddlcountry.ClientID%>');
            if (DDLC.value == "0") {
                return 'please select your Country !!\n';
            }
            else {
                return "";
            }
        }

        function checkState() {
            var DDLS = document.getElementById('<%=ddlstate.ClientID%>');
            if (DDLS.value == "0") {
                return 'please select your State !!\n';
            }
            else {
                return "";
            }
        }

        function checkCity() {
            var DDLCT = document.getElementById('<%=ddlcity.ClientID%>');
            if (DDLCT.value == "0") {
                return 'please select your city !!\n';
            }
            else {
                return "";
            }
        }


        function checkgender() {
            var RBLG = document.getElementById('<%=rblgender.ClientID%>');
            var ginputs = RBLG.getElementsByTagName('input');
            var count = 0;

            for (var i = 0; i < ginputs.length; i++) {
                if (ginputs[i].checked == true) {
                    count = 1;
                }
            }

            if (count == 0) {
                return 'please select your gender !!\n';
            }
            else {
                return "";
            }
        }


        function checkphoto() {
            var FUPHOTO = document.getElementById('<%=fuphoto.ClientID%>');
            if (FUPHOTO.value == "") {
                return 'please upload your photo !!\n';
            }
            else if (!FUPHOTO.files[0].name.match(/.(jpg|jpeg|png|gif)$/i)) {
                return 'please upload only jpg, jpeg, png or gif files !!\n';
            }
            else if (FUPHOTO.files[0].size > 1050000)
            {
                return 'please upload image less than 1 MB !!\n';
            }
            else {
                return "";
            }

           
                
        }

        function checkresume() {
            var FURS = document.getElementById('<%=furesume.ClientID%>');
            if (FURS.value == "") {
                return 'please upload your resume !!\n';
            }
            else if (!FURS.files[0].name.match(/.(doc|docx|pdf)$/i)) {
                return 'please upload only doc, docx or pdf files !!\n';
            }
            else {
                return "";
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table>
        <tr>
            <td>User Name :</td>
            <td><asp:TextBox ID="txtname" runat="server"></asp:TextBox></td>
        </tr>

        <tr>
            <td>User Gender :</td>
            <td><asp:RadioButtonList ID="rblgender" runat="server" RepeatColumns="3">
                <asp:ListItem Text="male" Value="1"></asp:ListItem>
                 <asp:ListItem Text="female" Value="2"></asp:ListItem>
                 <asp:ListItem Text="others" Value="3"></asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>

        <tr>
            <td>User Job Profile :</td>
            <td><asp:DropDownList ID="ddljp" runat="server" OnSelectedIndexChanged="ddljp_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td>
        </tr>

        <tr id="tr_skills" runat="server">
            <td>Skills :</td>
            <td><asp:CheckBoxList ID="cblskills" runat="server" RepeatColumns="5">
                
                </asp:CheckBoxList></td>
        </tr>

        <tr>
            <td>User Qualification :</td>
            <td><asp:DropDownList ID="ddlqualification" runat="server"></asp:DropDownList></td>
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
            <td>Photo Upload :</td>
            <td>
                <asp:FileUpload ID="fuphoto" runat="server"></asp:FileUpload></td>
        </tr>

          <tr>
            <td>Resume Upload :</td>
            <td>
                <asp:FileUpload ID="furesume" runat="server"></asp:FileUpload></td>
        </tr>

         <tr>
            <td></td>
            <td><asp:Button ID="btnreg" runat="server" Text="Register" OnClientClick="return alok()" OnClick="btnreg_Click" />
                <a href="Login.aspx">Sign In</a>
            </td>
        </tr>
        <tr>
            <td></td>
            <td><asp:Label ID="lblmsg" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label></td>
        </tr>
         
    </table>
</asp:Content>




<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="Manage_City.aspx.cs" Inherits="ProjectBatch1.Manage_City" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function Validation() {
            var msg = "";
            msg = checkcountry();
            msg += checkstate();
            msg += checkcity();

            if (msg != "") {
                alert(msg);
                return false;
            }
        }

        function checkcountry() {
            var DDL = document.getElementById('<%=ddlcountry.ClientID%>');
            if (DDL.value == "0") {
                return 'please select your country !!\n';
            }
            else {
                return "";
            }
        }

        function checkstate() {
            var DDL = document.getElementById('<%=ddlstate.ClientID%>');
            if (DDL.value == "0") {
                return 'please select your state !!\n';
            }
            else {
                return "";
            }
        }

        function checkcity() {
            var TB = document.getElementById('<%=txtname.ClientID%>');
            if (TB.value == "") {
                return 'please enter your city !!\n';
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
            <td>Country Name:</td>
            <td><asp:DropDownList ID="ddlcountry" runat="server" OnSelectedIndexChanged="ddlcountry_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td>
        </tr>

        <tr>
            <td>State Name:</td>
            <td><asp:DropDownList ID="ddlstate" runat="server"></asp:DropDownList></td>
        </tr>

         <tr>
            <td>City Name:</td>
            <td><asp:TextBox ID="txtname" runat="server"></asp:TextBox></td>
        </tr>

        <tr>
            <td></td>
            <td><asp:Button ID="btnsave" runat="server" Text="Save" OnClientClick="return Validation()" OnClick="btnsave_Click" /></td>
        </tr>

         <tr>
            <td></td>
            <td><asp:Label ID="lblmsg" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label></td>
        </tr>

        <tr>
            <td></td>
            <td><asp:GridView ID="gv_city"  OnRowCommand="gv_city_RowCommand" runat="server" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None">
                <Columns>
                    <asp:TemplateField HeaderText="Country Name">
                        <ItemTemplate>
                            <%#Eval("CountryName") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="State Name">
                        <ItemTemplate>
                            <%#Eval("StateName") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="City Name">
                        <ItemTemplate>
                            <%#Eval("cityName") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="btnedit" runat="server" Text="Edit" CommandName="B" CommandArgument='<%#Eval("cityid") %>' ></asp:LinkButton>
                            <asp:LinkButton ID="btndelete" runat="server" Text="Delete" CommandName="A" CommandArgument='<%#Eval("cityid") %>' ></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>

                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />
                </asp:GridView></td>
        </tr>

       
    </table>
</asp:Content>

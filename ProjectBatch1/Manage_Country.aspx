<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="Manage_Country.aspx.cs" Inherits="ProjectBatch1.Manage_Country" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function Validation() {
            var msg = "";
            msg = checkcountry();

            if (msg != "") {
                alert(msg);
                return false;
            }
        }

        function checkcountry() {
            var TB = document.getElementById('<%=txtname.ClientID%>');
            if (TB.value == "") {
                return 'please enter your name !!\n';
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
            <td><asp:GridView ID="gv_country" ShowFooter="true" OnRowCommand="gv_country_RowCommand" OnRowCancelingEdit="gv_country_RowCancelingEdit" DataKeyNames="countryid" runat="server" OnRowUpdating="gv_country_RowUpdating" OnRowDeleting="gv_country_RowDeleting" OnRowEditing="gv_country_RowEditing" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None">
                <Columns>
                    <asp:TemplateField HeaderText="Country ID">
                        <ItemTemplate>
                            <%#Eval("CountryID") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Country Name">
                        <ItemTemplate>
                            <%#Eval("CountryName") %>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtname1" runat="server" Text='<%#Eval("countryname") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtname2" runat="server"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="btnedit" runat="server" Text="Edit" CommandName="Edit" ></asp:LinkButton>
                            <asp:LinkButton ID="btndelete" runat="server" Text="Delete" CommandName="Delete"></asp:LinkButton>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:LinkButton ID="btnupdate" runat="server" Text="Update" CommandName="Update"></asp:LinkButton>
                            <asp:LinkButton ID="btncancel" runat="server" Text="Cancel" CommandName="Cancel"></asp:LinkButton>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Button ID="btnsave2" runat="server" Text="Save" CommandName="SV" />
                        </FooterTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField>
                         <HeaderTemplate>
                             <asp:CheckBox ID="chkdeleteall" runat="server" Text="Check All" AutoPostBack="true" OnCheckedChanged="chkdeleteall_CheckedChanged" />
                         </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkdelete" runat="server" />
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Button ID="btndeleteall2" runat="server" Text="Delete All" CommandName="DALL" />
                        </FooterTemplate>
                    </asp:TemplateField>


                    <%--<asp:CommandField ShowEditButton="true" />
                    <asp:CommandField ShowDeleteButton="true" />--%>
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

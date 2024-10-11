<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="Manage_Skills.aspx.cs" Inherits="ProjectBatch1.Manage_Skills" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>Job Profile:</td>
            <td><asp:DropDownList ID="ddljp" runat="server"></asp:DropDownList></td>
        </tr>

         <tr>
            <td>Skills:</td>
            <td><asp:TextBox ID="txtskills" runat="server"></asp:TextBox></td>
        </tr>

        <tr>
            <td></td>
            <td><asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" /></td>
        </tr>

         <tr>
            <td></td>
            <td><asp:Label ID="lblmsg" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label></td>
        </tr>

        <tr>
            <td></td>
            <td><asp:GridView ID="gv_skills"  OnRowCommand="gv_skills_RowCommand" runat="server" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None">
                <Columns>
                    <asp:TemplateField HeaderText="Job Profile">
                        <ItemTemplate>
                            <%#Eval("jpname") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Skill Name">
                        <ItemTemplate>
                            <%#Eval("SKName") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="btnedit" runat="server" Text="Edit" CommandName="B" CommandArgument='<%#Eval("skid") %>' ></asp:LinkButton>
                            <asp:LinkButton ID="btndelete" runat="server" Text="Delete" CommandName="A" CommandArgument='<%#Eval("skid") %>' ></asp:LinkButton>
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

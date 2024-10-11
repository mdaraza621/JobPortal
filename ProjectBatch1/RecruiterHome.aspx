<%@ Page Title="" Language="C#" MasterPageFile="~/Recruiter.Master" AutoEventWireup="true" CodeBehind="RecruiterHome.aspx.cs" Inherits="ProjectBatch1.RecruiterHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Welcome <asp:Label ID="lblname" runat="server"></asp:Label></h1>
     <table>
        <tr>
            <td><asp:GridView ID="grd" runat="server" CellPadding="4" Width="1200px" OnRowCommand="grd_RowCommand" ForeColor="#333333" GridLines="None" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="Company Name">
                        <ItemTemplate>
                            <%#Eval("name") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="URL">
                        <ItemTemplate>
                            <%#Eval("url") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                       <asp:TemplateField HeaderText="Company Address">
                        <ItemTemplate>
                          <%#Eval("Address") %>, <%#Eval("cityname") %>, <%#Eval("statename") %>, <%#Eval("countryname") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Contact Person">
                        <ItemTemplate>
                            <%#Eval("hr") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                      <asp:TemplateField HeaderText="Email ID">
                        <ItemTemplate>
                            <%#Eval("email") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Contact Number">
                        <ItemTemplate>
                            <%#Eval("contactno") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btndelete" runat="server" Text="Delete" CommandName="A" CommandArgument='<%#Eval("cid") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnedit" runat="server" Text="Edit" CommandName="B" CommandArgument='<%#Eval("cid") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <AlternatingRowStyle BackColor="White" />
                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView></td>
        </tr>

         <tr>
            <td><asp:Label ID="lblmsg" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label></td>
        </tr>
    </table>
</asp:Content>

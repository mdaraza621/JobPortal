<%@ Page Title="" Language="C#" MasterPageFile="~/Recruiter.Master" AutoEventWireup="true" CodeBehind="Recruiter_ManageJobPosts.aspx.cs" Inherits="ProjectBatch1.Recruiter_ManageJobPosts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                Job Title :
            <asp:DropDownList ID="ddljobtitle" runat="server"></asp:DropDownList>
            <asp:Button ID="btnsearch" runat="server" Text="Search" OnClick="btnsearch_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gv_jobposts" runat="server" OnRowCommand="gv_jobposts_RowCommand" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:TemplateField HeaderText="Job Title">
                <ItemTemplate>
                    <%#Eval("jpname") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Company Name">
                <ItemTemplate>
                    <%#Eval("name") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Required Exp.">
                <ItemTemplate>
                    <%#Eval("minexp") %> year - <%#Eval("maxexp") %> year
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Offered Salary">
                <ItemTemplate>
                    Rs.<%#Eval("minsalary") %>- Rs.<%#Eval("maxsalary") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="No of position">
                <ItemTemplate>
                    <%#Eval("noofvac") %> positions
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Comment">
                <ItemTemplate>
                    <%#Eval("comment") %>
                </ItemTemplate>
            </asp:TemplateField>

              <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btndelete" runat="server" Text="Delete" OnClientClick="return confirm('are you sure you want to delete ?')" CommandName="A" CommandArgument='<%#Eval("jobid") %>' ></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                         <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnedit" runat="server" Text="Edit" CommandName="B" CommandArgument='<%#Eval("jobid") %>' ></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
        </Columns>

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

    </asp:GridView>
            </td>
        </tr>
          <tr>
            <td><asp:Label ID="lblmsg" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label></td>
        </tr>
    </table>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="ManageRecruiter.aspx.cs" Inherits="ProjectBatch1.ManageRecruiter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td><asp:GridView ID="grd" runat="server" Width="1200px" CellPadding="4" OnRowCommand="grd_RowCommand" ForeColor="#333333" GridLines="None" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="Company Name">
                        <ItemTemplate>
                            <%#Eval("name") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Company URL">
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
                            <asp:LinkButton ID="btnapprove" runat="server" Text='<%#Eval("usertype").ToString()=="1" ? "Approved" : "Approve" %>' CommandName="APR" CommandArgument='<%#Eval("cid") %>' ></asp:LinkButton>
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

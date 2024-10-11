<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="ManageUsers.aspx.cs" Inherits="ProjectBatch1.ManageUsers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td><asp:GridView ID="grd" runat="server" Width="1200px" OnRowCommand="grd_RowCommand" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None">
                <Columns>
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <%#Eval("name") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Gender">
                        <ItemTemplate>
                             <%#Eval("ugender").ToString()=="1" ? "male" : Eval("ugender").ToString()=="2" ? "female" : "others" %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Email ID">
                        <ItemTemplate>
                            <%#Eval("email") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Password">
                        <ItemTemplate>
                            <%#Eval("password") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Job Title">
                        <ItemTemplate>
                            <%#Eval("jpname") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Qualification">
                        <ItemTemplate>
                            <%#Eval("qname") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                      <asp:TemplateField HeaderText="Full Address">
                        <ItemTemplate>
                          <%#Eval("cityname") %>, <%#Eval("statename") %>, <%#Eval("countryname") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                      <asp:TemplateField HeaderText="User Photo">
                        <ItemTemplate>
                            <asp:Image ID="img1" runat="server" Width="50px" Height="40px" ImageUrl='<%#Eval("photo","~/JOBSEEKER_PHOTO/{0}") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="User Resume">
                        <ItemTemplate>
                              <asp:LinkButton ID="btnresume" runat="server" CommandName="RSM" Text='<%#Eval("resumee") %>' CommandArgument='<%#Eval("resumee") %>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="btnapprove" runat="server" Text='<%#Eval("usertype").ToString()=="1" ? "Approved" : "Approve" %>' CommandName="APR" CommandArgument='<%#Eval("rid") %>' ></asp:LinkButton>
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
            <td>
                <asp:Label ID="lblmsg" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

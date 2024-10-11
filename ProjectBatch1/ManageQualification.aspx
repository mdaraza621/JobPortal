<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="ManageQualification.aspx.cs" Inherits="ProjectBatch1.ManageQualification" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>Qualification Title:</td>
            <td><asp:TextBox ID="txtname" runat="server"></asp:TextBox></td>
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
            <td><asp:GridView ID="gv_qualification" ShowFooter="true" OnRowCommand="gv_qualification_RowCommand" OnRowCancelingEdit="gv_qualification_RowCancelingEdit" DataKeyNames="qid" runat="server" OnRowUpdating="gv_qualification_RowUpdating" OnRowDeleting="gv_qualification_RowDeleting" OnRowEditing="gv_qualification_RowEditing" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" GridLines="None">
                <Columns>
                    <asp:TemplateField HeaderText="QualificationID">
                        <ItemTemplate>
                            <%#Eval("qid") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Qualification Name">
                        <ItemTemplate>
                            <%#Eval("qname") %>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtname1" runat="server" Text='<%#Eval("qname") %>'></asp:TextBox>
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

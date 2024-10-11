<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="UserHome.aspx.cs" Inherits="ProjectBatch1.UserHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Hello
        <asp:Label ID="lblname" runat="server"></asp:Label></h1>
    <table style="width: 100%">
        <tr>
            <td>
                <asp:Repeater ID="RepDetails" runat="server" OnItemCommand="RepDetails_ItemCommand">
                    <HeaderTemplate>
                        <table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Image ID="img1" runat="server" Width="600px" Height="350px" ImageUrl='<%#Eval("photo","~/JOBSEEKER_PHOTO/{0}") %>' />
                            </td>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                           Name : <%#Eval("Name") %>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Gender :<%#Eval("ugender").ToString()=="1" ? "male" :Eval("ugender").ToString()=="2" ? "female" : "others"  %>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Email ID :<%#Eval("email") %>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                           Password : <%#Eval("password") %>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                           Job Profile : <%#Eval("jpname") %> ( <%#Eval("skills") %> )
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Qualification : <%#Eval("qname") %>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                           Address : <%#Eval("cityname") %>, <%#Eval("statename") %>, <%#Eval("countryname") %>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                           Resume : <asp:LinkButton ID="btnresume" runat="server" CommandName="RSM" Text='<%#Eval("resumee") %>' CommandArgument='<%#Eval("resumee") %>'></asp:LinkButton>
                                        </td>
                                    </tr>

                                    
                                </table>
                            </td>
                        </tr>

                       <tr>
                           <td>
                               <table>
                                   <tr>
                                        <td>
                                            <asp:LinkButton ID="btndelete" runat="server" Text="Delete" OnClientClick="return confirm('are you sure you want to delete ?')" CommandName="A" CommandArgument='<%#Eval("rid") %>'></asp:LinkButton>
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="btnedit" runat="server" Text="Edit" CommandName="B" CommandArgument='<%#Eval("rid") %>'></asp:LinkButton>
                                        </td>


                                    </tr>
                               </table>
                           </td>
                           <td></td>
                       </tr>


                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </td>
        </tr>


        <tr>
            <td>
                <asp:Label ID="lblmsg" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

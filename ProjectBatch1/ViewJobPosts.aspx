<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="ViewJobPosts.aspx.cs" Inherits="ProjectBatch1.ViewJobPosts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function ApplyForm(jobid) {
            document.getElementById('iframe_pop').src = 'ApplyForm.aspx?JID=' + jobid;
            $('#div_overlay').fadeIn(500); $('#div_popup').fadeIn(500);
        }

        function CompanyInfo(cid) {
            document.getElementById('iframe_company').src = 'CompanyInfo.aspx?CID=' + cid;
            $('#div_overlaycompany').fadeIn(500); $('#div_popupcompany').fadeIn(500);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>Job Title :
            <asp:DropDownList ID="ddljobtitle" runat="server"></asp:DropDownList>
            Enter your Salary : 
            <asp:TextBox ID="txtsalary" runat="server"></asp:TextBox>
            <asp:Button ID="btnsearch" runat="server" Text="Search" OnClick="btnsearch_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gv_jobposts" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField HeaderText="Job Title">
                            <ItemTemplate>
                                <%#Eval("jpname") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Company Name">
                            <ItemTemplate>
                                <a href="javascript:void(0);" onclick="CompanyInfo('<%#Eval("cid") %>')"><%#Eval("name") %></a>
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
                                    <a href="javascript:void(0);" onclick="ApplyForm('<%#Eval("jobid") %>')">Apply</a>
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
    </table>
    <%--------------------------popup apply----------------------------%>
    <div id="div_overlay" style="position: fixed; left: 0px; top: 0px; right: 0px; bottom: 0px; background: black; opacity: 0.2; display: none"></div>
    <div id="div_popup" style="position: fixed; display: none; left: 0px; top: 150px; right: 0px; bottom: 0px;">
        <center>
    <div style="overflow:auto;width:500px;height:300px;background:white;">
    <div style="float:right"><a href="javascript:void(0);" onclick="$('#div_overlay').fadeOut(1000);$('#div_popup').fadeOut(1000);">close</a></div>
    <iframe id="iframe_pop" src="ApplyForm.aspx" style="border:none" width="500px" height="300px"></iframe>
    </div></center>
    </div>

    <%--------------------------popup company----------------------------%>
    <div id="div_overlaycompany" style="position: fixed; left: 0px; top: 0px; right: 0px; bottom: 0px; background: black; opacity: 0.2; display: none"></div>
    <div id="div_popupcompany" style="position: fixed; display: none; left: 0px; top: 150px; right: 0px; bottom: 0px;">
        <center>
    <div style="overflow:auto;width:500px;height:250px;background:white;">
    <div style="float:right"><a href="javascript:void(0);" onclick="$('#div_overlaycompany').fadeOut(1000);$('#div_popupcompany').fadeOut(1000);">close</a></div>
    <iframe id="iframe_company" src="CompanyInfo.aspx" style="border:none" width="500px" height="250px"></iframe>
    </div></center>
    </div>

</asp:Content>

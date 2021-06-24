<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebApplication2.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


        <asp:LoginView ID="LoginView1" runat="server">
                      <AnonymousTemplate>
                          You need to log in
                      </AnonymousTemplate>
                      <LoggedInTemplate>

                             <a href = "http://mackpotracker.zeywalk.com/HomePage.aspx"' target="_blank">Create A PO</a>

    <asp:GridView ID="GridView1"  runat="server" AutoGenerateColumns="False"   OnRowCommand="GridView1_RowCommand" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" >
                                    <Columns>
                                        <asp:BoundField ItemStyle-Width="250px" DataField="Number" HeaderText="Purchase Order Number" >
                                        
                                        <ItemStyle Width="250px" />
                                        </asp:BoundField>
                                        
                                        <asp:BoundField ItemStyle-Width="250px" DataField="POAttach1" HeaderText="Purchase Order Download" >
                                        <ItemStyle Width="250px" />
                                        </asp:BoundField>
                                        <asp:BoundField ItemStyle-Width="250px" DataField="SupplierName" HeaderText="Supplier" >

                                        <ItemStyle Width="250px" />
                                        </asp:BoundField>

                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Button ID="lnkDownload" runat="server" Text="Download" OnClick="DownloadFile"
                                                    CommandArgument='<%# Eval("POAttach1") %>'></asp:Button>
                                          
                                                   <asp:Button ID="Update" runat="server" Text="Update" OnClick="Update"
                                                    CommandArgument='<%# Eval("id") %>'></asp:Button>
                                          
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                      </Columns>
                                    <FooterStyle BackColor="#CCCCCC" />
                                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                                    <RowStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="3px" BackColor="White" />
                                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="#808080" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#383838" />
                                </asp:GridView>

                      </LoggedInTemplate>
                  </asp:LoginView>

                      </LoggedInTemplate>
                  </asp:LoginView>



</asp:Content>

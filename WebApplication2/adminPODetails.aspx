<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminPODetails.aspx.cs" Inherits="WebApplication2.adminPODetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

            <asp:LoginView ID="LoginView1" runat="server">
                      <AnonymousTemplate>
                          You need to log in
                      </AnonymousTemplate>
                      <LoggedInTemplate>

    <asp:GridView ID="GridView1"  runat="server" AutoGenerateColumns="False"   >
                                    <Columns>
                                        <asp:BoundField ItemStyle-Width="250px" DataField="CorinthianPO" HeaderText="Corinthian PO number" >
                                        
                                        <ItemStyle Width="250px" />
                                        </asp:BoundField>
                                        
                                        <asp:BoundField ItemStyle-Width="250px" DataField="DealerName" HeaderText="Dealer Name" >
                                        <ItemStyle Width="250px" />
                                        </asp:BoundField>
                                        <asp:BoundField ItemStyle-Width="250px" DataField="ApprovalStatus" HeaderText="Approval Status" >

                                        <ItemStyle Width="250px" />

                                        </asp:BoundField>
                                             <asp:BoundField ItemStyle-Width="250px" DataField="Status" HeaderText="Status" >
                                        
                                        <ItemStyle Width="250px" />
                                        </asp:BoundField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                         
                                                      <asp:Button ID="lnkDownload" runat="server" Text="Download Mack PO" OnClick="DownloadMackPO"
                                                    CommandArgument='<%# Eval("MackPOAttach") %>'></asp:Button>
                                                
                                                 <asp:Button ID="Button1" runat="server" Text="Download Corinthian PO" OnClick="DownloadCorinthianPO"
                                                    CommandArgument='<%# Eval("CorinthianPOAttach") %>'></asp:Button>
                                          
                                                     <asp:Button ID="Button2" runat="server" Text="Approve PO" OnClick="Approve"
                                                    CommandArgument='<%# Eval("id") %>'></asp:Button>

                                                       <asp:Button ID="Button3" runat="server" Text="Cancel" OnClick="Cancel"
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
                          <br /><br />    upload mack PO     <asp:FileUpload ID="FileUpload1" runat="server" />
                                   <br />         <asp:Label ID="Label1" runat="server" Text="Upload Mack Purchase Order PDF"></asp:Label>

         <asp:Button ID="UploadPO" runat="server" onclick="UploadPO"  Text="Submit" style="width:85px" />

                      </LoggedInTemplate>
                  </asp:LoginView>
</asp:Content>

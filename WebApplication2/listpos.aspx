<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="listpos.aspx.cs" Inherits="WebApplication2.listpos" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
  
 <body>
    <form id="form1" runat="server">
       

           


        <asp:LoginView ID="LoginView1" runat="server">
                      <AnonymousTemplate>
                          You need to log in
                      </AnonymousTemplate>
                      <LoggedInTemplate>
                             <a href = "http://mackpotracker.zeywalk.com/HomePage.aspx"' target="_blank">Create A PO</a>

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="ChildGrid"  OnRowCommand="GridView1_RowCommand" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                                    <Columns>
                                        <asp:BoundField ItemStyle-Width="250px" DataField="Number" HeaderText="Purchase Order Number" />
                                        
                                        <asp:BoundField ItemStyle-Width="250px" DataField="POAttach1" HeaderText="Purchase Order Download" />
                                        <asp:BoundField ItemStyle-Width="250px" DataField="SupplierName" HeaderText="Supplier" />

                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Button ID="lnkDownload" runat="server" Text="Download" OnClick="DownloadFile"
                                                    CommandArgument='<%# Eval("MackPOAttach") %>'></asp:Button>
                                          
                                                   <asp:Button ID="Update" runat="server" Text="Update" OnClick="Update"
                                                    CommandArgument='<%# Eval("id") %>'></asp:Button>
                                          
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                      </Columns>
                                </asp:GridView>

                      </LoggedInTemplate>
                  </asp:LoginView>



    


              


    </form>
</body>
    </html>

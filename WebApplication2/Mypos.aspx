<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mypos.aspx.cs" Inherits="WebApplication2.Mypos"  MasterPageFile="~/Site1.Master" %>

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


                                          <asp:BoundField ItemStyle-Width="250px" DataField="Status" HeaderText="Shipping Status" >
                                        <ItemStyle Width="250px" />
                                        </asp:BoundField>
                                    
                                           <asp:BoundField ItemStyle-Width="250px" DataField="DateReceived" HeaderText="Date Sent" >
                                        <ItemStyle Width="250px" />
                                        </asp:BoundField>


                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center">



                                            <ItemTemplate>
                                         
                                          
                                                
                                          
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

                



</asp:Content>

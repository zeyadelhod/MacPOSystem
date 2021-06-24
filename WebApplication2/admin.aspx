<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="admin.aspx.cs" Inherits="WebApplication2.admin" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



        <asp:LoginView ID="LoginView1" runat="server">
                      <AnonymousTemplate>
                          You need to log in
                      </AnonymousTemplate>
                      <LoggedInTemplate>
                             <a href = "http://mackpotracker.zeywalk.com/HomePage.aspx"' target="_blank">Go Back </a>

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="ChildGrid" >
                                    <Columns>
                                        <asp:BoundField ItemStyle-Width="250px" DataField="DealerName" HeaderText="Dealer Name" />
                                        <asp:BoundField ItemStyle-Width="250px" DataField="DealerPONumber" HeaderText="Dealer PO No" />
                                        <asp:BoundField ItemStyle-Width="250px" DataField="CorinthianPO" HeaderText="Corinthian PO No" />
                                        <asp:BoundField ItemStyle-Width="250px" DataField="UserID" HeaderText="Created By" />
                                                <asp:BoundField ItemStyle-Width="250px" DataField="ContainerNumber" HeaderText="Container No" />
                                                <asp:BoundField ItemStyle-Width="250px" DataField="FactoryEstimatedArrivalDate" HeaderText="Factory ETA" />
                                     <asp:BoundField ItemStyle-Width="250px" DataField="FactoryEstimatedShipDate" HeaderText="Factory ESA" />

                                        <asp:BoundField ItemStyle-Width="250px" DataField="Status" HeaderText="Status" />
                                            <asp:BoundField ItemStyle-Width="250px" DataField="Booked" HeaderText="Booked" />
                                        <asp:BoundField ItemStyle-Width="250px" DataField="ApprovalStatus" HeaderText="Approved" />


                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                                                  
                                           

                                                   <asp:Button ID="Button3" runat="server" Text="Review" OnClick="Review"
                                                    CommandArgument='<%# Eval("id") %>'></asp:Button>
                                                
                                            

                                                 
                                          
                                            </ItemTemplate>
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

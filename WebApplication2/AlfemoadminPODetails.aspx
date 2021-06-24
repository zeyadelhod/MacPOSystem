<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AlfemoadminPODetails.aspx.cs" Inherits="WebApplication2.AlfemoadminPODetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

            <asp:LoginView ID="LoginView1" runat="server">
                      <AnonymousTemplate>
                          You need to log in
                                <br />
                          <a href="http://mack.besafe.mochahosted.com/Account/login">Login</a>
                                <br />
                      </AnonymousTemplate>
                      <LoggedInTemplate>

    <asp:GridView ID="GridView1"  runat="server" AutoGenerateColumns="False"   >
                                    <Columns>
                                        <asp:BoundField ItemStyle-Width="250px" DataField="CorinthianPO" HeaderText="Mack PO number" >
                                        
                                        <ItemStyle Width="250px" />
                                        </asp:BoundField>
                                        
                                        <asp:BoundField ItemStyle-Width="250px" DataField="DealerName" HeaderText="Dealer Name" >
                                        <ItemStyle Width="250px" />
                                        </asp:BoundField>
                                        <asp:BoundField ItemStyle-Width="250px" DataField="ApprovalStatus" HeaderText="Approval Status" >

                                        <ItemStyle Width="250px" />
                                        </asp:BoundField>

                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                         
                                                    
                                                
                                                 <asp:Button ID="Button1" runat="server" Text="Download Mack PO" OnClick="DownloadMackPO"
                                                    CommandArgument='<%# Eval("CorinthianPOAttach") %>'></asp:Button>
                                          <br />
  
         
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
       <br /> 
      PO Status
                           <br /> 
  
                                                         <asp:DropDownList ID="DropDownList1" runat="server">
               <asp:ListItem>PO Sent</asp:ListItem>
               <asp:ListItem>Confirm PO Receipt</asp:ListItem>

                                <asp:ListItem>Waiting For Production</asp:ListItem>
              <asp:ListItem>In Production</asp:ListItem>
              <asp:ListItem>Loading</asp:ListItem>
          </asp:DropDownList>
        <br /><br /> 
              <asp:TextBox ID="ContainerNumber" placeholder="Container Number"  runat="server" AutoPostBack="True"></asp:TextBox>
        <br /><br /> 
              <asp:TextBox ID="FinalDestinatonTB" placeholder="Final Destinaton"  runat="server"></asp:TextBox>
        <br /><br /> 
        Factory Estaimed Arrival Date

                              <asp:Calendar ID="FactoryETA" runat="server"></asp:Calendar>
       <br /><br /> 
    Factory Estaimed Ship Date
                              <asp:Calendar ID="FACTORYETSD" runat="server"></asp:Calendar>
       <br /><br /> 
                                  


         <asp:Button ID="Update" runat="server" onclick="UpdateStatus"  Text="Update" style="width:85px" />
                                       <br />         <asp:Label ID="Label1" runat="server" Text="Upload Mack Purchase Order PDF"></asp:Label>

</asp:Content>

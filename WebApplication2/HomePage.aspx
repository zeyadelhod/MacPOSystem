<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="WebApplication2.Views.HomePage"   MasterPageFile="~/Site1.Master" %>




    <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


        <asp:LoginView ID="LoginView1" runat="server">
                      <AnonymousTemplate>
                          You need to log in
                      </AnonymousTemplate>
                      <LoggedInTemplate>

           <h3> Create PO </h3>
            <br />
          <asp:TextBox ID="TextBox1" placeholder="Dealer Name"  runat="server"></asp:TextBox>
         <br /><br />
          <asp:TextBox ID="TextBox2" placeholder="Dear PO Number"  runat="server"></asp:TextBox>
         <br /><br />
                            <asp:TextBox ID="CommentsTextBox" TextMode="MultiLine" Rows="5" placeholder="Comments"   runat="server"></asp:TextBox>
         <br /><br />
          <asp:TextBox ID="TextBox3" placeholder="Corinthian PO"  runat="server"></asp:TextBox>
         <br /><br />Production Request Date
                          <asp:Calendar ID="cal" runat="server"></asp:Calendar>

                              

  
         <br />
<br /><br />         <asp:FileUpload ID="FileUpload1" runat="server" />

         <asp:Button ID="btnsave" runat="server" onclick="btnsave_Click"  Text="Submit" style="width:85px" />
                           <br />
                        <asp:Label ID="Label1" runat="server" Text="Upload Purchase Order PDF"></asp:Label>



         <br /><br />
         <asp:Label ID="lblmessage" runat="server" />
                      </LoggedInTemplate>
                  </asp:LoginView>

             

</asp:Content>





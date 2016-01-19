<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="AntunIT.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="regForm">
            <h1>Promjena lozinke</h1> <br />
        <asp:Panel ID="Panel1" runat="server" DefaultButton="RegisterBttn">
            <asp:Label ID="OldUserPassLbl" runat="server" Text="Lozinka:" ></asp:Label> <br />
            <asp:TextBox ID="OldUserPassTb" runat="server" TextMode="Password"></asp:TextBox> <br /><br />

            <asp:Label ID="NewUserPassLbl" runat="server" Text="Nova lozinka:" ></asp:Label> <br />
            <asp:TextBox ID="NewUserPassTb" runat="server" TextMode="Password"></asp:TextBox> <br /><br />

            <asp:Label ID="RepeatPassLbl" runat="server" Text="Ponovite novu lozinku:"></asp:Label> <br />
            <asp:TextBox ID="RepeatPassTb" runat="server" TextMode="Password"></asp:TextBox> <br /> <br />

            <asp:Button ID="RegisterBttn" runat="server" Text="Promijeni" OnClick="ChangePasswordBttn_Click" /> <br /> <br />
        </asp:Panel>
      </div>
</asp:Content>

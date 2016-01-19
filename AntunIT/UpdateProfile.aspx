<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="UpdateProfile.aspx.cs" Inherits="AntunIT.UpdateProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Uredi moje podatke</title>

    <script type="text/javascript">
        function setText() {
            var ime = document.getElementById("ContentPlaceHolder1_Update_NameTb");
            var prezime=document.getElementById("ContentPlaceHolder1_Update_SurnameTb");
            var email=document.getElementById("ContentPlaceHolder1_Update_EmailTb");

            document.getElementById("ContentPlaceHolder1_HiddenIme").value = ime.value;
            document.getElementById("ContentPlaceHolder1_HiddenPrezime").value = prezime.value;
            document.getElementById("ContentPlaceHolder1_HiddenEmail").value = email.value;
        }
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Uredi moje podatke</h1>

    <h3><asp:Label ID="Update_UsernameLbl" runat="server" Text="Label"></asp:Label></h3>

    <asp:Label ID="Update_NameLbl" runat="server" Text="Ime:"></asp:Label> <br />
    <asp:TextBox ID="Update_NameTb" runat="server" EnableViewState="true" onchange=""></asp:TextBox> <br /><br />

    <asp:Label ID="Update_SurnameLbl" runat="server" Text="Prezime" EnableViewState="true"></asp:Label> <br />
    <asp:TextBox ID="Update_SurnameTb" runat="server"></asp:TextBox> <br /><br />

    <asp:Label ID="Update_EmailLbl" runat="server" Text="Email:"></asp:Label> <br />
    <asp:TextBox ID="Update_EmailTb" runat="server"></asp:TextBox> <br /><br />

    <div class="hidden" runat="server">
        <asp:TextBox ID="HiddenIme" runat="server" CssClass=""></asp:TextBox>
        <asp:TextBox ID="HiddenPrezime" runat="server" CssClass=""></asp:TextBox>
        <asp:TextBox ID="HiddenEmail" runat="server" CssClass=""></asp:TextBox>
    </div>

    <asp:Button ID="UpdateUserBttn" runat="server" Text="Izmjeni" OnClick="UpdateUserBttn_Click" OnClientClick="setText()"/>

</asp:Content>

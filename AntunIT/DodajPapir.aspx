<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="DodajPapir.aspx.cs" Inherits="AntunIT.DodajPapir" EnableViewState="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Dodavanje papira</title>

     <script>
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if ((charCode < 48 || charCode > 57) && charCode != 8)
                return false;

            return true;
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Dodavanje papira</h1>

    <br />
    <asp:Label ID="PrinterLbl" runat="server" Text="Printer:"></asp:Label><br />
    <asp:DropDownList ID="DropDownListPrinteri_Papir" runat="server"></asp:DropDownList><br /><br />

    <br />

    <asp:RadioButtonList ID="RadioButtonListPaper" runat="server" CssClass="RadioButtons" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" AutoPostBack="true">
        <asp:ListItem ID="RadioButtonStaro" runat="server" Text="Postojeći papir" Selected="True"></asp:ListItem>
        <asp:ListItem ID="RadioButtonNovo" runat="server" Text="Novi papir"></asp:ListItem>
    </asp:RadioButtonList> <br /><br />

    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="ViweStariPapir" runat="server">
            <asp:Label ID="PapirLbl" runat="server" Text="Papir:"></asp:Label><br />
            <asp:DropDownList ID="DropDownListPapir_Papir" runat="server"></asp:DropDownList><br /><br />
            <asp:Button ID="DodajPapirBttn" runat="server" Text="Dodaj papir" OnClick="DodajPapirBttn_Click" />
        </asp:View>

        <asp:View ID="ViewNoviPapir" runat="server">
            <asp:Label ID="NewPaperLbl" runat="server" Text="Naziv: "></asp:Label><br />
            <asp:TextBox ID="NewPaperNameTb" runat="server"></asp:TextBox> <br /><br />

            <asp:Label ID="NewPaperFormatLbl" runat="server" Text="Format: "></asp:Label><br />
            <asp:TextBox ID="NewPaperFormatTb" runat="server"></asp:TextBox> <br /><br />

            <asp:Label ID="NewPaperNumLbl" runat="server" Text="Komada u pakiranju:"></asp:Label> <br />
            <asp:TextBox ID="NewPaperNumTb" runat="server" TextMode="Number" onkeypress="return isNumberKey(event)"></asp:TextBox>
            <br /><br />
            <asp:Button ID="DodajNoviPapir" runat="server" Text="Dodaj papir" OnClick="DodajNoviPapirBttn_Click" />
        </asp:View>
    </asp:MultiView>


</asp:Content>

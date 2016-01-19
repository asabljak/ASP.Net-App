<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="DodajTintu.aspx.cs" Inherits="AntunIT.DodajTintu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <title>Dodavanje papira</title>

<%--<link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css"/>
  <script src="//code.jquery.com/jquery-1.10.2.js"></script>
  <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
  <link rel="stylesheet" href="/resources/demos/style.css"/>
  <script>
  $(function() {
    $("#ContentPlaceHolder1_Tinta").autocomplete({
        source: 'InksHandler.ashx'
    });
  });
  </script>--%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Dodavanje tinte</h1>

    <br />
    <asp:Label ID="PrinterLbl" runat="server" Text="Printer:"></asp:Label><br />
    <asp:DropDownList ID="DropDownListPrinteri_Tinta" runat="server"></asp:DropDownList><br /><br />
    
    <br />

    <asp:RadioButtonList ID="RadioButtonListInk" runat="server" CssClass="RadioButtons" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" AutoPostBack="true">
        <asp:ListItem ID="RadioButtonStaro" runat="server" Text="Postojeća tinta" Selected="True"></asp:ListItem>
        <asp:ListItem ID="RadioButtonNovo" runat="server" Text="Nova tinta"></asp:ListItem>
    </asp:RadioButtonList>

    <br /><br />
 
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="ViweStaraTinta" runat="server">
            <asp:Label ID="PapirLbl" runat="server" Text="Tinta:"></asp:Label><br />
            <asp:DropDownList ID="DropDownListPapir_Tinta" runat="server"></asp:DropDownList><br /><br />
            <asp:Button ID="DodajTintuBttn" runat="server" Text="Dodaj tintu" OnClick="DodajTintuBttn_Click" />
        </asp:View>
        <asp:View ID="ViewNovaTinta" runat="server">
            <asp:Label ID="NewInkLbl" runat="server" Text="Naziv: "></asp:Label><br />
            <asp:TextBox ID="NewInkNameTb" runat="server"></asp:TextBox> <br /><br />

            <asp:Label ID="NewInkTypeLbl" runat="server" Text="Vrsta:"></asp:Label> <br />
            <asp:DropDownList ID="NewInkTypeDD" runat="server">
                <asp:ListItem>Toner</asp:ListItem>
                <asp:ListItem>Tinta</asp:ListItem>
            </asp:DropDownList> <br /><br />
            <asp:Button ID="DodajNovuTintu" runat="server" Text="Dodaj tintu" OnClick="DodajNovuTintuBttn_Click" />
        </asp:View>
    </asp:MultiView>

    
    

</asp:Content>

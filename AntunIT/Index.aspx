<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="AntunIT.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2><asp:LoginName ID="LoginName1" runat="server" FormatString="Dobrodošao {0}"/></h2>
    <br />
    <div class="obavjest">
        <h3>Obavjest</h3>
        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed pretium aliquam tellus, eget malesuada dolor tristique a. Nunc vestibulum est eget lacus pharetra, nec mattis dui posuere. Nulla at rhoncus velit. Fusce id odio ultricies, aliquet nisi a, tincidunt lectus. Nunc vitae tristique est, a tincidunt diam. Quisque eu feugiat sapien, non hendrerit tellus. Pellentesque in tempus urna. Vestibulum gravida elit non leo egestas, a egestas orci molestie. </p>
    </div>
    <br />
    <div class="obavjest">
        <h3>Druga obavjest</h3>
        <p>Fusce in leo mauris. Fusce at ullamcorper mi. Sed leo libero, egestas quis eros sed, bibendum vestibulum ipsum. Duis libero magna, viverra sit amet nibh ullamcorper, pretium egestas augue. Donec malesuada nibh at odio dapibus laoreet. Ut ornare lectus et ipsum eleifend, sed consectetur sapien congue. Aliquam massa ligula, tincidunt et mi vel, eleifend varius est. Aliquam sed lorem eget neque consequat egestas. Proin mollis porta scelerisque. Duis euismod eu felis nec condimentum. Nam maximus quis sem nec ullamcorper. Etiam sit amet consectetur sapien. In hac habitasse platea dictumst. </p>
    </div>
</asp:Content>

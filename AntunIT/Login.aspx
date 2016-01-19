<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AntunIT.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Antun IT - Login</title>
    <link href="Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <header class="header">
            <h1>Antun IT</h1>
        </header>

        <div class="centar">
            <asp:Login ID="LoginForm" runat="server" OnAuthenticate="Login1_Authenticate" FailureText="Korisničko ime i/ili lozinka nisu ispravni." Width="298px" CssClass="LoginTable">
            </asp:Login>
        </div>

        <footer>
          <asp:Label ID="DateTimeLbl" runat="server" Text="Copyright: Antun Sabljak, TVZ 2015." CssClass="footerDateTime"></asp:Label>
        </footer>
    </div>
    </form>
</body>
</html>

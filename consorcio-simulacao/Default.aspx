<%@ Page Language="C#" Inherits="consorciosimulacao.Default" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>Default</title>
</head>
<body>
	<form id="form1" runat="server">
		<div>
         <asp:Label ID="Label1" runat="server" Text="Login: "></asp:Label>
          <asp:TextBox ID="txtLogin" runat="server"></asp:TextBox>
          <br />
          <br />
          <asp:Label ID="Label2" runat="server" Text="Senha: "></asp:Label>
          <asp:TextBox TextMode="Password" ID="txtSenha" runat="server"></asp:TextBox>
		  <br/>
          <asp:Label ID="lblMensagem" runat="server" Text=""></asp:Label>
          <br />
          <asp:Button ID="btnEntrar" runat="server"  Text="Entrar" OnClick="btnEntrar_Click" />
          <asp:Button ID="btnNovo" runat="server"  Text="Criar Conta" PostBackUrl="~/Views/Cadastro.aspx" />
      
		</div>
	</form>
</body>
</html>

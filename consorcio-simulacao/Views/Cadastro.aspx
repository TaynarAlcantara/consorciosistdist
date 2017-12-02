<%@ Page Language="C#" Inherits="consorciosimulacao.Cadastro" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>Default</title>
</head>
<body>
	<form id="form1" runat="server">
		<div>
            <asp:Label ID="lblNome" runat="server" Text="Nome: "></asp:Label>
            <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
            <br />
			<br />
			<asp:Label ID="lblLogin" runat="server" Text="Login: "></asp:Label>
            <asp:TextBox ID="txtLogin" runat="server"></asp:TextBox>
            <br />
			<br />
            <asp:Label ID="Label2" runat="server" Text="Senha: "></asp:Label>
            <asp:TextBox TextMode="Password" ID="txtSenha" runat="server"></asp:TextBox>
            <br/>
			<br />
		    <asp:Label ID="lblConfSenha" runat="server" Text="Confirmar Senha: "></asp:Label>
            <asp:TextBox TextMode="Password" ID="txtConfSenha" runat="server"></asp:TextBox>
            <br/>
			<asp:Label ID="lblMensagem" runat="server" Text=""></asp:Label>
            <br />
            
            <asp:Button ID="btnCadastrar" runat="server"  Text="Cadastrar" OnClick="btnCadastrar_Click"/>
            <asp:Button ID="btnVoltar" runat="server"  Text="Voltar" PostBackUrl="~/Default.aspx" />
      
			</div>
	</form>
</body>
</html>

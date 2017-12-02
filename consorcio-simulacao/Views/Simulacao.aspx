<%@ Page Language="C#" Inherits="consorciosimulacao.Simulacao" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>Default</title>
</head>
<body>
	<form id="form1" runat="server">
        <div>
			<asp:Label id="lblUsuario" runat="server" Text="" >
            </asp:Label>
			<br/>
			<asp:Label id="lblTipo" runat="server" Text="Tipo de imovel:" >
            </asp:Label>
			<select name="select">
                <option value="valor1">Escolha</option> 
                <option value="valor2">Comercial</option>
                <option value="valor3">Residencial</option>
            </select>
			<br/>
            <asp:Label id="lblCondicao" runat="server" Text="Condicao do imovel:" >
            </asp:Label>
		    <select id="condicao"  runat="server" ClientIDMode="Static">
                <option value="valor1">Escolha</option> 
                <option value="valor2">Imóvel Novo</option>
                <option value="valor3">Imóvel Usado</option>
                <option value="valor4">Construção</option>
                <option value="valor5">Terreno</option>
                <option value="valor6">Crédito com seu imóvel</option>
            </select>
			<br/>
            <asp:Label id="lblLocalizacao" runat="server" Text="Localizacao:" >
            </asp:Label>
			<asp:DropDownList ClientIDMode="Static" id="ddlEstado" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlEstadoSelectedIndexChanged" />
            
			<asp:DropDownList id="ddlCidade" runat="server" />
				
            <br/>
			<asp:Label id="lblPor" runat="server" Text="Simulacao por:" >
            </asp:Label>
			<asp:RadioButtonList ClientIDMode="Static" ID="tipoOpcao" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="tipoOpcaoSelectedIndexChanged"> 
                <asp:ListItem name="tipoOpcao" id="valor" Value="valor">Valor</asp:ListItem>
                <asp:ListItem name="tipoOpcao" id="renda" Value="renda">Renda</asp:ListItem>
            </asp:RadioButtonList>
			<div id="optValor" name="optValor" runat="server">
                <asp:Label id="lblValor" runat="server" Text="Valor do imovel:" >
                </asp:Label>
				<asp:TextBox ID="txtValor" MaxLength="15" TextMode="Number" runat="server"/>	
                <br/>
				<asp:Label id="lblPercentual" runat="server" Text="Percentual do financiamento:" >
                </asp:Label>
                <asp:TextBox ID="txtPercentual" MaxLength="15" Text="0" runat="server"/> 
				<asp:Label id="lblNumeroPercentual" runat="server" Text="% de" >
                <asp:TextBox ID="txtPercentualDe" MaxLength="15" Text="0" runat="server"/> 
                </asp:Label>
                <br/>
			</div>
            <div id="optRenda" name="optRenda" runat="server">
				<asp:Label id="lblRenda" runat="server" Text="Renda:" >
                </asp:Label>
                <asp:TextBox ID="txtRenda" MaxLength="2" Text="0" TextMode="Number" runat="server"/> 
                <br/>
                <asp:Label id="lblIdade" runat="server" Text="Idade:" >
                </asp:Label>
                <asp:TextBox ID="txtIdade" MaxLength="2" TextMode="Number" runat="server"/> 
			</div>
			<br />	
           
		    <asp:Button id="button1" runat="server" Text="Simular" OnClick="button1Clicked" />
				
        </div>

		
	</form>
</body>
</html>

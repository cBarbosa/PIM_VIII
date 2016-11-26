<%@ Page Title="Novo cadastro de tipo de atividade" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateFormCadastroAtividade.aspx.cs" Inherits="PIM_VIII.Atendente.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

<h1>Cadastro de tipo de atividades</h1>

    <asp:Label ID="msgRetorno" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label>
    <hr />

    <table>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblNome" runat="server" Text="Nome" ></asp:Label>
                <br/>
                <asp:TextBox ID="txtNome" runat="server" MaxLength="70" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
        <td style="text-align:center" colspan="2">
            <asp:Button ID="btnEnviar" runat="server" Text="Cadastrar" OnClick="btnEnviar_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="lbtVoltar" runat="server" OnClick="lbtVoltar_Click" >Voltar</asp:LinkButton>
        </td>
        </tr>
    </table>

</asp:Content>

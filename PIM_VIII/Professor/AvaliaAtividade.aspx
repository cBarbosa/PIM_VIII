<%@ Page Title="Avaliação de Atividade" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AvaliaAtividade.aspx.cs" Inherits="PIM_VIII.Professor.AvaliaAtividade" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label ID="msgRetorno" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label>

    <table>
        <tr>
            <td>
                <strong>Curso:</strong> <asp:Label ID="lblCurso" runat="server" Text=""></asp:Label><br/>
                <strong>Disciplina:</strong> <asp:Label ID="lblDisciplina" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <strong>Período de envio:</strong> de <asp:Label ID="dtInicio" runat="server" Text=""></asp:Label> 
                até <asp:Label ID="dtFim" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <strong>Enviado em:</strong> de <asp:Label ID="dtEnvio" runat="server" Text=""></asp:Label> 
            </td>
        </tr>
        <tr>
            <td>
                <strong>Corrigido em:</strong> <asp:Label ID="dtCorrecao" runat="server" Text=""></asp:Label> 
            </td>
        </tr>
        <tr>
            <td>
                <strong>Nota</strong>
                <br />
                <asp:TextBox ID="txtNota" runat="server" TextMode="Number" MaxLength="2" AutoPostBack="false" EnableViewState="false" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Observação do professor"></asp:Label>
                <br />
                <asp:TextBox ID="txtObsProf" runat="server" TextMode="MultiLine" Rows="3" ReadOnly="false" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblObs" runat="server" Text="Observação do aluno"></asp:Label>
                <br />
                <asp:TextBox ID="txtobs" runat="server" TextMode="MultiLine" Rows="3" ReadOnly="true"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Arquivo"></asp:Label>
                <br />
                [xxxxx]
            </td>
        </tr>
        <tr>
            <td style="text-align:center" >
                <asp:Button ID="btnEnviar" runat="server" Text="Enviar" OnClick="btnEnviar_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="lbtVoltar" runat="server" OnClick="lbtVoltar_Click" >Voltar</asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Content>

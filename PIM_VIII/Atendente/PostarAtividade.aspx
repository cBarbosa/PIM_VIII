<%@ Page Title="Postar Atividade" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PostarAtividade.aspx.cs" Inherits="PIM_VIII.Atendente.PostarAtividade" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Postar atividade</h1>
    <hr />
    <asp:Label ID="msgRetorno" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label>

    <asp:Panel ID="pnBuscaAluno" runat="server">
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
                    <asp:Label ID="Label1" runat="server" Text="Alunos"></asp:Label>
                    <br/>
                    <asp:DropDownList ID="dpAluno" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dpAluno_SelectedIndexChanged" OnTextChanged="dpAluno_TextChanged"></asp:DropDownList>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnPostagem" runat="server" Visible="false">
        <table>
        <tr>
            <td>
                <asp:Label ID="lblObs" runat="server" Text="Observação"></asp:Label>
                <br />
                <asp:TextBox ID="txtobs" runat="server" TextMode="MultiLine" Rows="3" MaxLength="1000" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Arquivo"></asp:Label>
                <br />
                <asp:FileUpload ID="FileUpload1" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="text-align:center" >
                <asp:Button ID="btnEnviar" runat="server" Text="Postar" OnClick="btnEnviar_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="lbtVoltar" runat="server" OnClick="lbtVoltar_Click" >Voltar</asp:LinkButton>
            </td>
        </tr>
    </table>
    </asp:Panel> 
    <table style="width: 350PX;">
        <tr>
            <td style="text-align:center" >
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="lbtVoltar_Click" >Voltar</asp:LinkButton>
            </td>
        </tr>
    </table>
    

</asp:Content>

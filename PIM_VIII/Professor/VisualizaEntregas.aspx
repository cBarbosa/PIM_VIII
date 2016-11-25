<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VisualizaEntregas.aspx.cs" Inherits="PIM_VIII.Professor.VisualizaEntregas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Lista das entregas</h1>
    <hr />
    <asp:Label ID="msgRetorno" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label>

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="cronograma.disciplina.Nome" HeaderText="Disciplina" />
            <asp:BoundField DataField="aluno.matricula" HeaderText="Aluno" />
            <asp:BoundField DataField="cronograma.DataInicio" HeaderText="Dt.Inicio" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="cronograma.DataFim" HeaderText="Dt Fim" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="dataEnvio" HeaderText="Dt Envio" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/Professor/AvaliaAtividade.aspx?Id={0}" Text="[Avaliar]" />
        </Columns>
    </asp:GridView>

</asp:Content>
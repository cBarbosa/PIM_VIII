<%@ Page Title="Página Principal" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PIM_VIII._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
   <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>Projeto TCC.</h2>
    </hgroup>

    <article>
        <p>        
            use esta área para informações adicionais do projeto
        </p>

        <p>        
            Use this area to provide additional information.
        </p>

        <p>        
            Use this area to provide additional information.
        </p>
    </article>

    <aside>
        <h3>você pode:</h3>
        <p>        
            Lista de tarefas liberadas a voce.
        </p>
        <ul>
            <li><a runat="server" href="About.aspx">Sobre</a></li>
            <li><a runat="server" href="~/Atendente/CadastrarAluno.aspx">Aluno</a></li>
        </ul>
    </aside>
</asp:Content>

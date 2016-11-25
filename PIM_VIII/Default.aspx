<%@ Page Title="Página Principal" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PIM_VIII._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
   <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>Projeto PIM VIII.</h2>
    </hgroup>

    <article>
        <h1>Sobre a Educação a Distância</h1>
        <h2>A UNIVERSIDADE PAULISTA VAI ATÉ VOCÊ</h2>
        <p>
            A Universidade Paulista – UNIP é  uma das maiores e mais conceituadas instituições de ensino superior do País,  e  possui  uma posição consolidada  na Educação a Distância - EaD.
            Parte de um dos mais prestigiados grupos educacionais do Brasil, o OBJETIVO, conta com a tradição e a experiência de mais de 50 anos dedicados à oferta de educação de qualidade.
        </p>

    </article>
    
    <aside>
        <!--
        <h3>você pode:</h3>
        <p>        
            Lista de tarefas liberadas a voce.
        </p>
        <ul>
            <li><a runat="server" href="About.aspx">Sobre</a></li>
            <li><a runat="server" href="~/Atendente/CadastrarAluno.aspx">Aluno</a></li>
        </ul>
        -->
    </aside>
</asp:Content>

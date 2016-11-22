<%@ Page Title="Sobre" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="PIM_VIII.About" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>Descrição da página.</h2>
    </hgroup>

    <article>
        <p>
            Use esta área para prover informações adicionais.       
        </p>

    </article>

    <aside>
        <h3>Recentes</h3>
        <p>        
            Use está área para prover informações adicionais.
        </p>
        <ul>
            <li><a runat="server" href="~/">Home</a></li>
            <li><a runat="server" href="~/About.aspx">Sobre</a></li>
            <!--
            <li><a runat="server" href="~/Contact.aspx">Contact</a></li>
            -->
        </ul>
    </aside>
</asp:Content>
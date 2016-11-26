<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PIM_VIII.Account.Login" %>
<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %></h1>
    </hgroup>
    <section id="loginForm">
        <h2>Use a matrícula para fazer o login.</h2>
        <asp:Login runat="server" ViewStateMode="Disabled" RenderOuterTable="false" ID="login1" DestinationPageUrl="~/Default.aspx" OnAuthenticate="login1_Authenticate">
            <LayoutTemplate>
                <p class="validation-summary-errors">
                    <asp:Literal runat="server" ID="FailureText" />
                </p>
                <fieldset>
                    <legend>Entrada</legend>
                    <ol>
                        <li>
                            <asp:Label runat="server" AssociatedControlID="UserName">Matrícula</asp:Label>
                            <asp:TextBox runat="server" ID="UserName" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName" CssClass="field-validation-error" ErrorMessage="A matrícula é obrigatória" />
                        </li>
                        <li>
                            <asp:Label runat="server" AssociatedControlID="Password">Senha</asp:Label>
                            <asp:TextBox runat="server" ID="Password" TextMode="Password" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="field-validation-error" ErrorMessage="A senha é obrigatória" />
                        </li>
                        <!--
                        <li>
                            <asp:CheckBox runat="server" ID="RememberMe" />
                            <asp:Label runat="server" AssociatedControlID="RememberMe" CssClass="checkbox">Lembrar senha?</asp:Label>
                        </li>
                        -->
                    </ol>
                    <asp:Button runat="server" CommandName="Login" Text="Logar" />
                </fieldset>
            </LayoutTemplate>
        </asp:Login>
        <!--
        <p>
            <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Register</asp:HyperLink>
            if you don't have an account.
        </p>
        -->
    </section>

    <!--
    <section id="socialLoginForm">
        <h2>Use another service to log in.</h2>
        <uc:OpenAuthProviders runat="server" ID="OpenAuthLogin" />
    </section>
    -->
</asp:Content>

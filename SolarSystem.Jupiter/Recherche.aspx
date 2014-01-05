<%@ Page Title="Recherche - EPSILab, le laboratoire Microsoft de l'EPSI" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Recherche.aspx.cs" Inherits="SolarSystem.Jupiter.Recherche" %>

<%-- Head content --%>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" src="Scripts/Recherche.js"></script>
    <link rel="stylesheet" type="text/css" href="Styles/Recherche.css" />
</asp:Content>

<%-- Body content --%>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    Recherche

    <h1>Résultats de la recherche pour : "<asp:Label runat="server" ID="labelRecherche" />"</h1>
    <br />

    <asp:Panel runat="server" ID="panelNoResults" CssClass="no_resultats">
        *** Veuillez entrer un ou plusieurs termes de recherche ***
    </asp:Panel>

    <asp:Panel runat="server" ID="panelResults" Visible="false">

        <%-- News results --%>
        <h2>
            <asp:Label runat="server" ID="labelNewsCount" Text="0" />
            résultats parmi les actualités
        </h2>

        <asp:Repeater runat="server" ID="repeaterNews">
            <HeaderTemplate>
                <ul>
            </HeaderTemplate>
            <ItemTemplate>
                <li>
                    <a class="titre" href="Actualites-<%# Eval("Code_News") %>-<%# Eval("Url") %>.aspx">
                        <%# Eval("Titre") %>
                    </a>
                    (<span class="date"><%# Eval("Date_Heure", "{0:d à HH:mm}")%></span>)
                </li>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>

        <%-- Conferences results --%>
        <h2>
            <asp:Label runat="server" ID="labelConferencesCount" Text="0" />
            résultats parmi les conférences
        </h2>
        <asp:Repeater runat="server" ID="repeaterConferences">
            <HeaderTemplate>
                <ul>
            </HeaderTemplate>
            <ItemTemplate>
                <li>
                    <a class="titre" href="Conferences-<%# Eval("Code_Conference") %>-<%# Eval("Url") %>.aspx">
                        <%# Eval("Nom") %>
                    </a>
                    <span class="date">( du <%# Eval("Date_Heure_Debut", "{0:dd/MM/yyyy HH:mm}")%>
                        au <%# Eval("Date_Heure_Fin", "{0:dd/MM/yyyy HH:mm}")%>
                        - <%# Eval("Lieu")%>)
                    </span>
                </li>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>

        <%-- Shows results --%>
        <h2>
            <asp:Label runat="server" ID="labelShowsCount" Text="0" />
            résultats parmi les salons
        </h2>
        <asp:Repeater runat="server" ID="repeaterShows">
            <HeaderTemplate>
                <ul>
            </HeaderTemplate>
            <ItemTemplate>
                <li>
                    <a class="titre" href="Salons-<%# Eval("Code_Salon") %>-<%# Eval("Url") %>.aspx">
                        <%# Eval("Nom") %>
                    </a>
                    <span class="date">( du <%# Eval("Date_Heure_Debut", "{0:dd/MM/yyyy HH:mm}")%>
                        au <%# Eval("Date_Heure_Fin", "{0:dd/MM/yyyy HH:mm}")%>
                        - <%# Eval("Lieu")%>)
                    </span>
                </li>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>

        <%-- Members results --%>
        <h2>
            <asp:Label runat="server" ID="labelMembersCount" Text="0" />
            résultats parmi les membres
        </h2>
        <asp:Repeater runat="server" ID="repeaterMembers">
            <HeaderTemplate>
                <ul>
            </HeaderTemplate>
            <ItemTemplate>
                <li>
                    <a class="titre" href="Membres-<%# Eval("Code_Membre") %>-<%# Eval("Url") %>.aspx">
                        <%# Eval("Prenom") %> <%# Eval("Nom") %>
                    </a>
                </li>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>
    </asp:Panel>
</asp:Content>
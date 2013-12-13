<%@ Page Title="Recherche - EPSILab, le laboratoire Microsoft de l'EPSI" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Recherche.aspx.cs" Inherits="EPSILab.Jupiter.Recherche" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" src="Scripts/Recherche.js"></script>
    <link rel="stylesheet" type="text/css" href="Styles/Recherche.css" />
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    Recherche

    <h1>Résultats de la recherche pour : "<asp:Label runat="server" ID="lblRecherche" />"</h1>
    <br />

    <asp:Panel runat="server" ID="panelNoResultats" CssClass="no_resultats">
        *** Veuillez entrer un ou plusieurs termes de recherche ***
    </asp:Panel>

    <asp:Panel runat="server" ID="panelResultats" Visible="false">
        <h2>
            <asp:Label runat="server" ID="lblNombreNews" Text="0" /> résultats parmi les actualités
        </h2>
        <asp:Repeater runat="server" ID="rptNews">
            <HeaderTemplate>
                <ul>
            </HeaderTemplate>
            <ItemTemplate>
                <li>
                    <a class="titre" href="Actualites-<%# Eval("Code_News") %>-<%# Eval("Url") %>.aspx">
                        <%# Eval("Titre") %>
                    </a>
                    (<span class="date"><%# Eval("Date_Heure", "{0:dd MMMM yyyy à HH:mm}")%></span>)
                </li>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>
        <h2>
            <asp:Label runat="server" ID="lblNombreConferences" Text="0" /> résultats parmi les conférences
        </h2>
        <asp:Repeater runat="server" ID="rptConferences">
            <HeaderTemplate>
                <ul>
            </HeaderTemplate>
            <ItemTemplate>
                <li>
                    <a class="titre" href="Conferences-<%# Eval("Code_Conference") %>-<%# Eval("Url") %>.aspx">
                        <%# Eval("Nom") %>
                    </a>
                    <span class="date">
                        ( du <%# Eval("Date_Heure_Debut", "{0:dd/MM/yyyy HH:mm}")%>
                        au <%# Eval("Date_Heure_Fin", "{0:dd/MM/yyyy HH:mm}")%>
                        - <%# Eval("Lieu")%>)
                    </span>
                </li>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>
        <h2>
            <asp:Label runat="server" ID="lblNombreSalons" Text="0" /> résultats parmi les salons
        </h2>
        <asp:Repeater runat="server" ID="rptSalons">
            <HeaderTemplate>
                <ul>
            </HeaderTemplate>
            <ItemTemplate>
                <li>
                    <a class="titre" href="Salons-<%# Eval("Code_Salon") %>-<%# Eval("Url") %>.aspx">
                        <%# Eval("Nom") %>
                    </a>
                    <span class="date">
                        ( du <%# Eval("Date_Heure_Debut", "{0:dd/MM/yyyy HH:mm}")%>
                        au <%# Eval("Date_Heure_Fin", "{0:dd/MM/yyyy HH:mm}")%>
                        - <%# Eval("Lieu")%>)
                    </span>
                </li>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>
        <h2>
            <asp:Label runat="server" ID="lblNombreMembres" Text="0" /> résultats parmi les membres
        </h2>
        <asp:Repeater runat="server" ID="rptMembres">
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

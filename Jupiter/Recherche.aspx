<%@ Page Title="Recherche - EPSILab, le laboratoire Microsoft de l'EPSI" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Recherche.aspx.cs" Inherits="EPSILab.SolarSystem.Jupiter.Recherche" %>

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
                    <a class="title" href="News-<%# Eval("Id") %>-<%# Eval("Url") %>.aspx">
                        <%# Eval("Title") %>
                    </a>
                    (<span class="date"><%# Eval("DateTime", "{0:d à HH:mm}")%></span>)
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
                    <a class="title" href="Conferences-<%# Eval("Id") %>-<%# Eval("Url") %>.aspx">
                        <%# Eval("LastName") %>
                    </a>
                    <span class="date">( du <%# Eval("Start_DateTime", "{0:dd/MM/yyyy HH:mm}")%>
                        au <%# Eval("End_DateTime", "{0:dd/MM/yyyy HH:mm}")%>
                        - <%# Eval("Place")%>)
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
            résultats parmi les Shows
        </h2>
        <asp:Repeater runat="server" ID="repeaterShows">
            <HeaderTemplate>
                <ul>
            </HeaderTemplate>
            <ItemTemplate>
                <li>
                    <a class="title" href="Shows-<%# Eval("Id") %>-<%# Eval("Url") %>.aspx">
                        <%# Eval("LastName") %>
                    </a>
                    <span class="date">( du <%# Eval("Start_DateTime", "{0:dd/MM/yyyy HH:mm}")%>
                        au <%# Eval("End_DateTime", "{0:dd/MM/yyyy HH:mm}")%>
                        - <%# Eval("Place")%>)
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
                    <a class="title" href="Members-<%# Eval("Id") %>-<%# Eval("Url") %>.aspx">
                        <%# Eval("FirstName") %> <%# Eval("LastName") %>
                    </a>
                </li>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>
    </asp:Panel>
</asp:Content>
<%@ Page Title="Actualités - EPSILab, le laboratoire Microsoft de l'EPSI" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Actualites.aspx.cs" Inherits="SolarSystem.Jupiter.Actualites" %>

<%-- Head content --%>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <asp:Literal ID="metaDescription" runat="server" Text='<meta name="description" content="Retrouvez les actualités des nouveaux produits et technologies Microsoft." />' />
    <asp:Literal ID="metaKeywords" runat="server" />
    <asp:Literal ID="metaAuthor" runat="server" />
    <link rel="stylesheet" type="text/css" href="Styles/Actualites.css" />
    <script type="text/javascript" src="http://w.sharethis.com/button/buttons.js"></script>
    <script type="text/javascript" src="Scripts/jquery.touchSwipe.min.js"></script>
    <script type="text/javascript" src="Scripts/jquery.carouFredSel-6.2.1-packed.js"></script>
    <script type="text/javascript" src="Scripts/Actualites.js"></script>
</asp:Content>

<%-- Body content --%>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <a href="Actualites.aspx">Actualités</a>

    <%-- One news --%>
    <asp:Panel runat="server" ID="panelNews" Visible="false">
        <div>&nbsp;</div>

        <div class="templateTitle">
            <div class="image">
                <asp:Image runat="server" ID="imgNews" Height="100" Width="100" />
            </div>
            <h1>
                <asp:Label runat="server" ID="labelTitle" />
            </h1>
            <div class="date">
                <asp:Label runat="server" ID="labelDateTime" />
            </div>
            <div class="date">
                par
                <asp:HyperLink runat="server" ID="linkAuthor" CssClass="titre" />
            </div>
        </div>
        <div class="social">
            <span class='st_facebook_large' displaytext='Facebook'></span>
            <span class='st_twitter_large' displaytext='Twitter'></span>
            <span class='st_viadeo_large' displaytext='Viadeo'></span>
            <span class='st_linkedin_large' displaytext='LinkedIn'></span>
            <span class='st_email_large' displaytext='Email'></span>
        </div>
        <div class="keywords">
            Mots-clés:
            <asp:Repeater runat="server" ID="repeaterKeywords">
                <ItemTemplate>
                    <a href="Recherche.aspx?mots=<%# Container.DataItem %>"><%# Container.DataItem %></a>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div>
            <asp:Label runat="server" ID="labelTexteLong" />
        </div>
    </asp:Panel>

    <%-- News list --%>
    <asp:ListView runat="server" ID="listviewNews" ItemPlaceholderID="phNews" OnPreRender="listviewNews_PreRender">
        <LayoutTemplate>
            <h1>Nos actualités</h1>

            <%-- Pagination system --%>
            <div class="paginationNews" id="news_pag"></div>

            <%-- Prevents display problems --%>
            <div class="clearfix"></div>

            <div id="NewsInternCarousel">
                <asp:PlaceHolder runat="server" ID="phNews" />
            </div>

            <%-- Prevents display problems --%>
            <div class="clearfix"></div>

            <%-- Pagination system --%>
            <div class="paginationNews" id="news_pag2"></div>
        </LayoutTemplate>
        <ItemTemplate>
            <article class="news">
                <a class="lienNews" href="Actualites-<%# Eval("Code_News") %>-<%# Eval("Url") %>.aspx">
                    <img class="image" src="<%# Eval("Image") %>" alt="<%# Eval("Titre") %>" title="<%# Eval("Titre") %>" width="70" height="70" />

                    <div class="titreNews">
                        <%# Eval("Titre") %>
                    </div>

                    <div class="date">
                        par
                        <%# Eval("Membre.Prenom") %> <%# Eval("Membre.Nom") %>,
                        <%# Eval("Date_Heure", "{0:f}")%>
                    </div>

                    <div class="description">
                        <%# Eval("Texte_Court") %>
                    </div>
                </a>
            </article>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
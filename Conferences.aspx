<%@ Page Title="Conférences - EPSILab, le laboratoire Microsoft de l'EPSI" Language="C#"
    MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Conferences.aspx.cs"
    Inherits="EPSILab.Jupiter.Conferences" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
    <asp:Literal ID="metaDescription" runat="server" Text='<meta name="description" content="Retrouvez les conférences que nous organisons pour les étudiants dans chaque école." />' />
    <script type="text/javascript" src="Scripts/Conferences.js"></script>
    <script type="text/javascript" src="http://w.sharethis.com/button/buttons.js"></script>
    <script type="text/javascript" src="Scripts/ShareThis.js"></script>
    <script type="text/javascript" src="Scripts/jquery.touchSwipe.min.js"></script>
    <script type="text/javascript" src="Scripts/jquery.carouFredSel-6.2.1-packed.js"></script>
    <link rel="stylesheet" type="text/css" href="Styles/Conferences.css" />
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <a href="Evenements.aspx">Evènements</a>
    &gt;
    <a href="Conferences.aspx">Conférences</a>
    
    <!-- Affichage d'une conférence -->
    <asp:Panel runat="server" ID="panelConference" Visible="false">
        <div>&nbsp;</div>

        <div class="templateTitle">
            <div class="image">
                <asp:Image runat="server" ID="imgConference" Height="100" Width="100" />
            </div>
            <h1>
                <asp:Label runat="server" ID="lblNom" />
            </h1>
            <div class="date">
                <asp:Label runat="server" ID="lblDateHeure" />
            </div>
            <div class="date">
                <asp:Label runat="server" ID="lblLieu" />
                (EPSI
            <asp:Label runat="server" ID="lblVille" />)
            </div>
        </div>

        <div class="social">
            <span class='st_facebook_large' displaytext='Facebook'></span>
            <span class='st_twitter_large' displaytext='Tweet'></span>
            <span class='st_viadeo_large' displaytext='Viadeo'></span>
            <span class='st_linkedin_large' displaytext='LinkedIn'></span>
            <span class='st_email_large' displaytext='Email'></span>
        </div>
        <br />
        <div class="texte">
            <asp:Label runat="server" ID="lblDescription" />
        </div>
    </asp:Panel>
    
    <!-- Liste des conférences -->
    <asp:ListView runat="server" ID="lvConferences" ItemPlaceholderID="phConferences" OnPreRender="lvConferences_PreRender">
        <LayoutTemplate>
            <h1>Nos conférences</h1>

            <!-- Affiche la navigation au dessus des news -->
            <div class="paginationConferences" id="news_pag"></div>

            <!-- Empêche des problèmes d'affichage : utiliser le clear -->
            <div class="clearfix"></div>

            <div id="ConferencesInternCarousel">
                <asp:PlaceHolder runat="server" ID="phConferences" />
            </div>

            <!-- Empêche des problèmes d'affichage : utiliser le clear -->
            <div class="clearfix"></div>

            <!-- Affiche la navigation en dessous des news -->
            <div class="paginationConferences" id="news_pag2"></div>
        </LayoutTemplate>
        <ItemTemplate>
            <article class="conference">
                <a class="lienConference" href="Conferences-<%# Eval("Code_Conference") %>-<%# Eval("Url") %>.aspx">
                    <img class="imageConference" src="<%# Eval("Image") %>" alt="<%# Eval("Nom") %>" title="<%# Eval("Nom") %>" width="70" height="70" />

                    <div class="nomConference">
                        <%# Eval("Nom") %>
                    </div>

                    <div class="date">
                        Le <%# Eval("Date_Heure_Debut", "{0:dd MMMM yyyy}")%> de <%# Eval("Date_Heure_Debut", "{0:HH:mm}")%>
                        à  <%# Eval("Date_Heure_Fin", "{0:HH:mm}")%>
                    </div>

                    <div class="date">
                        <%# Eval("Lieu")%>, EPSI (<%# Eval("Ville.Libelle")%>)
                    </div>
                </a>
            </article>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>

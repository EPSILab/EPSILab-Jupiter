﻿<%@ Page Title="Salons - EPSILab, le laboratoire Microsoft de l'EPSI" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Salons.aspx.cs" Inherits="SolarSystem.Jupiter.Salons" %>

<%-- Head content --%>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
    <asp:Literal ID="metaDescription" runat="server" Text='<meta name="description" content="Retrouvez la list de toutes les journées portes ouvertes des EPSI." />' />
    <script type="text/javascript" src="Scripts/Salons.js"></script>
    <script type="text/javascript" src="http://w.sharethis.com/button/buttons.js"></script>
    <script type="text/javascript" src="Scripts/ShareThis.js"></script>
    <script type="text/javascript" src="Scripts/jquery.touchSwipe.min.js"></script>
    <script type="text/javascript" src="Scripts/jquery.carouFredSel-6.2.1-packed.js"></script>
    <link rel="stylesheet" type="text/css" href="Styles/Salons.css" />
</asp:Content>

<%-- Body content --%>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <a href="Evenements.aspx">Evènements</a>
    &gt;
    <a href="Salons.aspx">Salons</a>
    
    <%-- One show --%>
    <asp:Panel runat="server" ID="panelSalon" Visible="false">
        <div>&nbsp;</div>

        <div class="templateTitle">
            <div class="image">
                <asp:Image runat="server" ID="imageSalon" Height="100" Width="100" />
            </div>
            <h1>
                <asp:Label runat="server" ID="labelName" />
            </h1>
            <div class="date">
                <asp:Label runat="server" ID="labelDateTime" />
            </div>
            <div class="date">
                <asp:Label runat="server" ID="labelPlace" />
            </div>
        </div>

        <div class="social">
            <span class='st_facebook_large' displaytext='Facebook'></span>
            <span class='st_twitter_large' displaytext='Twitter'></span>
            <span class='st_viadeo_large' displaytext='Viadeo'></span>
            <span class='st_linkedin_large' displaytext='LinkedIn'></span>
            <span class='st_email_large' displaytext='Email'></span>
        </div>
        <br />
        <div class="texte">
            <asp:Label runat="server" ID="labelDescription" />
        </div>
    </asp:Panel>

    <%-- Shows list --%>
    <asp:ListView runat="server" ID="listviewSalons" ItemPlaceholderID="phConferences" OnPreRender="listviewSalons_PreRender">
        <LayoutTemplate>
            <h1>Les salons</h1>

            <%-- Pagination system --%>
            <div class="paginationSalons" id="news_pag"></div>

            <%-- Prevents display problems --%>
            <div class="clearfix"></div>

            <div id="SalonsInternCarousel">
                <asp:PlaceHolder runat="server" ID="phConferences" />
            </div>

            <%-- Prevents display problems --%>
            <div class="clearfix"></div>

            <%-- Pagination system --%>
            <div class="paginationSalons" id="news_pag2"></div>
        </LayoutTemplate>
        <ItemTemplate>
            <article class="salon">
                <a class="lienSalon" href="Salons-<%# Eval("Code_Salon") %>-<%# Eval("Url") %>.aspx">
                    <img class="imageSalon" src="<%# Eval("Image") %>" alt="<%# Eval("Nom") %>" title="<%# Eval("Nom") %>" width="70" height="70" />

                    <div class="nomSalon">
                        <%# Eval("Nom") %>
                    </div>

                    <div class="date">
                        Le <%# Eval("Date_Heure_Debut", "{0:d}")%> de <%# Eval("Date_Heure_Debut", "{0:t}")%>
                        au <%# Eval("Date_Heure_Fin", "{0:d}")%> de <%# Eval("Date_Heure_Fin", "{0:t}")%>
                    </div>
                </a>
            </article>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
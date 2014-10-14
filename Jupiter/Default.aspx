<%@ Page Title="EPSILab, le laboratoire Microsoft de l'EPSI" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="EPSILab.SolarSystem.Jupiter.Default" %>

<%-- Head content --%>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <meta name="description" content="Le laboratoire Microsoft dirigé par les étudiants de l'EPSI. Retrouvez nos actualités, nos projects, nos évènements et bien d'autres..." />
    <meta name="keywords" content="epsilab, laboratoire, microsoft, laboratoire, windows, office, visual studio, wpf, wcf, windows phone" />
    <link rel="stylesheet" type="text/css" href="Styles/Default.css" />
    <link rel="stylesheet" type="text/css" href="Styles/coin-slider-styles.css" />
    <script type="text/javascript" src="Scripts/coin-slider.min.js"></script>
    <script type="text/javascript" src="Scripts/jquery.touchSwipe.min.js"></script>
    <script type="text/javascript" src="Scripts/jquery.carouFredSel-6.2.1-packed.js"></script>
    <script type="text/javascript" src="Scripts/Default.js"></script>
</asp:Content>

<%-- Body content --%>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>&nbsp;</div>

    <%-- Ads --%>
    <section id="sectionTemporaryNews" title="TemporaryNews">
        <asp:Repeater runat="server" ID="repeater_TemporaryNews">
            <HeaderTemplate>
                <div id="temporaryNews">
            </HeaderTemplate>
            <ItemTemplate>
                <a href="<%# Eval("Url") %>" target="_blank">
                    <img src="<%# Eval("ImageUrl") %>" alt="<%# Eval("Name") %>" title="<%# Eval("Name") %>" />
                    <span>
                        <strong><%# Eval("Name") %></strong><br />
                        <%# Eval("Presentation") %>
                    </span>
                </a>
            </ItemTemplate>
            <FooterTemplate>
                </div>
            </FooterTemplate>
        </asp:Repeater>
    </section>

    <%-- Last news --%>
    <section title="Dernières actualités">

        <h1>Dernières actualités</h1>

        <asp:Repeater runat="server" ID="repeaterNews">
            <HeaderTemplate>
                <p id="NewsCarousel">
                    <div id="NewsInternCarousel">
            </HeaderTemplate>
            <ItemTemplate>
                <a id="<% Response.Write("NumNews" + IdNews++); %>" class="lienNews" href="Actualites-<%# Eval("Id") %>-<%# Eval("Url") %>.aspx">
                    <article class="news">
                        <img src="<%# Eval("ImageUrl") %>" alt="<%# Eval("Title") %>" title="<%# Eval("Title") %>" />
                        <h2><%# Eval("Title") %></h2>
                    </article>
                </a>
            </ItemTemplate>
            <FooterTemplate>
                    </div>

                <%-- Prevents display problems --%>
                <div class="clearfix"></div>

                <%-- Pagination system --%>
                <div class="paginationNews" id="news_pag"></div>

                </p>
            </FooterTemplate>
        </asp:Repeater>
    </section>

    <article id="presentation">
        <h1>Présentation</h1>
        <p>
            EPSILab est une association étudiante de l'école <a href="http://www.epsi.fr" target="_blank">EPSI</a>
            dont l'objectif est d'étudier et de promouvoir les produits et technologies
            <a href="http://www.microsoft.com/france" target="_blank">Microsoft</a>.
        </p>
        <p style="float: right; margin: 5px">
            <a href="http://www.microsoft.com/france" target="_blank">
                <img id="imgMicrosoft" src="Images/Home/Microsoft.png" alt="Microsoft" title="Le partenariat EPSI-Microsoft remonte à 2004" />
            </a>
        </p>
        <p>
            Depuis sa création, EPSILab s'est ouvert au sein des campus de Paris, Lyon ainsi que de Nantes.
        </p>
        <p>
            Nos activités se concentrent principalement sur la formation des étudiants aux technologies Microsoft ainsi que sur
            l'organisation d'évènements comme des conférences au sein des campus avec des intervenants de Microsoft sur des sujets
            de veille. Nous sommes également présents lors des grands rendez-vous comme les
            <a href="http://www.microsoft.com/france/mstechdays/" target="_blank">TechDays</a> à Paris ou les
            <a href="http://www.microsoft.com/france/microsoft-days/">Microsoft Days</a> en province.
        </p>
        <p style="float: left; margin: 5px">
            <a href="http://www.epsi.fr" target="_blank">
                <img id="imgEPSI" src="Images/Home/EPSI.png" alt="Logo de l'EPSI" />
            </a>
        </p>
        <p>
            Chaque labo est dirigé par des <a href="http://www.microsoft.com/france/etudiants/student-partners/">Microsoft Student Partners</a>.
            Leur mission est d'assurer une continuité dans les activités de l'association ainsi que de renforcer les liens entre l'EPSI et
            Microsoft France.
        </p>
        <p>
            Nous sommes également en partenariat avec le <a href="https://www.facebook.com/polecom.arras" target="_blank">PôleCom</a> de
            l'EPSI Arras. Vous pouvez retrouver certains de nos articles sur les
            <a href="http://www.lavenirdelartois.fr/EPSI/Labo/Microsoft/" target="_blank">sites de presse du Nord-Pas-de-Calais</a>.
        </p>
        <p>
            A ce jour, EPSILab reste actif et concentré particulièrement sur les technologies actuelles telles que Windows 8 et Windows
            Phone, sans oublier également WPF, Kinect, Azure, Silverlight, etc...
        </p>
        <p>
            Nous vous souhaitons une bonne visite sur notre site !
        </p>
    </article>
</asp:Content>
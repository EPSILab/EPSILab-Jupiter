<%@ Page Title="Qui sommes-nous - EPSILab, le laboratoire Microsoft de l'EPSI" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="APropos.aspx.cs" Inherits="EPSILab.Jupiter.APropos" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <meta name="description" content="EPSILab est le laboratoire Microsoft de l'EPSI dans le but de promouvoir les produits et technologies Microsoft auprès des étudiants de l'EPSI. Celui-ci a été crée à Arras en 2004 puis s'est étendu à d'autres écoles du groupe EPSI." />
    <script type="text/javascript" src="Scripts/APropos.js"></script>
    <link rel="stylesheet" type="text/css" href="Styles/APropos.css" />
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    
    <a href="APropos.aspx">A Propos</a>

    <h1>Qui sommes nous ?</h1>
    
    <p>
        EPSILab est le laboratoire Microsoft de l'EPSI dont le but est de promouvoir les produits et technologies Microsoft auprès des étudiants de l'EPSI.
        Celui-ci a été crée à Arras en 2004 puis s'est étendu à d'autres écoles du groupe EPSI.
    </p>

    <p>
        Aujourd'hui, l'association est implantée dans 4 des 9 EPSI de France:  Arras, Paris, Nantes et Lyon.
    </p>

    <h2>Réalisation du site:</h2>
    <div>Version: 3.5 (Livraison juillet 2013)</div>
    <div>
        Responsable du projet: <a href="Membres-1-jean-baptiste-vigneron.aspx">Jean-Baptiste Vigneron</a>
    </div>
    <div>
        Développement:
        <a href="Membres-44-david-bottiau.aspx">David Bottiau</a>
        ,
        <a href="Membres-39-nicolas-janssoone.aspx">Nicolas Janssoone</a>
        et
        <a href="Membres-43-paul-guilbert.aspx">Paul Guilbert</a>
    </div>
    <h2>L'EPSI:</h2>
    <div>
        L'<a href="http://www.epsi.fr">EPSI (Ecole Privée des Sciences Informatiques)</a> est une école privée
        qui propose une formation en ingénierie informatique (BAC+5) et est implantée dans 9 endroits en France:
        Paris, Bordeaux, Montpellier, Arras, Nantes, Lyon, Amiens, Lille et Grenoble. 
        Elle forme des spécialistes de haut niveau en ingénierie informatique en s’adaptant de manière permanente 
        aux réalités du marché.
        De ce fait, l'EPSI offre des qualifications répondant précisément aux offres professionnelles.
    </div>

    <h2>Hébergement:</h2>
    <div>
        Le site est hébergé chez <a href="http://www.ikoula.com">Ikoula</a>,
        hébergeur partenaire de <a href="http://www.microsoft.fr">Microsoft.</a>
    </div>
</asp:Content>

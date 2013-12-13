<%@ Page Title="Nos événements - EPSILab, le laboratoire Microsoft de l'EPSI" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Evenements.aspx.cs" Inherits="EPSILab.Jupiter.Evenements" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
    <meta name="description" content="La liste de nos conférences, des salons et de nos journées portes ouvertes." />
    <script type="text/javascript" src="Scripts/Evenements.js"></script>
    <link rel="stylesheet" type="text/css" href="Styles/Evenements.css" />
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <a href="Evenements.aspx">Evènements</a>

    <h1>Les événements</h1>
    <br />

    <!-- Affichage des conférences -->
    <h2>Nos dernières conférences</h2>

    <asp:Repeater ID="rptConferences" runat="server">
        <ItemTemplate>
            <a class="blocConferences" href="Conferences-<%# Eval("Code_Conference") %>-<%# Eval("Url") %>.aspx">
                <img class="photoElement" src="<%# Eval("Image") %>" alt="<%# Eval("Nom") %>" width="75" height="75" />
                <span class="descElement">
                    <span class="nom">
                        <%# Eval("Nom") %>
                    </span>
                    <br />
                    le <%# Eval("Date_Heure_Debut", "{0:dd MMMM yyyy}")%>
                        de <%# Eval("Date_Heure_Debut", "{0:HH:mm}")%>
                        à <%# Eval("Date_Heure_Fin", "{0:HH:mm}")%>
                    <br />
                    <%# Eval("Lieu")%>, EPSI <%# Eval("Ville.Libelle")%>
                </span>

            </a>
        </ItemTemplate>
    </asp:Repeater>
    <br />
    <div class="lien">
        <a href="Conferences.aspx">-&gt; Voir la liste de toutes nos conférences</a>
    </div>

    <p>&nbsp;</p>

    <!-- Affichage des salons -->
    <h2>Les derniers salons</h2>

    <asp:Repeater ID="rptSalons" runat="server">
        <ItemTemplate>
            <a class="blocSalons" href="Salons-<%# Eval("Code_Salon") %>-<%# Eval("Url") %>.aspx">
                <span class="descElement">
                    <span class="nom">
                        <%# Eval("Nom") %>
                    </span>
                    <br />
                    le <%# Eval("Date_Heure_Debut", "{0:dd MMMM yyyy}")%>
                        de <%# Eval("Date_Heure_Debut", "{0:HH:mm}")%>
                        au  <%# Eval("Date_Heure_Fin", "{0:dd MMMM yyyy}")%>
                    <%# Eval("Date_Heure_Fin", "{0:HH:mm}")%>
                    <br />
                    <%# Eval("Lieu")%>
                </span>
                <img class="photoElement" src="<%# Eval("Image") %>" alt="<%# Eval("Nom") %>" width="75" height="75" />
            </a>
        </ItemTemplate>
    </asp:Repeater>
    <br />
    <div class="lien">
        <a href="Salons.aspx">-&gt; Voir l'ensemble des salons</a>
    </div>
</asp:Content>

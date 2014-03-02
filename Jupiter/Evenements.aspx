<%@ Page Title="Nos événements - EPSILab, le laboratoire Microsoft de l'EPSI" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Evenements.aspx.cs" Inherits="EPSILab.SolarSystem.Jupiter.Evenements" %>

<%-- Head content --%>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
    <meta name="description" content="La liste de nos conférences et des salons Microsoft." />
    <script type="text/javascript" src="Scripts/Evenements.js"></script>
    <link rel="stylesheet" type="text/css" href="Styles/Evenements.css" />
</asp:Content>

<%-- Body content --%>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <a href="Evenements.aspx">Evènements</a>

    <h1>Les événements</h1>
    <br />

    <%-- Last conferences --%>
    <h2>Nos dernières conférences</h2>

    <asp:Repeater ID="repeaterConferences" runat="server">
        <ItemTemplate>
            <a class="blocConferences" href="Conferences-<%# Eval("Id") %>-<%# Eval("Url") %>.aspx">
                <img class="photoElement" src="<%# Eval("ImageUrl") %>" alt="<%# Eval("Name") %>" width="75" height="75" />
                <span class="descElement">
                    <span class="nom">
                        <%# Eval("Name") %>
                    </span>
                    <br />
                    le <%# Eval("Start_DateTime", "{0:d}")%>
                        de <%# Eval("Start_DateTime", "{0:t}")%>
                        à <%# Eval("End_DateTime", "{0:t}")%>
                    <br />
                    <%# Eval("Place")%>, EPSI <%# Eval("Campus.Place")%>
                </span>

            </a>
        </ItemTemplate>
    </asp:Repeater>
    <br />
    <div class="lien">
        <a href="Conferences.aspx">-&gt; Voir la liste de toutes nos conférences</a>
    </div>

    <p>&nbsp;</p>

    <%-- Last shows --%>
    <h2>Les derniers salons</h2>

    <asp:Repeater ID="repeaterShows" runat="server">
        <ItemTemplate>
            <a class="blocSalons" href="Salons-<%# Eval("Id") %>-<%# Eval("Url") %>.aspx">
                <span class="descElement">
                    <span class="nom">
                        <%# Eval("Name") %>
                    </span>
                    <br />
                    le <%# Eval("Start_DateTime", "{0:d}")%>
                        de <%# Eval("Start_DateTime", "{0:t}")%>
                        au  <%# Eval("End_DateTime", "{0:d}")%>
                    <%# Eval("End_DateTime", "{0:t}")%>
                    <br />
                    <%# Eval("Place")%>
                </span>
                <img class="photoElement" src="<%# Eval("ImageUrl") %>" alt="<%# Eval("Name") %>" width="75" height="75" />
            </a>
        </ItemTemplate>
    </asp:Repeater>
    <br />
    <div class="lien">
        <a href="Salons.aspx">-&gt; Voir l'ensemble des salons</a>
    </div>
</asp:Content>
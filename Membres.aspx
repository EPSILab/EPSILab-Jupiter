<%@ Page Title="Membres - EPSILab, le laboratoire Microsoft de l'EPSI" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Membres.aspx.cs" Inherits="EPSILab.Jupiter.Membres" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
    <asp:Literal ID="metaDescription" runat="server" Text='<meta name="description" content="Voici les membres qui composent EPSILab à ce jour." />' />
    <script type="text/javascript" src="Scripts/Membres.js"></script>
    <link rel="stylesheet" type="text/css" href="Styles/Membres.css" />
</asp:Content>

<asp:Content ID="CNT_ListeMembres" ContentPlaceHolderID="MainContent" runat="server">

    <a href="Membres.aspx">Membres</a>

    <!-- Affichage d'un seul membre -->
    <asp:Panel runat="server" CssClass="membre" ID="panelMembre">
        <div>&nbsp;</div>

        <div class="templateTitle">
            <div id="image">
                <asp:Image runat="server" ID="imgMembre" Width="100" Height="100" />
            </div>
            <h1 id="nom_prenom">
                <asp:Label runat="server" ID="lblPrenom" />
                <asp:Label runat="server" ID="lblNom" />
            </h1>
            <div>
                <asp:Label runat="server" ID="lblStatut" />
            </div>
            <div>
                <asp:Label runat="server" ID="lblPromo" />, EPSI
                <asp:Label runat="server" ID="lblVille" />
            </div>
            <div>
                de
                <asp:HyperLink runat="server" ID="lnkVilleOrigine" CssClass="titre" Target="_blank" />
            </div>
        </div>

        <div class="presentation">
            <asp:Label runat="server" ID="lblPresentation" />
        </div>

        <div>&nbsp;</div>

        <div id="reseauxSociaux">
            <asp:HyperLink runat="server" ID="lnkWebsite" Visible="false" Target="_blank">
                <img src="Images/Website.png" width="50" height="50" class="image_social" alt="Voir le site web" title="Voir le site web" />
            </asp:HyperLink>

            <asp:HyperLink runat="server" ID="lnkFacebook" Visible="false" Target="_blank">
                <img src="Images/SocialFacebook.png" width="50" height="50" class="image_social" alt="Page Facebook" title="Page Facebook" />
            </asp:HyperLink>

            <asp:HyperLink runat="server" ID="lnkTwitter" Visible="false" Target="_blank">
                <img src="Images/SocialTwitter.png" width="50" height="50" class="image_social" alt="Page Twitter" title="Page Twitter" />
            </asp:HyperLink>

            <asp:HyperLink runat="server" ID="lnkLinkedIn" Visible="false" Target="_blank">
                <img src="Images/SocialLinkedIn.png" width="50" height="50" class="image_social" alt="Profil LinkedIn" title="Profil LinkedIn" />
            </asp:HyperLink>

            <asp:HyperLink runat="server" ID="lnkViadeo" Visible="false" Target="_blank">
                <img src="Images/SocialViadeo.png" width="50" height="50" class="image_social" alt="Profil Viadeo" title="Profil Viadeo" />
            </asp:HyperLink>
        </div>
    </asp:Panel>

    <!-- Affichage de l'ensemble du bureau et des membres par ville -->
    <asp:Panel ID="panelMembres" runat="server">
        <h1>Bureau et membres</h1>
        <br />

        <asp:Repeater ID="rptVilles" runat="server" OnItemDataBound="prtVilles_ItemDataBound">
            <ItemTemplate>
                <div class="ville">
                    <h2 class="titreVille"><%# Eval("Libelle") %></h2>
                    <div class="listeBureau">
                        <h3 class="titreListe">Bureau</h3>
                        <asp:Repeater ID="rptBureau" runat="server">
                            <ItemTemplate>
                                <a class="blocMembre" href="Membres-<%# Eval("Code_Membre") %>-<%# Eval("Url") %>.aspx">
                                    <img class="photoMembre" src="<%# Eval("Image") %>" alt="<%# Eval("Prenom") %> <%# Eval("Nom") %>" width="75" height="75" />
                                    <span class="descMembre">
                                        <span class="nomMembre">
                                            <%# Eval("Prenom") %> <%# Eval("Nom") %>
                                        </span>
                                        <br />
                                        <%# Eval("Statut") %>
                                    </span>
                                </a>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>

                    <div class="listeMembres">
                        <h3 class="titreListe">Membres</h3>
                        <asp:Repeater ID="rptMembres" runat="server">
                            <ItemTemplate>
                                <a class="blocMembre" href="Membres-<%# Eval("Code_Membre") %>-<%# Eval("Url") %>.aspx">
                                    <img class="photoMembre" src="<%# Eval("Image") %>" alt="<%# Eval("Prenom") %> <%# Eval("Nom") %>" width="75" height="75" />
                                    <span class="descMembre">
                                        <span class="nomMembre">
                                            <%# Eval("Prenom") %> <%# Eval("Nom") %>
                                        </span>
                                    </span>
                                </a>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </asp:Panel>
</asp:Content>

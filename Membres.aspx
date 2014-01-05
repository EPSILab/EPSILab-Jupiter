<%@ Page Title="Membres - EPSILab, le laboratoire Microsoft de l'EPSI" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Membres.aspx.cs" Inherits="SolarSystem.Jupiter.Membres" %>

<%-- Head content --%>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
    <asp:Literal ID="metaDescription" runat="server" Text='<meta name="description" content="Voici les membres qui composent EPSILab à ce jour." />' />
    <script type="text/javascript" src="Scripts/Membres.js"></script>
    <link rel="stylesheet" type="text/css" href="Styles/Membres.css" />
</asp:Content>

<%-- Body content --%>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <a href="Membres.aspx">Membres</a>

    <%-- One member's informations --%>
    <asp:Panel runat="server" CssClass="membre" ID="panelMembre">
        <div>&nbsp;</div>

        <div class="templateTitle">
            <div id="image">
                <asp:Image runat="server" ID="imageMembre" Width="100" Height="100" />
            </div>
            <h1 id="nom_prenom">
                <asp:Label runat="server" ID="labelName" />
            </h1>
            <div>
                <asp:Label runat="server" ID="labelStatus" />
            </div>
            <div>
                <asp:Label runat="server" ID="labelEPSI" />
            </div>
            <div>
                de
                <asp:Label runat="server" ID="labelCityFrom" CssClass="titre" />
            </div>
        </div>

        <div class="presentation">
            <asp:Label runat="server" ID="labelPresentation" />
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

    <%-- Memebrs list by cities --%>
    <asp:Panel ID="panelMembres" runat="server">
        <h1>Bureau et membres</h1>
        <br />

        <asp:Repeater ID="repeaterVilles" runat="server" OnItemDataBound="repeaterVilles_ItemDataBound">
            <ItemTemplate>
                <div class="ville">
                    <h2 class="titreVille"><%# Eval("Libelle") %></h2>

                    <asp:Repeater ID="repeaterBureau" runat="server">
                        <HeaderTemplate>
                            <div class="listBureau">
                                <h3 class="titreListe">Bureau</h3>
                        </HeaderTemplate>
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
                        <FooterTemplate>
                            </div>
                        </FooterTemplate>
                    </asp:Repeater>

                    <asp:Repeater ID="repeaterOthers" runat="server">
                        <HeaderTemplate>
                            <div class="listMembres">
                                <h3 class="titreListe">Membres</h3>
                        </HeaderTemplate>
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
                        <FooterTemplate>
                            </div>
                        </FooterTemplate>
                    </asp:Repeater>

                    <asp:Repeater ID="repeaterAlumnis" runat="server">
                        <HeaderTemplate>
                            <div class="listAlumnis">
                                <h3 class="titreListe">Anciens</h3>
                        </HeaderTemplate>
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
                        <FooterTemplate>
                            </div>
                        </FooterTemplate>
                    </asp:Repeater>

                </div>
            </ItemTemplate>
        </asp:Repeater>
    </asp:Panel>
</asp:Content>

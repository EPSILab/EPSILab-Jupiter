<%@ Page Title="Membres - EPSILab, le laboratoire Microsoft de l'EPSI" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Membres.aspx.cs" Inherits="EPSILab.SolarSystem.Jupiter.Membres" %>

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
    <asp:Panel runat="server" CssClass="member" ID="panelMember">
        <div>&nbsp;</div>

        <div class="templateTitle">
            <div id="image">
                <asp:Image runat="server" ID="imageMember" Width="100" Height="100" />
            </div>
            <h1 id="lastname_firstname">
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
                <asp:Label runat="server" ID="labelCityFrom" CssClass="title" />
            </div>
        </div>

        <div class="presentation">
            <asp:Label runat="server" ID="labelPresentation" />
        </div>

        <div>&nbsp;</div>

        <div id="socialNetworks">
            <asp:HyperLink runat="server" ID="lnkWebsite" Visible="false" Target="_blank">
                <img src="Images/Social/Website.png" width="50" height="50" class="image_social" alt="Voir le site web" title="Voir le site web" />
            </asp:HyperLink>

            <asp:HyperLink runat="server" ID="lnkFacebook" Visible="false" Target="_blank">
                <img src="Images/Social/Facebook.png" width="50" height="50" class="image_social" alt="Page Facebook" title="Page Facebook" />
            </asp:HyperLink>

            <asp:HyperLink runat="server" ID="lnkTwitter" Visible="false" Target="_blank">
                <img src="Images/Social/Twitter.png" width="50" height="50" class="image_social" alt="Page Twitter" title="Page Twitter" />
            </asp:HyperLink>

            <asp:HyperLink runat="server" ID="lnkLinkedIn" Visible="false" Target="_blank">
                <img src="Images/Social/LinkedIn.png" width="50" height="50" class="image_social" alt="Profil LinkedIn" title="Profil LinkedIn" />
            </asp:HyperLink>

            <asp:HyperLink runat="server" ID="lnkViadeo" Visible="false" Target="_blank">
                <img src="Images/Social/Viadeo.png" width="50" height="50" class="image_social" alt="Profil Viadeo" title="Profil Viadeo" />
            </asp:HyperLink>
            
            <asp:HyperLink runat="server" ID="lnkGitHub" Visible="false" Target="_blank">
                <img src="Images/Social/GitHub.png" width="50" height="50" class="image_social" alt="Profil Viadeo" title="Profil GitHub" />
            </asp:HyperLink>
        </div>
    </asp:Panel>

    <%-- Memebrs list by cities --%>
    <asp:Panel ID="panelMembers" runat="server">
        <h1>Bureau et membres</h1>
        <br />

        <asp:Repeater ID="repeaterCampuses" runat="server" OnItemDataBound="repeaterCampuses_ItemDataBound">
            <ItemTemplate>
                <div class="campus">
                    <h2 class="titleCampus"><%# Eval("Place") %></h2>

                    <asp:Repeater ID="repeaterBureau" runat="server">
                        <HeaderTemplate>
                            <div class="listBureau">
                                <h3 class="titleListe">Bureau</h3>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <a class="blocMember" href="Membres-<%# Eval("Id") %>-<%# Eval("Url") %>.aspx">
                                <img class="photoMember" src="<%# Eval("ImageUrl") %>" alt="<%# Eval("FirstName") %> <%# Eval("LastName") %>" width="75" height="75" />
                                <span class="descMember">
                                    <span class="title">
                                        <%# Eval("FirstName") %> <%# Eval("LastName") %>
                                    </span>
                                    <br />
                                    <%# Eval("Status") %>
                                </span>
                            </a>
                        </ItemTemplate>
                        <FooterTemplate>
                            </div>
                        </FooterTemplate>
                    </asp:Repeater>

                    <asp:Repeater ID="repeaterOthers" runat="server">
                        <HeaderTemplate>
                            <div class="listMembers">
                                <h3 class="titleListe">Membres</h3>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <a class="blocMember" href="Membres-<%# Eval("Id") %>-<%# Eval("Url") %>.aspx">
                                <img class="photoMember" src="<%# Eval("ImageUrl") %>" alt="<%# Eval("FirstName") %> <%# Eval("LastName") %>" width="75" height="75" />
                                <span class="descMember">
                                    <span class="title">
                                        <%# Eval("FirstName") %> <%# Eval("LastName") %>
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
                                <h3 class="titleListe">Anciens</h3>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <a class="blocMember" href="Membres-<%# Eval("Id") %>-<%# Eval("Url") %>.aspx">
                                <img src="<%# Eval("ImageUrl") %>" alt="<%# Eval("FirstName") %> <%# Eval("LastName") %>" width="50" height="50" />
                                <span class="descMember">
                                    <span class="title">
                                        <%# Eval("FirstName") %> <%# Eval("LastName") %>
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
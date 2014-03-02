<%@ Page Title="Links - EPSILab, le Laboratoire Microsoft de l'EPSI" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Liens.aspx.cs" Inherits="EPSILab.SolarSystem.Jupiter.Liens" %>

<%-- Head content --%>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
    <meta name="Description" lang="fr" content="Links utiles et sites partenaires.">
    <script type="text/javascript" src="Scripts/Liens.js"></script>
    <link rel="stylesheet" type="text/css" href="Styles/Liens.css" />
</asp:Content>

<%-- Body content --%>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <a href="Liens.aspx">Links</a>

    <h1>Links utiles</h1>
    <br />

    <asp:Repeater ID="repeaterLinks" runat="server">
        <ItemTemplate>
            <a class="lien" target="_blank" href="<%# Eval("Url") %>">
                
                <div class="image">
                    <img src="<%# Eval("ImageUrl") %>" alt="<%# Eval("Label") %>" title="<%# Eval("Label") %>" />
                </div>

                <div class="nom">
                    <%# Eval("Label") %>
                </div>

                <div class="description">
                    <%# Eval("Description") %>
                </div>
            </a>
            
            <div class="clear"></div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
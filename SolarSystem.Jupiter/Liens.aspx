<%@ Page Title="Liens - EPSILab, le Laboratoire Microsoft de l'EPSI" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Liens.aspx.cs" Inherits="SolarSystem.Jupiter.Liens" %>

<%-- Head content --%>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
    <meta name="Description" lang="fr" content="Liens utiles et sites partenaires.">
    <script type="text/javascript" src="Scripts/Liens.js"></script>
    <link rel="stylesheet" type="text/css" href="Styles/Liens.css" />
</asp:Content>

<%-- Body content --%>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <a href="Liens.aspx">Liens</a>

    <h1>Liens utiles</h1>
    <br />

    <asp:Repeater ID="repeaterLiens" runat="server">
        <ItemTemplate>
            <a class="lien" target="_blank" href="<%# Eval("URL") %>">
                
                <div class="image">
                    <img src="<%# Eval("Image") %>" alt="<%# Eval("Nom") %>" title="<%# Eval("Nom") %>" />
                </div>

                <div class="nom">
                    <%# Eval("Nom") %>
                </div>

                <div class="description">
                    <%# Eval("Description") %>
                </div>
            </a>
            
            <div class="clear"></div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
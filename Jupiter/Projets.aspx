<%@ Page Title="Projets - EPSILab, le laboratoire Microsoft de l'EPSI" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Projets.aspx.cs" Inherits="EPSILab.SolarSystem.Jupiter.Projets" %>

<%-- Head content --%>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
    <meta name="Description" lang="fr" content="Découvrez nos projets en cours et ceux terminés.">
    <script type="text/javascript" src="Scripts/Projets.js"></script>
    <link rel="stylesheet" type="text/css" href="Styles/Projets.css" />
</asp:Content>

<%-- Body content --%>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <a href="Projets.aspx">Projets</a>

    <h1>Nos projets</h1>
    <br />
    Vous pouvez également nous suivre directement depuis notre page
    <a href="http://www.github.com/epsilab" target="_blank">GitHub</a> et ainsi retrouver nos codes sources.
    <p>&nbsp;</p>

    <asp:Repeater ID="repeaterVilles" runat="server" OnItemDataBound="repeaterVilles_ItemDataBound">
        <ItemTemplate>

            <h2><%# Eval("Libelle") %></h2>

            <asp:Repeater ID="repeaterProjects" runat="server">
                <ItemTemplate>
                    <div class="item">
                        <img class="image" src="<%# Eval("Image") %>" alt="<%# Eval("Nom") %>" width="150" height="150" />

                        <div class="title"><%# Eval("Nom") %></div>
                        <div class="description"><%# Eval("Description")%></div>
                        <div class="avancement">
                            Avancement
                            <table class="progressbar">
                                <tr>
                                    <td class="tabGauche" style="width: <%# (int)Eval("Avancement") * 2 %>px"></td>
                                    <td class="tabDroite" style="width: <%# 200 - (int)Eval("Avancement") * 2 %>px"></td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

            <br />
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>

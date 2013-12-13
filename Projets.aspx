<%@ Page Title="Projets - EPSILab, le laboratoire Microsoft de l'EPSI" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Projets.aspx.cs" Inherits="EPSILab.Jupiter.Projets" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
    <meta name="Description" lang="fr" content="Découvrez nos projets en cours et ceux terminés.">
    <script type="text/javascript" src="Scripts/Projets.js"></script>
    <link rel="stylesheet" type="text/css" href="Styles/Projets.css" />
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <a href="Projets.aspx">Projets</a>

    <h1>Nos projets</h1>
    <br />

    <asp:Repeater ID="RPT_Villes" runat="server" OnItemDataBound="rptVilles_ItemDataBound">
        <ItemTemplate>

            <h2><%# Eval("Libelle") %></h2>

            <asp:Repeater ID="rptProjets" runat="server">
                <ItemTemplate>
                    <div class="item">
                        <img class="image" src="<%# Eval("Image") %>" alt="<%# Eval("Nom") %>" width="150" height="150" />

                        <div class="titre"><%# Eval("Nom") %></div>
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

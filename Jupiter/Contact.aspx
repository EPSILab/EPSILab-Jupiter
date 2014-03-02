<%@ Page Title="Nous contacter - EPSILab, le laboratoire Microsoft de l'EPSI" Language="C#"
    MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs"
    Inherits="EPSILab.SolarSystem.Jupiter.Contact" %>

<%@ Register TagPrefix="recaptcha" Namespace="Recaptcha" Assembly="Recaptcha" %>

<%-- Head content --%>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" src="Scripts/Contact.js"></script>
    <link rel="stylesheet" type="text/css" href="Styles/Contact.css" />
</asp:Content>

<%-- Body content --%>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <a href="Contact.aspx">Contact</a>

    <h1>Nous contacter</h1>

    <p>
        <asp:Label CssClass="erreur" ID="labelMessage" runat="server" Font-Bold="true" />
    </p>

    <asp:Panel runat="server" ID="panelFormulaire">
        <div class="formulaire">
            <div>
                Vous désirez nous contacter pour un renseignement, une remarque ou une question ?<br />
                Nous vous invitons à remplir ce formulaire afin de nous faire part de votre demande.
            </div>
            <div>&nbsp;</div>

            <div>* Votre nom :</div>
            <asp:TextBox ID="txtSurname" MaxLength="64" runat="server" Width="250" />
            <div>&nbsp;</div>

            <div>* Votre prénom :</div>
            <asp:TextBox ID="txtFirstName" MaxLength="64" runat="server" Width="250" />
            <div>&nbsp;</div>

            <div>* Votre adresse email :</div>
            <asp:TextBox ID="txtEmail" runat="server" Width="250" />
            <div>&nbsp;</div>

            <div>* Ecole EPSI à contacter:</div>
            <asp:DropDownList ID="listCampus" DataTextField="Place" DataValueField="Id" runat="server" Width="200px" />

            <div id="message">
                <div>* Corps du message :</div>
                <asp:TextBox ID="txtMessage" runat="server" Height="200px" Width="300" TextMode="MultiLine" />
            </div>
        </div>

        <div>&nbsp;</div>

        <div id="captcha">
            <recaptcha:RecaptchaControl runat="server"
                                        PublicKey="6Lf7ANESAAAAAHT_D_LdgutgWmlFEaBrX9GMqldy"
                                        PrivateKey="6Lf7ANESAAAAAAJuSybqKc8pV1tVnkDZoJ2C_Z4N"
                                        Theme="clean" />
        </div>

        <div>&nbsp;</div>

        <div class="formulaire">
            <div id="boutonEnvoyer">
                <asp:Button ID="BT_Envoyer" runat="server" Text="Envoyer votre message" OnClick="btnSend_Click" />
            </div>
        </div>
    </asp:Panel>
</asp:Content>
using EPSILab.Jupiter.Classes;
using EPSILab.Jupiter.Webservice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EPSILab.Jupiter
{
    public partial class Membres : Page
    {
        private readonly IMembreReader _clientMembres = new MembreReaderClient();
        private readonly IVilleReader _clientsVille = new VilleReaderClient();

        private List<MembresVille> _membresVilles;

        protected void Page_Load(object sender, EventArgs e)
        {
            int codeMembre;

            // Le paramètre $_GET['id'] n'est pas vide, on veut les informations d'un membre uniquement
            if (int.TryParse(HttpContext.Current.Request["id"], out codeMembre))
            {
                Membre membre = _clientMembres.GetMembre(codeMembre);

                if (membre != null)
                {
                    panelMembres.Visible = false;
                    panelMembre.Visible = true;

                    Page.Title = membre.Prenom + " " + membre.Nom + " - EPSILab, le laboratoire Microsoft de l'EPSI";
                    metaDescription.Text = "<meta name=\"description\" content=\"Fiche profil de " + membre.Prenom + " " + membre.Nom + ", " + membre.Statut + " d'EPSILab " + membre.Ville.Libelle + "\" />";

                    imgMembre.ImageUrl = membre.Image;
                    imgMembre.AlternateText = "Profil de " + membre.Prenom + " " + membre.Nom;
                    lblNom.Text = membre.Nom;
                    lblPrenom.Text = membre.Prenom;
                    lblStatut.Text = membre.Statut;
                    lblVille.Text = membre.Ville.Libelle;
                    lblPromo.Text = "Promo " + membre.Classe.Annee_Promo_Sortante;
                    lblPresentation.Text = membre.Presentation;
                    lnkVilleOrigine.Text = membre.Ville_origine;
                    lnkVilleOrigine.NavigateUrl = "http://www.bing.com/maps/?where1=" + membre.Ville_origine;

                    if (!string.IsNullOrWhiteSpace(membre.Site_web))
                    {
                        lnkWebsite.Visible = true;
                        lnkWebsite.NavigateUrl = membre.Site_web;
                    }

                    if (!string.IsNullOrWhiteSpace(membre.URL_Facebook))
                    {
                        lnkFacebook.Visible = true;
                        lnkFacebook.NavigateUrl = membre.URL_Facebook;
                    }

                    if (!string.IsNullOrWhiteSpace(membre.URL_Twitter))
                    {
                        lnkTwitter.Visible = true;
                        lnkTwitter.NavigateUrl = membre.URL_Twitter;
                    }

                    if (!string.IsNullOrWhiteSpace(membre.URL_Viadeo))
                    {
                        lnkViadeo.Visible = true;
                        lnkViadeo.NavigateUrl = membre.URL_Viadeo;
                    }

                    if (!string.IsNullOrWhiteSpace(membre.URL_LinkedIn))
                    {
                        lnkLinkedIn.Visible = true;
                        lnkLinkedIn.NavigateUrl = membre.URL_LinkedIn;
                    }
                }
            }
            // Le paramètre $_GET['id'] est vide, on veut la liste des membres
            else
            {
                panelMembres.Visible = true;
                panelMembre.Visible = false;

                IList<Ville> villes = _clientsVille.GetVilles();
                _membresVilles = villes.Select(ville => new MembresVille(ville, _clientMembres.GetMembresByVilleAndRole(ville, null, 0, 0, SortOrder.Ascending))).ToList();
                _membresVilles.RemoveAll(mv => !mv.Bureau.Any() && !mv.Membres.Any());

                rptVilles.DataSource = villes;
                rptVilles.DataBind();
            }
        }

        protected void prtVilles_ItemDataBound(object sender, RepeaterItemEventArgs repeaterItemEventArgs)
        {
            Ville ville = repeaterItemEventArgs.Item.DataItem as Ville;

            if (ville != null)
            {
                MembresVille membresVilles = (from mv in _membresVilles
                                              where mv.Ville.Code_Ville == ville.Code_Ville
                                              select mv).FirstOrDefault();

                if (membresVilles != null)
                {
                    Repeater subrepeaterBu = (Repeater)repeaterItemEventArgs.Item.FindControl("rptBureau");
                    subrepeaterBu.DataSource = membresVilles.Bureau;
                    subrepeaterBu.DataBind();

                    Repeater subrepeaterMb1 = (Repeater)repeaterItemEventArgs.Item.FindControl("rptMembres");
                    subrepeaterMb1.DataSource = membresVilles.Membres;
                    subrepeaterMb1.DataBind();
                }
            }
        }
    }
}
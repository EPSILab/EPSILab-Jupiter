using SolarSystem.Jupiter.Classes;
using SolarSystem.Jupiter.ReadersService;
using SolarSystem.Jupiter.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SolarSystem.Jupiter
{
    /// <summary>
    /// Members page
    /// </summary>
    public partial class Membres : Page
    {
        #region Attributes

        /// <summary>
        /// Webservice proxy for members
        /// </summary>
        private readonly IMembreReader _webserviceMembres = new MembreReaderClient();

        /// <summary>
        /// Webservice proxy for cities
        /// </summary>
        private readonly IVilleReader _webserviceVilles = new VilleReaderClient();

        /// <summary>
        /// Allows to show members for each city
        /// </summary>
        private List<MembresVille> _membresByVilles;

        #endregion

        #region Events

        /// <summary>
        /// Raised when the page is loaded
        /// </summary>
        /// <param name="sender">Element which raised the event.</param>
        /// <param name="e">Event arguments</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            int codeMembre;

            // Check if the member id is given in GET parameters. If yes, load the member's informations and if not, load the member list
            if (int.TryParse(HttpContext.Current.Request["id"], out codeMembre))
            {
                Membre membre = _webserviceMembres.GetMembre(codeMembre);

                if (membre != null)
                {
                    panelMembres.Visible = false;
                    panelMembre.Visible = true;

                    // Write member's informations
                    Page.Title = string.Format("{0} {1} - {2}", membre.Prenom, membre.Nom, GlobalRessources.SiteName);
                    metaDescription.Text = string.Format("<meta name=\"description\" content=\"Fiche profil de {0} {1}, {2} d'EPSILab {3}.\" />", membre.Prenom, membre.Nom, membre.Statut, membre.Ville.Libelle);

                    imageMembre.ImageUrl = membre.Image;
                    imageMembre.AlternateText = string.Format("Profil de {0} {1}", membre.Prenom, membre.Nom);

                    labelName.Text = string.Format("{0} {1}", membre.Nom, membre.Prenom);
                    labelStatus.Text = membre.Statut;
                    labelEPSI.Text = string.Format("Promo {0}, EPSI {1}", membre.Classe.Annee_Promo_Sortante, membre.Ville.Libelle);
                    labelCityFrom.Text = membre.Ville_origine;
                    labelPresentation.Text = membre.Presentation;

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
            else
            {
                panelMembres.Visible = true;
                panelMembre.Visible = false;

                IList<Ville> villes = _webserviceVilles.GetVilles();

                _membresByVilles = villes.Select(ville => new MembresVille(ville,
                                                                        _webserviceMembres.GetMembresInBureauByVille(ville),
                                                                        _webserviceMembres.GetMembresNotInBureauByVille(ville),
                                                                        _webserviceMembres.GetMembresAlumnis(ville))).ToList();
                
                _membresByVilles.RemoveAll(m => !m.Bureau.Any() && !m.Others.Any() && !m.Alumnis.Any());

                repeaterVilles.DataSource = _membresByVilles.Select(m => m.Campus);
                repeaterVilles.DataBind();
            }
        }

        /// <summary>
        /// Raised when a datasource is binded to the cities ASP.NET Repeater.
        /// Get the subrepeater to link the campus's members.
        /// </summary>
        /// <param name="sender">Element which raised the event.</param>
        /// <param name="repeaterItemEventArgs">Event arguments</param>
        protected void repeaterVilles_ItemDataBound(object sender, RepeaterItemEventArgs repeaterItemEventArgs)
        {
            Ville ville = repeaterItemEventArgs.Item.DataItem as Ville;

            if (ville != null)
            {
                MembresVille membresVilles = (from mv in _membresByVilles
                                              where mv.Campus.Code_Ville == ville.Code_Ville
                                              select mv).FirstOrDefault();

                if (membresVilles != null)
                {
                    Repeater subrepeaterBu = (Repeater)repeaterItemEventArgs.Item.FindControl("repeaterBureau");

                    if (membresVilles.Bureau.Any())
                    {
                        subrepeaterBu.DataSource = membresVilles.Bureau;
                        subrepeaterBu.DataBind();
                    }
                    else
                    {
                        subrepeaterBu.Visible = false;
                    }

                    Repeater subrepeaterOthers = (Repeater)repeaterItemEventArgs.Item.FindControl("repeaterOthers");

                    if (membresVilles.Others.Any())
                    {
                        subrepeaterOthers.DataSource = membresVilles.Others;
                        subrepeaterOthers.DataBind();
                    }
                    else
                    {
                        subrepeaterOthers.Visible = false;
                    }

                    Repeater subrepeaterAlumnis = (Repeater)repeaterItemEventArgs.Item.FindControl("repeaterAlumnis");

                    if (membresVilles.Alumnis.Any())
                    {
                        subrepeaterAlumnis.DataSource = membresVilles.Alumnis;
                        subrepeaterAlumnis.DataBind();
                    }
                    else
                    {
                        subrepeaterAlumnis.Visible = false;
                    }
                }
            }
        }

        #endregion
    }
}
using EPSILab.Jupiter.Webservice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EPSILab.Jupiter
{
    public partial class Conferences : Page
    {
        private readonly IConferenceReader _client = new ConferenceReaderClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            int codeConference;

            // On vérifie si un paramètre GET est passé. Si oui, on affiche une seule news, sinon on affiche la liste
            if (int.TryParse(HttpContext.Current.Request["id"], out codeConference))
            {
                // Récupération des informations
                Conference conference = _client.GetConference(codeConference);

                if (conference != null)
                {
                    lvConferences.Visible = false;
                    panelConference.Visible = true;

                    // Génération des balises Meta
                    Page.Title = conference.Nom + " - EPSILab, le laboratoire Microsoft de l'EPSI";
                    metaDescription.Text = "<meta name=\"description\" content=\"Conférence " + conference.Nom +
                                            ", le " + conference.Date_Heure_Debut.ToLongDateString() +
                                            " de " + conference.Date_Heure_Debut.ToShortTimeString() +
                                            " à " + conference.Date_Heure_Fin.ToShortTimeString() +
                                            ", à l'EPSI " + conference.Ville.Libelle + "\" />";

                    // Ecriture des informations associées
                    lblNom.Text = conference.Nom;
                    lblDateHeure.Text = conference.Date_Heure_Debut.ToLongDateString() +
                                        " de " + conference.Date_Heure_Debut.ToShortTimeString() +
                                        " à " + conference.Date_Heure_Fin.ToShortTimeString();
                    imgConference.ImageUrl = conference.Image;
                    lblLieu.Text = conference.Lieu;
                    lblVille.Text = conference.Ville.Libelle;
                    lblDescription.Text = conference.Description;
                }
            }
        }

        protected void lvConferences_PreRender(object sender, EventArgs e)
        {
            BaseDataBoundControl listView = (BaseDataBoundControl)sender;

            if (listView.Visible)
            {
                IList<Conference> conferences = _client.GetConferences();

                listView.DataSource = !conferences.Any() ? null : conferences;
                listView.DataBind();
            }
        }
    }
}
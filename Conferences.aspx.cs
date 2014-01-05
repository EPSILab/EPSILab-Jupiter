using SolarSystem.Jupiter.ReadersService;
using SolarSystem.Jupiter.Resources;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SolarSystem.Jupiter
{
    /// <summary>
    /// Conferences pages
    /// </summary>
    public partial class Conferences : Page
    {
        #region Attributes

        /// <summary>
        /// Webservice proxy
        /// </summary>
        private readonly IConferenceReader _webserviceConferences = new ConferenceReaderClient();

        #endregion

        #region Events

        /// <summary>
        /// Raised when the page is loaded
        /// </summary>
        /// <param name="sender">Element which raised the event.</param>
        /// <param name="e">Event arguments</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            int codeConference;

            // Check if a news id is given in GET parameters. If yes, show the news and if not, show the list of news
            if (int.TryParse(HttpContext.Current.Request["Id"], out codeConference))
            {
                Conference conference = _webserviceConferences.GetConference(codeConference);

                if (conference != null)
                {
                    listviewConferences.Visible = false;
                    panelConference.Visible = true;

                    // Generate meta tags
                    Page.Title = string.Format("{0} - {1}", conference.Nom, GlobalRessources.SiteName);
                    metaDescription.Text = string.Format("<meta name=\"description\" content=\"Conférence organisée le {0:d} de {0:t} à {1:t}, à l'EPSI {2}", conference.Date_Heure_Debut, conference.Date_Heure_Fin, conference.Ville.Libelle);

                    // Write all conference's informations
                    imgConference.ImageUrl = conference.Image;
                    labelName.Text = conference.Nom;
                    labelDateTime.Text = string.Format("le {0:D}, de {0:t} à {1:t}", conference.Date_Heure_Debut, conference.Date_Heure_Fin);
                    labelPlace.Text = conference.Lieu;
                    labelCampus.Text = string.Format("(EPSI {0})", conference.Ville.Libelle);
                    labelDescription.Text = conference.Description;
                }
            }
        }

        /// <summary>
        /// Raised when the news listview is rendered. Prevents from pagination problems.
        /// </summary>
        /// <param name="sender">Element which raised the event.</param>
        /// <param name="e">Event arguments</param>
        protected void listviewConferences_PreRender(object sender, EventArgs e)
        {
            BaseDataBoundControl listView = (BaseDataBoundControl)sender;

            if (listView.Visible)
            {
                IList<Conference> conferences = _webserviceConferences.GetConferences();

                listView.DataSource = conferences;
                listView.DataBind();
            }
        }

        #endregion
    }
}
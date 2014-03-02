using EPSILab.SolarSystem.Jupiter.ReadersService;
using EPSILab.SolarSystem.Jupiter.Resources;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EPSILab.SolarSystem.Jupiter
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
                    Page.Title = string.Format("{0} - {1}", conference.Name, GlobalRessources.SiteName);
                    metaDescription.Text = string.Format("<meta name=\"description\" content=\"Conférence organisée le {0:d} de {0:t} à {1:t}, à l'EPSI {2}", conference.Start_DateTime, conference.End_DateTime, conference.Campus.Place);

                    // Write all conference's informations
                    imgConference.ImageUrl = conference.ImageUrl;
                    labelName.Text = conference.Name;
                    labelDateTime.Text = string.Format("le {0:D}, de {0:t} à {1:t}", conference.Start_DateTime, conference.End_DateTime);
                    labelPlace.Text = conference.Place;
                    labelCampus.Text = string.Format("(EPSI {0})", conference.Campus.Place);
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
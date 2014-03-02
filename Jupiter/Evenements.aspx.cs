using EPSILab.SolarSystem.Jupiter.ReadersService;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace EPSILab.SolarSystem.Jupiter
{
    /// <summary>
    /// Events page (Shows and Conferences)
    /// </summary>
    public partial class Evenements : Page
    {
        #region Attributes

        /// <summary>
        /// Webservice proxy for shows
        /// </summary>
        private readonly IShowReader _webserviceShows = new ShowReaderClient();

        /// <summary>
        /// Webservice proxy for conferences
        /// </summary>
        private readonly IConferenceReader _webserviceConferences = new ConferenceReaderClient();

        #endregion

        #region Properties

        /// <summary>
        /// Raised when the page is loaded
        /// </summary>
        /// <param name="sender">Element which raised the event.</param>
        /// <param name="e">Event arguments</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            // Load shows from the webservice
            IEnumerable<Show> shows = _webserviceShows.GetShowsLimited(0, 6);
            repeaterShows.DataSource = shows;
            repeaterShows.DataBind();

            // Load conferences from the webservice
            IEnumerable<Conference> conferences = _webserviceConferences.GetConferencesLimited(0, 8);
            repeaterConferences.DataSource = conferences;
            repeaterConferences.DataBind();
        }

        #endregion
    }
}
using SolarSystem.Jupiter.ReadersService;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;

namespace SolarSystem.Jupiter
{
    /// <summary>
    /// Search page
    /// </summary>
    public partial class Recherche : Page
    {
        #region Attributes

        /// <summary>
        /// Webservice proxy for news
        /// </summary>
        private readonly INewsReader _webserviceNews = new NewsReaderClient();

        /// <summary>
        /// Webservice proxy for conferences
        /// </summary>
        private readonly IConferenceReader _webserviceConferences = new ConferenceReaderClient();

        /// <summary>
        /// Webservice proxy for shows
        /// </summary>
        private readonly ISalonReader _webserviceSalons = new SalonReaderClient();

        /// <summary>
        /// Webservice proxy for members
        /// </summary>
        private readonly IMembreReader _webserviceMembres = new MembreReaderClient();

        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if search arguments has been given in the GET parameters
            if (!string.IsNullOrWhiteSpace(HttpContext.Current.Request["search"]))
            {
                panelNoResults.Visible = false;
                panelResults.Visible = true;

                string keywords = HttpContext.Current.Request["search"].Trim();

                labelRecherche.Text = keywords;

                // Search in news
                ICollection<News> news = _webserviceNews.SearchNews(keywords);
                labelNewsCount.Text = news.Count.ToString("0");
                repeaterNews.DataSource = news;
                repeaterNews.DataBind();

                // Search in conferences
                ICollection<Conference> conferences = _webserviceConferences.SearchConferences(keywords);
                labelConferencesCount.Text = conferences.Count.ToString("0");
                repeaterConferences.DataSource = conferences;
                repeaterConferences.DataBind();

                // Search in shows
                ICollection<Salon> salons = _webserviceSalons.SearchSalons(keywords);
                labelShowsCount.Text = salons.Count.ToString("0");
                repeaterShows.DataSource = salons;
                repeaterShows.DataBind();

                // Search in members
                ICollection<Membre> membres = _webserviceMembres.SearchMembres(keywords);
                labelMembersCount.Text = membres.Count.ToString("0");
                repeaterMembers.DataSource = membres;
                repeaterMembers.DataBind();
            }
        }

        #endregion
    }
}
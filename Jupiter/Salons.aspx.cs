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
    /// Shows page
    /// </summary>
    public partial class Salons : Page
    {
        #region Attributes

        /// <summary>
        /// Webservice proxy for shows
        /// </summary>
        private readonly IShowReader _client = new ShowReaderClient();

        #endregion

        #region Events

        /// <summary>
        /// Raised when the page is loaded
        /// </summary>
        /// <param name="sender">Element which raised the event.</param>
        /// <param name="e">Event arguments</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            int codeShow;

            // CHeck if the show Id is given on GET parameters. If yes, load the show's informations and if not, display the shows list
            if (int.TryParse(HttpContext.Current.Request["Id"], out codeShow))
            {
                Show show = _client.GetShow(codeShow);

                if (show != null)
                {
                    listviewShows.Visible = false;
                    panelShow.Visible = true;

                    // Generate meta tags
                    Page.Title = string.Format("{0} - {1}", show.Name, GlobalRessources.SiteName);
                    metaDescription.Text = string.Format("<meta name=\"description\" content=\"Show organisé du {0:d} à {0:t} au {1:d} à {1:t}, à {2}\" />", show.Start_DateTime, show.End_DateTime, show.Place);

                    // Write show's informations
                    imageShow.ImageUrl = show.ImageUrl;
                    labelName.Text = show.Name;
                    labelDateTime.Text = string.Format("du {0:d} à {0:t} au {1:d} à {1:t}", show.Start_DateTime, show.End_DateTime);
                    labelPlace.Text = show.Place;
                    labelDescription.Text = show.Description;
                }
            }
        }

        /// <summary>
        /// Raised when the news listview is rendered. Prevents from pagination problems.
        /// </summary>
        /// <param name="sender">Element which raised the event.</param>
        /// <param name="e">Event arguments</param>
        protected void listviewShows_PreRender(object sender, EventArgs e)
        {
            DataBoundControl control = (DataBoundControl)sender;

            if (control.Visible)
            {
                IEnumerable<Show> shows = _client.GetShows();
                control.DataSource = shows;
                control.DataBind();
            }
        }

        #endregion
    }
}
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
        private readonly ISalonReader _client = new SalonReaderClient();

        #endregion

        #region Events

        /// <summary>
        /// Raised when the page is loaded
        /// </summary>
        /// <param name="sender">Element which raised the event.</param>
        /// <param name="e">Event arguments</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            int codeSalon;

            // CHeck if the show Id is given on GET parameters. If yes, load the show's informations and if not, display the shows list
            if (int.TryParse(HttpContext.Current.Request["Id"], out codeSalon))
            {
                Salon salon = _client.GetSalon(codeSalon);

                if (salon != null)
                {
                    listviewSalons.Visible = false;
                    panelSalon.Visible = true;

                    // Generate meta tags
                    Page.Title = string.Format("{0} - {1}", salon.Nom, GlobalRessources.SiteName);
                    metaDescription.Text = string.Format("<meta name=\"description\" content=\"Salon organisé du {0:d} à {0:t} au {1:d} à {1:t}, à {2}\" />", salon.Date_Heure_Debut, salon.Date_Heure_Fin, salon.Lieu);

                    // Write show's informations
                    imageSalon.ImageUrl = salon.Image;
                    labelName.Text = salon.Nom;
                    labelDateTime.Text = string.Format("du {0:d} à {0:t} au {1:d} à {1:t}", salon.Date_Heure_Debut, salon.Date_Heure_Fin);
                    labelPlace.Text = salon.Lieu;
                    labelDescription.Text = salon.Description;
                }
            }
        }

        /// <summary>
        /// Raised when the news listview is rendered. Prevents from pagination problems.
        /// </summary>
        /// <param name="sender">Element which raised the event.</param>
        /// <param name="e">Event arguments</param>
        protected void listviewSalons_PreRender(object sender, EventArgs e)
        {
            DataBoundControl control = (DataBoundControl)sender;

            if (control.Visible)
            {
                IEnumerable<Salon> salons = _client.GetSalons();
                control.DataSource = salons;
                control.DataBind();
            }
        }

        #endregion
    }
}
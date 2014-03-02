using EPSILab.SolarSystem.Jupiter.ReadersService;
using System;
using System.Web.UI;

namespace EPSILab.SolarSystem.Jupiter
{
    /// <summary>
    /// Links page
    /// </summary>
    public partial class Liens : Page
    {
        #region Attributes

        /// <summary>
        /// Webservice proxy for links
        /// </summary>
        private readonly ILinkReader _webservice = new LinkReaderClient();

        #endregion

        #region Events

        /// <summary>
        /// Raised when the page is loaded
        /// </summary>
        /// <param name="sender">Element which raised the event.</param>
        /// <param name="e">Event arguments</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            repeaterLinks.DataSource = _webservice.GetLinks();
            repeaterLinks.DataBind();
        }

        #endregion
    }
}
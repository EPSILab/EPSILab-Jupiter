using SolarSystem.Jupiter.ReadersService;
using System;
using System.Web.UI;

namespace SolarSystem.Jupiter
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
        private readonly ILienReader _webservice = new LienReaderClient();

        #endregion

        #region Events

        /// <summary>
        /// Raised when the page is loaded
        /// </summary>
        /// <param name="sender">Element which raised the event.</param>
        /// <param name="e">Event arguments</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            repeaterLiens.DataSource = _webservice.GetLiens();
            repeaterLiens.DataBind();
        }

        #endregion
    }
}
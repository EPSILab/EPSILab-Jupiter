using System.Web.UI;

namespace SolarSystem.Jupiter
{
    /// <summary>
    /// Master page for all the website
    /// </summary>
    public partial class SiteMaster : MasterPage
    {
        #region Events

        /// <summary>
        /// Raised when the user clicks on the search button
        /// </summary>
        /// <param name="sender">Element which raised the event.</param>
        /// <param name="e">Event arguments</param>
        protected void imgRechercher_Click(object sender, ImageClickEventArgs e)
        {
            string searchUrl = string.Format("Recherche.aspx?search={0}", txtRechercher.Text);
            Response.Redirect(searchUrl);
        }

        #endregion
    }
}
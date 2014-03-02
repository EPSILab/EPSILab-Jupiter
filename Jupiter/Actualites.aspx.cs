using EPSILab.SolarSystem.Jupiter.ReadersService;
using EPSILab.SolarSystem.Jupiter.Resources;
using System;
using System.Web;
using System.Web.UI;

namespace EPSILab.SolarSystem.Jupiter
{
    /// <summary>
    /// News page
    /// </summary>
    public partial class Actualites : Page
    {
        #region Attributes

        /// <summary>
        /// Webservice proxy
        /// </summary>
        private readonly INewsReader _webservice = new NewsReaderClient();

        #endregion

        #region Events

        /// <summary>
        /// Raised when the page is loaded
        /// </summary>
        /// <param name="sender">Element which raised the event.</param>
        /// <param name="e">Event arguments</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            int codeNews;

            // Check if a news id is given in GET parameters. If yes, show the news and if not, show the list of news
            if (int.TryParse(HttpContext.Current.Request["Id"], out codeNews))
            {
                // Récupération des informations
                News news = _webservice.GetNews(codeNews);

                if (news != null)
                {
                    listviewNews.Visible = false;
                    panelNews.Visible = true;

                    // Generate meta tags
                    Page.Title = string.Format("{0} - {1}", news.Title, GlobalRessources.SiteName);
                    metaAuthor.Text = string.Format("<meta name=\"author\" content=\"{0} {1}\" />", news.Member.FirstName, news.Member.LastName);
                    metaDescription.Text = string.Format("<meta name=\"description\" content=\"{0}\" />", news.ShortText);
                    metaKeywords.Text = string.Format("<meta name=\"keywords\" content=\"{0}\" />", news.Keywords);

                    // Write all news informations
                    imgNews.ImageUrl = news.ImageUrl;
                    imgNews.AlternateText = news.Title;

                    labelTitle.Text = news.Title;

                    linkAuthor.Text = string.Format("{0} {1}", news.Member.FirstName, news.Member.LastName);
                    linkAuthor.NavigateUrl = string.Format("Members-{0}-{1}.aspx", news.Member.Id, news.Member.Url);
                   
                    labelDateTime.Text = news.DateTime.ToLongDateString();

                    labelTexteLong.Text = news.Text;

                    // Write the keywords
                    repeaterKeywords.DataSource = news.Keywords.Split(',');
                    repeaterKeywords.DataBind();
                }
            }
        }

        /// <summary>
        /// Raised when the news listview is rendered. Prevents from pagination problems.
        /// </summary>
        /// <param name="sender">Element which raised the event.</param>
        /// <param name="e">Event arguments</param>
        protected void listviewNews_PreRender(object sender, EventArgs e)
        {
            if (listviewNews.Visible)
            {
                listviewNews.DataSource = _webservice.GetListNews();
                listviewNews.DataBind();
            }
        }

        #endregion
    }
}
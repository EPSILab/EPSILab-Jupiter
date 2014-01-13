using SolarSystem.Jupiter.ReadersService;
using SolarSystem.Jupiter.Resources;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Xml;

namespace SolarSystem.Jupiter
{
    /// <summary>
    /// Generate the news RSS feed
    /// </summary>
    public class RSS : IHttpHandler
    {
        #region Attributes

        /// <summary>
        /// Webservice proxy for news
        /// </summary>
        private readonly INewsReader _webserviceNews = new NewsReaderClient();

        #endregion

        #region Methods

        /// <summary>
        /// Generate the feed
        /// </summary>
        /// <param name="context">Encapsulate all HTTP-specific information about an individual HTTP request.</param>
        public void ProcessRequest(HttpContext context)
        {
            context.Response.Clear();
            context.Response.ContentType = "text/xml";

            using (XmlWriter writerRss = new XmlTextWriter(context.Response.OutputStream, Encoding.UTF8))
            {
                writerRss.WriteStartDocument();
                writerRss.WriteStartElement("rss");
                writerRss.WriteAttributeString("version", "2.0");
                writerRss.WriteStartElement("channel");
                writerRss.WriteElementString("title", GlobalRessources.SiteName);
                writerRss.WriteStartElement("image");
                writerRss.WriteElementString("url", "Images/logo.png");
                writerRss.WriteElementString("title", GlobalRessources.SiteName);
                writerRss.WriteElementString("link", GlobalRessources.SiteUrl);
                writerRss.WriteEndElement();
                writerRss.WriteElementString("link", GlobalRessources.SiteUrl);
                writerRss.WriteElementString("description", "Retrouvez les dernières actualités de notre association.");

                IEnumerable<News> news = _webserviceNews.GetListNewsLimited(0, 15);

                foreach (News item in news)
                {
                    writerRss.WriteStartElement("item");

                    writerRss.WriteElementString("title", item.Titre);

                    writerRss.WriteStartElement("description");
                    writerRss.WriteString(string.Format("<img src=\"{0}\" width=\"100\" height=\"113\" style=\"float: left\" />", item.Image));
                    writerRss.WriteString(item.Texte_Long);
                    writerRss.WriteEndElement();

                    writerRss.WriteElementString("link", string.Format("http://www.epsilab.net/Actualites-{0}-{1}.aspx", item.Code_News, item.URL));
                    writerRss.WriteElementString("pubDate",  item.Date_Heure.ToString("f"));
                    writerRss.WriteElementString("author", string.Format("{0} {1}", item.Membre.Prenom, item.Membre.Nom));
                    
                    writerRss.WriteEndElement();
                }

                writerRss.WriteEndElement();
                writerRss.WriteEndElement();
                writerRss.WriteEndDocument();

                writerRss.Flush();
                writerRss.Close();
            }

            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }

        #endregion
    }
}
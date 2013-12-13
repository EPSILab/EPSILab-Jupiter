using EPSILab.Jupiter.Webservice;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Xml;

namespace EPSILab.Jupiter
{
    public class RSS : IHttpHandler
    {
        private readonly INewsReader _client = new NewsReaderClient();

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Clear();
            context.Response.ContentType = "text/xml";

            XmlWriter writerRss = new XmlTextWriter(context.Response.OutputStream, Encoding.UTF8);

            writerRss.WriteStartDocument();
            writerRss.WriteStartElement("rss");
            writerRss.WriteAttributeString("version", "2.0");
            writerRss.WriteStartElement("channel");
            writerRss.WriteElementString("title", "EPSILab, le laboratoire Microsoft de l'EPSI");
            writerRss.WriteStartElement("image");
            writerRss.WriteElementString("url", "Images/logo.png");
            writerRss.WriteElementString("title", "EPSILab, le laboratoire Microsoft de l'EPSI");
            writerRss.WriteElementString("link", "http://www.epsilab.net");
            writerRss.WriteEndElement();
            writerRss.WriteElementString("link", "http://www.epsilab.net");
            writerRss.WriteElementString("description", "Retrouvez les dernières actualités de notre association.");

            IEnumerable<News> news = _client.GetListNewsLimited(0, 15);

            foreach (News item in news)
            {
                writerRss.WriteStartElement("item");
                writerRss.WriteElementString("title", item.Titre);
                writerRss.WriteStartElement("description");
                writerRss.WriteString("<img src=\"" + item.Image +
                                  "\" width=\"100\" height=\"113\" style=\"float: left\" />");
                writerRss.WriteString(item.Texte_Long);
                writerRss.WriteEndElement();
                writerRss.WriteElementString("link",
                                         "http://www.epsilab.net/Actualites-" + item.Code_News + "-" +
                                         item.Titre.Replace(' ', '-').ToLower() + ".aspx");

                writerRss.WriteElementString("pubDate",
                                         item.Date_Heure.ToShortDateString() + " " +
                                         item.Date_Heure.ToShortTimeString());

                writerRss.WriteElementString("author", item.Membre.Prenom + " " + item.Membre.Nom);
                writerRss.WriteEndElement();

            }

            writerRss.WriteEndElement();
            writerRss.WriteEndElement();
            writerRss.WriteEndDocument();

            writerRss.Flush();
            writerRss.Close();

            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }
    }
}
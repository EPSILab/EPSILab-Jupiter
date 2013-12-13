using EPSILab.Jupiter.Webservice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

namespace EPSILab.Jupiter
{
    public partial class Default : Page
    {
        private readonly IPubliciteReader _clientPublicites = new PubliciteReaderClient();
        private readonly INewsReader _clientNews = new NewsReaderClient();

        private int _idNews = 1;

        public int IdNews
        {
            get { return _idNews; }
            set { _idNews = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Obtention des publicités
            IEnumerable<Publicite> publicites = _clientPublicites.GetPublicites();

            // On masque les publicités si aucune n'a été trouvée
            if (!publicites.Any())
            {
                RPT_TemporaryNews.Visible = false;
            }
            else
            {
                RPT_TemporaryNews.DataSource = publicites;
                RPT_TemporaryNews.DataBind();
            }

            // Obtention des 20 dernières news
            IEnumerable<News> news = _clientNews.GetListNewsLimited(0, 20);
            
            rptNews.DataSource = news;
            rptNews.DataBind();
        }
    }
}

using EPSILab.Jupiter.Webservice;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;

namespace EPSILab.Jupiter
{
    public partial class Recherche : Page
    {
        private readonly INewsReader _clientNews = new NewsReaderClient();
        private readonly IConferenceReader _clientConferences = new ConferenceReaderClient();
        private readonly ISalonReader _clientSalons = new SalonReaderClient();
        private readonly IMembreReader _clientMembres = new MembreReaderClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            // On vérifie qu'un critère de recherche existe bien
            if (!string.IsNullOrWhiteSpace(HttpContext.Current.Request["mots"]))
            {
                panelNoResultats.Visible = false;
                panelResultats.Visible = true;

                string keywords = HttpContext.Current.Request["mots"].Trim();

                lblRecherche.Text = keywords;

                // Récupération des news correspondantes
                ICollection<News> news = _clientNews.SearchNews(keywords);
                lblNombreNews.Text = news.Count.ToString();
                rptNews.DataSource = news;
                rptNews.DataBind();

                // Récupération des conférences correspondantes
                ICollection<Conference> conferences = _clientConferences.SearchConferences(keywords);
                lblNombreConferences.Text = conferences.Count.ToString();
                rptConferences.DataSource = conferences;
                rptConferences.DataBind();

                // Récupération des salons correspondants
                ICollection<Salon> salons = _clientSalons.SearchSalons(keywords);
                lblNombreSalons.Text = salons.Count.ToString();
                rptSalons.DataSource = salons;
                rptSalons.DataBind();

                // Récupération des membres correspondants
                ICollection<Membre> membres = _clientMembres.SearchMembres(keywords);
                lblNombreMembres.Text = membres.Count.ToString();
                rptMembres.DataSource = membres;
                rptMembres.DataBind();
            }
        }
    }
}
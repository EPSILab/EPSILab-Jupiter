using EPSILab.Jupiter.Webservice;
using System;
using System.Web;
using System.Web.UI;

namespace EPSILab.Jupiter
{
    public partial class Actualites : Page
    {
        private readonly INewsReader _client = new NewsReaderClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            int codeNews;

            // On vérifie si un paramètre GET est passé. Si oui, on affiche une seule news, sinon on affiche la liste
            if (int.TryParse(HttpContext.Current.Request["id"], out codeNews))
            {
                // Récupération des informations
                News news = _client.GetNews(codeNews);

                if (news != null)
                {
                    lvNews.Visible = false;
                    panelNews.Visible = true;

                    // Génération des balises Meta
                    Page.Title = news.Titre + " - EPSILab, le laboratoire Microsoft de l'EPSI";
                    metaAuthor.Text = "<meta name=\"author\" content=\"" + news.Membre.Prenom + " " + news.Membre.Nom + "\" />";
                    metaDescription.Text = "<meta name=\"description\" content=\"" + news.Texte_Court + "\" />";
                    metaKeywords.Text = "<meta name=\"keywords\" content=\"" + news.Mots_Cles + "\" />";

                    // Ecriture des news et des informations de l'auteur
                    imgNews.ImageUrl = news.Image;
                    imgNews.AlternateText = news.Titre;
                    lblTitre.Text = news.Titre;
                    lnkAuteur.Text = news.Membre.Prenom + " " + news.Membre.Nom;
                    lnkAuteur.NavigateUrl = "Membres-" + news.Membre.Code_Membre + "-" + news.Membre.Prenom.Replace(' ', '-').ToLower() + "-" + news.Membre.Nom.Replace(' ', '-').ToLower() + ".aspx";
                    lblDateHeure.Text = news.Date_Heure.ToLongDateString();
                    lblTexteLong.Text = news.Texte_Long;

                    // Générer un tableau de mots-clés
                    rptKeywords.DataSource = news.Mots_Cles.Split(',');
                    rptKeywords.DataBind();
                }
            }
        }

        protected void lvNews_PreRender(object sender, EventArgs e)
        {
            if (lvNews.Visible)
            {
                lvNews.DataSource = _client.GetListNews();
                lvNews.DataBind();
            }
        }
    }
}
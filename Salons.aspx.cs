using EPSILab.Jupiter.Webservice;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EPSILab.Jupiter
{
    public partial class Salons : Page
    {
        private readonly ISalonReader _client = new SalonReaderClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            int codeSalon;

            // On vérifie si un paramètre GET est passé. Si oui, on affiche une seule news, sinon on affiche la liste
            if (int.TryParse(HttpContext.Current.Request["id"], out codeSalon))
            {
                // Récupération des informations
                Salon salon = _client.GetSalon(codeSalon);

                if (salon != null)
                {
                    lvSalons.Visible = false;
                    panelSalon.Visible = true;

                    // Génération des balises Meta
                    Page.Title = salon.Nom + " - EPSILab, le laboratoire Microsoft de l'EPSI";
                    metaDescription.Text = "<meta name=\"description\" content=\"Conférence " + salon.Nom +
                                            ", du " + salon.Date_Heure_Debut.ToString("dd MMMM yyyy à HH:mm") +
                                            " au " + salon.Date_Heure_Fin.ToString("dd MMMM yyyy à HH:mm") +
                                            ", à " + salon.Lieu + "\" />";

                    imgSalon.ImageUrl = salon.Image;
                    lblNom.Text = salon.Nom;
                    lblDateHeure.Text = "du " + salon.Date_Heure_Debut.ToString("dd MMMM yyyy à HH:mm") +
                                        " au " + salon.Date_Heure_Fin.ToString("dd MMMM yyyy à HH:mm");

                    lblLieu.Text = salon.Lieu;
                    lblDescription.Text = salon.Description;
                }
            }
        }

        protected void lvSalons_PreRender(object sender, EventArgs e)
        {
            DataBoundControl control = (DataBoundControl)sender;

            if (control.Visible)
            {
                IEnumerable<Salon> salons = _client.GetSalons();
                control.DataSource = salons;
                control.DataBind();
            }
        }
    }
}
using EPSILab.Jupiter.Webservice;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace EPSILab.Jupiter
{
    public partial class Evenements : Page
    {
        private readonly ISalonReader _clientSalons = new SalonReaderClient();
        private readonly IConferenceReader _clientConferences = new ConferenceReaderClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Traitement des salons 
            IEnumerable<Salon> salons = _clientSalons.GetSalonsLimited(0, 6);
            rptSalons.DataSource = salons;

            rptSalons.DataBind();

            // Traitement des conférences
            IEnumerable<Conference> conferences = _clientConferences.GetConferencesLimited(0, 8);
            rptConferences.DataSource = conferences;
            rptConferences.DataBind();
        }
    }
}

        
    

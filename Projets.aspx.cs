using EPSILab.Jupiter.Classes;
using EPSILab.Jupiter.Webservice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EPSILab.Jupiter
{
    public partial class Projets : Page
    {
        private readonly IProjetReader _clientProjets = new ProjetReaderClient();
        private readonly IVilleReader _clientVilles = new VilleReaderClient();

        private List<ProjetsVille> _projetsVilles;

        protected void Page_Load(object sender, EventArgs e)
        {
            IList<Ville> villes = _clientVilles.GetVilles();

            _projetsVilles = villes.Select(ville => new ProjetsVille(ville, _clientProjets.GetProjetsByVille(ville, 0, 0, SortOrder.Ascending))).ToList();
            _projetsVilles.RemoveAll(mp => !mp.Projets.Any());

            RPT_Villes.DataSource = _projetsVilles.Select(pv => pv.Ville);
            RPT_Villes.DataBind();
        }

        protected void rptVilles_ItemDataBound(object sender, RepeaterItemEventArgs repeaterItemEventArgs)
        {
            Ville ville = repeaterItemEventArgs.Item.DataItem as Ville;

            if (ville != null)
            {
                IEnumerable<Projet> projets = (from pv in _projetsVilles
                                               where pv.Ville == ville
                                               select pv).First().Projets;

                Repeater subrepeater = (repeaterItemEventArgs.Item.FindControl("rptProjets") as Repeater);

                if (subrepeater != null)
                {
                    subrepeater.DataSource = projets;
                    subrepeater.DataBind();
                }
            }
        }
    }
}
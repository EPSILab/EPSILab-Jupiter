using EPSILab.SolarSystem.Jupiter.Classes;
using EPSILab.SolarSystem.Jupiter.ReadersService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EPSILab.SolarSystem.Jupiter
{
    /// <summary>
    /// Projects page
    /// </summary>
    public partial class Projets : Page
    {
        #region Attributes

        /// <summary>
        /// Webservice proxy for projects
        /// </summary>
        private readonly IProjetReader _webserviceProjets = new ProjetReaderClient();

        /// <summary>
        /// Webservice proxy for cities
        /// </summary>
        private readonly IVilleReader _webserviceVilles = new VilleReaderClient();

        /// <summary>
        /// List of the projects by cities
        /// </summary>
        private List<ProjetsVille> _projetsVilles;

        #endregion

        #region Events

        /// <summary>
        /// Raised when the page is loaded
        /// </summary>
        /// <param name="sender">Element which raised the event.</param>
        /// <param name="e">Event arguments</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            IList<Ville> villes = _webserviceVilles.GetVilles();

            _projetsVilles = villes.Select(ville => new ProjetsVille(ville, _webserviceProjets.GetProjetsByVille(ville))).ToList();
            _projetsVilles.RemoveAll(mp => !mp.Projets.Any());

            repeaterVilles.DataSource = _projetsVilles.Select(pv => pv.Ville);
            repeaterVilles.DataBind();
        }

        /// <summary>
        /// Raised when a datasource is binded to the cities ASP.NET Repeater.
        /// Get the subrepeater to link the campus's projects.
        /// </summary>
        /// <param name="sender">Element which raised the event.</param>
        /// <param name="repeaterItemEventArgs">Event arguments</param>
        protected void repeaterVilles_ItemDataBound(object sender, RepeaterItemEventArgs repeaterItemEventArgs)
        {
            Ville ville = repeaterItemEventArgs.Item.DataItem as Ville;

            if (ville != null)
            {
                IEnumerable<Projet> projets = (from pv in _projetsVilles
                                               where pv.Ville == ville
                                               select pv).First().Projets;

                Repeater subrepeater = (repeaterItemEventArgs.Item.FindControl("repeaterProjects") as Repeater);

                if (subrepeater != null)
                {
                    subrepeater.DataSource = projets;
                    subrepeater.DataBind();
                }
            }
        }

        #endregion
    }
}
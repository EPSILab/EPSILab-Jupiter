using EPSILab.SolarSystem.Jupiter.ReadersService;
using System.Collections.Generic;

namespace EPSILab.SolarSystem.Jupiter.Classes
{
    /// <summary>
    /// Class for displaying projects by campus using ASP.NET Repeater
    /// </summary>
    public class ProjetsVille
    {
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ville">City</param>
        /// <param name="projets">Projects list of the campus</param>
        public ProjetsVille(Ville ville, IEnumerable<Projet> projets)
        {
            Ville = ville;
            Projets = projets;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Campus
        /// </summary>
        public Ville Ville { get; private set; }

        /// <summary>
        /// Liste des projets
        /// </summary>
        public IEnumerable<Projet> Projets { get; private set; }

        #endregion
    }
}
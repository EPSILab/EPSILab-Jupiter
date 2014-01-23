using EPSILab.SolarSystem.Jupiter.ReadersService;
using System.Collections.Generic;

namespace EPSILab.SolarSystem.Jupiter.Classes
{
    /// <summary>
    /// Class for displaying conferences by campus using ASP.NET Repeater
    /// </summary>
    public class ConferencesVille
    {
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ville">Campus</param>
        /// <param name="conferences">Conferences to associate to the campus</param>
        public ConferencesVille(Ville ville, IEnumerable<Conference> conferences)
        {
            Ville = ville;
            Conferences = conferences;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Campus
        /// </summary>
        public Ville Ville { get; set; }

        /// <summary>
        /// Campus's conferences
        /// </summary>
        public IEnumerable<Conference> Conferences { get; set; }

        #endregion
    }
}
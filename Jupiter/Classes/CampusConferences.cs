using EPSILab.SolarSystem.Jupiter.ReadersService;
using System.Collections.Generic;

namespace EPSILab.SolarSystem.Jupiter.Classes
{
    /// <summary>
    /// Class for displaying conferences by campus using ASP.NET Repeater
    /// </summary>
    public class CampusConferences
    {
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="campus">Campus</param>
        /// <param name="conferences">Conferences to associate to the campus</param>
        public CampusConferences(Campus campus, IEnumerable<Conference> conferences)
        {
            Campus = campus;
            Conferences = conferences;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Campus
        /// </summary>
        public Campus Campus { get; private set; }

        /// <summary>
        /// Campus's conferences
        /// </summary>
        public IEnumerable<Conference> Conferences { get; private set; }

        #endregion
    }
}
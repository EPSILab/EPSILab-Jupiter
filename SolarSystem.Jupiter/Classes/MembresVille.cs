using SolarSystem.Jupiter.ReadersService;
using System.Collections.Generic;

namespace SolarSystem.Jupiter.Classes
{
    /// <summary>
    /// Class for displaying members (bureau and not) by campus using ASP.NET Repeater
    /// </summary>
    public class MembresVille
    {
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="campus">Campus</param>
        /// <param name="bureau">Members in the campus bureau</param>
        /// <param name="others">Members who are not in the campus bureau</param>
        /// <param name="alumnis">Alumnis</param>
        public MembresVille(Ville campus, IEnumerable<Membre> bureau, IEnumerable<Membre> others, IEnumerable<Membre> alumnis)
        {
            Campus = campus;
            Bureau = bureau;
            Others = others;
            Alumnis = alumnis;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Campus
        /// </summary>
        public Ville Campus { get; private set; }

        /// <summary>
        /// Members of the bureau
        /// </summary>
        public IEnumerable<Membre> Bureau { get; private set; }

        /// <summary>
        /// Members who are not in the bureau
        /// </summary>
        public IEnumerable<Membre> Others { get; private set; }

        /// <summary>
        /// Alumnis
        /// </summary>
        public IEnumerable<Membre> Alumnis { get; private set; }

        #endregion
    }
}
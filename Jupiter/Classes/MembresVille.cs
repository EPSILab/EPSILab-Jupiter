using EPSILab.SolarSystem.Jupiter.ReadersService;
using System.Collections.Generic;

namespace EPSILab.SolarSystem.Jupiter.Classes
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
        /// <param name="membres">Members in the campus</param>
        /// <param name="alumnis">Alumnis</param>
        public MembresVille(Ville campus, IEnumerable<Membre> membres, IEnumerable<Membre> alumnis)
        {
            Campus = campus;
            Membres = membres;
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
        public IEnumerable<Membre> Membres { get; private set; }

        /// <summary>
        /// Alumnis
        /// </summary>
        public IEnumerable<Membre> Alumnis { get; private set; }

        #endregion
    }
}
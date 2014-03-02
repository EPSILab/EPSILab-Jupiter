using EPSILab.SolarSystem.Jupiter.ReadersService;
using System.Collections.Generic;

namespace EPSILab.SolarSystem.Jupiter.Classes
{
    /// <summary>
    /// Class for displaying members (bureau and not) by campus using ASP.NET Repeater
    /// </summary>
    public class CampusMembers
    {
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="campus">Campus</param>
        /// <param name="membres">Members in the campus</param>
        /// <param name="alumnis">Alumnis</param>
        public CampusMembers(Campus campus, IEnumerable<Member> membres, IEnumerable<Member> alumnis)
        {
            Campus = campus;
            Members = membres;
            Alumnis = alumnis;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Campus
        /// </summary>
        public Campus Campus { get; private set; }

        /// <summary>
        /// Members of the bureau
        /// </summary>
        public IEnumerable<Member> Members { get; private set; }

        /// <summary>
        /// Alumnis
        /// </summary>
        public IEnumerable<Member> Alumnis { get; private set; }

        #endregion
    }
}
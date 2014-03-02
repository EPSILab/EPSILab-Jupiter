using EPSILab.SolarSystem.Jupiter.ReadersService;
using System.Collections.Generic;

namespace EPSILab.SolarSystem.Jupiter.Classes
{
    /// <summary>
    /// Class for displaying projects by campus using ASP.NET Repeater
    /// </summary>
    public class CampusProjects
    {
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="campus">City</param>
        /// <param name="projects">Projects list of the campus</param>
        public CampusProjects(Campus campus, IEnumerable<Project> projects)
        {
            Campus = campus;
            Projects = projects;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Campus
        /// </summary>
        public Campus Campus { get; private set; }

        /// <summary>
        /// Liste des projects
        /// </summary>
        public IEnumerable<Project> Projects { get; private set; }

        #endregion
    }
}
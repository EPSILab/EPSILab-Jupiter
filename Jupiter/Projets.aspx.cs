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
        private readonly IProjectReader _webserviceProjects = new ProjectReaderClient();

        /// <summary>
        /// Webservice proxy for cities
        /// </summary>
        private readonly ICampusReader _webserviceCampuses = new CampusReaderClient();

        /// <summary>
        /// List of the projects by cities
        /// </summary>
        private List<CampusProjects> _projectsCampuses;

        #endregion

        #region Events

        /// <summary>
        /// Raised when the page is loaded
        /// </summary>
        /// <param name="sender">Element which raised the event.</param>
        /// <param name="e">Event arguments</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            IList<Campus> campuss = _webserviceCampuses.GetCampuses();

            _projectsCampuses = campuss.Select(campus => new CampusProjects(campus, _webserviceProjects.GetProjectsByCampus(campus))).ToList();
            _projectsCampuses.RemoveAll(mp => !mp.Projects.Any());

            repeaterCampuses.DataSource = _projectsCampuses.Select(pv => pv.Campus);
            repeaterCampuses.DataBind();
        }

        /// <summary>
        /// Raised when a datasource is binded to the cities ASP.NET Repeater.
        /// Get the subrepeater to link the campus's projects.
        /// </summary>
        /// <param name="sender">Element which raised the event.</param>
        /// <param name="repeaterItemEventArgs">Event arguments</param>
        protected void repeaterCampuses_ItemDataBound(object sender, RepeaterItemEventArgs repeaterItemEventArgs)
        {
            Campus campus = repeaterItemEventArgs.Item.DataItem as Campus;

            if (campus != null)
            {
                IEnumerable<Project> projects = (from pv in _projectsCampuses
                                               where pv.Campus == campus
                                               select pv).First().Projects;

                Repeater subrepeater = (repeaterItemEventArgs.Item.FindControl("repeaterProjects") as Repeater);

                if (subrepeater != null)
                {
                    subrepeater.DataSource = projects;
                    subrepeater.DataBind();
                }
            }
        }

        #endregion
    }
}
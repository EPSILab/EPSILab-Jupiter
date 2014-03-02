using EPSILab.SolarSystem.Jupiter.Classes;
using EPSILab.SolarSystem.Jupiter.ReadersService;
using EPSILab.SolarSystem.Jupiter.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EPSILab.SolarSystem.Jupiter
{
    /// <summary>
    /// Members page
    /// </summary>
    public partial class Membres : Page
    {
        #region Attributes

        /// <summary>
        /// Webservice proxy for members
        /// </summary>
        private readonly IMemberReader _webserviceMembers = new MemberReaderClient();

        /// <summary>
        /// Webservice proxy for cities
        /// </summary>
        private readonly ICampusReader _webserviceCampuses = new CampusReaderClient();

        /// <summary>
        /// Allows to show members for each city
        /// </summary>
        private List<CampusMembers> _membresByCampuses;

        #endregion

        #region Events

        /// <summary>
        /// Raised when the page is loaded
        /// </summary>
        /// <param name="sender">Element which raised the event.</param>
        /// <param name="e">Event arguments</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            int codeMember;

            // Check if the member id is given in GET parameters. If yes, load the member's informations and if not, load the member list
            if (int.TryParse(HttpContext.Current.Request["id"], out codeMember))
            {
                Member membre = _webserviceMembers.GetMember(codeMember);

                if (membre != null)
                {
                    panelMembers.Visible = false;
                    panelMember.Visible = true;

                    // Write member's informations
                    Page.Title = string.Format("{0} {1} - {2}", membre.FirstName, membre.LastName, GlobalRessources.SiteName);
                    metaDescription.Text = string.Format("<meta name=\"description\" content=\"Fiche profil de {0} {1}, {2} d'EPSILab {3}.\" />", membre.FirstName, membre.LastName, membre.Status, membre.Campus.Place);

                    imageMember.ImageUrl = membre.ImageUrl;
                    imageMember.AlternateText = string.Format("Profil de {0} {1}", membre.FirstName, membre.LastName);

                    labelName.Text = string.Format("{0} {1}", membre.FirstName, membre.LastName);
                    labelStatus.Text = membre.Status;
                    labelEPSI.Text = string.Format("Promo {0}, EPSI {1}", membre.Promotion.GraduationYear, membre.Campus.Place);
                    labelCityFrom.Text = membre.CityFrom;
                    labelPresentation.Text = membre.Presentation;

                    if (!string.IsNullOrWhiteSpace(membre.Website))
                    {
                        lnkWebsite.Visible = true;
                        lnkWebsite.NavigateUrl = membre.Website;
                    }

                    if (!string.IsNullOrWhiteSpace(membre.FacebookUrl))
                    {
                        lnkFacebook.Visible = true;
                        lnkFacebook.NavigateUrl = membre.FacebookUrl;
                    }

                    if (!string.IsNullOrWhiteSpace(membre.TwitterUrl))
                    {
                        lnkTwitter.Visible = true;
                        lnkTwitter.NavigateUrl = membre.TwitterUrl;
                    }

                    if (!string.IsNullOrWhiteSpace(membre.ViadeoUrl))
                    {
                        lnkViadeo.Visible = true;
                        lnkViadeo.NavigateUrl = membre.ViadeoUrl;
                    }

                    if (!string.IsNullOrWhiteSpace(membre.LinkedInUrl))
                    {
                        lnkLinkedIn.Visible = true;
                        lnkLinkedIn.NavigateUrl = membre.LinkedInUrl;
                    }

                    if (!string.IsNullOrWhiteSpace(membre.GitHubUrl))
                    {
                        lnkGitHub.Visible = true;
                        lnkGitHub.NavigateUrl = membre.GitHubUrl;
                    }
                }
            }
            else
            {
                panelMembers.Visible = true;
                panelMember.Visible = false;

                IList<Campus> campuses = _webserviceCampuses.GetCampuses();

                _membresByCampuses = campuses.Select(campus => new CampusMembers(campus,
                                                                        _webserviceMembers.GetMembersByCampus(campus),
                                                                        _webserviceMembers.GetMembersAlumnis(campus))).ToList();
                
                _membresByCampuses.RemoveAll(m => !m.Members.Any() && !m.Alumnis.Any());

                repeaterCampuses.DataSource = _membresByCampuses.Select(m => m.Campus);
                repeaterCampuses.DataBind();
            }
        }

        /// <summary>
        /// Raised when a datasource is binded to the cities ASP.NET Repeater.
        /// Get the subrepeater to link the campus's members.
        /// </summary>
        /// <param name="sender">Element which raised the event.</param>
        /// <param name="repeaterItemEventArgs">Event arguments</param>
        protected void repeaterCampuses_ItemDataBound(object sender, RepeaterItemEventArgs repeaterItemEventArgs)
        {
            Campus campus = repeaterItemEventArgs.Item.DataItem as Campus;

            if (campus != null)
            {
                CampusMembers membresCampuses = (from mv in _membresByCampuses
                                              where mv.Campus.Id == campus.Id
                                              select mv).FirstOrDefault();

                if (membresCampuses != null)
                {
                    Repeater subrepeaterBu = (Repeater)repeaterItemEventArgs.Item.FindControl("repeaterBureau");

                    if (membresCampuses.Members.Any(m => m.Role == Role.Bureau))
                    {
                        subrepeaterBu.DataSource = membresCampuses.Members.Where(m => m.Role == Role.Bureau);
                        subrepeaterBu.DataBind();
                    }
                    else
                        subrepeaterBu.Visible = false;

                    Repeater subrepeaterOthers = (Repeater)repeaterItemEventArgs.Item.FindControl("repeaterOthers");

                    if (membresCampuses.Members.Any(m => m.Role == Role.MemberActive))
                    {
                        subrepeaterOthers.DataSource = membresCampuses.Members.Where(m => m.Role == Role.MemberActive);
                        subrepeaterOthers.DataBind();
                    }
                    else
                    {
                        subrepeaterOthers.Visible = false;
                    }

                    Repeater subrepeaterAlumnis = (Repeater)repeaterItemEventArgs.Item.FindControl("repeaterAlumnis");

                    if (membresCampuses.Alumnis.Any())
                    {
                        subrepeaterAlumnis.DataSource = membresCampuses.Alumnis;
                        subrepeaterAlumnis.DataBind();
                    }
                    else
                    {
                        subrepeaterAlumnis.Visible = false;
                    }
                }
            }
        }

        #endregion
    }
}
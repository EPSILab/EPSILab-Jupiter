using System.Web.UI;

namespace EPSILab.Jupiter
{
    public partial class SiteMaster : MasterPage
    {
        protected void imgRechercher_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Recherche.aspx?mots=" + txtRechercher.Text);
        }
    }
}

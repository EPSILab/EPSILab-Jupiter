using EPSILab.Jupiter.Webservice;
using System;
using System.Web.UI;

namespace EPSILab.Jupiter
{
    public partial class Liens : Page
    {
        private readonly ILienReader _client = new LienReaderClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            rptLiens.DataSource = _client.GetLiens();
            rptLiens.DataBind();
        }
    }
}
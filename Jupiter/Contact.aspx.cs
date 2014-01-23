using EPSILab.SolarSystem.Jupiter.ReadersService;
using EPSILab.SolarSystem.Jupiter.Resources;
using System;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EPSILab.SolarSystem.Jupiter
{
    /// <summary>
    /// Contact page
    /// </summary>
    public partial class Contact : Page
    {
        #region Events

        /// <summary>
        /// Raised when the page is loaded
        /// </summary>
        /// <param name="sender">Element which raised the event.</param>
        /// <param name="e">Event arguments</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IVilleReader client = new VilleReaderClient();
                listCampus.DataSource = client.GetVilles();
                listCampus.DataBind();
            }
        }

        /// <summary>
        /// Raised when the user click on the Send button.
        /// </summary>
        /// <param name="sender">Element which raised the event.</param>
        /// <param name="e">Event arguments</param>
        protected void btnSend_Click(object sender, EventArgs e)
        {
            labelMessage.ForeColor = Color.Red;

            if (Page.IsValid)
            {
                if (string.IsNullOrWhiteSpace(txtSurname.Text))
                {
                    labelMessage.Text = ErrorRessources.EnterSurname;
                }
                else if (string.IsNullOrWhiteSpace(txtFirstName.Text))
                {
                    labelMessage.Text = ErrorRessources.EnterFirstName;
                }
                else if (string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    labelMessage.Text = ErrorRessources.EnterEmail;
                }
                else if (!Regex.IsMatch(txtEmail.Text, @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"))
                {
                    labelMessage.Text = ErrorRessources.EmailFormatInvalid;
                }
                else
                {
                    SendEmail();

                    panelFormulaire.Visible = false;

                    labelMessage.ForeColor = Color.Green;
                    labelMessage.Text = ErrorRessources.EmailSent;
                }
            }
            else
            {
                labelMessage.Text = ErrorRessources.CaptchaError;
            }
        }

        #endregion

        #region Methods

        private void SendEmail()
        {
            IVilleReader client = new VilleReaderClient();

            ListItem selectedIdVille = listCampus.SelectedItem;
            int idVille = int.Parse(selectedIdVille.Value);
            Ville ville = client.GetVille(idVille);

            using (MailMessage mail = new MailMessage())
            {
                MailAddress sender = new MailAddress(txtEmail.Text);
                mail.From = sender;

                MailAddress reciever = new MailAddress(ville.Email);
                mail.To.Add(reciever);

                mail.Subject = EmailRessources.Title;
                mail.IsBodyHtml = true;
                mail.Body = string.Format(EmailRessources.Body, txtFirstName.Text, txtSurname.Text, Regex.Replace(txtEmail.Text, "<.*?>", string.Empty), txtEmail.Text);
                mail.Priority = MailPriority.Normal;

                SmtpClient smtp = new SmtpClient
                    {
                        Credentials = new NetworkCredential(EmailRessources.Login, EmailRessources.Password),
                        Host = EmailRessources.Host,
                        Port = int.Parse(EmailRessources.Port),
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        EnableSsl = true
                    };

                smtp.Send(mail);
                smtp.Dispose();
            }

            txtSurname.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtMessage.Text = string.Empty;
        }

        #endregion
    }
}
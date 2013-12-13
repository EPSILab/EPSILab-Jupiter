using EPSILab.Jupiter.Webservice;
using System;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EPSILab.Jupiter
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IVilleReader client = new VilleReaderClient();
                ddlVilles.DataSource = client.GetVilles();
                ddlVilles.DataBind();
            }
        }

        protected void btEnvoyer_Click(object sender, EventArgs e)
        {
            LB_Message.ForeColor = Color.Red;
            
            if (Page.IsValid)
            {
                if (string.IsNullOrWhiteSpace(tbNom.Text))
                {
                    LB_Message.Text = "Veuillez entrer votre nom.";
                }
                else if (string.IsNullOrWhiteSpace(tbPrenom.Text))
                {
                    LB_Message.Text = "Veuillez entrer votre prénom.";
                }
                else if (string.IsNullOrWhiteSpace(tbEmail.Text))
                {
                    LB_Message.Text = "Veuillez entrer votre adresse email.";
                }
                else if (!Regex.IsMatch(tbEmail.Text, @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"))
                {
                    LB_Message.Text = "Veuillez entrer votre adresse email valide.";
                }
                else
                {
                    EnvoyerMail();

                    panelFormulaire.Visible = false;

                    LB_Message.ForeColor = Color.Green;
                    LB_Message.Text = "Votre message a bien été envoyé.";
                }
            }
            else
            {
                LB_Message.Text = "Le code que vous avez rentré est erroné.";
            }
        }

        private void EnvoyerMail()
        {
            IVilleReader client = new VilleReaderClient();

            ListItem li = ddlVilles.SelectedItem;
            Ville ville = client.GetVille(int.Parse(li.Value));

            using (MailMessage mail = new MailMessage())
            {
                MailAddress expediteur = new MailAddress(tbEmail.Text);
                mail.From = expediteur;

                MailAddress destinataire = new MailAddress(ville.Email);
                mail.To.Add(destinataire);

                mail.Subject = "Formulaire de contact du site EPSILab";
                mail.IsBodyHtml = true;
                mail.Body = "Un message a été laissé sur le site par <strong>" + tbPrenom.Text + "</strong> <strong>" +
                            tbNom.Text + "</strong>.<br /><br />";
                mail.Body += Regex.Replace(tbMessage.Text, "<.*?>", string.Empty) + "<br /><br />";
                mail.Body += "Son adresse email: <strong>" + tbEmail.Text + "</strong>";
                mail.Priority = MailPriority.Normal;

                SmtpClient smtp = new SmtpClient
                    {
                        Credentials = new NetworkCredential("epsilab@outlook.com", "3ps1l4b62!"),
                        Host = "smtp.live.com",
                        Port = 587,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        EnableSsl = true
                    };

                smtp.Send(mail);
                smtp.Dispose();
            }

            tbNom.Text = string.Empty;
            tbPrenom.Text = string.Empty;
            tbEmail.Text = string.Empty;
            tbMessage.Text = string.Empty;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace mailing_app
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        //Field variables
        String email = "";
        String user = "";
        String pass = "";
        String htmlText = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            for (int i = 0; i < emailBox.Items.Count; i++)
            {
                Random rnd = new Random();
                int num = rnd.Next(60000, 15000000);

                System.Threading.Thread.Sleep(num);
                try
                {
                    if ( mailLoginBox.Text.Length>0)
                    {
                        MailMessage mail = new MailMessage();
                        SmtpClient SmtpServer = new SmtpClient("smtp.office365.com");
                        mail.IsBodyHtml = true;

                        mail.From = new MailAddress(email);

                        String text = emailBox.Items[i].ToString();
                        mail.To.Add(text);
                        //mail.Bcc.Add(text);

                        mail.Subject = assBox.Text;
                        mail.AlternateViews.Add(AddBody(htmlText));

                        SmtpServer.Port = 25;
                        SmtpServer.Credentials = new System.Net.NetworkCredential(user, pass);
                        SmtpServer.EnableSsl = true;

                        SmtpServer.Send(mail);
                    }
                    else
                    {
                        MailMessage mail = new MailMessage();
                        SmtpClient SmtpServer = new SmtpClient("smtp.ptempresas.pt");
                        mail.IsBodyHtml = true;

                        mail.From = new MailAddress(email);

                        String text = emailBox.Items[i].ToString();
                        mail.To.Add(text);
                        //mail.Bcc.Add(text);

                        mail.Subject = assBox.Text;
                        mail.AlternateViews.Add(AddBody(htmlBox.Text));

                        SmtpServer.Port = 25;
                        SmtpServer.Credentials = new System.Net.NetworkCredential(user, pass);
                        SmtpServer.EnableSsl = true;


                        SmtpServer.Send(mail);

                    }


                }
                catch (Exception ex)
                {

                }
            }
            MessageBox.Show("Processo concluido");

        }
    }

    
}

using System;
using System.Collections.Generic;
using System.Linq;
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
using WpfTestMailSender.Data;

namespace WpfTestMailSender
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();

  
        }

        private void BtnSendMail_Click(object sender, RoutedEventArgs e)
        {
            MailMessage mailMessage = new MailMessage();
            Sender senderUser = new Sender();
            Recipient recipient = new Recipient();
            Server server = new Server();

            //sender
            senderUser.Name = txtSenderName.Text;
            senderUser.Address = txtSenderAddress.Text;
            //recipient
            recipient.Name = txtRecipientName.Text;
            recipient.Address = txtRecipientAddress.Text;
            //mail
            mailMessage.Subject = txtObject.Text;
            mailMessage.Body = txtBody.Text;
            //server
            server.Address = "smtp.yandex.ru";
            server.UserName = "vl.kolbt87@yandex.ru";
            server.Password = "";

            var emailSend = new EmailSendServiceClass(senderUser.Name, senderUser.Address, recipient.Name, recipient.Address);
            emailSend.CreateMailMessage(mailMessage.Subject, mailMessage.Body);
            emailSend.SendMail(server.Address, server.Port, server.UserName, server.Password, server.UseSSl);
        }
    }
}

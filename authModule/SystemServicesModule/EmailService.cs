using System.Threading.Tasks;
using ConfigurationModule;
using CuttingEdge.Conditions;
using Microsoft.AspNet.Identity;

namespace SystemServicesModule
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your email service here to send an email.
            //return Task.FromResult(0);

            // Credentials:
            var account = CONFIGURATIONS.SystemEmailAccount;

            Condition.Requires(account).IsNotNull();
            Condition.Requires(account.From).IsNotNull();
            Condition.Requires(account.UserName).IsNotNull();
            Condition.Requires(account.Password).IsNotNull();
            Condition.Requires(account.Smtp).IsNotNull();

             var credentialUserName = account.UserName;
            var sentFrom = account.From;
            var pwd = account.Password;

            // Configure the client:
            var client =
                new System.Net.Mail.SmtpClient(account.Smtp)
                {
                    Port = 587,
                    DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false
                };

            // Create the credentials:
            var credentials =new System.Net.NetworkCredential(credentialUserName, pwd);

            client.EnableSsl = true;
            client.Credentials = credentials;

            // Create the message:
            var mail =
                new System.Net.Mail.MailMessage(sentFrom, message.Destination)
                {
                    Subject = message.Subject,
                    Body = message.Body,
                    IsBodyHtml = true
                };

            // Send:
            return client.SendMailAsync(mail);
        }
    }
}

//    The EmailService Configured to Use Sendgrid:
// Collapse | Copy Code
//public class EmailService : IIdentityMessageService
//{
//    public Task SendAsync(IdentityMessage message)
//    {
//        // Credentials:
//        var sendGridUserName = "yourSendGridUserName";
//        var sentFrom = "whateverEmailAdressYouWant";
//        var sendGridPassword = "YourSendGridPassword";

//        // Configure the client:
//        var client = 
//            new System.Net.Mail.SmtpClient("smtp.sendgrid.net", Convert.ToInt32(587));

//        client.Port = 587;
//        client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
//        client.UseDefaultCredentials = false;

//        // Creatte the credentials:
//        System.Net.NetworkCredential credentials = 
//            new System.Net.NetworkCredential(sendGridUserName, pwd);

//        client.EnableSsl = true;
//        client.Credentials = credentials;

//        // Create the message:
//        var mail = 
//            new System.Net.Mail.MailMessage(sentFrom, message.Destination);

//        mail.Subject = message.Subject;
//        mail.Body = message.Body;

//        // Send:
//        return client.SendMailAsync(mail);
//    }
//}
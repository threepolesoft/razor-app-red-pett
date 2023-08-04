
using MailKit.Net.Smtp;
using MimeKit;
using RestSharp.Authenticators;
using RestSharp;
using System.Net.Http;
using System.Security.Authentication;
using System.Text;
using System.Text.Json;
using MailKit.Security;

namespace ReDpett.Service
{
    public class EmailService : IEmail
    {
        private readonly HttpClient httpClient;
        private readonly string sendGridApiKey = "YOUR_SENDGRID_API_KEY";


        // public const SecurityProtocolType Tls12 = (SecurityProtocolType)_Tls12;

        //public async Task<bool> Execute(string email, string otp)
        //{
        //    try
        //    {
        //        var client = new SendGridClient("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");
        //        var from = new EmailAddress("info@redpett.org", "redpettSMTP");
        //        var subject = "Your OTP to forget your password";
        //        var to = new EmailAddress(email, "Example User");
        //        var plainTextContent = "Your otp is:" + otp;
        //        var htmlContent = "<strong>and do not share this otp with anyone</strong>";
        //        var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
        //        var response = await client.SendEmailAsync(msg);
        //        if (response.IsSuccessStatusCode)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //    //var apiKey = Environment.GetEnvironmentVariable("NAME_OF_THE_ENVIRONMENT_VARIABLE_FOR_YOUR_SENDGRID_KEY");


        //}
        public async Task<bool> SendEmailAsync(string toEmail, string subject, string body, CancellationToken ct)
        {
            try
            {
                var email = new MimeMessage();
                email.Sender = MailboxAddress.Parse("admin@redpett.com");
                email.From.Add(MailboxAddress.Parse("admin@redpett.com"));
                email.To.Add(MailboxAddress.Parse(toEmail));
                email.Subject = subject;

                var builder = new BodyBuilder();

                builder.HtmlBody = body;


                using var smtp = new SmtpClient();

                //if (false)
                //{
                //    await smtp.ConnectAsync(_mailGunSettings.Host, _mailGunSettings.Port, SecureSocketOptions.SslOnConnect, ct);
                //}
                //else if (_mailGunSettings.UseStartTls)
                //{
                await smtp.ConnectAsync("smtp.eu.mailgun.org", 587, SecureSocketOptions.StartTls, ct);
                //
                await smtp.AuthenticateAsync("admin@redpett.com", "Password1234567!", ct);
                var result = await smtp.SendAsync(email, ct);
                await smtp.DisconnectAsync(true, ct);

                return true;
            }
            catch (Exception ex)
            {
                return true;
            }

        }
    }
}

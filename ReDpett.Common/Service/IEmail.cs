using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReDpett.Service
{
    public interface IEmail
    {
        // Task<bool> Execute(string email, string otp);
         Task<bool> SendEmailAsync(string toEmail, string subject, string body,CancellationToken ct);
  }
}

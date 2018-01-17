using Notifications.Emails.Models;
using System.Net;
using System.Threading.Tasks;

namespace Notifications.Emails.Transport
{
    public abstract class AbstractTransport
    {
        public WebProxy Proxy { get; set; }
        public abstract EmailResponse SendEmail(Email email);
        public abstract Task<EmailResponse> SendEmailAsync(Email email);
    }
}

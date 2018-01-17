using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Notifications.Emails.Transport;
using Notifications.Emails.Models;
using Notifications.Emails;

namespace NotificationDemoTest
{
    [TestClass]
    public class UnitTestSMTP
    {
        [TestMethod]
        [Priority(1)]
        [Owner("AHSAN")]
        public void SendTest()
        {
            SmtpTransport aSmtpTransport = new SmtpTransport
            {
                Host = "smtp.gmail.com",
                Port = 587, //ssl=465
                Ssl = true,
                User = "rupomahsan@gmail.com",
                Password = "Swapno2ndApril"
            };
            Email email = new Email(aSmtpTransport, EmailContentType.Text)
            {
                From = new Contact { Name = "Rupom Gmail", Email = "rupomahsan@gmail.com" }
            };
            email.AddTo("rupom@live.com", "Rupom Ahsan");
            email.Subject = "subject";
            //email.Template = "template";
            //email.AddTemplateVar("person", "teste");
            //email.AddTemplateVar("number", "123");
            email.Message = "Hello";
            Assert.IsTrue(email.Send().Success);
        }
    }
}

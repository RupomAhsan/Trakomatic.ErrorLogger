﻿using Notifications.Emails.Models;
using Notifications.Emails.Transport;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notifications.Emails
{
    public class Email
    {
        public AbstractTransport Transport { get; set; }
        public String Message { get; set; }
        public String Template { get; set; }
        public List<TemplateVar> TemplateVars { get; set; }
        public List<Contact> To { get; set; }
        public List<Contact> Cco { get; set; }
        public List<Contact> Bco { get; set; }
        public Contact From { get; set; }
        public String Subject { get; set; }
        public EmailContentType Type { get; set; }
        public List<Attachment> Attachments { get; set; }
        public Boolean HasReadNotification { get; set; }
        public String ReplyTo { get; set; }

        public Email(AbstractTransport transport, EmailContentType type = EmailContentType.Text)
        {
            Transport = transport;
            Type = type;
        }

        //public Email(EmailContentType type = EmailContentType.Text)
        //{
        //    Transport = AppConfig.DefaultInstance.TryGetDefaultTransport();
        //    Type = type;
        //}

        public void AddTo(string email, string name = null)
        {
            if (To == null)
            {
                To = new List<Contact>();
            }
            To.Add(new Contact(){Email = email, Name=name});
        }

        public void AddCco(string email, string name = null)
        {
            if (Cco == null)
            {
                Cco = new List<Contact>();
            }
            Cco.Add(new Contact() { Email = email, Name = name });
        }

        public void AddBco(string email, string name = null)
        {
            if (Bco == null)
            {
                Bco = new List<Contact>();
            }
            Bco.Add(new Contact() { Email = email, Name = name });
        }

        public void AddTemplateVar(string name, object data)
        {
            if (TemplateVars == null)
            {
                TemplateVars = new List<TemplateVar>();
            }
            TemplateVars.Add(new TemplateVar(){Name = name, Data = data});
        }

        public void AddAttachment(Attachment file)
        {
            if (Attachments == null)
            {
                Attachments = new List<Attachment>();
            }
            Attachments.Add(file);
        }

        public EmailResponse Send()
        {
            ValidateEmail();

            return Transport.SendEmail(this);
        }

        public async Task<EmailResponse> SendEmailAsync()
        {
            ValidateEmail();

            return await Transport.SendEmailAsync(this);
        }

        private void ValidateEmail()
        {
            if (From == null)
            {
                throw new InvalidOperationException("The From is not defined!");
            }

            if (To == null && Bco == null && Cco == null)
            {
                throw new InvalidOperationException("You need specify one destination on to, cc or bcc.");
            }

            if (Transport == null)
            {
                throw new InvalidOperationException("Transport is not defined!");
            }

            if (!String.IsNullOrEmpty(Template))
            {
                Message = EmailRender.RenderEmail(this);
            }
        }
    }
}

﻿namespace Notifications.Emails.Models
{
    public class Contact
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return Name + "<" + Email + ">";
        }
    }
}

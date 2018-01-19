using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PNotify.Models
{
    public class NotificationHub:Hub
    {
        public void SendNotification(string name)
        {
            Clients.All.notify(name);
        }
    }
}
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Utility
{
    public class Notification:BaseEntity
    {
        public int Id { get; set; }
        public int? CorporateId { get; set; }
        public Guid? UserId { get; set; }
        public int? DeviceId { get; set; }
        public string NotificationType { get; set; }
        public string NotificationCategory { get; set; }        
        public string Message { get; set; }
    }
}

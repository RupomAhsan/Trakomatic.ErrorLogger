using Domain.Entities.Utility;
using Infrastructures;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PNotify.Models
{
    public class NotificationComponent
    {

        private TrakoDbContext _dbContext;
        private readonly UnitOfWork _unitOfWork;
        public NotificationComponent()
        {
            _dbContext = new TrakoDbContext();
            _unitOfWork=new UnitOfWork(_dbContext);
        }

        internal List<Notification> GetNotifications(DateTime afterDateTime)
        {
            return _unitOfWork.Repository<Notification>().GetAll().Where(a => a.CreatedDate > afterDateTime).OrderByDescending(a => a.CreatedDate).ToList();
        }

        public void RegisterNotification(DateTime currentTime)
        {
            string commandText = null;
            string conStr = _dbContext.Connectionstring();
            // var query = _dbContext.Notification.Where(a => a.CreatedDate > currentTime).OrderByDescending(a => a.CreatedDate) as DbQuery<Notification>;
            var query = "SELECT [Id] ,[CorporateId] ,[UserId] ,[DeviceId] ,[NotificationType] ,[NotificationCategory] ,[Message] ,[created_date] ,[modified_date] ,[is_active] ,[is_deleted] ,[created_by_userid] ,[modified_by_userid] FROM[dbo].[Notification] WHERE [created_date]>'" + currentTime + "'";
            commandText = query.ToString();
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    connection.Open();

                    var sqlDependency = new SqlDependency(command);

                    sqlDependency.OnChange += new OnChangeEventHandler(sqlDependency_OnChange);

                    // NOTE: You have to execute the command, or the notification will never fire.
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                    }
                }
            }
        }

        

        void sqlDependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Type == SqlNotificationType.Change)
            {
                SqlDependency sqlDep = sender as SqlDependency;
                sqlDep.OnChange -= sqlDependency_OnChange;

                //from here we will send notification message to client
                var notificationHub = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
               

                notificationHub.Clients.All.notify("added");

                //re-register notification
                RegisterNotification(DateTime.Now);

            }
        }
    }
}
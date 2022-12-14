using BugTracker.Models;

namespace BugTracker.Services.Interfaces
{
    public interface INotificationService
    {
        public Task AddNotificationAsync(Notification notification);
        public Task AdminNotificationAsync(Notification notification, int companyId);
        public Task<List<Notification>> GetNewNotificationsByUserIdAsync(string userId);
        public Task<List<Notification>> GetNotificationsByUserIdAsync(string userId);
        public Task<List<NotificationType>> GetNotificationTypesAsync();
        public Task<bool> SendAdminEmailNotificationAsync(Notification notification, string emailSubject, int companyId);
        public Task<bool> SendEmailNotificationAsync(Notification notification, string emailSubject);
        public Task UpdateNotificationAsync(Notification notification);
    }
}

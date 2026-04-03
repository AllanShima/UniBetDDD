using UniBet.Contexts.Profile.DTO;

namespace UniBet.Contexts.Profile.Entities
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Document { get; private set; }
        public string Phone { get; private set; }
        public List<Achievement> Achievements { get; private set; }
        public List<Notification> Notifications { get; private set; }

        public User(Guid id, string name, string email, string password, string document, string phone)
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
            this.Password = password;
            this.Document = document;
            this.Phone = phone;
            this.Achievements = new List<Achievement>();
            this.Notifications = new List<Notification>();
        }

        public void AddAchievement(Achievement achievement)
        {
            this.Achievements.Add(achievement);
        }

        public void AddNotification(Notification notification)
        {
            this.Notifications.Add(notification);
        }

        public void UpdateMainData(UpdateMainDataDTO data)
        {
            this.Name = data.Name;
            this.Email = data.Email;
            this.Password = data.Password;
        }
        public void UpdateOptionalData(UpdateOptionalDataDTO data)
        {
            this.Phone = data.Phone;
        }

        public void CreateOptionalData(CreateOptionalDataDTO data)
        {
            this.Document = data.Document;
            this.Phone = data.Phone;
        }

        public List<Notification> ListNotifications()
        {
            return this.Notifications;
        }
        public List<Achievement> ListAchievements()
        {
            return this.Achievements;
        }
    }
}

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

        //public User GetUserById(Guid Id)
        //{
        //    User user = new User(Guid.NewGuid(), "John Doe", "
        //    return User;
        //}
        public void AddAchievement(Achievement achievement)
        {
            this.Achievements.Add(achievement);
        }

        public void AddNotification(Notification notification)
        {
            this.Notifications.Add(notification);
        }

        public void UpdateMainData(string name, string email, string password)
        {
            this.Name = name;
            this.Email = email;
            this.Password = password;
        }
        public void UpdateOptionalData(string phone)
        {
            this.Phone = phone;
        }

        public void CreateOptionalData(string document, string phone)
        {
            this.Document = document;
            this.Phone = phone;
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

namespace UniBet.Contexts.Billing.Interfaces
{
    public class Email
    {
        public string Value { get; private set; }

        public Email(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Email cannot be null or empty.");
            }
            if (!IsValidEmail(value))
            {
                throw new ArgumentException("Invalid email format.");
            }
            this.Value = value;
        }
    }
}

namespace UniBet.Contexts.Billing.DTOs
{
    public class Password
    {
        public string Value { get; private set; }

        public Password(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Password cannot be null or empty.");
            }
            if (value.Length < 8)
            {
                throw new ArgumentException("Password must be at least 8 characters long.");
            }
            // Verifica presença de maiúscula, minúscula e dígito
            if (!value.Any(char.IsUpper) || !value.Any(char.IsLower) || !value.Any(char.IsDigit))
            {
                throw new ArgumentException("Password must contain at least one uppercase letter, one lowercase letter, and one digit.");
            }
            this.Value = value;
        }
    }
}

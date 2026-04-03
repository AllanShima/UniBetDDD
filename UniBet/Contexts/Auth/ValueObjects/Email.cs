namespace UniBet.Contexts.Auth.ValueObjects
{
    public class Email
    {
        public string Value { get; set; }

        public Email(string email)
        {
            // regra de validação de email
            this.Value = email;
        }
    }
}

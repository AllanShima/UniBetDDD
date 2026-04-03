using UniBet.Entities;

namespace UniBet.Contexts.Billing.Interfaces
{
    public class Team
    {
        public string Value { get; private set; }

        public Team(string value)
        {
            if (value == null)
            {
                throw new ArgumentException("Time inválido.");
            }
            this.Value = value;
        }
    }
}

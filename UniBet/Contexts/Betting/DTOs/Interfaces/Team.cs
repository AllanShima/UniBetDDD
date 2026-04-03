using UniBet.Entities;

namespace UniBet.Contexts.Billing.DTOs.Interfaces
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

namespace UniBet.Contexts.Billing.DTOs
{
    public class Amount
    {
        public decimal Value { get; private set; }

        public Amount(decimal value)
        {
            if (value <= 0)
            {
                throw new Exception("Amount precisa ser positivo.");
            }
            this.Value = value;
        }
    }
}

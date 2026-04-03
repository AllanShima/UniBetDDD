namespace UniBet.Contexts.Billing.Entities
{
    public class Bet : EntityBase
    {
        public Guid UserId { get; set; }
        public Guid GameId { get; set; }
        public Amount Amount { get; set; }
        public Team Team { get; set; }

        public Bet(Guid userId, Guid gameId, Amount amount, Team team)
        {
            this.UserId = userId;
            this.GameId = gameId;
            this.Amount = amount;
            this.Team = team;
        }

        public void AddBet(Guid userId, Guid gameId, Amount amount, Team team)
        {
            // Lógica para adicionar uma aposta ao jogo
            
        }

        public void CancelarBet()
        {
            // Lógica para cancelar a aposta, se necessário
            // Devolver o valor da aposta para o os usuários que apostaram
        }


    }
}

namespace UniBet.Contexts.Billing.Entities
{
    public class Game : EntityBase
    {
        public Guid GameId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        private readonly List<Bet> _bets = new List<Bet>();
        public IReadOnlyCollection<Bet> Bets => _bets.AsReadOnly();
        public string Status { get; set; }
        public Team ATeam { get; set; }
        public Team BTeam { get; set; }


        // Criar Jogo (Constructor)
        public Game(string description, string Name, string ImageUrl)
        {
            GameId = Guid.NewGuid();
            this.Description = description;
            this.Name = Name;
            this.ImageUrl = ImageUrl;
        }

        public void ChangeProfile(string description, string Name, string ImageUrl)
        {
            this.Description = description;
            this.Name = Name;
            this.ImageUrl = ImageUrl;
        }
        public void UpdateStatus(string newStatus)
        {
            this.Status = newStatus;
        }

        public void ListGame()
        {
            Console.WriteLine($"ID: {GameId}");
            Console.WriteLine($"Nome: {Name}");
            Console.WriteLine($"Descrição: {Description}");
            Console.WriteLine($"URL da Imagem: {ImageUrl}");
            Console.WriteLine($"Status: {Status}");
        }

        public void BeginSettle()
        {
            // Lógica para iniciar o processo de liquidação do jogo
        }

        public void FinishSettle()
        {
            // Lógica para deletar o jogo, se necessário
        }

        public void Place(Guid userId, Amount amount, Team team)
        {
            // Lógica para realizar uma aposta no jogo
            if (team.Value != ATeam.Value && team.Value != BTeam.Value)
            {
                throw new ArgumentException("Time inválido para este jogo.");
            }
            Bet newBet = new Bet(userId, this.GameId, amount, team);

            _bets.Add(newBet);
        }

        public void StatusCanceled()
        {
            this.Status = "Canceled";

            // Lógica para cancelar as bets, se necessário
            foreach (var bet in this._bets)
            {
                bet.CancelarBet();
            }
        }
        public void StatusFinished()
        {
            this.Status = "Finished";
        }
        public void StatusActive()
        {
            this.Status = "Active";
        }

    }
}

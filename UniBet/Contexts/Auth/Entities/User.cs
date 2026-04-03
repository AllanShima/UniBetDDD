namespace UniBet.Contexts.Auth.Entities
{
    public class User
    {
        public string Email { get; private set; } 
        public string Password { get; private set; }

        public User(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }

        public string Login() // Objetivo: recuperar o token de autenticação JWT para o usuário
        {
            // código que faz login JWT e retorna token de autenticação
            
            return "nvjfjenjvfkjv k,vnrkfednj";
        }
    }
}

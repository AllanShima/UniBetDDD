using Microsoft.EntityFrameworkCore;

namespace UniBet.Contexts.Billing.Entities
{
    public class User : EntityBase
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public Email Email { get; private set; }
        private Password Password { get; set; }
        public DateTime BirthDate { get; private set; }
        private string Cpf {  get; set; }
        private string Rg { get; set; }
        private Amount Balance { get; set; }
        

        // Criar User (Constructor)
        public User(string firstName, string lastName, Email email, Password password, DateTime birthDate, string cpf, string rg)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Password = password;
            this.BirthDate = birthDate;
            this.Cpf = cpf;
            this.Rg = rg;
            this.Balance = 0; // Initial balance
        }

        public void ChangeProfile(string firstName, string lastName, Email email, DateTime birthDate)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.BirthDate = birthDate;
        }

        public void UpdatePassword(Password newPassword)
        {
            this.Password = newPassword;
        }
        public void ListUser()
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Nome: {FirstName} {LastName}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Data de Nascimento: {BirthDate.ToShortDateString()}");
            Console.WriteLine($"CPF: {Cpf}");
            Console.WriteLine($"RG: {Rg}");
            Console.WriteLine($"Saldo: {Balance:C}"); Console.Wri
        }

        public void Withdraw(Amount amount)
        {

            if (amount.Value > this.Balance.Value)
            {
                throw new Exception("Saldo inválido.");
            }
            this.Balance.Value -= amount.Value;


        }
    }
}

using UniBet.Contexts.Billing.Data;
using UniBet.Contexts.Billing.DTOs.Entities;
using UniBet.Contexts.Billing.DTOs.Filters;
using UniBet.Contexts.Billing.DTOs.Helpers;
using UniBet.Contexts.Billing.DTOs.Interfaces.IRepositories;
using UniBet.Contexts.Billing.Entities;
using UniBet.Contexts.Billing.Helpers;
using UniBet.Contexts.Billing.Interfaces.IRepositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UniBet.Contexts.Billing.DTOs.Repositories
{
    public class UserRepository : IUserRepository
    {
        public readonly Context _database; 
        public UserRepository(Context context) 
        {
            _database = context;
        }

        public void Create(User user)
        {
            _database.Users.Add(user);
            _database.SaveChanges();
        }

        public void Delete(User user)
        {
            //User user = _database.Users.Where( usr => usr.Id == id).FirstOrDefault();
            _database.Users.Remove(user);
        }

        public List<User> GetAll()
        {
            List<User> list = _database.Users
                                .Select(users => users)
                                .ToList();
            return list;
        }

        public Paginator<User> PaginateAll(UserFilter filter)
        {
            var query = _database.Users
                    .Select(users => users)
                    .Where(users => users.RemovedAt == null);

            if (!string.IsNullOrEmpty(filter.Name))
            {
                query = query.Where(user => user.FirstName.Contains(filter.Name));
            }

            List<User> data = query
                .Skip((filter.Page - 1) * filter.ItensPerPage)
                .Take(filter.ItensPerPage)
                .ToList();

            int totalItems = query.Count();
            decimal toTotalPages = totalItems / filter.ItensPerPage;
            int totalPages = (int)Math.Ceiling(toTotalPages);

            return new Paginator<User>(totalPages, totalItems, data, filter.ItensPerPage);
        }

        public User GetById(Guid Id)
        {
            return _database.Users.Select(user => user).Where(user => user.Id == Id).FirstOrDefault();
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}

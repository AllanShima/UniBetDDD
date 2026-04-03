using UniBet.Contexts.Billing.DTOs.Entities;
using UniBet.Contexts.Billing.Entities;
using UniBet.DTOs.Filters;
using UniBet.Helpers;

namespace UniBet.Contexts.Billing.DTOs.Interfaces.IRepositories
{
    public interface IGameRepository
    {
        public List<Game> GetAll();
        // public Paginator<Game> PaginateAll(GameFilter filter);
        public Game GetById(Guid Id);
        public void Create(Game user);
        public void Update(Game user);
        public void Delete(Game user);
    }
}

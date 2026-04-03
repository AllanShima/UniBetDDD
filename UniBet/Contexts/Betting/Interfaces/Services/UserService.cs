using Microsoft.AspNetCore.Mvc.RazorPages;
using UniBet.Contexts.Billing.DTOs;
using UniBet.Contexts.Billing.DTOs.Entities;
using UniBet.Contexts.Billing.DTOs.Filters;
using UniBet.Contexts.Billing.DTOs.Helpers;
using UniBet.Contexts.Billing.DTOs.Interfaces.IRepositories;
using UniBet.Contexts.Billing.DTOs.Interfaces.IServices;
using UniBet.Contexts.Billing.Entities;
using UniBet.Contexts.Billing.Helpers;
using UniBet.Contexts.Billing.Interfaces.IRepositories;
using UniBet.Contexts.Billing.Interfaces.IServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UniBet.Contexts.Billing.Interfaces.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository) {
            this._repository = repository;
        }

        public void CreateUser(CreateUserDTO userDto)
        {
            try
            {
                User newUser = new User();

                if (userDto.FirstName == null)
                {
                    throw new Exception("FirstName é obrigatorio");
                }

                newUser.FirstName = userDto.FirstName;
                newUser.LastName = userDto.LastName;
                newUser.Email = userDto.Email;

                newUser.UpdatePassword("sadas");

                _repository.Create(newUser);
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public User GetById(Guid id)
        {
            try
            {
                User user = _repository.GetById(id);

                if (user == null)
                {
                    return null;
                }

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
         
        public Paginator<UserEmail> Paginate(UserFilter filter)
        {
            try
            {
                filter.Page = (filter.Page <= 0) ? 1 : filter.Page;
                filter.ItensPerPage = (filter.ItensPerPage <= 0) ? 10 : filter.ItensPerPage;
            
                Paginator<User> paginator = _repository.PaginateAll(filter);

                Paginator<UserEmail> newPaginator = new Paginator<UserEmail>(
                    paginator.TotalPages,
                    paginator.TotalItems,
                    new List<UserEmail>(),
                    paginator.PageCount
                );

                if (paginator.TotalItems == 0)
                {
                    return newPaginator;
                }

                foreach (User user in paginator.Data)
                {
                    UserEmail userEmail = new UserEmail();
                    userEmail.Name = user.FirstName + " " + user.LastName;
                    userEmail.Email = user.Email;
                    newPaginator.Data.Add(userEmail);
                }

                return newPaginator;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<User> ListUsers()
        {
            try
            {
                List<User> list = _repository.GetAll();
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateUser(Guid Id, User user)
        {
            throw new NotImplementedException();
        }
    }
}

public class UserEmail
{
    public string Email { get; set; }
    public string Name { get; set; }
}

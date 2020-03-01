using BusinessLogic.DTOs;
using BusinessLogic.Repositories;
using EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic
{
    public class UserLogic
    {
        private UserRepository userRepo = new UserRepository(new AdvancedDBContext());

        public List<UserDTO> GetUsers()
        {
            var users = userRepo.GetAll();
            return users.Select(x => new UserDTO 
            { 
                userId = x.UserId, 
                userName = x.UserName, 
                name = x.Name, 
                email = x.Email, 
                phone = x.Phone
            }).ToList();
        }

        public void AddUser(UserDTO dto)
        {
            var user = Map(dto);
            userRepo.Insert(user);
        }

        public void EditUser(UserDTO dto)
        {
            var user = Map(dto);
            userRepo.Update(user);
        }

        public void DeleteUser(int UserId)
        {
            userRepo.Delete(UserId);
        }

        public UserDTO GetUser(int UserId)
        {
            var user = userRepo.GetUserById(UserId);
            return Map(user);
        }

        private User Map(UserDTO dto)
        {
            return new User()
            {
                UserId = dto.userId ?? 0,
                UserName = dto.userName,
                Name = dto.name,
                Email = dto.email,
                Phone = dto.phone
            };
        }

        private UserDTO Map(User user)
        {
            return new UserDTO()
            {
                userId = user.UserId,
                userName = user.UserName,
                name = user.Name,
                email = user.Email,
                phone = user.Phone
            };
        }
    }
}

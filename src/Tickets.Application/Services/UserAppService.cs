using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.Application.DTOs;
using Tickets.Domain.Entities.UserEntity;
using Tickets.Infrastrucure.Data;

namespace Tickets.Application.Services
{
   public class UserAppService
    {
        public TicketsDbContext ticketDbContext { get; set; }
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;

        public UserAppService(UserManager<User> userManager,
                            SignInManager<User> signInManager,
                            TicketsDbContext ticketsDb)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            ticketDbContext = ticketsDb;
        }
        public async Task<IdentityResult> Insert(UserRegistration User)
        {
                var result = await userManager.CreateAsync(new User
                {
                    UserName = User.UserName,
                    Email = User.Email,
                    FullName = User.FullName,
                    PhoneNumber = User.PhoneNumber
                }, User.Password);

                if (result.Succeeded)
                {
               
                    await signInManager.PasswordSignInAsync(User.UserName, User.Password, true, false);
                   

                }

            return result;
           
            
        }
        public async Task<SignInResult> LogIn(UserRegistration User)
        {
            var identityResult = await signInManager.PasswordSignInAsync(User.UserName, User.Password, false, false);
            return identityResult;

        }
        public List<UserDto> GetAllUsers()
        {
            List<UserDto> usersDto = new List<UserDto>();
            List<User> Users = new List<User>();
          
            
            Users = ticketDbContext.Users.ToList();
            
            foreach (var user in Users)
            {
                usersDto.Add(
                    new UserDto
                    {
                        FullName = user.FullName,
                        Email = user.Email,
                        Id = user.Id,
                        PhoneNumber = user.PhoneNumber,
                        UserName = user.UserName
                    }
                    );

            }
            return usersDto;
        }
        public List<UserDto> Search(UserSearchDto userSearch)
        {
          var users = ticketDbContext.Users
                .Where(e => e.FullName.Contains(userSearch.FullName) || e.Email == userSearch.Email)
                .ToList();
            List<UserDto> usersDto = new List<UserDto>();
            foreach (var user in users)
            {
                usersDto.Add(
                    new UserDto
                    {
                        FullName = user.FullName,
                        Email = user.Email,
                        Id = user.Id,
                        PhoneNumber = user.PhoneNumber,
                        UserName = user.UserName
                    }
                    );

            }
            return usersDto;
        }
        public void Remove(int id)
        {
            var user = ticketDbContext.Users.FirstOrDefault(e => e.Id == id);
            ticketDbContext.Users.Remove(user);
            ticketDbContext.SaveChanges();
        }
        public UserDto Find(int id)
        {
            User user = new User();
            user = ticketDbContext.Users.FirstOrDefault(e => e.Id == id);
            UserDto userDto = new UserDto()
            {
                Email = user.Email,
                FullName= user.FullName,
                Id = user.Id,
                PhoneNumber = user.PhoneNumber,
                UserName = user.UserName,
                ProfileImage = user.ProfileImage
            };
            return userDto;
        }
        public void Edit(UserDto updatedUser , int id)
        {

            var user = ticketDbContext.Users.FirstOrDefault(e => e.Id == id);
            user.FullName = updatedUser.FullName;
            user.Email = updatedUser.Email;
            user.PhoneNumber = updatedUser.PhoneNumber;
            if(updatedUser.ProfileImage != null)
                user.ProfileImage = updatedUser.ProfileImage;
            ticketDbContext.Update(user);
            ticketDbContext.SaveChanges();

        }
        public async Task<IdentityResult> ChangePassword(string newPassword,string token ,int id)
        {
            var user = ticketDbContext.Users.FirstOrDefault(e => e.Id == id);
          var result=  await userManager.ResetPasswordAsync(user, token, newPassword);
            return result;
        }
    }
}

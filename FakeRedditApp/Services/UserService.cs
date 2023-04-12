using FakeRedditApp.Data.Models;
using FakeRedditApp.Data.Repositories;
using Microsoft.AspNetCore.Identity;

namespace FakeRedditApp.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserService(UserRepository userRepository,UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }

        public User GetUserById(string id)
        {
            return _userRepository.GetById(id);
        }

        public void AddUser(User user)
        {
            _userRepository.Add(user);
        }

        public void UpdateUser(User user)
        {
            _userRepository.Update(user);
        }

        public void DeleteUser(string id)
        {
            _userRepository.Delete(id);
        }

        public async Task<IdentityResult> Register(User user)
        {
            var result = await _userManager.CreateAsync(user, user.PasswordHash);
            return result;
        }

        public async Task<User> Login(LoginCredentials credentials)
        {
            var user = await _userManager.FindByNameAsync(credentials.Username);
            if (user != null)
            {
                var signInResult = await _signInManager.CheckPasswordSignInAsync(user, credentials.Password, false);
                if (signInResult.Succeeded)
                {
                    return user;
                }
            }
            return null;
        }
    }
}

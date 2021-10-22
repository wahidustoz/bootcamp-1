using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bot.Entity;
using Microsoft.Extensions.Logging;

namespace bot.Services
{
    public class InternalStorageService : IStorageService
    {
        private readonly List<BotUser> _users;
        private readonly ILogger<InternalStorageService> _logger;

        public InternalStorageService(ILogger<InternalStorageService> logger)
        {
            _users = new List<BotUser>();
            _logger = logger;
        }

        public Task<bool> ExistsAsync(long chatId)
            => Task.FromResult<bool>(_users.Any(u => u.ChatId == chatId));

        public Task<bool> ExistsAsync(string username)
            => Task.FromResult<bool>(_users.Any(u => u.Username == username));
       

        public Task<BotUser> GetUserAsync(long chatId)
            => Task.FromResult<BotUser>(_users.FirstOrDefault(u => u.ChatId == chatId));
        

        public Task<BotUser> GetUserAsync(string username)
            => Task.FromResult<BotUser>(_users.FirstOrDefault(u => u.Username == username));

        public async Task<(bool IsSuccess, Exception exception)> InsertUserAsync(BotUser user)
        {
            if(await ExistsAsync(user.ChatId))
            {
                return (false, new Exception("User already exists!"));
            }

            _users.Add(user);
            return (true, null);
        }

        public async Task<(bool IsSuccess, Exception exception, BotUser user)> RemoveAsync(BotUser user)
        {
            if(await ExistsAsync(user.ChatId))
            {
                var savedUser = await GetUserAsync(user.ChatId);
                _users.Remove(savedUser);
                return (true, null, savedUser);
            }

            return (false, new Exception("User does not exist!"), null);
        }

        public async Task<(bool IsSuccess, Exception exception)> UpdateUserAsync(BotUser user)
        {
            if(await ExistsAsync(user.ChatId))
            {
                var savedUser = await GetUserAsync(user.ChatId);
                _users.Remove(savedUser);
                _users.Add(user);

                return (true, null);
            }

            return (false, new Exception("User does not exist!"));
        }
    }
}
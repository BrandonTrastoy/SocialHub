﻿using Backend.Models;
using Backend.Services;

namespace Backend.Interfaces
{
    public interface IUserService
    {
        Task<ServiceResponse<int>> Register(User user, string password);
        Task<ServiceResponse<string>> Login(string username, string password);
        Task<bool> UserExists(string username);
    }
}

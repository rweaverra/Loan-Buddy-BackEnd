﻿using AutoMapper;
using Loan_Buddy_Api.Data;
using Loan_Buddy_Api.DTOs;
using Loan_Buddy_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Loan_Buddy_Api.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly AppDBContext _db;
        private readonly IMapper _mapper;

        public UserService(IMapper mapper, AppDBContext context)
        {
            _mapper = mapper;
            _db = context;
        }
        public async Task<ServiceResponse<UserDto>> GetUser(int userId)
        {
            var serviceResponse = new ServiceResponse<UserDto>();
            var user = await _db.Users.SingleOrDefaultAsync(r => r.UserId == userId);
            serviceResponse.Data = _mapper.Map<UserDto>(user);

            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<User>>> GetUsers()
        {
            var serviceResponse = new ServiceResponse<IEnumerable<User>>();
            serviceResponse.Data = await _db.Users.ToListAsync();

            return serviceResponse;
        }
    }
}

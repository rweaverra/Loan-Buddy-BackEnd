
using AutoMapper;
using Loan_Buddy_Api.DTOs;
using Loan_Buddy_Api.Models;

namespace Loan_Buddy_Api
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}


using AutoMapper;
using Loan_Buddy_Api.Data;
using Loan_Buddy_Api.DTOs;

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

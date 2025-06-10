using AutoMapper;
using RegistrationForm.DTOs;
using RegistrationForm.Models;

namespace RegistrationForm.Mappings
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<RegistrationRequestDto, User>()
                .ForMember(dest => dest.PasswordHash, opt =>
                    opt.MapFrom(src => BCrypt.Net.BCrypt.HashPassword(src.Password)))
                .ForMember(dest => dest.DateOfBirth, opt =>
                    opt.MapFrom(src => DateTime.Parse(src.DateOfBirth)))
                .ForMember(dest => dest.Name, opt =>
                    opt.MapFrom(src => src.FullName))
                ;
        }
    }
}

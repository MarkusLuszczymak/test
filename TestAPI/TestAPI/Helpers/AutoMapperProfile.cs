namespace TestAPI.Helpers;

using AutoMapper;
using System.Net.Mail;
using TestAPI.Models.Account;
using TestAPI.Models;
using TestAPI.Entities;


public class AutoMapperProfile : Profile
{
    // mappings between model and entity objects
    public AutoMapperProfile()
    {
        CreateMap<User, UserResponse>();

        CreateMap<User, AuthenticateResponse>();

        CreateMap<RegisterRequest, User>();

        CreateMap<EntriesRequest, Entries>();
    }
}

        


using AutoMapper;
using BasicCRM.DTOs;
using BasicCRM.Models;
using Microsoft.AspNetCore.Identity;

namespace BasicCRM.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Contact, ContactDto>().ReverseMap();
            CreateMap<Interaction, InteractionDto>().ReverseMap();
            CreateMap<InteractionType, InteractionTypeDto>().ReverseMap();
            CreateMap<IdentityUser, UpdateUserDto>().ReverseMap();
        }
    }
}
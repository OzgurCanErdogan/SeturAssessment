using AutoMapper;
using ContactApplication.Dtos;
using ContactApplication.Models;

namespace ContactApplication.Profiles
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<Person, PersonReadDto>();
            CreateMap<PersonCreateDto, Person>();
            CreateMap<ContactInformationCreateDto, ContactInformation>();
            //CreateMap<PlatformReadDto, PlatformPublishedDto>();

        }
    }
}

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
            CreateMap<ContactInformation, ContactInformationReadDto>();
            CreateMap<Person, PersonContactDetailedReadDto>();
            /*
            CreateMap<Person, PersonContactDetailedReadDto>().AfterMap((src,dest) =>
            {
                foreach(var item in src.ContactInformation)
                {
                    dest.Con
                }
            });
            */
            //CreateMap<PlatformReadDto, PlatformPublishedDto>();

        }
    }
}

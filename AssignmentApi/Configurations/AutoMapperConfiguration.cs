using Assignment.Entities.Models;
using AssignmentApi.Models;
using AutoMapper;

namespace Assignment.Api.ServiceCollectionConfigurations
{
    public  class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<PersonModel, Person>().ReverseMap();
        }
    }
}
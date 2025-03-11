using AutoMapper;
using UKParliament.CodeTest.Data;
using UKParliament.CodeTest.Web.ViewModels;

public class MappingProfile : Profile {
     public MappingProfile() {
         // Add as many of these lines as you need to map your objects
         CreateMap<Person, PersonViewModel>().ReverseMap();
     }
 }
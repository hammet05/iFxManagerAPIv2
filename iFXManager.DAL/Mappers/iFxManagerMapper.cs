using AutoMapper;
using iFXManager.API.Models;
using iFXManager.DAL.DTOs;
using iFXManager.DAL.Models;

namespace iFXManager.DAL.Mappers
{
    public class iFxManagerMapper: Profile
    {
        public iFxManagerMapper()
        {
            CreateMap<Position, PositionsDto>().ReverseMap();
            CreateMap<IdentificationType, IdentificationTypesDto>().ReverseMap();
            CreateMap<EntityType, EntityTypesDto>().ReverseMap();
            CreateMap<Entity, EntityDto>().ReverseMap();
            CreateMap<Employee, EmployeesDto>().ReverseMap();
        }
    }
}

using AutoMapper;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.DTOs.Requests;
using FormulaOne.Entities.DTOs.Responses;

namespace FormulaOne.Api.MappingProfiles
{
    public class DomainToResponse : Profile
    {
        public DomainToResponse()
        {
            CreateMap<Achievement, DriverAchievementResponse>()
                .ForMember(
                    destination => destination.Wins,
                    options => options.MapFrom(source => source.RaceWins));

            //CreateMap<UpdateDriverAchievementRequest, Achievement>()
            //    .ForMember(
            //        destination => destination.RaceWins,
            //        options => options.MapFrom(source => source.Wins))
            //    .ForMember(
            //        destination => destination.UpdatedDate,
            //        options => options.MapFrom(source => DateTime.UtcNow));

            CreateMap<Driver, GetDriverResponse>()
                .ForMember(
                    destination => destination.DriverId,
                    options => options.MapFrom(source => source.Id))
                .ForMember(
                    destination => destination.FullName,
                    options => options.MapFrom(source => $"{source.FirstName} {source.LastName}"));
        }
    }
}

using AutoMapper;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.DTOs.Requests;
using FormulaOne.Entities.DTOs.Responses;

namespace FormulaOne.Api.MappingProfiles
{
    public class RequestToDomain : Profile
    {
        public RequestToDomain()
        {
            CreateMap<CreateDriverAchievementRequest, Achievement>()
                .ForMember(
                    destination => destination.RaceWins,
                    options => options.MapFrom(source => source.Wins))
                .ForMember(
                    destination => destination.Status,
                    options => options.MapFrom(source => 1))
                .ForMember(
                    destination => destination.AddedDate,
                    options => options.MapFrom(source => DateTime.UtcNow))
                .ForMember(
                    destination => destination.UpdatedDate,
                    options => options.MapFrom(source => DateTime.UtcNow));

            CreateMap<UpdateDriverAchievementRequest, Achievement>()
                .ForMember(
                    destination => destination.RaceWins,
                    options => options.MapFrom(source => source.Wins))
                .ForMember(
                    destination => destination.UpdatedDate,
                    options => options.MapFrom(source => DateTime.UtcNow));

            CreateMap<CreateDriverRequest, Driver>()
                .ForMember(
                    destination => destination.Status,
                    options => options.MapFrom(source => 1))
                .ForMember(
                    destination => destination.AddedDate,
                    options => options.MapFrom(source => DateTime.UtcNow))
                .ForMember(
                    destination => destination.UpdatedDate,
                    options => options.MapFrom(source => DateTime.UtcNow));

            CreateMap<UpdateDriverRequest, Driver>()
                .ForMember(
                    destination => destination.UpdatedDate,
                    options => options.MapFrom(source => DateTime.UtcNow));
        }
    }
}

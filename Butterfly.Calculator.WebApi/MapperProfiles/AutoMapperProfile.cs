using AutoMapper;
using Butterfly.Calculator.Models;
using Butterfly.Calculator.Core.Models;

namespace Butterfly.Calculator.MapperProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CalculationRequestModel, CalculationRequest>();
            CreateMap<CalculationResponse, CalculationResponseModel>();
        }
    }
}
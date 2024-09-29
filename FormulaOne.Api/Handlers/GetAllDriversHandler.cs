using AutoMapper;
using FormulaOne.Api.Queries;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DTOs.Responses;
using MediatR;

namespace FormulaOne.Api.Handlers
{
    public class GetAllDriversHandler : IRequestHandler<GetAllDriversQuery, IEnumerable<GetDriverResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllDriversHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetDriverResponse>> Handle(GetAllDriversQuery request, CancellationToken cancellationToken)
        {
            var drivers = await _unitOfWork.DriverRepository.All();
            return _mapper.Map<IEnumerable<GetDriverResponse>>(drivers);
        }
    }
}

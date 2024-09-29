using AutoMapper;
using FormulaOne.Api.Queries;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.DTOs.Responses;
using MediatR;

namespace FormulaOne.Api.Handlers
{
    public class GetDriverHandler : IRequestHandler<GetDriverQuery, GetDriverResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetDriverHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetDriverResponse> Handle(GetDriverQuery request, CancellationToken cancellationToken)
        {
            var driver = await _unitOfWork.DriverRepository.GetById(request.DriverId);
            if (driver == null)
            {
                return null;
            }
            return _mapper.Map<GetDriverResponse>(driver);
        }
    }
}

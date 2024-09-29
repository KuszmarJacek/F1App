using AutoMapper;
using FormulaOne.Api.Commands;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using MediatR;

namespace FormulaOne.Api.Handlers
{
    public class UpdateDriverHandler : IRequestHandler<UpdateDriverCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateDriverHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateDriverCommand request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<Driver>(request.DriverRequest);
            await _unitOfWork.DriverRepository.Update(result);
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}

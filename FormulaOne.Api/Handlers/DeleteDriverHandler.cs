using AutoMapper;
using FormulaOne.Api.Commands;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.DTOs.Responses;
using MediatR;

namespace FormulaOne.Api.Handlers
{
    public class DeleteDriverHandler : IRequestHandler<DeleteDriverCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteDriverHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteDriverCommand request, CancellationToken cancellationToken)
        {
            var driver = await _unitOfWork.DriverRepository.GetById(request.DriverId);
            if (driver == null)
            {
                return false;
            }
            await _unitOfWork.DriverRepository.Delete(request.DriverId);
            await _unitOfWork.CompleteAsync();

            return true;
        }
    }
}

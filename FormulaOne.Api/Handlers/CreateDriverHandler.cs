﻿using AutoMapper;
using FormulaOne.Api.Commands;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.DTOs.Responses;
using MediatR;

namespace FormulaOne.Api.Handlers
{
    public class CreateDriverHandler : IRequestHandler<CreateDriverCommand, GetDriverResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateDriverHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetDriverResponse> Handle(CreateDriverCommand request, CancellationToken cancellationToken)
        {
            
            var driver = _mapper.Map<Driver>(request.DriverRequest);
            await _unitOfWork.DriverRepository.Add(driver);
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<GetDriverResponse>(driver);   
        }
    }
}

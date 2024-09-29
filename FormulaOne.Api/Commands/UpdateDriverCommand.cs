using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.DTOs.Requests;
using MediatR;

namespace FormulaOne.Api.Commands
{
    public class UpdateDriverCommand : IRequest<bool>
    {
        public UpdateDriverRequest DriverRequest;

        public UpdateDriverCommand(UpdateDriverRequest driverRequest)
        {
            DriverRequest = driverRequest;
        }
    }
}

using MediatR;

namespace FormulaOne.Api.Commands
{
    public class DeleteDriverCommand : IRequest<bool>
    {
        public Guid DriverId { get; }

        public DeleteDriverCommand(Guid driverId)
        {
            DriverId = driverId;
        }
    }
}

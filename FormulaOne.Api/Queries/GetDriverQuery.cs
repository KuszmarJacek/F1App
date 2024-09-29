using FormulaOne.Entities.DTOs.Responses;
using MediatR;

namespace FormulaOne.Api.Queries
{
    public class GetDriverQuery : IRequest<GetDriverResponse>
    {
        // Specify that this query takes a parameter
        public Guid DriverId { get; }

        public GetDriverQuery(Guid driverId)
        {
            DriverId = driverId;
        }
    }
}

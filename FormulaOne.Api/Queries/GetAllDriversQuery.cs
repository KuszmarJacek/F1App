using FormulaOne.Entities.DTOs.Responses;
using MediatR;

namespace FormulaOne.Api.Queries
{
    public class GetAllDriversQuery : IRequest<IEnumerable<GetDriverResponse>>
    {


    }
}

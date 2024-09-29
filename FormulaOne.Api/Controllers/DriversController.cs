using AutoMapper;
using FormulaOne.Api.Commands;
using FormulaOne.Api.Queries;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.DTOs.Requests;
using FormulaOne.Entities.DTOs.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.Api.Controllers
{
    public class DriversController : BaseController
    {
        
        public DriversController(IUnitOfWork unitOfWork, IMapper mapper, IMediator mediator) : base(unitOfWork, mapper, mediator)
        {
        }

        [HttpGet]
        [Route("Foo")]
        public async Task<IActionResult> Foo()
        {
            var result = await Task.FromResult("Foo :D");
            return Ok(result);
        }

        [HttpGet]
        [Route("{driverId:guid}")]
        public async Task<IActionResult> GetDriver(Guid driverId)
        {
            //var driver = await _unitOfWork.DriverRepository.GetById(driverId);
            //if (driver == null)
            //{
            //    return NotFound();
            //}
            //var result = _mapper.Map<GetDriverResponse>(driver);
            //return Ok(result);
            var query = new GetDriverQuery(driverId);
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDrivers()
        {
            //var drivers = await _unitOfWork.DriverRepository.All();
            //var result = _mapper.Map<IEnumerable<GetDriverResponse>>(drivers);
            //return Ok(result);
            var query = new GetAllDriversQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{driverId:guid}")]
        public async Task<IActionResult> DeleteDriver(Guid driverId)
        {
            //var driver = await _unitOfWork.DriverRepository.GetById(driverId);
            //if (driver == null)
            //{
            //    return NotFound();
            //}
            //await _unitOfWork.DriverRepository.Delete(driverId);
            //await _unitOfWork.CompleteAsync();

            //return NoContent();
            var command = new DeleteDriverCommand(driverId);
            var result = await _mediator.Send(command);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> AddDriver([FromBody] CreateDriverRequest driver)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest();
            //}
            //var result = _mapper.Map<Driver>(driver);
            //await _unitOfWork.DriverRepository.Add(result);
            //await _unitOfWork.CompleteAsync();
            //return CreatedAtAction(nameof(GetDriver), new { driverId = result.Id }, result);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var command = new CreateDriverCommand(driver);
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetDriver), new { driverId = result.DriverId }, result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDriver([FromBody] UpdateDriverRequest driver)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest();
            //}
            //var result = _mapper.Map<Driver>(driver);
            //await _unitOfWork.DriverRepository.Update(result);
            //await _unitOfWork.CompleteAsync();
            //return NoContent();
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var command = new UpdateDriverCommand(driver);
            var result = await _mediator.Send(command);

            if (result)
            {
                return NoContent();
            }

            return BadRequest();
        }
    }
}

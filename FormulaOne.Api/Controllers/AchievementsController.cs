using AutoMapper;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.DTOs.Requests;
using FormulaOne.Entities.DTOs.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace FormulaOne.Api.Controllers
{
    public class AchievementsController : BaseController
    {
        public AchievementsController(IUnitOfWork unitOfWork, IMapper mapper, IMediator mediator) : base(unitOfWork, mapper, mediator)
        {       
        }

        [HttpGet]
        [Route("{driverId:guid}")]
        public async Task<IActionResult> GetDriverAchievements(Guid driverId)
        {
            var driverAchievements = await _unitOfWork.AchievementRepository.GetDriverAchievementAsync(driverId);
            if (driverAchievements == null)
            {
                return NotFound("Achievements not found");
            }
            var result = _mapper.Map<DriverAchievementResponse>(driverAchievements);
            return Ok(result);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddAchievement([FromBody] CreateDriverAchievementRequest achievement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = _mapper.Map<Achievement>(achievement);
            await _unitOfWork.AchievementRepository.Add(result);
            await _unitOfWork.CompleteAsync();
            return CreatedAtAction(nameof(GetDriverAchievements), new { driverId = result.DriverId }, result);
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateAchievement([FromBody] UpdateDriverAchievementRequest achievement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = _mapper.Map<Achievement>(achievement);
            await _unitOfWork.AchievementRepository.Update(result);
            await _unitOfWork.CompleteAsync();
            return NoContent();
        }
    }
}

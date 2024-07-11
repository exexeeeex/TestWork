using Application.DTOS;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("/api/password/")]
    public class PasswordController(IPasswordService passwordService) : Controller
    {
        [HttpGet("get-all")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken) =>
            Ok(await passwordService.GetAllPasswordsAsync(cancellationToken));

        [HttpGet("get-all-types")]
        public async Task<IActionResult> GetAllTypes(CancellationToken cancellationToken = default) => 
            Ok(await passwordService.GetAllPasswordTypes());
        
        [HttpPost("create")]
        public async Task<IActionResult> Create(PasswordDTO password, CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await passwordService.CreatePasswordAsync(password, cancellationToken));
            }
            catch(ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
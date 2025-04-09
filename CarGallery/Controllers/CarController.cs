using Application.Command.Car;
using Application.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarGallery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _service;

        public CarController(ICarService service)
        {
            _service = service;
        }



        [HttpPost("AddCar")]
        public async Task<IActionResult> AddCar(AddCarCommand command,ICollection<IFormFile>? carFiles)
        {
            command.Carimgs = carFiles;
            if (ModelState.IsValid)
            {
                await _service.AddCar(command);
                return Ok("Success");
            }

            return BadRequest();
        }
    }
}

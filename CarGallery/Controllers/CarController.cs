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

        [HttpGet("GetAllCars")]
        public async Task<IActionResult> GetAllCars() 
        {
            var Cars = await _service.GetAllCars();

            return Ok();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteCar(int id) 
        {
        await _service.DeleteCar(id);
            return Ok();
        }
        [HttpGet("GetCarById")]
        public async Task<IActionResult> GetCarById(int id)
        {
            await _service.GetCarById(id);
            return Ok();

        }

    } 
}

using Microsoft.AspNetCore.Http;

namespace Application.Command.Car;

public class CarimgCommand
{
    public IFormFile img{ get; set; }
    public int CarId{ get; set; }
}
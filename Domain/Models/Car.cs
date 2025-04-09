using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Car
{
    public Car( string carBrand, int yearCar, string color, float price, string vinCar, CarState carState)
    {
        CarBrand = carBrand;
        YearCar = yearCar;
        Color = color;
        Price = price;
        VinCar = vinCar;
        CarState = carState;
        
    }


    [Key]
    public int Id { get;private set; }

    [Required(ErrorMessage = "Enter CarBrand")]
    [MaxLength(250, ErrorMessage = "CarBrand is Long")]
    [MinLength(5, ErrorMessage = "CarBrand is Short")]
    public string CarBrand { get; private set; }

    [Required(ErrorMessage = "Enter YearCar")]
    [MaxLength(4,ErrorMessage = "YearCar Should Be 4 Char")]
    public int YearCar { get; private set; }

    [Required(ErrorMessage = "Enter Color")]
    [MaxLength(55, ErrorMessage = "Color Should Be 55 Char")]
    public string Color { get; private set; }

    [Required(ErrorMessage = "Enter Price")]
    public float Price { get; private set; }

    [Required(ErrorMessage = "Enter PVinCarrice")]
    public string VinCar { get; private set; }
    public CarState CarState { get; private set; }

    public ICollection<CarImg>? CarImgs{ get; set; }


    public void EditCar(string carBrand,int yearCar,string color,float price,string vinCar)
    {
        CarBrand = carBrand;
        Color =color;
        VinCar = vinCar;
        Price = price;
        YearCar = yearCar;
    }

    public void ChangeState(CarState carState)
    {
        CarState = carState;
    }

    public void AddImg(int CarId,string Path)
    {
        var img = new CarImg(Path,CarId);
        CarImgs.Add(img);
    }

    private Car()
    {
        
    }
}

public enum CarState
{
    New,
    Stoke,
    Sold,
}
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public class OrderItem
{
    public int Id{ get; set; }
    public int OrderId{ get; set; }
    [ForeignKey("OrderId")]
    public Order Order{ get; set; }
    public int CarId{ get; set; }
    [ForeignKey("CarId")]
    public Car Car{ get; set; }
}
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public class Order
{
    public int Id{ get; set; }
    public int UserId{ get; set; }
    [ForeignKey("UserId")]
    public User User{ get; set; }
    public BasketState State{ get; set; }
    public ICollection<OrderItem>? OrderItems{ get; set; }
}


public enum BasketState
{
    Open,
    Close,
}
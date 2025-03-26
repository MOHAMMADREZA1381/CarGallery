using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Application.Command.User;

public class LoginUserCommand
{
    [EmailAddress]
    public string Email{ get; set; }
    public string Password{ get; set; }
}

public enum StateOfLogin
{
    Failed,
    Success
}

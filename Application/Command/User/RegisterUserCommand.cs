using System.ComponentModel.DataAnnotations;

namespace Application.Command.User;

public class RegisterUserCommand
{
    [Required]
    public string Name{ get; set; }

    [EmailAddress]
    public string Email{ get; set; }

    [Required]
    public string Password{ get; set; }

    [Compare("Password")]
    public string ConfirmPassword{ get; set; }

}

public enum StateOfRegister
{
    Success,
    UserAlreadyExist,
    WrongPassword

}
﻿using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class User
{
    public User(string fullname, string email, string password)
    {
        Email = email;
        FullName = fullname;
        Password = password;
    }

    [Key]
    public int Id { get; private set; }

    [Required(ErrorMessage = "Enter Full Name")]
    [MaxLength(250, ErrorMessage = "Full Name is Long")]
    [MinLength(5, ErrorMessage = "Full Name is Short")]
    public string FullName { get; private set; }

    [Required(ErrorMessage = "Enter Full Email")]
    [EmailAddress(ErrorMessage = "Email is Not Valid")]
    public string Email { get; set; }
    [Required]
    public string Password { get; private set; }
    public UserLevel Level { get; private set; }
    public string? OTPCode { get; private set; }
    public ICollection<Order> Orders{ get; set; }

    public void ChangeLevel(int id)
    {
        Level = (UserLevel)id;
    }

    public void ChangePassword(string password)
    {
        Password = password;
    }

    public string GenerateOtp()
    {
        var OTP = Guid.NewGuid().ToString().Substring(0, 4);
        return OTP;
    }


    private User()
    {

    }
}

public enum UserLevel
{
    Admin,
    Seller,
    Buyer
}

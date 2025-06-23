using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.DTOs.Requests;

public class RegisterRequest
{
    public string Email { get; set; } = "Elvin_123";
    public string Password { get; set; } = "Elvin_1234";
    public string ConfirmPassword { get; set; } = "Elvin_1234";
}
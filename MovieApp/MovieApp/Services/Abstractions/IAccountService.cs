using MovieApp.DTOs.Requests;
using MovieApp.DTOs.Responses;
using MovieApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Services.Abstractions;

public interface IAccountService
{
    public Result<User> RegisterUser(RegisterRequest request);

}

using MovieApp.DTOs.Requests;
using MovieApp.DTOs.Responses;
using MovieApp.Models;
using MovieApp.Services.Abstractions;
using MovieApp.Services.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Data;
using Rg = MovieApp.Services.Utils.RegexPatterns;

namespace MovieApp.Services.Implementations;

class AccountService : IAccountService
{
    private readonly IDataService _dataService;

    public AccountService(IDataService dataService)
    {
        _dataService = dataService;
    }

    public Result<User> RegisterUser(RegisterRequest request)
    {
        if(Rg.Email.IsMatch(request.Email) != true && Rg.Password.IsMatch(request.Password) != true && request.Password == request.ConfirmPassword)
        {
            return Result<User>.Error(null, "Error validating data");
        }
     
        var user = new User() { Email = request.Email, Password = request.Password };

        _dataService.AddData<User>(user);

        return Result<User>.Success(user, "User registered successfully");

    }
}

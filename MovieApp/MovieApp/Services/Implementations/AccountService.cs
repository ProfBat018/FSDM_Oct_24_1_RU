using MovieApp.DTOs.Requests;
using MovieApp.DTOs.Responses;
using MovieApp.Models;
using MovieApp.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        

    }
}

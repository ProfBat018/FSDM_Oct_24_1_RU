using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.DTOs.Requests;

record RegisterRequest(string Email, string Password, string ConfirmPassword);

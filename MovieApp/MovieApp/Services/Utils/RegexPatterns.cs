using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MovieApp.Services.Utils;

static class RegexPatterns
{
    public static string Username = @"^[a-zA-Z0-9_\\-]{6,}$";
    public const string Password = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[_*$#@!%]).{8,}$";
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MovieApp.Services.Utils;

 class RegexPatterns
{
    public static readonly Regex Username = new(@"^[a-zA-Z0-9_\\-]{6,}$");
    public static readonly Regex Password = new( @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[_*$#@!%]).{8,}$");
    public static readonly Regex Email = new(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}(?:\.[a-zA-Z]{2,})*$");
}

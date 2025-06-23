using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Services.Implementations;

static class EmailService
{
    private static readonly string _username;
    private static readonly string _hostName;
    private static readonly string _password;

    private static readonly SmtpClient _client;
    static EmailService()
    {
        var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        _hostName = config["Email:Hostname"];
        _password = config["Email:Password"];
        _username = config["Email:Username"];

        _client = new()
        {
            Port = 587,
            Host = _hostName,
            Credentials = new NetworkCredential(_username, _password)
        };

    }

    public static void Send(MailMessage message)
    {
        _client.Send(message);
    }


}
